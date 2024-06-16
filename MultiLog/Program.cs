using System;
using log4net;
using log4net.Config;

class Program
{
    // 获取不同功能的 logger
    private static readonly ILog functionALogger = LogManager.GetLogger("FunctionALogger");
    private static readonly ILog functionBLogger = LogManager.GetLogger("FunctionBLogger");

    static void Main(string[] args)
    {
        // 初始化 log4net 配置
        XmlConfigurator.Configure();

        for (var i = 0; i < 5; i++)
        {
            functionALogger.Info("AA");
            functionBLogger.Info("BB");
        }
        
        // 记录功能A的信息
        LogFunctionA();

        // 记录功能B的信息
        LogFunctionB();
    }

    static void LogFunctionA()
    {
        functionALogger.Info("This is a log message for Function A.");
        try
        {
            throw new Exception("Function A exception");
        }
        catch (Exception ex)
        {
            functionALogger.Error("An error occurred in Function A", ex);
        }
    }

    static void LogFunctionB()
    {
        functionBLogger.Info("This is a log message for Function B.");
        try
        {
            throw new Exception("Function B exception");
        }
        catch (Exception ex)
        {
            functionBLogger.Error("An error occurred in Function B", ex);
        }
    }
}