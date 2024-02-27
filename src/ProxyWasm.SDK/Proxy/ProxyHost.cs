using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

public static class ProxyHost
{
    [DllImport("proxywasm", EntryPoint = "proxy_log")]
    public static extern StatusType ProxyLog(LogLevelType logLevel, byte messageData, int messageSize);

    [DllImport("proxywasm", EntryPoint = "proxy_send_local_response")]
    public static extern StatusType ProxySendLocalResponse(uint statusCode, byte? statusCodeDetailData, int statusCodeDetailsSize, byte bodyData, int bodySize, byte headersData, int headersSize, int grpcStatus);

    [DllImport("proxywasm", EntryPoint = "proxy_get_shared_data")]
    public static extern StatusType ProxyGetSharedData(byte keyData, int keySize, out byte returnValueData, out int returnValueSize, out uint returnCas);

    [DllImport("proxywasm", EntryPoint = "proxy_set_shared_data")]
    public static extern StatusType ProxySetSharedData(byte keyData, int keySize, byte valueData, int valueSize, uint cas);

    [DllImport("proxywasm", EntryPoint = "proxy_register_shared_queue")]
    public static extern StatusType ProxyRegisterSharedQueue(byte nameData, int nameSize, out uint returnId);

    [DllImport("proxywasm", EntryPoint = "proxy_resolve_shared_queue")]
    public static extern StatusType ProxyResolveSharedQueue(byte vmIdData, int vmIdSize, byte nameData, int nameSize, out uint returnId);

    [DllImport("proxywasm", EntryPoint = "proxy_dequeue_shared_queue")]
    public static extern StatusType ProxyDequeueSharedQueue(uint queueId, out byte returnValueData, out int returnValueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_enqueue_shared_queue")]
    public static extern StatusType ProxyEnqueueSharedQueue(uint queueId, byte valueData, int valueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_add_header_map_value")]
    public static extern StatusType ProxyGetHeaderMapValue(MapType map, byte keyData, int keySize, out byte returnValueData, out int returnValueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_add_header_map_value")]
    public static extern StatusType ProxyAddHeaderMapValue(MapType map, byte keyData, int keySize, byte valueData, int valueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_replace_header_map_value")]
    public static extern StatusType ProxyReplaceHeaderMapValue(MapType map, byte keyData, int keySize, byte valueData, int valueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_remove_header_map_value")]
    public static extern StatusType ProxyRemoveHeaderMapValue(MapType map, byte keyData, int keySize);

    [DllImport("proxywasm", EntryPoint = "proxy_get_header_map_pairs")]
    public static extern StatusType ProxyGetHeaderMapPairs(MapType map, out byte returnValueData, out int returnValueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_set_header_map_pairs")]
    public static extern StatusType ProxySetHeaderMapPairs(MapType map, byte mapData, int mapSize);

    [DllImport("proxywasm", EntryPoint = "proxy_get_buffer_bytes")]
    public static extern StatusType ProxyGetBufferBytes(BufferType buffer, int start, int maxSize, out byte returnBufferData, out int returnBufferSize);

    [DllImport("proxywasm", EntryPoint = "proxy_set_buffer_bytes")]
    public static extern StatusType ProxySetBufferBytes(BufferType buffer, int start, int maxSize, byte bufferData, int bufferSize);

    [DllImport("proxywasm", EntryPoint = "proxy_continue_stream")]
    public static extern StatusType ProxyContinueStream(StreamType stream);

    [DllImport("proxywasm", EntryPoint = "proxy_close_stream")]
    public static extern StatusType ProxyCloseStream(StreamType stream);

    [DllImport("proxywasm", EntryPoint = "proxy_http_call")]
    public static extern StatusType ProxyHttpCall(byte upstreamData, int upstreamSize, byte headerData, int headerSize, byte bodyData, int bodySize, byte trailersData, int trailersSize, uint timeout, out uint calloutIdPtr);

    [DllImport("proxywasm", EntryPoint = "proxy_call_foreign_function")]
    public static extern StatusType ProxyCallForeignFunction(byte funcNamePtr, int funcNameSize, byte paramPtr, int paramSize, out byte returnData, out int returnSize);

    [DllImport("proxywasm", EntryPoint = "proxy_set_tick_period_milliseconds")]
    public static extern StatusType ProxySetTickPeriodMilliseconds(uint period);

    [DllImport("proxywasm", EntryPoint = "proxy_set_effective_context")]
    public static extern StatusType ProxySetEffectiveContext(uint contextId);

    [DllImport("proxywasm", EntryPoint = "proxy_done")]
    public static extern StatusType ProxyDone();

    [DllImport("proxywasm", EntryPoint = "proxy_define_metric")]
    public static extern StatusType ProxyDefineMetric(MetricType metric, byte metricNameData, int metricNameSize, out uint returnMetricIdPtr);

    [DllImport("proxywasm", EntryPoint = "proxy_increment_metric")]
    public static extern StatusType ProxyIncrementMetric(uint metricId, long offset);

    [DllImport("proxywasm", EntryPoint = "proxy_record_metric")]
    public static extern StatusType ProxyRecordMetric(uint metricId, long offset);

    [DllImport("proxywasm", EntryPoint = "proxy_get_metric")]
    public static extern StatusType ProxyGetMetric(uint metricId, out ulong returnMetricValue);

    [DllImport("proxywasm", EntryPoint = "proxy_get_property")]
    public static extern StatusType ProxyGetProperty(byte pathData, int pathSize, out byte returnValueData, out int returnValueSize);

    [DllImport("proxywasm", EntryPoint = "proxy_set_property")]
    public static extern StatusType ProxySetProperty(byte pathData, int pathSize, byte valueData, int valueSize);

}