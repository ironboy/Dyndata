namespace Dyndata;
// Arr: IEnumarable implementation
// (so that Arr behaves like a enumerable)

public partial class Arr : IEnumerable<object>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<dynamic> GetEnumerator()
    {
        return new ArrEnum(memory.ToArray());
    }
}
public class ArrEnum : IEnumerator<object>
{
    public dynamic[] _arr;

    public void Dispose() { _arr = null!; }

    int position = -1;

    public ArrEnum(dynamic[] list)
    {
        _arr = list;
    }

    public bool MoveNext()
    {
        position++;
        return position < _arr.Length;
    }

    public void Reset()
    {
        position = -1;
    }

    dynamic IEnumerator.Current
    {
        get { return Current!; }
    }

    public dynamic Current
    {
        get
        {
            try { return _arr[position]; }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}