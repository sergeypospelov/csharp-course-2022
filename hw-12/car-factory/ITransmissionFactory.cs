namespace car_factory;

public interface ITransmissionFactory<out T> : IFactory<T> where T : ITransmission
{
}

public class AutomaticTransmission : ITransmission
{
    public int Weight()
    {
        return 300;
    }

    public ITransmission.TransmissionType Type()
    {
        return ITransmission.TransmissionType.Automatic;
    }

    public override string ToString()
    {
        return $"{Type()}";
    }
}

public class AutomaticTransmissionFactory : ITransmissionFactory<AutomaticTransmission>
{
    public AutomaticTransmission Manufacture()
    {
        return new AutomaticTransmission();
    }
}

public class ManualTransmission6Gears : ITransmission
{
    public readonly int Gears = 6;
    
    public int Weight()
    {
        return 400;
    }

    public ITransmission.TransmissionType Type()
    {
        return ITransmission.TransmissionType.Manual;
    }

    public override string ToString()
    {
        return $"{Type()} [Gears: {Gears}]";
    }
}

public class ManualTransmissionFactory : ITransmissionFactory<ManualTransmission6Gears>
{
    public ManualTransmission6Gears Manufacture()
    {
        return new ManualTransmission6Gears();
    }
}