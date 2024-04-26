namespace Dyndata;
// Arr: Find methods

public partial class Arr
{
    public dynamic Find(_bd func)
    {
        return memory.FirstOrDefault(x => func(x))!;
    }
    public dynamic Find(_bdi func)
    {
        var i = 0;
        return memory.FirstOrDefault(x => func(x, i++))!;
    }
    public dynamic Find(_bdiA func)
    {
        var i = 0;
        return memory.FirstOrDefault(x => func(x, i++, this))!;
    }

    public dynamic FindLast(_bd func)
    {
        return memory.LastOrDefault(x => func(x))!;
    }
    public dynamic FindLast(_bdi func)
    {
        var i = Length;
        return memory.LastOrDefault(x => func(x, --i))!;
    }
    public dynamic FindLast(_bdiA func)
    {
        var i = Length;
        return memory.LastOrDefault(x => func(x, --i, this))!;
    }

    public int FindIndex(_bd func)
    {
        return IndexOf(Find(func));
    }
    public int FindIndex(_bdi func)
    {
        return IndexOf(Find(func));
    }
    public int FindIndex(_bdiA func)
    {
        return IndexOf(Find(func));
    }

    public int FindLastIndex(_bd func)
    {
        return LastIndexOf(FindLast(func));
    }
    public int FindLastIndex(_bdi func)
    {
        return LastIndexOf(FindLast(func));
    }
    public int FindLastIndex(_bdiA func)
    {
        return LastIndexOf(FindLast(func));
    }
}