打開命令提示符（以管理員身份），切到到發布的可執行文件所在的目錄

sc create MyWorkerService binPath= "E:\path to your exe\WorkerService1.exe"

sc start MyWorkerService

sc delete MyWorkerService

net stop MyWorkerService

打開“服務”管理器 (services.msc)，找到 MyWorkerService，右鍵單擊並選擇“停止”。
