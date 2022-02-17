

//Run 
new Client().Main();




//Abstract Products
public interface IChair
{
    bool HasLegs();
    void SitOn();
}

public interface ISofa
{
    void LieOnSofa();
}

public interface ICoffeeTable
{
    void PutYourCoffee();
}


//Concrete Products
public class VictorianChair : IChair
{
    public bool HasLegs() => true;
    public void SitOn() => Console.WriteLine("Sit on Victorian Chair");
}

public class VictorianCoffeeTable : ICoffeeTable
{
    public void PutYourCoffee() => Console.WriteLine("Put your Coffee on Victiorian Coffee Table");
}


public class VictorianSofa : ISofa
{
    public void LieOnSofa() => Console.WriteLine("Lie on Victorian Sofa");
}


public class ModernChair : IChair
{
    public bool HasLegs() => true;
    public void SitOn() => Console.WriteLine("Sit on Modern Chair");
}

public class ModernCoffeeTable : ICoffeeTable
{
    public void PutYourCoffee() => Console.WriteLine("Put your Coffee on Modern Coffee Table");
}


public class ModernSofa : ISofa
{
    public void LieOnSofa() => Console.WriteLine("Lie on Modern Sofa");
}



//Factory Methods

public interface IFurnitureFactory
{
    IChair CreateChair();
    ICoffeeTable CreateCoffeeTable();
    ISofa CreateSofa();
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new VictorianCoffeeTable();
    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }
}

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new ModernCoffeeTable();
    }

    public ISofa CreateSofa()
    {
        return new ModernSofa();
    }
}

//Test Client

class Client
{
    public void Main()
    {
        Console.WriteLine("Client:Test Modern Furniture Factory");
        ClientMethod(new ModernFurnitureFactory());
        Console.WriteLine("Client:Test Victorian Furniture Factory");
        ClientMethod(new VictorianFurnitureFactory());

    }

    public void ClientMethod(IFurnitureFactory factory)
    {
        var sofa = factory.CreateSofa();
        var chair = factory.CreateChair();
        var coffeTable = factory.CreateCoffeeTable();

        chair.SitOn();
        coffeTable.PutYourCoffee();
        sofa.LieOnSofa();
    }

}

