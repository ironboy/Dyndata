namespace Dyndata;
using System.Globalization;

// Utils:
//
// TryToObjOrArr:
// Convert all IEnumerables to Arrs
// and all objects to Obj, if possible

public static class Utils
{
    public static dynamic TryToObjOrArr(dynamic value)
    {
        Type t = typeof(int);
        if (value != null) { t = value.GetType(); }
        var isPrimitive = value == null || t.IsPrimitive || t == typeof(String) || t == typeof(Decimal);
        if ((t + "").Contains("Newtonsoft.Json.Linq.JValue")) { isPrimitive = true; }
        var isDict = !isPrimitive && (t + "").Contains("System.Collections.Generic.Dictionary");
        var isList = !isPrimitive && !isDict && value is IEnumerable;
        var isObject = !isPrimitive && !isList && !isDict && value is object;
        if ((t + "").Contains("Newtonsoft.Json.Linq.JObject"))
        {
            return TryToObjOrArr(JSON.Parse(JSON.Stringify(value!)));
        }
        if (isList && value is not Arr)
        {
            try { value = new Arr(value); }
            catch (Exception) { };
        }
        if (isDict)
        {
            var obj = new Obj();
            foreach (var item in value!)
            {
                obj[item.Key] = item.Value;
            }
            value = obj;
        }
        if (isObject && value is not Obj)
        {
            try { value = new Obj(value!); }
            catch (Exception) { };
        }
        return value!;
    }

    private static CultureInfo orgCulture = null!;

    public static void SetInvariantCulture()
    {
        orgCulture = CultureInfo.DefaultThreadCurrentCulture!;
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }

    public static void SetOriginalCulture()
    {
        CultureInfo.DefaultThreadCurrentCulture = orgCulture;
    }
}