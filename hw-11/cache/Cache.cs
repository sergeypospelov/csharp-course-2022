namespace cache;

public class Cache<TKey, TValue> where TValue : IDisposable where TKey : notnull
{
    private readonly int _maxSize;
    private readonly int _maxUseTime;

    private class CacheNode
    {
        public TValue Value { get; }
        public int LastUsed { get; set; }

        public CacheNode(TValue value, int lastUsed)
        {
            Value = value;
            LastUsed = lastUsed;
        }
    }

    private Dictionary<TKey, CacheNode> _cache = new();
    private int _timer = 0;

    public Cache(int maxSize = 5, int maxUseTime = 3)
    {
        if (maxSize < maxUseTime)
        {
            throw new ArgumentException("maxSize should not be less than maxUseTime, because it's meaningless");
        }

        _maxUseTime = maxUseTime;
        _maxSize = maxSize;
    }

    ~Cache()
    {
        Console.Out.WriteLine("Now GC will clear everything...\n");
        ClearAll();
    }

    private void ClearAll()
    {
        foreach (var (key, value) in _cache)
        {
            value.Value.Dispose();
        }
        _cache.Clear();
    }

    public TValue? this[TKey k]
    {
        get
        {
            if (_cache.ContainsKey(k))
            {
                _cache[k].LastUsed = _timer++;
                return _cache[k].Value;
            }

            return default;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_cache.ContainsKey(k))
            {
                _cache[k].LastUsed = _timer++;
                return;
            }

            if (_cache.Count + 1 > _maxSize)
            {
                Clear();
            }

            _cache.Add(k, new CacheNode(value, _timer++));
        }
    }

    private void Clear()
    {
        var valuesForRemoving = _cache
            .Where(kv => kv.Value.LastUsed + _maxUseTime <= _timer)
            .ToList();
        
        foreach (var keyValuePair in valuesForRemoving)
        {
            keyValuePair.Value.Value.Dispose();
            _cache.Remove(keyValuePair.Key);
        }
    }
}