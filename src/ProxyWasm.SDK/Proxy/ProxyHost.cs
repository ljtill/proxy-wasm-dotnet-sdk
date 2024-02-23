namespace ProxyWasm.SDK;

public static class ProxyHost
{
    //export proxy_log
    public static uint ProxyLog(uint logLevel, byte messageData, int messageSize)
    {
        return 1;
    }

    //export proxy_send_local_response
    public static uint ProxySendLocalResponse(uint statusCode, byte? statusCodeDetailData, int statusCodeDetailsSize, byte bodyData, int bodySize, byte headersData, int headersSize, int grpcStatus)
    {
        return 1;
    }

    //export proxy_get_shared_data
    public static uint ProxyGetSharedData(byte keyData, int keySize, byte returnValueData, int returnValueSize, uint returnCas)
    {
        return 1;
    }

    //export proxy_set_shared_data
    public static uint ProxySetSharedData(byte keyData, int keySize, byte valueData, int valueSize, uint cas)
    {
        return 1;
    }

    //export proxy_register_shared_queue
    public static uint ProxyRegisterSharedQueue(byte nameData, int nameSize, out uint returnId)
    {
        returnId = 0;
        return 1;
    }

    //export proxy_resolve_shared_queue
    public static uint ProxyResolveSharedQueue(byte vmIdData, int vmIdSize, byte nameData, int nameSize, out uint returnId)
    {
        returnId = 0;
        return 1;
    }

    //export proxy_dequeue_shared_queue
    public static uint ProxyDequeueSharedQueue(uint queueId, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return 1;
    }

    //export proxy_enqueue_shared_queue
    public static uint ProxyEnqueueSharedQueue(uint queueId, byte valueData, int valueSize)
    {
        return 1;
    }

    //export proxy_get_header_map_value
    public static uint ProxyGetHeaderMapValue(uint map, byte keyData, int keySize, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return 1;
    }

    //export proxy_add_header_map_value
    public static uint ProxyAddHeaderMapValue(uint map, byte keyData, int keySize, byte valueData, int valueSize)
    {
        return 1;
    }

    //export proxy_replace_header_map_value
    public static uint ProxyReplaceHeaderMapValue(uint map, byte keyData, int keySize, byte valueData, int valueSize)
    {
        return 1;
    }

    //export proxy_remove_header_map_value
    public static uint ProxyRemoveHeaderMapValue(uint map, byte keyData, int keySize)
    {
        return 1;
    }

    //export proxy_get_header_map_pairs
    public static uint ProxyGetHeaderMapPairs(uint map, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return 1;
    }

    //export proxy_set_header_map_pairs
    public static uint ProxySetHeaderMapPairs(uint map, byte mapData, int mapSize)
    {
        return 1;
    }

    //export proxy_get_buffer_bytes
    public static uint ProxyGetBufferBytes(uint buffer, int start, int maxSize, byte returnBufferData, int returnBufferSize)
    {
        return 1;
    }

    //export proxy_set_buffer_bytes
    public static uint ProxySetBufferBytes(uint buffer, int start, int maxSize, byte bufferData, int bufferSize)
    {
        return 1;
    }

    //export proxy_continue_stream
    public static uint ProxyContinueStream(uint stream)
    {
        return 1;
    }

    //export proxy_close_stream
    public static uint ProxyCloseStream(uint stream)
    {
        return 1;
    }

    //export proxy_http_call
    public static uint ProxyHttpCall(byte upstreamData, int upstreamSize, byte headerData, int headerSize, byte bodyData, int bodySize, byte trailersData, int trailersSize, uint timeout, out uint calloutIdPtr)
    {
        calloutIdPtr = 0;
        return 1;
    }

    //export proxy_call_foreign_function
    public static uint ProxyCallForeignFunction(byte funcNamePtr, int funcNameSize, byte paramPtr, int paramSize, out byte returnData, out int returnSize)
    {
        returnData = 0;
        returnSize = 0;
        return 1;
    }

    //export proxy_set_tick_period_milliseconds
    public static uint ProxySetTickPeriodMilliseconds(uint period)
    {
        return 1;
    }

    //export proxy_set_effective_context
    public static uint ProxySetEffectiveContext(uint contextId)
    {
        return 1;
    }

    //export proxy_done
    public static uint ProxyDone()
    {
        return 1;
    }

    //export proxy_define_metric
    public static uint ProxyDefineMetric(uint metric, byte metricNameData, int metricNameSize, uint returnMetricIdPtr)
    {
        return 1;
    }

    //export proxy_increment_metric
    public static uint ProxyIncrementMetric(uint metricId, Int64 offset)
    {
        return 1;
    }

    //export proxy_record_metric
    public static uint ProxyRecordMetric(uint metricId, Int64 offset)
    {
        return 1;
    }

    //export proxy_get_metric
    public static uint ProxyGetMetric(uint metricId, UInt64 returnMetricValue)
    {
        return 1;
    }

    //export proxy_get_property
    public static uint ProxyGetProperty(byte pathData, int pathSize, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return 1;
    }

    //export proxy_set_property
    public static uint ProxySetProperty(byte pathData, int pathSize, byte valueData, int valueSize)
    {
        return 1;
    }
}