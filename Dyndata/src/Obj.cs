namespace Dyndata;
// Obj: A dynamic object

public partial class Obj : DynamicObject
{

    private readonly Dictionary<string, object> memory = [];

    private dynamic GetValue(string key)
    {
        return memory.TryGetValue(key, out object value) ? value : null;
    }

    public Obj() { }

    public Obj(object source)
    {
        Merge(source);
    }

    public dynamic this[string key]
    {
        get { return GetValue(key); }
        set { memory[key] = Utils.TryToObjOrArr(value); }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        result = GetValue(binder.Name);
        return true;
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        var key = binder.Name;
        memory[key] = Utils.TryToObjOrArr(value!);
        return true;
    }

    public bool Delete(string key)
    {
        memory.Remove(key);
        return true;
    }

    public bool HasKey(string key)
    {
        return memory.ContainsKey(key);
    }

    public Arr GetKeys()
    {
        return new Arr(memory.Keys.ToArray());
    }

    public Arr GetValues()
    {
        return new Arr(memory.Values.ToArray());
    }

    public Arr GetEntries()
    {
        var arr = new Arr();
        var values = GetValues();
        GetKeys().ForEach((key, i) =>
            arr.Push(new Arr(key, values[i])));
        return arr;
    }

    public override string[] GetDynamicMemberNames()
    {
        return memory.Keys.ToArray();
    }

    public override string ToString()
    {
        return JSON.Stringify(memory, true);
    }
}