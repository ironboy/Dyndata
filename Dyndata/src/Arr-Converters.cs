namespace Dyndata;
// Arr: Converters
// (convert ToString/JSON, ToArray and ToList)

public partial class Arr
{
    public override String ToString()
    {
        return JSON.Stringify(this, true);
    }

    public List<object> ToList()
    {
        return memory.ToList();
    }

    public dynamic[] ToArray()
    {
        return memory.ToArray();
    }
}