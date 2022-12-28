class ConcurrentArray
{
    private Dictionary<int, List<int>> _v2a = new();
    
    private int _version = 0;
    private object _lock = new();
    private readonly Random _rng = new();

    private Dictionary<int, int> _v2usages = new();

    public ConcurrentArray(List<int> array)
    {
        _v2usages.Add(_version, 1);
        _v2a.Add(_version, array);
    }

    private int VersionIn()
    {
        int version;
        
        lock (_lock)
        {
            version = _version;
            _v2usages[_version]++;
        }

        return version;
    }

    private void VersionOut(int version)
    {
        lock (_lock)
        {
            _v2usages[version]--;

            if (_v2usages[version] == 0)
            {
                _v2usages.Remove(version);
                _v2a.Remove(version);
            }
        }
    }
    
    private void VersionUpdate(int oldVersion, List<int> copy)
    {
        VersionOut(oldVersion);

        int version;
        lock (_lock)
        {
            version = _version;
            _version++;
            _v2a.Add(_version, copy);
            _v2usages.Add(_version, 1);
        }
        VersionOut(version);
    }

    

    public float ComputeAverage()
    {
        int version = VersionIn();

        int sum = 0;
        _v2a[version].ForEach(it => sum += it);
        int len = _v2a[version].Count;

        VersionOut(version);

        return (float)sum / len;
    }

    public int ComputeMin()
    {
        int version = VersionIn();

        int min = int.MaxValue;
        _v2a[version].ForEach(it => min = Math.Min(min, it));

        VersionOut(version);

        return min;
    }

    public void Sort()
    {
        int version = VersionIn();

        var copy = _v2a[version].ToList();
        copy.Sort();
        
        VersionUpdate(version, copy);
    }

    public void Swap()
    {
        int version = VersionIn();

        var copy = _v2a[version].ToList();
        int x = _rng.Next(copy.Count);
        int y = _rng.Next(copy.Count);
        
        (copy[x], copy[y]) = (copy[y], copy[x]);
        
        VersionUpdate(version, copy);
    }
}