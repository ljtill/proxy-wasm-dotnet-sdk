namespace ProxyWasm.SDK.Exceptions;

public class CasMismatchException : Exception
{
    public CasMismatchException() { }

    public CasMismatchException(string message) : base(message) { }

    public CasMismatchException(string message, Exception inner) : base(message, inner) { }
}