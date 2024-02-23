using ProxyWasm.SDK.Exceptions;

namespace ProxyWasm.SDK.Helpers;

public class StatusHelper
{
    public static Exception ToException(StatusType statusType)
    {
        return statusType switch
        {
            StatusType.NotFound => new NotFoundException("Exception thrown by host: Not Found"),
            StatusType.BadArgument => new BadArgumentException("Exception thrown by host: Bad Argument"),
            StatusType.Empty => new EmptyException("Exception thrown by host: Empty"),
            StatusType.CasMismatch => new CasMismatchException("Exception thrown by host: CAS Mismatch"),
            StatusType.InternalFailure => new InternalFailureException("Exception thrown by host: Internal Failure"),
            StatusType.Unimplemented => new UnimplementedException("Exception thrown by host: Unimplemented"),
            _ => new Exception("Exception unknown: " + statusType.ToString()),
        };
    }
}
