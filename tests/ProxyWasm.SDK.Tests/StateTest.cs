namespace ProxyWasm.SDK.Tests;

public class StateTests
{
    [Fact]
    public void SetVMContext_Should_Set_VMContext()
    {
        // Arrange
        var state = new State();
        var vmContext = new DefaultVMContext();

        // Act
        state.SetVMContext(vmContext);

        // Assert
        Assert.Equal(vmContext, state.RootContext.VMContext);
    }
}
