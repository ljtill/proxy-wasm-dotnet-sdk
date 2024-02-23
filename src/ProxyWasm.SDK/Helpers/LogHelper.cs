namespace ProxyWasm.SDK.Helpers;

public static class LogHelper
{
    public static void LogTrace(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Trace, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void LogDebug(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Debug, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void LogInfo(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Information, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void LogWarn(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Warning, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void LogError(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Error, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void LogCritical(string message)
    {
        var status = ProxyHost.ProxyLog(LogLevelType.Critical, HostcallHelper.StringToByte(message), message.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static string ToString(LogLevelType logLevel)
    {
        switch (logLevel)
        {
            case LogLevelType.Trace:
                return "trace";
            case LogLevelType.Debug:
                return "debug";
            case LogLevelType.Information:
                return "info";
            case LogLevelType.Warning:
                return "warn";
            case LogLevelType.Error:
                return "error";
            case LogLevelType.Critical:
                return "critical";
            case LogLevelType.Max:
                return "max";
            default:
                // TODO: Panic
                return "unknown";
        }
    }
}