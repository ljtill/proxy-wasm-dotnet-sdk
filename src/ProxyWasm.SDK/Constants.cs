using ProxyWasm.SDK.Exceptions;

namespace ProxyWasm.SDK;

/// <summary>
/// Contains constants related to the OnVM event.
/// </summary>
public static class OnVMType
{
    public static bool
        StartStatusOK = true,
        StartStatusFailed = false;
}

/// <summary>
/// Contains constants related to the OnPlugin event.
/// </summary>
public class OnPluginType
{
    public const bool
        StartStatusOK = true,
        StartStatusFailed = false;
}

/// <summary>
/// Contains constants related to different actions.
/// </summary>
public class ActionType
{
    public const uint
        Continue = 0,
        Pause = 1;
}

/// <summary>
/// Contains constants related to different peer types.
/// </summary>
public class PeerType
{
    public const uint
        PeerTypeUnknown = 0,
        PeerTypeLocal = 1,
        PeerTypeRemote = 2;
}


/// <summary>
/// Buffer is a class that contains the buffer that can be returned by the ABI.
/// </summary>
public static class BufferType
{
    public const uint
        HttpRequestBody = 0,
        HttpResponseBody = 1,
        DownstreamData = 2,
        UpstreamData = 3,
        HttpCallResponseBody = 4,
        GrpcReceiveBuffer = 5,
        VMConfiguration = 6,
        PluginConfiguration = 7,
        CallData = 8;
}

/// <summary>
/// LogLevels is a class that contains the log levels that can be returned by the ABI.
/// </summary>
public static class LogLevelType
{
    public const uint
        LogLevelTrace = 0,
        LogLevelDebug = 1,
        LogLevelInfo = 2,
        LogLevelWarn = 3,
        LogLevelError = 4,
        LogLevelCritical = 5,
        LogLevelMax = 6;

    /// <summary>
    /// Converts a log level value to its corresponding string representation.
    /// </summary>
    /// <param name="logLevel">The log level value.</param>
    /// <returns>The string representation of the log level.</returns>
    public static string ToString(uint logLevel)
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

/// <summary>
/// Map is a class that contains the map that can be returned by the ABI.
/// </summary>
public static class MapType
{
    public const uint
        HttpRequestHeaders = 0,
        HttpRequestTrailers = 1,
        HttpResponseHeaders = 2,
        HttpResponseTrailers = 3,
        HttpCallResponseHeaders = 6,
        HttpCallResponseTrailers = 7;
}

/// <summary>
/// Metric is a class that contains the metric that can be returned by the ABI.
/// </summary>
public static class MetricType
{
    public const uint
        Counter = 0,
        Gauge = 1,
        Histogram = 2;
}

/// <summary>
/// Stream is a class that contains the stream that can be returned by the ABI.
/// </summary>
public static class StreamType
{
    public const uint
        StreamRequest = 0,
        StreamResponse = 1,
        StreamDownstream = 2,
        StreamUpstream = 3;
}

/// <summary>
/// Status is a class that contains the status codes that can be returned by the ABI.
/// </summary>
public static class StatusType
{
    public const uint
        OK = 0,
        NotFound = 1,
        BadArgument = 2,
        Empty = 7,
        CasMismatch = 8,
        InternalFailure = 10,
        Unimplemented = 12;

    /// <summary>
    /// Converts a status code to the corresponding exception.
    /// </summary>
    /// <param name="statusType">The status code to convert.</param>
    /// <returns>An exception corresponding to the given status code.</returns>
    public static Exception ToException(uint statusType)
    {
        return statusType switch
        {
            NotFound => new NotFoundException("Exception thrown by host: Not Found"),
            BadArgument => new BadArgumentException("Exception thrown by host: Bad Argument"),
            Empty => new EmptyException("Exception thrown by host: Empty"),
            CasMismatch => new CasMismatchException("Exception thrown by host: CAS Mismatch"),
            InternalFailure => new InternalFailureException("Exception thrown by host: Internal Failure"),
            Unimplemented => new UnimplementedException("Exception thrown by host: Unimplemented"),
            _ => new Exception("Exception unknown: " + statusType.ToString()),
        };
    }
}