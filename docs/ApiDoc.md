# �����ĵ�

## AimRobot.Api.Robot.GetInstance()

### ������
��̬��������ȡ��ǰ���е�Robot���󣬿���ͨ����ȡ���Ķ���������һ�������飨Ban�ˡ�˵����
### ����ֵ: 
AimRobot.Api.Robot

---

## Robot().BanPlayer(long playerId)
### ������
ͨ��Robot����ʵ����**Ban**��ָ��PlayerId�����

---

## Robot().KickPlayer(long playerId);
### ������
ͨ��Robot����ʵ����**Kick**��ָ��PlayerId�����

---

## Robot().UnBanPlayer(long playerId);
### ������
ͨ��Robot����ʵ����**���**ָ��PlayerId��ҵķ��

---

## Robot().SendChat(string message);
### ������
ͨ��Robot����ʵ��������Ϸ�з���ָ����������Ϣ

---

## Robot().JoinGame(long gameId);
### ������
ͨ��Robot����ʵ�����õ�ǰRobot���ڵ���ң�����ָ�� `gameId` �ķ�����

---

## Robot().GetLogger();
### ������
ͨ��Robot����ʵ������ȡRobot�� **����־���**�����Ƽ��Ӵ˻�ȡ��

---

## Robot().GetPluginManager()
### ������
ͨ��Robot����ʵ������ȡ����������������ڹ�������ע�ᡢȡ����Ӧ�Ĳ�������¼�������
### ����ֵ
AimRobot.api.plugin.PluginManager

����Robot�Ĳ��������

---

## Robot().GetGameContext()
### ������
ͨ��Robot����ʵ������ȡ��Ϸ������GameContext��GameContext������Robot�ĸ�����������Ϣ��������ݡ���ѯ�ص������׼��ȣ�

### ����ֵ
AimRobot.api.IGameContext


---

## PluginManager().CallEvent(RobotEvent robotEvent)
### ������
���̳���RobotEvent����Σ��㲥�����м����˸�RobotEvent���¼�������

---

## PluginManager().CheckCommand(string sender, string content)
### ������
ֱ�ӷ���ָ�������ָ����������� `sender` Ϊ **null** ʱ������������ֱ���Կ���̨����ݷ����ģ�����Ա��

## PluginManager().GetDefaultAutoSaveConfig(PluginBase plugin, string datasetName)
### ������
��ȡһ����β����Ӧ������Config�ļ����������ڴ�Ų�����������
### ����ֵ��
AimRobot.Api.config.AutoSaveConfig
ʵ���� **IDataset**����ʾΪһ�����������Map���Key -> Value��

--- 

## PluginManager().ConfigAutoSave<K, V>(IDataset<K, V> config)
### ������
��һ�� **IDataset** ���ݼ�����Robot��������Զ����棬Robot����ÿ��һ���¼��Զ��������ݼ��������ÿ������Լ��ֶ�����

--- 

## GameContext().GetPlayerStatInfo(long playerId, StatCallBack callBack)
### ������
��ѯ `playerId` ��Ӧ��������ݣ����ڲ�ѯ�ɹ������ `StatCallBack`

---

## GameContext().RegisterAntiCheat(IAntiCheat antiCheat)
### ������
��һ�� `IAntiCheat` ע���� `GameContext`����ע���ÿ�μ��������ݶ�����õ���ע��� `IAntiCheat`

---

## GameContext().PlayerCheck(long playerId)
### ������
������������ `IAntiCheat` ��������ҵ�״̬��������쳣������
