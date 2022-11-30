namespace car_factory;

public interface IEngineFactory<out T> : IFactory<T> where T : IEngine
{
    
}

public class DieselEngine : IEngine
{
    public int Weight()
    {
        return 350;
    }

    public int Hp()
    {
        return 180;
    }

    public override string ToString()
    {
        return $"{nameof(DieselEngine)} [{Hp()}], ";
    }
}

public class DieselEngineFactory : IEngineFactory<DieselEngine>
{
    public DieselEngine Manufacture()
    {
        return new DieselEngine();
    }
}

public class ElectricEngine : IEngine
{
    public int Weight()
    {
        return 250;
    }

    public int Hp()
    {
        return 300;
    }

    public override string ToString()
    {
        return $"{nameof(ElectricEngine)} [{Hp()}], ";
    }
}

public class ElectricEngineFactory : IEngineFactory<ElectricEngine>
{
    public ElectricEngine Manufacture()
    {
        return new ElectricEngine();
    }
}