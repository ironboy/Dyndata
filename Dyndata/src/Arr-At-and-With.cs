namespace Dyndata;
// Arr: At + With
public partial class Arr
{
    public dynamic At(int index)
    {
        index = index < 0 ? Length + index : index;
        index = index < 0 ? 0 : index;
        return this[index];
    }

    public Arr With(int index, dynamic element)
    {
        index = index < 0 ? Length + index : index;
        index = index < 0 ? 0 : index;
        var copy = Slice();
        copy[index] = element;
        return copy;
    }
}