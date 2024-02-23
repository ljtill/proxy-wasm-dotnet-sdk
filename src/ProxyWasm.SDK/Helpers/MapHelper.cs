namespace ProxyWasm.SDK.Helpers;

public static class MapHelper
{
    public static void SetMap(MapType map, List<KeyValuePair<string, string>> headers)
    {
        var serializeHeaders = HostcallHelper.SerializeMap(headers);
        var headerPointer = serializeHeaders[0];
        var headerLength = serializeHeaders.Length;

        var status = ProxyHost.ProxySetHeaderMapPairs(map, headerPointer, headerLength);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static string GetMapValue(MapType mapType, string key)
    {
        var status = ProxyHost.ProxyGetHeaderMapValue(mapType, HostcallHelper.StringToByte(key), key.Length, out byte raw, out int rvs);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }

        return HostcallHelper.RawByteToString(raw, rvs);
    }

    public static void RemoveMapValue(MapType map, string key)
    {
        var status = ProxyHost.ProxyRemoveHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void ReplaceMapValue(MapType map, string key, string value)
    {
        var status = ProxyHost.ProxyReplaceHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length, HostcallHelper.StringToByte(value), value.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static void AddMapValue(MapType map, string key, string value)
    {
        var status = ProxyHost.ProxyAddHeaderMapValue(map, HostcallHelper.StringToByte(key), key.Length, HostcallHelper.StringToByte(value), value.Length);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }
    }

    public static List<KeyValuePair<string, string>> GetMap(MapType map)
    {
        var status = ProxyHost.ProxyGetHeaderMapPairs(map, out byte raw, out int rvs);
        if (status != StatusType.OK)
        {
            throw StatusHelper.ToException(status);
        }

        var byteArray = HostcallHelper.RawByteToByteArray(raw, rvs);
        return HostcallHelper.DeserializeMap(byteArray);
    }
}