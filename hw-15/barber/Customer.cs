namespace barber;

public class Customer
{
    public readonly int Id;
    public readonly int TimeToCut;

    public Customer(int id, int timeToCut)
    {
        Id = id;
        TimeToCut = timeToCut;
    }
}