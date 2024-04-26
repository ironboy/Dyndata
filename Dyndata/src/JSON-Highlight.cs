namespace Dyndata;

// Helper methods for syntax highlighting
// of JSON

public static partial class JSON
{

    private static bool _highlight = true;

    public static readonly dynamic colors = Obj(new
    {
        propNames = 186, // green/yellow
        booleans = 180,  // orange
        strings = 250,   // off-white
        numbers = 153,   // blue
        brackets = 245,  // gray
        _default = 245,  // gray
        reset = 0        // reset code
    });

    public static bool Highlight
    {
        get { return _highlight; }
        set { _highlight = value; }
    }

    private static string Colorize(string json)
    {
        var c = Obj(colors);
        ((Arr)c.GetKeys()).ForEach(x => c[x] = "!%&€38;5;" + c[x] + "m");
        c.reset += c._default;
        var rr = RemoveAndReinsertStrings(json);

        var x = Regex.Replace(rr.str, @"([\d\.]+)", $"{c.numbers}$1{c.reset}");
        x = Regex.Replace(x, "\"([^\"]*)\":", $"{c.propNames}__quote__$1__quote__:{c.reset}");
        x = Regex.Replace(x, "\"([^\"]*)\"", $"{c.strings}\"$1\"{c.reset}");
        x = x.Replace("__quote__", "\"");
        x = x.Replace("true", $"{c.booleans}true{c.reset}");
        x = x.Replace("false", $"{c.booleans}false{c.reset}");
        x = RemoveAndReinsertStrings(x, rr.extracted).str;

        return c._default + x.Replace("\n", "\n" + c._default);
    }

    private static dynamic RemoveAndReinsertStrings(
        string json, string reinsert = ""
    )
    {
        var isRe = reinsert != "";
        var inString = false;
        var lastChar = 'x';
        var str = "";
        var extracted = "";
        var co = 0;
        foreach (var c in json)
        {
            if (c == '"' && lastChar != '\\')
            {
                inString = !inString;
                if (inString) { str += c; continue; }
            }
            str += inString ? isRe ? reinsert[co++] : "_" : c;
            extracted += inString ? c : "";
            lastChar = c;
        }
        return new { str, extracted };
    }
}