namespace car_factory;

public interface IWheelFactory<out T> : IFactory<T> where T : IWheel
{
}

public class StampedWheel : IWheel
{
    private readonly int _weight;
    private readonly double _diameter;

    public StampedWheel(int weight, double diameter)
    {
        _weight = weight;
        _diameter = diameter;
    }

    public int Weight()
    {
        return _weight;
    }

    public double Diameter()
    {
        return _diameter;
    }
    
    public override string ToString()
    {
        return $"{nameof(StampedWheel)}: {_diameter}";
    }
}

public class StampedWheelFactory : IWheelFactory<StampedWheel>
{
    private readonly int _weight;
    private readonly double _diameter;

    public StampedWheelFactory(int weight, double diameter)
    {
        _weight = weight;
        _diameter = diameter;
    }

    public StampedWheel Manufacture()
    {
        return new StampedWheel(_weight, _diameter);
    }
}