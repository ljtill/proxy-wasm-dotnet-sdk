namespace ProxyWasm.SDK.Helpers;

public static class MapHelper
{
    public static void SetMap(uint map, List<KeyValuePair<string, string>> headers)
    {
        var serializeHeaders = HostcallHelper.SerializeMap(headers);
        var headerPointer = serializeHeaders[0];
        var headerLength = serializeHeaders.Length;

        var status = Host.ProxySetHeaderMapPairs(map, headerPointer, headerLength);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static string GetMapValue(uint mapType, string key)
    {
        var status = Host.ProxyGetHeaderMapValue(mapType, HostcallHelper.StringToByte(key), key.Length, out byte raw, out int rvs);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }

        return HostcallHelper.RawByteToString(raw, rvs);
    }

    public static void RemoveMapValue(uint map, string key)
    {
        var status = Host.ProxyRemoveHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void ReplaceMapValue(uint map, string key, string value)
    {
        var status = Host.ProxyReplaceHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length, HostcallHelper.StringToByte(value), value.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static void AddMapValue(uint map, string key, string value)
    {
        var status = Host.ProxyAddHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length, HostcallHelper.StringToByte(value), value.Length);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }
    }

    public static List<KeyValuePair<string, string>> GetMap(uint map)
    {
        var status = Host.ProxyGetHeaderMapPairs(map, out byte raw, out int rvs);
        if (status != StatusType.StatusOK)
        {
            throw StatusType.ToException(status);
        }

        var byteArray = HostcallHelper.RawByteToByteArray(raw, rvs);
        return HostcallHelper.DeserializeMap(byteArray);
    }
}