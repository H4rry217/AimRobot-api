using AimRobot.Api.command;
using AimRobot.Api.events;
using AimRobot.Api.events.ev;
using System.Reflection;
using System.Text;
using static AimRobot.Api.command.ICommandListener;

namespace AimRobot.Api.plugin {
    public abstract class PluginManager {

        protected Dictionary<string, PluginBase> Plugins = new Dictionary<string, PluginBase>();
        protected ISet<IEventListener> EventListeners = new HashSet<IEventListener>();
        protected ISet<ICommandListener> CommandListeners = new HashSet<ICommandListener>();

        protected Dictionary<Type, MethodList> EventMethods = new Dictionary<Type, MethodList>();

        protected Robot robot;

        public PluginManager(Robot robot) { 
            this.robot = robot;
        }

        public void LoadPlugin(PluginBase plugin) {
            if (!this.Plugins.ContainsKey(plugin.GetPluginName())) {
                plugin.OnLoad();

                this.Plugins.Add(plugin.GetPluginName(), plugin);
                this.robot.GetLogger().Info($"插件 {plugin.GetPluginName()} 加载");

            } else if(this.Plugins.TryGetValue(plugin.GetPluginName(), out PluginBase loadedPlugin)){
                this.robot.GetLogger().Warn($"重复加载同一插件 {loadedPlugin.GetPluginName()}! 已加载版本: {loadedPlugin.GetVersion()} 未加载版本: {plugin.GetVersion()}");
            }
        }

        public bool EnablePlugin(PluginBase plugin) {
            if(this.Plugins.TryGetValue(plugin.GetPluginName(), out PluginBase loadPlugin)) {
                if (!loadPlugin.IsEnable()) {
                    loadPlugin.SetEnable(true);

                    loadPlugin.OnEnable();
                    this.robot.GetLogger().Info($"插件 {plugin.GetPluginName()} 已启用");

                    return true;
                }
            }

            return false;
        }

        public bool DisablePlugin(PluginBase plugin) {
            if (this.Plugins.TryGetValue(plugin.GetPluginName(), out PluginBase loadPlugin)) {
                if (loadPlugin.IsEnable()) {
                   loadPlugin.SetEnable(false);

                    loadPlugin.OnDisable();
                    this.robot.GetLogger().Info($"插件 {plugin.GetPluginName()} 已卸载");

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// <para>注册IEventListener和其实现类内的所有EventHandler，若ARL收到对应EventHandler感兴趣的事件，则会执行EventHandler标注的方法</para>
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="eventListener"></param>
        public void RegisterListener(PluginBase plugin, IEventListener eventListener) {
            if (plugin == null) return;
            var type = eventListener.GetType();

            MethodInfo[] methods = type.GetMethods();
            Type robotEventBase = typeof(RobotEvent);

            if (!EventListeners.Contains(eventListener)) {
                foreach (var method in methods) {
                    if (Attribute.IsDefined(method, typeof(events.EventHandler))) {

                        ParameterInfo[] parameters = method.GetParameters();
                        if (parameters.Length == 1) {

                            var paramType = parameters[0].ParameterType;
                            if (robotEventBase.IsAssignableFrom(paramType)) {
                                EventMethod eventMethod = new EventMethod(method, eventListener, plugin);

                                MethodList methodList = EventMethods.ContainsKey(paramType) ? EventMethods[paramType] : new MethodList();
                                methodList.RegisterMethod(eventMethod);

                                EventMethods[paramType] = methodList;
                            }

                        }
                    }
                }

                EventListeners.Add(eventListener);
            }
        }

        /// <summary>
        /// 注销IEventListener。
        /// </summary>
        /// <param name="eventListener"></param>
        public void UnregisterListener(IEventListener eventListener) {
            EventListeners.Remove(eventListener);

            foreach (var item in EventMethods){
                item.Value.UnregisterMethod(eventListener);
            }
        }

        /// <summary>
        /// 注册ICommandListener。注册后若收到对应的指令，将传递给该ICommandListener
        /// </summary>
        /// <param name="commandListener"></param>
        public void RegisterCommandListener(ICommandListener commandListener) {
            if (!CommandListeners.Contains(commandListener)) {
                CommandListeners.Add(commandListener);
            }
        }

        /// <summary>
        /// 注销ICommandListener。注销后若收到对应的指令，将不会传递给该ICommandListener
        /// </summary>
        /// <param name="commandListener"></param>
        public void UnregisterCommandListener(ICommandListener commandListener) {
            CommandListeners.Remove(commandListener);
        }

        /// <summary>
        /// 根据传入的RobotEvent事件类型，传递给每一个“订阅”了该事件类型的IEventListener的EventHandler
        /// </summary>
        /// <param name="robotEvent">继承至RobotEvent的所有事件</param>
        public void CallEvent(RobotEvent robotEvent) {
            if (robot.IsEnable()) {
                if (robotEvent is PlayerChatEvent chatEvent) {
                    CheckCommand(chatEvent.speaker, chatEvent.message);
                }

                if (EventMethods.TryGetValue(robotEvent.GetType(), out MethodList methodList)) {
                    methodList.InvokeAll(robotEvent);
                }
            }
        }

        public void CheckCommand(string sender, string content) {
            if (content.StartsWith(ICommandListener.CMD_SIGN)) {
                string part2 = content.Substring(ICommandListener.CMD_SIGN.Length);

                StringBuilder keywordBuilder = new StringBuilder();
                CommandStyle commandStyle = CommandStyle.Unknown;

                int equalSignIndex = 0;
                int greaterThanIndex = 0;

                Dictionary<string, string> paramMap = new Dictionary<string, string>();

                for (int i = 0; i < part2.Length; i++) {
                    char chr = part2[i];

                    if (chr == '=') {
                        commandStyle = CommandStyle.Style1;
                        equalSignIndex = i;
                    } else if (chr == '>') {
                        greaterThanIndex = i;
                        commandStyle = CommandStyle.Style1;
                    } else if (chr == ' ') {
                        commandStyle = CommandStyle.Style2;
                    } else {
                        keywordBuilder.Append(chr);
                        continue;
                    }

                    break;
                }

                string keyword = keywordBuilder.ToString();

                switch (commandStyle) {
                    case CommandStyle.Style1:

                        if (greaterThanIndex == 0) {
                            paramMap["param"] = part2.Substring(equalSignIndex + 1);
                        } else {
                            StringBuilder toBuilder = new StringBuilder();

                            for (int i = greaterThanIndex + 1; i < part2.Length; i++) {
                                if (part2[i] == '=') {
                                    paramMap["param"] = part2.Substring(i + 1);
                                    paramMap["to"] = toBuilder.ToString();
                                } else {
                                    toBuilder.Append(part2[i]);
                                }
                            }

                        }

                        break;
                    case CommandStyle.Style2:
                        var argMap = Utils.getArgs(part2.Substring(part2.IndexOf(' ') == -1 ? part2.Length : part2.IndexOf(' ')));
                        foreach (var item in argMap) paramMap[item.Key] = item.Value;
                        break;
                }

                CommandData commandData = new CommandData(paramMap, sender);

                StringBuilder logBuilder = new StringBuilder($"Command ({keyword}) ARGS -> ");

                if (paramMap.Count > 0) {
                    foreach (var kv in paramMap) logBuilder.Append($"\"{kv.Key}\": \"{kv.Value}\"").Append("   ");
                }

                Robot.GetInstance().GetLogger().Debug(logBuilder.ToString());

                CallCommmand(keyword, commandData);

            }
        }

        public void CallCommmand(string keyword, CommandData commandData) {
            foreach (var item in CommandListeners){
                if (item.GetCommandKeyword().Equals(keyword)) item.OnCommand(commandData);
            }
        }

        public PluginBase GetPlugin(string pluginName) {
            return Plugins[pluginName];
        }

        public ISet<PluginBase> GetPlugins() {
            return new HashSet<PluginBase>(this.Plugins.Values);
        }

    }
}
