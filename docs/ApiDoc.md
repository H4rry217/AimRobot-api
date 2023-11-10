# 开发文档

## AimRobot.Api.Robot.GetInstance()

### 描述：
静态方法。获取当前运行的Robot对象，可以通过获取到的对象做更进一步的事情（Ban人、说话）
### 返回值: 
AimRobot.Api.Robot

---

## Robot().BanPlayer(long playerId)
### 描述：
通过Robot对象实例，**Ban**掉指定PlayerId的玩家

---

## Robot().KickPlayer(long playerId);
### 描述：
通过Robot对象实例，**Kick**掉指定PlayerId的玩家

---

## Robot().UnBanPlayer(long playerId);
### 描述：
通过Robot对象实例，**解除**指定PlayerId玩家的封禁

---

## Robot().SendChat(string message);
### 描述：
通过Robot对象实例，往游戏中发送指定的聊天消息

---

## Robot().JoinGame(long gameId);
### 描述：
通过Robot对象实例，让当前Robot所在的玩家，跳至指定 `gameId` 的服务器

---

## Robot().GetLogger();
### 描述：
通过Robot对象实例，获取Robot的 **主日志组件**，不推荐从此获取。

---

## Robot().GetPluginManager()
### 描述：
通过Robot对象实例，获取插件管理器，可以在管理器中注册、取消对应的插件或者事件监听器
### 返回值
AimRobot.api.plugin.PluginManager

返回Robot的插件管理器

---

## Robot().GetGameContext()
### 描述：
通过Robot对象实例，获取游戏上下文GameContext；GameContext管理着Robot的各种上下文信息（玩家数据、查询回调、作弊检测等）

### 返回值
AimRobot.api.IGameContext


---

## PluginManager().CallEvent(RobotEvent robotEvent)
### 描述：
将继承自RobotEvent的入参，广播给所有监听了该RobotEvent的事件监听器

---

## PluginManager().CheckCommand(string sender, string content)
### 描述：
直接发送指令给所有指令监听器，当 `sender` 为 **null** 时，代表发送者是直接以控制台的身份发出的（管理员）

## PluginManager().GetDefaultAutoSaveConfig(PluginBase plugin, string datasetName)
### 描述：
获取一个入参插件对应的配置Config文件，可以用于存放插件自身的数据
### 返回值：
AimRobot.Api.config.AutoSaveConfig
实现了 **IDataset**，表示为一个抽象的数据Map概念（Key -> Value）

--- 

## PluginManager().ConfigAutoSave<K, V>(IDataset<K, V> config)
### 描述：
将一个 **IDataset** 数据集交由Robot对象进行自动保存，Robot对象每隔一段事件自动保存数据集，而不用开发者自己手动保存

--- 

## GameContext().GetPlayerStatInfo(long playerId, StatCallBack callBack)
### 描述：
查询 `playerId` 对应的玩家数据，并在查询成功后调用 `StatCallBack`

---

## GameContext().RegisterAntiCheat(IAntiCheat antiCheat)
### 描述：
将一个 `IAntiCheat` 注册至 `GameContext`，当注册后，每次检测玩家数据都会调用到已注册的 `IAntiCheat`

---

## GameContext().PlayerCheck(long playerId)
### 描述：
遍历调用所有 `IAntiCheat` 检测该名玩家的状态，如果有异常则屏蔽
