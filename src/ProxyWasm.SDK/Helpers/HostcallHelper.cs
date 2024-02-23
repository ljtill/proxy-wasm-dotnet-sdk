using System.Runtime.InteropServices;
using System.Text;

namespace ProxyWasm.SDK.Helpers;

public static class HostcallHelper
{
    public static string RawByteToString(byte raw, int size)
    {
        return Marshal.PtrToStringAnsi(raw, size);
    }

    public static byte[] RawByteToByteArray(byte raw, int size)
    {
        byte[]? returnData = Marshal.PtrToStructure<byte[]>(raw) ?? throw new Exception("Null pointer exception");
        return returnData;
    }

    public static byte StringToByte(string message)
    {
        if (message.Length == 0)
        {
            throw new Exception("Empty string");
        }

        byte[] byteData = Encoding.UTF8.GetBytes(message);
        byte result = byteData.FirstOrDefault();
        return result;
    }

    public static byte[] SerializeMap(List<KeyValuePair<string, string>> ms)
    {
        int size = 4;
        foreach (var m in ms)
        {
            size += Encoding.UTF8.GetByteCount(m.Key) + Encoding.UTF8.GetByteCount(m.Value) + 10;
        }

        byte[] ret = new byte[size];
        BitConverter.GetBytes(ms.Count).CopyTo(ret, 0);

        int baseIndex = 4;
        foreach (var m in ms)
        {
            BitConverter.GetBytes(Encoding.UTF8.GetByteCount(m.Key)).CopyTo(ret, baseIndex);
            baseIndex += 4;
            BitConverter.GetBytes(Encoding.UTF8.GetByteCount(m.Value)).CopyTo(ret, baseIndex);
            baseIndex += 4;
        }

        foreach (var m in ms)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(m.Key);
            byte[] valueBytes = Encoding.UTF8.GetBytes(m.Value);

            keyBytes.CopyTo(ret, baseIndex);
            baseIndex += keyBytes.Length;
            baseIndex++;

            valueBytes.CopyTo(ret, baseIndex);
            baseIndex += valueBytes.Length;
            baseIndex++;
        }

        return ret;
    }

    public static List<KeyValuePair<string, string>> DeserializeMap(byte[] bs)
    {
        int numHeaders = BitConverter.ToInt32(bs, 0);
        int sizeIndex = 4;
        int dataIndex = 4 + 4 * 2 * numHeaders;
        var ret = new List<KeyValuePair<string, string>>(numHeaders);
        for (int i = 0; i < numHeaders; i++)
        {
            int keySize = BitConverter.ToInt32(bs, sizeIndex);
            sizeIndex += 4;
            string key = Encoding.UTF8.GetString(bs, dataIndex, keySize);
            dataIndex += keySize + 1;

            int valueSize = BitConverter.ToInt32(bs, sizeIndex);
            sizeIndex += 4;
            string value = Encoding.UTF8.GetString(bs, dataIndex, valueSize);
            dataIndex += valueSize + 1;
            ret.Add(new KeyValuePair<string, string>(key, value));
        }
        return ret;
    }

    public static byte[] SerializePropertyPath(List<string> path)
    {
        if (path.Count == 0)
        {
            return [];
        }

        int size = path.Sum(p => p.Length + 1);
        List<byte> ret = new(size);
        foreach (var p in path)
        {
            ret.AddRange(Encoding.ASCII.GetBytes(p));
            ret.Add(0);
        }
        ret.RemoveAt(ret.Count - 1);
        return ret.ToArray();
    }
}
