// See https://aka.ms/new-console-template for more information

using car_factory;

var bodyFactory1 = new CoupeBodyFactory();
var bodyFactory2 = new SedanBodyFactory();

var engineFactory1 = new DieselEngineFactory();
var engineFactory2 = new ElectricEngineFactory();

var transmissionFactory1 = new AutomaticTransmissionFactory();
var transmissionFactory2 = new ManualTransmissionFactory();

var wheelFactory = new StampedWheelFactory(10, 28.7);

var teslaFactory = new CarFactory("Tesla", bodyFactory1, engineFactory2, transmissionFactory1, wheelFactory);
var bmwFactory = new CarFactory("Bmw", bodyFactory2, engineFactory1, transmissionFactory2, wheelFactory);
var mercedesFactory = new CarFactory("Mercedes", bodyFactory2, engineFactory1, transmissionFactory1, wheelFactory);

var tesla1 = teslaFactory.Manufacture();
Console.Out.WriteLine(tesla1);

var bmw1 = bmwFactory.Manufacture();
Console.Out.WriteLine(bmw1);

var mercedes1 = mercedesFactory.Manufacture();
Console.Out.WriteLine(mercedes1);

var tesla2 = teslaFactory.Manufacture();
Console.Out.WriteLine(tesla2);

var bmw2 = bmwFactory.Manufacture();
Console.Out.WriteLine(bmw2);

var mercedes2 = mercedesFactory.Manufacture();
Console.Out.WriteLine(mercedes2);
