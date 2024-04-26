namespace Dyndata;
// Arr: Pop/push, shift/unshift and other basic methods

public partial class Arr
{
    public int Push(params object[] values)
    {
        Splice(Length, 0, values);
        return Length;
    }

    public object Pop()
    {
        return Splice(Length - 1, 1)[0];
    }

    public int Unshift(params object[] values)
    {
        Splice(0, 0, values);
        return Length;
    }

    public object Shift()
    {
        return Splice(0, 1)[0];
    }

    public int IndexOf(object value, int fromIndex = 0)
    {
        var i = Slice(fromIndex).memory.IndexOf(value);
        return i < 0 ? -1 : i + fromIndex;
    }

    public int LastIndexOf(object value, int fromIndex = int.MaxValue)
    {
        return Slice(0, fromIndex).memory.LastIndexOf(value);
    }

    public bool Includes(object value, int fromIndex = 0)
    {
        return Slice(fromIndex).memory.Contains(value);
    }

    public bool Contains(object value, int fromIndex = 0)
    {
        return Includes(value, fromIndex);
    }

    public Arr Reverse()
    {
        memory.Reverse();
        return this;
    }

    public Arr ToReversed()
    {
        return Slice().Reverse();
    }
}