using ProxyWasm.SDK.Helpers;

namespace ProxyWasm.SDK;

public class Hostcall
{
    public static byte[] GetVMConfiguration()
    {
        return BufferHelper.GetBuffer(BufferType.VMConfiguration, 0, int.MaxValue);
    }

    public static byte[] GetPluginConfiguration()
    {
        return BufferHelper.GetBuffer(BufferType.PluginConfiguration, 0, int.MaxValue);
    }

    public static void SetTickPeriodMilliseconds(uint millSec)
    {
        var status = Host.ProxySetTickPeriodMilliseconds(millSec);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void SetEffectiveContext(uint contextId)
    {
        var status = Host.ProxySetEffectiveContext(contextId);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static uint RegisterSharedQueue(string name)
    {
        var status = Host.ProxyRegisterSharedQueue(HostcallHelper.StringToByte(name), name.Length, out uint queueId);

        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }

        return queueId;
    }

    public static uint ResolveSharedQueue(string vmId, string queueName)
    {
        var status = Host.ProxyResolveSharedQueue(HostcallHelper.StringToByte(vmId), vmId.Length, HostcallHelper.StringToByte(queueName), queueName.Length, out uint returnId);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }

        return returnId;
    }

    public static void EnqueueSharedQueue(uint queueId, byte[] data)
    {
        var status = Host.ProxyEnqueueSharedQueue(queueId, data[0], data.Length);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static byte[] DequeueSharedQueue(uint queueId)
    {
        var status = Host.ProxyDequeueSharedQueue(queueId, out byte raw, out int size);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }

        return HostcallHelper.RawByteToByteArray(raw, size);
    }

    public static void PluginDone()
    {
        Host.ProxyDone();
    }

    public static uint DispatchHttpCall(string cluster, List<KeyValuePair<string, string>> headers, byte[] body, List<KeyValuePair<string, string>> trailers, uint timeoutMillisecond, Action<int, int, int> callBack)
    {
        var serializeHeaders = HostcallHelper.SerializeMap(headers);
        var headerPointer = serializeHeaders[0];
        var headerLength = serializeHeaders.Length;

        var serializeTrailers = HostcallHelper.SerializeMap(trailers);
        var trailerPointer = serializeTrailers[0];
        var trailerLength = serializeTrailers.Length;

        var bodyPointer = body[0];
        if (body.Length == 0)
        {
            bodyPointer = body[0];
        }

        var x = HostcallHelper.StringToByte(cluster);
        var status = Host.ProxyHttpCall(x, cluster.Length, headerPointer, headerLength, bodyPointer, body.Length, trailerPointer, trailerLength, timeoutMillisecond, out uint calloutId);
        switch (status)
        {
            case StatusType.OK:
                // TODO: Implement
                // VMState.RegisterHttpCallOut(calloutId, callBack);
                return calloutId;
            default:
                throw StatusType.ToException(status);
        }
    }

    public static List<KeyValuePair<string, string>> GetHttpCallResponseHeaders()
    {
        return MapHelper.GetMap(MapType.HttpCallResponseHeaders);
    }

    public static byte[] GetHttpCallResponseBody(int start, int maxSize)
    {
        return BufferHelper.GetBuffer(BufferType.HttpCallResponseBody, start, int.MaxValue);
    }

    public static List<KeyValuePair<string, string>> GetHttpCallResponseTrailers()
    {
        return MapHelper.GetMap(MapType.HttpCallResponseTrailers);
    }

    public static byte[] GetDownstreamData(int start, int maxSize)
    {
        return BufferHelper.GetBuffer(BufferType.DownstreamData, start, maxSize);
    }

    public static void AppendDownstreamData(byte[] data)
    {
        BufferHelper.AppendToBuffer(BufferType.DownstreamData, data);
    }

    public static void PrependDownstreamData(byte[] data)
    {
        BufferHelper.PrependToBuffer(BufferType.DownstreamData, data);
    }

    public static void ReplaceDownstreamData(byte[] data)
    {
        BufferHelper.ReplaceBuffer(BufferType.DownstreamData, data);
    }

    public static void GetUpstreamData(int start, int maxSize)
    {
        BufferHelper.GetBuffer(BufferType.UpstreamData, start, maxSize);
    }

    public static void AppendUpstreamData(byte[] data)
    {
        BufferHelper.AppendToBuffer(BufferType.UpstreamData, data);
    }

    public static void PrependUpstreamData(byte[] data)
    {
        BufferHelper.PrependToBuffer(BufferType.UpstreamData, data);
    }

    public static void ReplaceUpstreamData(byte[] data)
    {
        BufferHelper.ReplaceBuffer(BufferType.UpstreamData, data);
    }

    public static void ContinueTcpStream()
    {
        var status = Host.ProxyContinueStream(StreamType.StreamDownstream);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void CloseDownstream()
    {
        var status = Host.ProxyCloseStream(StreamType.StreamDownstream);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void CloseUpstream()
    {
        var status = Host.ProxyCloseStream(StreamType.StreamUpstream);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static List<KeyValuePair<string, string>> GetHttpRequestHeaders()
    {
        return MapHelper.GetMap(MapType.HttpRequestHeaders);
    }

    public static void ReplaceHttpRequestHeaders(List<KeyValuePair<string, string>> headers)
    {
        MapHelper.SetMap(MapType.HttpRequestHeaders, headers);
    }

    public static string GetHttpRequestHeader(string key)
    {
        return MapHelper.GetMapValue(MapType.HttpRequestHeaders, key);
    }

    public static void RemoveHttpRequestHeader(string key)
    {
        MapHelper.RemoveMapValue(MapType.HttpRequestHeaders, key);
    }

    public static void ReplaceHttpRequestHeader(string key, string value)
    {
        MapHelper.ReplaceMapValue(MapType.HttpRequestHeaders, key, value);
    }

    public static void AddHttpRequestHeader(string key, string value)
    {
        MapHelper.AddMapValue(MapType.HttpRequestHeaders, key, value);
    }

    public static byte[] GetHttpRequestBody(int start, int maxSize)
    {
        return BufferHelper.GetBuffer(BufferType.HttpRequestBody, start, maxSize);
    }

    public static void AppendHttpRequestBody(byte[] data)
    {
        BufferHelper.AppendToBuffer(BufferType.HttpRequestBody, data);
    }

    public static void PrependHttpRequestBody(byte[] data)
    {
        BufferHelper.PrependToBuffer(BufferType.HttpRequestBody, data);
    }

    public static void ReplaceHttpRequestBody(byte[] data)
    {
        BufferHelper.ReplaceBuffer(BufferType.HttpRequestBody, data);
    }

    public static List<KeyValuePair<string, string>> GetHttpRequestTrailers()
    {
        return MapHelper.GetMap(MapType.HttpRequestTrailers);
    }

    public static void ReplaceHttpRequestTrailers(List<KeyValuePair<string, string>> headers)
    {
        MapHelper.SetMap(MapType.HttpRequestTrailers, headers);
    }

    public static string GetHttpRequestTrailer(string key)
    {
        return MapHelper.GetMapValue(MapType.HttpRequestTrailers, key);
    }

    public static void RemoveHttpRequestTrailer(string key)
    {
        MapHelper.RemoveMapValue(MapType.HttpRequestTrailers, key);
    }

    public static void ReplaceHttpRequestTrailer(string key, string value)
    {
        MapHelper.ReplaceMapValue(MapType.HttpRequestTrailers, key, value);
    }

    public static void AddHttpRequestTrailer(string key, string value)
    {
        MapHelper.AddMapValue(MapType.HttpRequestTrailers, key, value);
    }

    public static void ResumeHttpRequest()
    {
        var status = Host.ProxyContinueStream(StreamType.StreamRequest);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static List<KeyValuePair<string, string>> GetHttpResponseHeaders()
    {
        return MapHelper.GetMap(MapType.HttpResponseHeaders);
    }

    public static void ReplaceHttpResponseHeaders(List<KeyValuePair<string, string>> headers)
    {
        MapHelper.SetMap(MapType.HttpResponseHeaders, headers);
    }

    public static string GetHttpResponseHeader(string key)
    {
        return MapHelper.GetMapValue(MapType.HttpResponseHeaders, key);
    }

    public static void RemoveHttpResponseHeader(string key)
    {
        MapHelper.RemoveMapValue(MapType.HttpResponseHeaders, key);
    }

    public static void ReplaceHttpResponseHeader(string key, string value)
    {
        MapHelper.ReplaceMapValue(MapType.HttpResponseHeaders, key, value);
    }

    public static void AddHttpResponseHeader(string key, string value)
    {
        MapHelper.AddMapValue(MapType.HttpResponseHeaders, key, value);
    }

    public static byte[] GetHttpResponseBody(int start, int maxSize)
    {
        return BufferHelper.GetBuffer(BufferType.HttpResponseBody, start, maxSize);
    }

    public static void AppendHttpResponseBody(byte[] data)
    {
        BufferHelper.AppendToBuffer(BufferType.HttpResponseBody, data);
    }

    public static void PrependHttpResponseBody(byte[] data)
    {
        BufferHelper.PrependToBuffer(BufferType.HttpResponseBody, data);
    }

    public static void ReplaceHttpResponseBody(byte[] data)
    {
        BufferHelper.ReplaceBuffer(BufferType.HttpResponseBody, data);
    }

    public static List<KeyValuePair<string, string>> GetHttpResponseTrailers()
    {
        return MapHelper.GetMap(MapType.HttpResponseTrailers);
    }

    public static void ReplaceHttpResponseTrailers(List<KeyValuePair<string, string>> trailers)
    {
        MapHelper.SetMap(MapType.HttpResponseTrailers, trailers);
    }

    public static string GetHttpResponseTrailer(string key)
    {
        return MapHelper.GetMapValue(MapType.HttpResponseTrailers, key);
    }

    public static void RemoveHttpResponseTrailer(string key)
    {
        MapHelper.RemoveMapValue(MapType.HttpResponseTrailers, key);
    }

    public static void ReplaceHttpResponseTrailer(string key, string value)
    {
        MapHelper.ReplaceMapValue(MapType.HttpResponseTrailers, key, value);
    }

    public static void AddHttpResponseTrailer(string key, string value)
    {
        MapHelper.AddMapValue(MapType.HttpResponseTrailers, key, value);
    }

    public static void ResumeHttpResponse()
    {
        var status = Host.ProxyContinueStream(StreamType.StreamResponse);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void SendHttpResponse(uint statusCode, List<KeyValuePair<string, string>> headers, byte[] body, int gRPCStatus)
    {
        var serializeHeaders = HostcallHelper.SerializeMap(headers);
        byte bytePointer = 0;
        if (body.Length != 0)
        {
            bytePointer = body[0];
        }

        var headerPointer = serializeHeaders[0];
        var headerLength = serializeHeaders.Length;

        var status = Host.ProxySendLocalResponse(statusCode, null, 0, bytePointer, body.Length, headerPointer, headerLength, gRPCStatus);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void GetSharedData()
    {
        // TODO: Implement
    }

    public static void SetSharedData(string key, byte[] data, uint cas)
    {
        byte dataPtr = 0;
        if (data.Length != 0)
        {
            dataPtr = data[0];
        }

        var status = Host.ProxySetSharedData(HostcallHelper.StringToByte(key), key.Length, dataPtr, data.Length, cas);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static byte[] GetProperty(List<string> path)
    {
        if (path.Count == 0)
        {
            throw new Exception("path cannot be empty");
        }

        var raw = HostcallHelper.SerializePropertyPath(path);

        var status = Host.ProxyGetProperty(raw[0], raw.Length, out byte ret, out int retSize);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }

        return HostcallHelper.RawByteToByteArray(ret, retSize);
    }

    public static List<KeyValuePair<string, string>> GetPropertyMap(List<string> path)
    {
        return HostcallHelper.DeserializeMap(GetProperty(path));
    }

    public static void SetProperty(List<string> path, byte[] data)
    {
        if (path.Count == 0)
        {
            throw new Exception("path cannot be empty");
        }

        var raw = HostcallHelper.SerializePropertyPath(path);

        var status = Host.ProxySetProperty(raw[0], raw.Length, data[0], data.Length);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static byte[] CallForeignFunction(string funcName, byte[] param)
    {
        var function = HostcallHelper.StringToByte(funcName);

        byte paramPtr = 0;
        if (param.Length != 0)
        {
            paramPtr = param[0];
        }

        var status = Host.ProxyCallForeignFunction(function, funcName.Length, paramPtr, param.Length, out byte returnData, out int returnSize);
        if (status != StatusType.OK)
        {
            throw StatusType.ToException(status);
        }

        return HostcallHelper.RawByteToByteArray(returnData, returnSize);
    }

    public static MetricCounter DefineCounterMetric()
    {
        // TODO: Implement
        return new MetricCounter();
    }

    public static MetricGauge DefineGaugeMetric()
    {
        // TODO: Implement
        return new MetricGauge();
    }

    public static MetricHistogram DefineHistogramMetric()
    {
        // TODO: Implement
        return new MetricHistogram();
    }
}
