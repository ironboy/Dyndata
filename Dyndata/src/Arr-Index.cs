namespace Dyndata;
// Arr: Index - make it possible to use indexes
public partial class Arr
{
    public dynamic this[int index]
    {
        get
        {
            return index >= 0 && index < Length ?
                memory[index] : null!;
        }
        set
        {
            if (index < 0) { return; }
            while (index >= Length) { Push(null!); }
            memory[index] = Utils.TryToObjOrArr(value);
        }
    }
}