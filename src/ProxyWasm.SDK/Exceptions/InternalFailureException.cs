namespace ProxyWasm.SDK.Exceptions;

public class InternalFailureException : Exception
{
    public InternalFailureException() { }

    public InternalFailureException(string message) : base(message) { }

    public InternalFailureException(string message, Exception inner) : base(message, inner) { }
}