namespace ProxyWasm.SDK;

public class UnimplementedException : Exception
{
    public UnimplementedException() { }

    public UnimplementedException(string message) : base(message) { }

    public UnimplementedException(string message, Exception inner) : base(message, inner) { }
}
