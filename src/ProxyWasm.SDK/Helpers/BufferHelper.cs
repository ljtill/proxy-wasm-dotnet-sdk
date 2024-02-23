namespace ProxyWasm.SDK.Helpers;

public static class BufferHelper
{
    public static byte[] GetBuffer(BufferType bufType, int start, int maxSize)
    {
        byte returnData = 0;
        int returnSize = 0;

        var status = ProxyHost.ProxyGetBufferBytes(bufType, start, maxSize, returnData, returnSize);

        switch (status)
        {
            case StatusType.OK:
                if (returnData == 0)
                {
                    throw new Exceptions.NotFoundException();
                }
                return HostcallHelper.RawByteToByteArray(returnData, returnSize);
            default:
                throw StatusHelper.ToException(status);
        }
    }

    public static void AppendToBuffer(BufferType bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = ProxyHost.ProxySetBufferBytes(bufferType, int.MaxValue, 0, bufferData, buffer.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void PrependToBuffer(BufferType bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = ProxyHost.ProxySetBufferBytes(bufferType, 0, 0, bufferData, buffer.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void ReplaceBuffer(BufferType bufferType, byte[] buffer)
    {
        byte bufferData = 0;
        if (buffer.Length != 0)
        {
            bufferData = buffer[0];
        }

        var status = ProxyHost.ProxySetBufferBytes(bufferType, 0, int.MaxValue, bufferData, buffer.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }
}