namespace ProxyWasm.SDK.Helpers;

public static class LogHelper
{
    public static void LogTrace(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelTrace, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogDebug(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelDebug, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogInfo(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelInfo, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogWarn(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelWarn, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogError(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelError, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void LogCritical(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.LogLevelCritical, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public string ToString(LogLevelType logLevel)
    {
        switch (logLevel)
        {
            case LogLevelTrace:
                return "trace";
            case LogLevelDebug:
                return "debug";
            case LogLevelInfo:
                return "info";
            case LogLevelWarn:
                return "warn";
            case LogLevelError:
                return "error";
            case LogLevelCritical:
                return "critical";
            case LogLevelMax:
                return "max";
            default:
                // TODO: Panic
                return "unknown";
        }
    }
}