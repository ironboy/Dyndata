namespace Dyndata;
using A = Arr;
using O = Obj;

// Static factory functions for Arr, Obj
// + Log

public static class Factory
{
    public static A Arr()
    {
        return new A();
    }

    public static A Arr(IEnumerable items)
    {
        return new A(items);
    }

    public static A Arr(params dynamic[] items)
    {
        if (items.Length == 1 && items[0] is Arr) { return (Arr)items[0]; }
        return new A(items);
    }

    public static dynamic Obj()
    {
        return new O();
    }

    public static dynamic Obj(object source)
    {
        return new O(source);
    }

    public static void Log(params object[] paras)
    {
        var p = Arr();
        if (paras == null) { paras = [(object)null!]; }
        foreach (var para in paras) { p.Push(para); }
        var stringColor = "\u001b[38;5;" + JSON.colors.strings + "m";
        var resetColor = "\u001b[" + JSON.colors.reset + "m";
        var r = p.Every(x => x is string) ?
            stringColor + p.Join(" ") + resetColor : JSON.StringifyForLog(p);
        Console.WriteLine(r + (_logExtraNewLine ? "\r\n" : ""));
    }

    public static bool LogHighlight
    {
        get { return JSON.Highlight; }
        set { JSON.Highlight = value; }
    }

    private static bool _logExtraNewLine = true;

    public static bool LogExtraNewline
    {
        get { return _logExtraNewLine; }
        set { _logExtraNewLine = value; }
    }
}