namespace ProxyWasm.SDK;

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
        return logLevel switch
        {
            LogLevelType.Trace => "trace",
            LogLevelType.Debug => "debug",
            LogLevelType.Information => "info",
            LogLevelType.Warning => "warn",
            LogLevelType.Error => "error",
            LogLevelType.Critical => "critical",
            LogLevelType.Max => "max",
            _ => "unknown",
        };
    }
}
