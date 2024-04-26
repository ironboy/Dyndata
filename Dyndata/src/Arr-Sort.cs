namespace Dyndata;
// Arr: Sort methods

public partial class Arr
{
    public Arr Sort()
    {
        memory.Sort();
        return this;
    }

    public Arr Sort(_ddd2 func)
    {
        var toSort = memory.ToArray();
        Array.Sort(toSort, (a, b) =>
        {
            dynamic result = func(a, b);
            return result == 0 ? 0 : result > 0 ? 1 : -1;
        });
        Length = 0;
        foreach (var item in toSort) { Push(item); }
        return this;
    }

    public Arr ToSorted()
    {
        return Slice().Sort();
    }

    public Arr ToSorted(_ddd2 func)
    {
        return Slice().Sort(func);
    }
}