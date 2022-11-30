namespace car_factory;

public interface IFactory<out T>
{
    public T Manufacture();
}