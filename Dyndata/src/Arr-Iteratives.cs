namespace Dyndata;
// Arr: Basic iterative methods:
// Foreach, Map And Filter

public partial class Arr
{
    public void ForEach(_vd func)
    {
        memory.ForEach(x => func(x));
    }
    public void ForEach(_vdi func)
    {
        var i = 0;
        memory.ForEach(x => func(x, i++));
    }
    public void ForEach(_vdiA func)
    {
        var i = 0;
        memory.ForEach(x => func(x, i++, this));
    }

    public Arr Map(_dd func)
    {
        return new Arr(memory.Select(x => func(x)));
    }
    public Arr Map(_ddi func)
    {
        return new Arr(memory.Select((x, i) => func(x, i)));
    }
    public Arr Map(_ddiA func)
    {
        return new Arr(memory.Select((x, i) => func(x, i, this)));
    }

    public Arr Filter(_bd func)
    {
        return new Arr(memory.Where(x => func(x)));
    }
    public Arr Filter(_bdi func)
    {
        return new Arr(memory.Where((x, i) => func(x, i)));
    }
    public Arr Filter(_bdiA func)
    {
        return new Arr(memory.Where((x, i) => func(x, i, this)));
    }
}