namespace ProxyWasm.SDK;

public class MetricCounter
{
    public void Value() { }
    public void Increment() { }
}

public class MetricGauge
{
    public void Value() { }
    public void Add() { }
}

public class MetricHistogram
{
    public void Value() { }
    public void Record() { }
}
