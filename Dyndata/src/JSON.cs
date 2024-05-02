namespace Dyndata;
using Newtonsoft.Json;
using FracturedJson;

// Parse JSON with a focus on creating Objs and Arrs (via Utils.TryToObjOrArr)
// Stringify to JSON with an identation option
// that also turns on syntax highlighting of the JSON
public static partial class JSON
{
    public static dynamic Parse(string json)
    {
        dynamic parsed;
        try
        {
            parsed = JsonConvert.DeserializeObject
                <Dictionary<string, object>>(json);
        }
        catch (Exception)
        {
            dynamic json2 = "{\"_holder\":" + json + "}";
            dynamic x = JsonConvert.DeserializeObject
                <Dictionary<string, object>>(json2);
            parsed = x["_holder"];
        }
        return Utils.TryToObjOrArr(parsed);
    }

    public static string Stringify(
        dynamic obj, bool indented = false, bool highlight = false
    )
    {
        var json = JsonConvert.SerializeObject(obj);
        return !indented ? json : Humane(json, false, highlight);
    }

    public static string StringifyForLog(dynamic obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        return Humane(json, true, _highlight);
    }

    private static string Humane(
        string json, bool forLog = false, bool highlight = false
    )
    {
        Utils.SetInvariantCulture();
        var opts = new FracturedJsonOptions()
        {
            MaxTotalLineLength = 90,
            MaxInlineComplexity = 3
        };
        var formatter = new Formatter() { Options = opts };
        var output = formatter.Reformat(json, 0).Trim();
        Utils.SetOriginalCulture();
        var rr = RemoveAndReinsertStrings(output);
        output = forLog ? ForLog(output) : output;
        output = highlight ? Colorize(output) : output;
        output = forLog ? ForLog(output, false) : output;
        output = highlight ? output.Replace("!%&€", "\u001b[") : output;
        return output;
    }
}