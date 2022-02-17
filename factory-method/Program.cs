// See https://aka.ms/new-console-template for more information

var client = new Client();
client.Main();


abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public string DoOperation()
    {
        var product = FactoryMethod();

        return "Creator:The same creator's code has just worked with" + product.Operation();
    }

}

public interface IProduct
{
    string Operation();
}

class TruckCreator : Creator
{
    public override IProduct FactoryMethod()
    {
        return new TruckProduct();
    }
}

class ShipCreator : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ShipProduct();
    }
}

class TruckProduct : IProduct
{
    public string Operation()
    {
        return "{Result of TruckProduct}";
    }
}
class ShipProduct : IProduct
{
    public string Operation()
    {
        return "{Result of ShipProduct}";
    }
}

class Client
{
    public void Main()
    {
        Console.WriteLine("App:Launched with TruckCreator");
        ClientCode(new TruckCreator());

        Console.WriteLine("App:Launched with ShipCreator");
        ClientCode(new ShipCreator());
    }

    public void ClientCode(Creator creator)
    {
        Console.WriteLine($"Client:I'm not aware of the creator's class, but still works. \n {creator.DoOperation()}");
    }
}






