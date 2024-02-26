namespace ProxyWasm.SDK;

public class MetricCounter(uint id)
{
    public uint Id { get; set; } = id;

    public ulong Value()
    {
        var status = ProxyHost.ProxyGetMetric(Id, out ulong val);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to get metric value");
        }

        return val;
    }
    public void Increment(uint offset)
    {
        var status = ProxyHost.ProxyIncrementMetric(Id, offset);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to increment metric");
        }
    }
}

public class MetricGauge(uint id)
{
    public uint Id { get; set; } = id;

    public ulong Value()
    {
        var status = ProxyHost.ProxyGetMetric(Id, out ulong val);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to get metric value");
        }

        return val;
    }
    public void Add(uint offset)
    {
        var status = ProxyHost.ProxyIncrementMetric(Id, offset);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to increment metric");
        }
    }
}

public class MetricHistogram(uint id)
{
    public uint Id { get; set; } = id;

    public void Value()
    {
        var status = ProxyHost.ProxyGetMetric(Id, out ulong val);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to get metric value");
        }
    }
    public void Record(uint value)
    {
        var status = ProxyHost.ProxyRecordMetric(Id, value);
        if (status != StatusType.OK)
        {
            throw new Exception("Failed to record metric");
        }
    }
}
