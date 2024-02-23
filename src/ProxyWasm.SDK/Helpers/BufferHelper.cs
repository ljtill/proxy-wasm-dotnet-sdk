namespace ProxyWasm.SDK.Helpers;

public static class BufferHelper
{
    public static byte[] GetBuffer(uint bufType, int start, int maxSize)
    {
        byte returnData = 0;
        int returnSize = 0;

        var status = Host.ProxyGetBufferBytes(bufType, start, maxSize, returnData, returnSize);

        switch (status)
        {
            case StatusType.StatusOK:
                if (returnData == 0)
                {
                    throw new Exceptions.NotFoundException();
                }
                return HostcallHelper.RawByteToByteArray(returnData, returnSize);
            default:
                throw StatusType.ToException(status);
        }
    }

    public static void AppendToBuffer(uint bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = Host.ProxySetBufferBytes(bufferType, int.MaxValue, 0, bufferData, buffer.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void PrependToBuffer(uint bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = Host.ProxySetBufferBytes(bufferType, 0, 0, bufferData, buffer.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void ReplaceBuffer(uint bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = Host.ProxySetBufferBytes(bufferType, 0, int.MaxValue, bufferData, buffer.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }
}