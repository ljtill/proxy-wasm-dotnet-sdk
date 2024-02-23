namespace ProxyWasm.SDK.Helpers;

public static class LogHelper
{
    public static void LogTrace(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelTrace, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogDebug(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelDebug, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogInfo(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelInfo, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogWarn(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelWarn, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogError(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelError, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogCritical(string message)
    {
        var status = Host.ProxyLog(LogLevelType.LogLevelCritical, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }
}