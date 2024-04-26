namespace Dyndata;
// Arr: Flat - flatten an array up to a certain depth

public partial class Arr
{
    private static Arr FlatRecurse(
        Arr org, long depth, long currentDepth = 1
    )
    {
        var a = new Arr();
        var hasSubArray = false;
        for (var i = 0; i < org.Length; i++)
        {
            if (org[i] is Arr && depth >= 1)
            {
                hasSubArray = true;
                foreach (var item in org[i])
                {
                    a.Push(item);
                }
            }
            else
            {
                a.Push(org[i]);
            }
        }
        if (currentDepth < depth && hasSubArray)
        {
            a = FlatRecurse(a, depth, currentDepth + 1);
        }
        return a;
    }

    public Arr Flat(long depth = 1)
    {
        return FlatRecurse(this, depth);
    }
}