namespace Dyndata;
// Arr: Constructors 
// (empty, from any IEnumerable or from parameter list)

public partial class Arr
{
    public Arr() { }

    public Arr(IEnumerable items)
    {
        foreach (var item in items) { Push(item); }
    }

    public Arr(params dynamic[] items)
    {
        foreach (var item in items)
        {
            Push(item);
        }
    }
}