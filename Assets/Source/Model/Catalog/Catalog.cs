using System.Collections.Generic;

public abstract class Catalog<Key, Value>
{
    private readonly Dictionary<Key, Value> _catalog = new();

    public void AddPar(Key key,Value valeu)
    => _catalog.Add(key, valeu);

    public bool TryGetValue(Key key, out Value value)
    => _catalog.TryGetValue(key, out value);
}