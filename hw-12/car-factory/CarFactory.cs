namespace car_factory;

public class Car
{
    public readonly String Model;

    public readonly IBody Body;
    public readonly IEngine Engine;
    public readonly ITransmission Transmission;
    public readonly IWheel Wheel;
    public readonly int TotalWeight;

    public Car(string model, IBody body, IEngine engine, ITransmission transmission, IWheel wheel)
    {
        Model = model;
        Body = body;
        Engine = engine;
        Transmission = transmission;
        Wheel = wheel;

        TotalWeight = body.Weight() + engine.Weight() + transmission.Weight() + 4 * wheel.Weight();
    }
    
    
    public override string ToString()
    {
        return $"{nameof(Model)}: {Model}\n{nameof(Body)}: {Body}\n{nameof(Engine)}: {Engine}\n{nameof(Transmission)}: {Transmission}\n{nameof(Wheel)}: {Wheel}\n{nameof(TotalWeight)}: {TotalWeight}\n";
    }

}

public class CarFactory : IFactory<Car>
{
    public readonly string ModelName;

    private readonly IBodyFactory<IBody> _bodyFactory;
    private readonly IEngineFactory<IEngine> _engineFactory;
    private readonly ITransmissionFactory<ITransmission> _transmissionFactory;
    private readonly IWheelFactory<IWheel> _wheelFactory;

    public CarFactory(string modelName, IBodyFactory<IBody> bodyFactory, IEngineFactory<IEngine> engineFactory,
        ITransmissionFactory<ITransmission> transmissionFactory, IWheelFactory<IWheel> wheelFactory)
    {
        ModelName = modelName;
        _bodyFactory = bodyFactory;
        _engineFactory = engineFactory;
        _transmissionFactory = transmissionFactory;
        _wheelFactory = wheelFactory;
    }

    public Car Manufacture()
    {
        var model = ModelName;
        var body = _bodyFactory.Manufacture();
        var engine = _engineFactory.Manufacture();
        var transmission = _transmissionFactory.Manufacture();
        var wheel = _wheelFactory.Manufacture();
        return new Car(model, body, engine, transmission, wheel);
    }
}