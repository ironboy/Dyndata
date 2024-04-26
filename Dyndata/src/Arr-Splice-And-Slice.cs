namespace Dyndata;
// Arr: Splice and slice + Length
// (Splice is is used heavily by other methods)

public partial class Arr
{
    public dynamic Length
    {
        get { return memory.Count(); }
        set
        {
            Splice(value, Length);
            while (Length < value) { Push(null!); }
        }
    }

    public Arr Splice(int start, int deleteCount, params object[] values)
    {
        if (values == null) { values = [null!]; }
        start = start < 0 ? Length + start : start;
        start = start < 0 ? 0 : start;
        var removed = new List<object>();
        for (var i = 0; i < deleteCount; i++)
        {
            if (start >= Length) { break; }
            removed.Add(memory[start]);
            memory.RemoveAt(start);
        }
        start = start > Length ? Length : start;
        for (var i = values.Length - 1; i >= 0; i--)
        {
            memory.Insert(start, Utils.TryToObjOrArr(values[i]));
        }
        return new Arr(removed.ToArray());
    }

    public Arr ToSpliced(int start, int deleteCount, params object[] values)
    {
        var copy = Slice();
        copy.Splice(start, deleteCount, values);
        return copy;
    }

    public Arr Slice(int start, int end)
    {
        start = start < 0 ? Length + start : start;
        start = start < 0 ? 0 : start;
        end = end < 0 ? Length + end : end;
        end = end < 0 ? 0 : end;
        var collected = new List<object>();
        for (var i = start; i < end; i++)
        {
            if (i >= Length) { break; }
            collected.Add(memory[i]);
        }
        return new Arr(collected.ToArray());
    }

    public Arr Slice(int start)
    {
        return Slice(start, Length);
    }

    public Arr Slice()
    {
        return Slice(0, Length);
    }
}