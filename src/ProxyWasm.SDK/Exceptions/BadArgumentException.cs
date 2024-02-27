namespace ProxyWasm.SDK;

public class BadArgumentException : Exception
{
    public BadArgumentException() { }

    public BadArgumentException(string message) : base(message) { }

    public BadArgumentException(string message, Exception inner) : base(message, inner) { }
}