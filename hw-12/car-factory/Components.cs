namespace car_factory;

public interface IComponent
{
    int Weight();
}
public interface IBody : IComponent
{
    public String Id();
}

public interface IEngine : IComponent
{
    public int Hp();
}

public interface ITransmission : IComponent
{
    public enum TransmissionType
    {
        Automatic,
        Manual,
        Variator
    }

    public TransmissionType Type();
}

public interface IWheel : IComponent
{
    public double Diameter();
}