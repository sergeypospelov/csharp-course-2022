
using NUnit.Framework;

namespace barber;

public class BarberTests
{
    [Test]
    public void TestOne()
    {
        var barber = new Barber(1);
        
        var customer1 = new Customer(0, 100);
        var success1 = barber.NewCustomer(customer1);
        Assert.IsTrue(success1);
        
        Thread.Sleep(10);

        var customer2 = new Customer(1, 100);
        var success2 = barber.NewCustomer(customer2);
        Assert.IsTrue(success2);
        
        Thread.Sleep(10);

        var customer3 = new Customer(2, 100);
        var success3 = barber.NewCustomer(customer3);
        Assert.IsFalse(success3);
        
        barber.Close();
    }
    
    [Test]
    public void TestWaitSucceeds()
    {
        var barber = new Barber(2);
        
        var customer1 = new Customer(0, 100);
        var success1 = barber.NewCustomer(customer1);
        Assert.IsTrue(success1);
        
        Thread.Sleep(10);

        var customer2 = new Customer(1, 100);
        var success2 = barber.NewCustomer(customer2);
        Assert.IsTrue(success2);
        
        Thread.Sleep(10);

        var customer3 = new Customer(2, 100);
        var success3 = barber.NewCustomer(customer3);
        Assert.IsTrue(success3);
        
        barber.Close();
    }
}