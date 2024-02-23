namespace ProxyWasm.SDK;

public class Entrypoint
{
    public static void SetVMContext(IVMContext context)
    {
        VMState state = new();
        state.SetVMContext(context);
    }
}
