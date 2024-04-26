namespace Dyndata;
// Arr: Some and Every methods

public partial class Arr
{
    public bool Some(_bd func)
    {
        return memory.Any(x => func(x));
    }
    public bool Some(_bdi func)
    {
        var i = 0;
        return memory.Any(x => func(x, i++));
    }
    public bool Some(_bdiA func)
    {
        var i = 0;
        return memory.Any(x => func(x, i++, this));
    }

    public bool Every(_bd func)
    {
        return memory.All(x => func(x));
    }
    public bool Every(_bdi func)
    {
        var i = 0;
        return memory.All(x => func(x, i++));
    }
    public bool Every(_bdiA func)
    {
        var i = 0;
        return memory.All(x => func(x, i++, this));
    }
}