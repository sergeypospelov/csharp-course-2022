class Tree
{
    private int _maxSize;
    private readonly List<int> l;
    private readonly List<int> r;

    public Tree(int maxSize)
    {
        this._maxSize = maxSize;
        this.l = Enumerable.Repeat(-1, maxSize).ToList();
        this.r = Enumerable.Repeat(-1, maxSize).ToList();
    }
    
    public void AddVertex(int u, int lChild, int rChild)
    {
        l[u] = lChild;
        r[u] = rChild;
    }

    public static Tree? FromString(string str)
    {
        var splits = str.Split("\n");

        if (splits.Length != 3)
        {
            return null;
        }

        var success = int.TryParse(splits[0], out var maxSize);

        if (!success)
        {
            return null;
        }
        
        var ls = splits[1].Split(" ");
        var rs = splits[2].Split(" ");

        if (ls.Length != maxSize || rs.Length != maxSize)
        {
            return null;
        }

        var tree = new Tree(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            success = int.TryParse(ls[i], out var l);
            success &= int.TryParse(rs[i], out var r);

            if (!success)
            {
                return null;
            }
            
            tree.AddVertex(i, l, r);
        }

        return tree;
    }

    public override string ToString()
    {
        return $"{_maxSize}\n{string.Join(" ", l)}\n{string.Join(" ", r)}";
    }
}