namespace Dyndata;
// Obj: A dynamic object
// The merge method

public partial class Obj
{
    public void Merge(params object[] sources)
    {
        foreach (dynamic source in sources)
        {
            var keys = new Arr();
            var values = new Arr();
            if (source is Obj)
            {
                foreach (var key in source.GetKeys())
                {
                    keys.Push(key);
                    values.Push((object)source[key]);
                }
            }
            else
            {
                foreach (var prop in source.GetType().GetProperties())
                {
                    keys.Push(prop.Name);
                    values.Push((object)prop.GetValue(source));
                }
            }

            foreach (string key in keys)
            {
                if (key.StartsWith("___"))
                {
                    Merge(values.Shift());
                }
                else
                {
                    memory[key] = Utils.TryToObjOrArr(values.Shift());
                }
            }
        }
    }
}