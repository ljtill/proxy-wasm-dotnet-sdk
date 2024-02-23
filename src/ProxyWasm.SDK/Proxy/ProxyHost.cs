namespace ProxyWasm.SDK;

public static class ProxyHost
{
    //export proxy_log
    public static StatusType ProxyLog(LogLevelType logLevel, byte messageData, int messageSize)
    {
        return StatusType.OK;
    }

    //export proxy_send_local_response
    public static StatusType ProxySendLocalResponse(uint statusCode, byte? statusCodeDetailData, int statusCodeDetailsSize, byte bodyData, int bodySize, byte headersData, int headersSize, int grpcStatus)
    {
        return StatusType.OK;
    }

    //export proxy_get_shared_data
    public static StatusType ProxyGetSharedData(byte keyData, int keySize, byte returnValueData, int returnValueSize, uint returnCas)
    {
        return StatusType.OK;
    }

    //export proxy_set_shared_data
    public static StatusType ProxySetSharedData(byte keyData, int keySize, byte valueData, int valueSize, uint cas)
    {
        return StatusType.OK;
    }

    //export proxy_register_shared_queue
    public static StatusType ProxyRegisterSharedQueue(byte nameData, int nameSize, out uint returnId)
    {
        returnId = 0;
        return StatusType.OK;
    }

    //export proxy_resolve_shared_queue
    public static StatusType ProxyResolveSharedQueue(byte vmIdData, int vmIdSize, byte nameData, int nameSize, out uint returnId)
    {
        returnId = 0;
        return StatusType.OK;
    }

    //export proxy_dequeue_shared_queue
    public static StatusType ProxyDequeueSharedQueue(uint queueId, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return StatusType.OK;
    }

    //export proxy_enqueue_shared_queue
    public static StatusType ProxyEnqueueSharedQueue(uint queueId, byte valueData, int valueSize)
    {
        return StatusType.OK;
    }

    //export proxy_get_header_map_value
    public static StatusType ProxyGetHeaderMapValue(MapType map, byte keyData, int keySize, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return StatusType.OK;
    }

    //export proxy_add_header_map_value
    public static StatusType ProxyAddHeaderMapValue(MapType map, byte keyData, int keySize, byte valueData, int valueSize)
    {
        return StatusType.OK;
    }

    //export proxy_replace_header_map_value
    public static StatusType ProxyReplaceHeaderMapValue(MapType map, byte keyData, int keySize, byte valueData, int valueSize)
    {
        return StatusType.OK;
    }

    //export proxy_remove_header_map_value
    public static StatusType ProxyRemoveHeaderMapValue(MapType map, byte keyData, int keySize)
    {
        return StatusType.OK;
    }

    //export proxy_get_header_map_pairs
    public static StatusType ProxyGetHeaderMapPairs(MapType map, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return StatusType.OK;
    }

    //export proxy_set_header_map_pairs
    public static StatusType ProxySetHeaderMapPairs(MapType map, byte mapData, int mapSize)
    {
        return StatusType.OK;
    }

    //export proxy_get_buffer_bytes
    public static StatusType ProxyGetBufferBytes(BufferType buffer, int start, int maxSize, byte returnBufferData, int returnBufferSize)
    {
        return StatusType.OK;
    }

    //export proxy_set_buffer_bytes
    public static StatusType ProxySetBufferBytes(BufferType buffer, int start, int maxSize, byte bufferData, int bufferSize)
    {
        return StatusType.OK;
    }

    //export proxy_continue_stream
    public static StatusType ProxyContinueStream(StreamType stream)
    {
        return StatusType.OK;
    }

    //export proxy_close_stream
    public static StatusType ProxyCloseStream(StreamType stream)
    {
        return StatusType.OK;
    }

    //export proxy_http_call
    public static StatusType ProxyHttpCall(byte upstreamData, int upstreamSize, byte headerData, int headerSize, byte bodyData, int bodySize, byte trailersData, int trailersSize, uint timeout, out uint calloutIdPtr)
    {
        calloutIdPtr = 0;
        return StatusType.OK;
    }

    //export proxy_call_foreign_function
    public static StatusType ProxyCallForeignFunction(byte funcNamePtr, int funcNameSize, byte paramPtr, int paramSize, out byte returnData, out int returnSize)
    {
        returnData = 0;
        returnSize = 0;
        return StatusType.OK;
    }

    //export proxy_set_tick_period_milliseconds
    public static StatusType ProxySetTickPeriodMilliseconds(uint period)
    {
        return StatusType.OK;
    }

    //export proxy_set_effective_context
    public static StatusType ProxySetEffectiveContext(uint contextId)
    {
        return StatusType.OK;
    }

    //export proxy_done
    public static StatusType ProxyDone()
    {
        return StatusType.OK;
    }

    //export proxy_define_metric
    public static StatusType ProxyDefineMetric(uint metric, byte metricNameData, int metricNameSize, uint returnMetricIdPtr)
    {
        return StatusType.OK;
    }

    //export proxy_increment_metric
    public static StatusType ProxyIncrementMetric(uint metricId, Int64 offset)
    {
        return StatusType.OK;
    }

    //export proxy_record_metric
    public static StatusType ProxyRecordMetric(uint metricId, Int64 offset)
    {
        return StatusType.OK;
    }

    //export proxy_get_metric
    public static StatusType ProxyGetMetric(uint metricId, UInt64 returnMetricValue)
    {
        return StatusType.OK;
    }

    //export proxy_get_property
    public static StatusType ProxyGetProperty(byte pathData, int pathSize, out byte returnValueData, out int returnValueSize)
    {
        returnValueData = 0;
        returnValueSize = 0;
        return StatusType.OK;
    }

    //export proxy_set_property
    public static StatusType ProxySetProperty(byte pathData, int pathSize, byte valueData, int valueSize)
    {
        return StatusType.OK;
    }
}