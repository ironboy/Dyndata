namespace Dyndata;
// Arr: Reduce methods

public partial class Arr
{
    public dynamic Reduce(_ddd func)
    {
        return memory.Aggregate((a, c) => func(a, c));
    }
    public dynamic Reduce(_dddi func)
    {
        var i = 0;
        return memory.Aggregate((a, c) => func(a, c, i++));
    }
    public dynamic Reduce(_dddiA func)
    {
        var i = 0;
        return memory.Aggregate((a, c) => func(a, c, i++, this));
    }

    public dynamic Reduce(_ddd func, object initVal)
    {
        return memory.Aggregate(initVal, (a, c) => func(a, c));
    }
    public dynamic Reduce(_dddi func, object initVal)
    {
        var i = 0;
        return memory.Aggregate(initVal, (a, c) => func(a, c, i++));
    }
    public dynamic Reduce(_dddiA func, object initVal)
    {
        var i = 0;
        return memory.Aggregate(initVal, (a, c) => func(a, c, i++, this));
    }

    public dynamic ReduceRight(_ddd func)
    {
        return Rrh().Aggregate((a, c) => func(a, c));
    }
    public dynamic ReduceReduceRight(_dddi func)
    {
        var i = Length;
        return Rrh().Aggregate((a, c) => func(a, c, --i));
    }
    public dynamic ReduceRight(_dddiA func)
    {
        var i = Length;
        return Rrh().Aggregate((a, c) => func(a, c, i++, this));
    }

    public dynamic ReduceRight(_ddd func, object initVal)
    {
        return Rrh().Aggregate(initVal, (a, c) => func(a, c));
    }
    public dynamic ReduceRight(_dddi func, object initVal)
    {
        var i = Length;
        return Rrh().Aggregate(initVal, (a, c) => func(a, c, --i));
    }
    public dynamic ReduceRight(_dddiA func, object initVal)
    {
        var i = Length;
        return Rrh().Aggregate(initVal, (a, c) => func(a, c, --i, this));
    }
}