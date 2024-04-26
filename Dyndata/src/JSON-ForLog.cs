namespace Dyndata;

// Special ForLog option
// adopting the output of JSON.tringify 
// to suit the Factory.Log method
public static partial class JSON
{
    private static string ForLog(string json, bool beforeColorize = true)
    {
        var x = beforeColorize ?
            json.Trim('[', ']').Trim().Replace("\n    ", "\n") : json;
        var output = "";
        var inArr = 0;
        var lastChar = 'x';
        var inString = false;
        foreach (var c in x)
        {
            if ((c == '[' || c == '{') && lastChar != '\\') { inArr++; }
            if ((c == ']' || c == '}') && lastChar != '\\') { inArr--; }
            if (c == '"' && lastChar != '\\') { inString = !inString; }
            output += beforeColorize ?
                inArr == 0 && !inString && c == ',' ? "" : c :
                inArr == 0 && c == '"' && lastChar != '\\' ? "" : c;
            lastChar = c;
        }
        return output;
    }
}