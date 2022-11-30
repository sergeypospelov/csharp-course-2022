namespace car_factory;

public interface IBodyFactory<out T> : IFactory<T> where T : IBody
{
}

public class CoupeBody : IBody
{
    private readonly string _id;

    public CoupeBody(string id)
    {
        _id = id;
    }

    public int Weight()
    {
        return 550;
    }

    public string Id()
    {
        return _id;
    }

    public override string ToString()
    {
        return $"{nameof(CoupeBody)} {_id},";
    }
}

public class CoupeBodyFactory: IBodyFactory<CoupeBody>
{
    private int _idCounter = 0;

    public CoupeBody Manufacture()
    {
        return new CoupeBody("coupe_" + _idCounter++);
    }
}

public class SedanBody : IBody
{
    private readonly string _id;

    public SedanBody(string id)
    {
        _id = id;
    }

    public int Weight()
    {
        return 550;
    }

    public string Id()
    {
        return _id;
    }

    public override string ToString()
    {
        return $"{nameof(SedanBody)} {_id},";
    }
}

public class SedanBodyFactory : IBodyFactory<SedanBody>
{
    private int _idCounter = 0;
    
    public SedanBody Manufacture()
    {
        return new SedanBody("sedan_" + _idCounter++);
    }
}