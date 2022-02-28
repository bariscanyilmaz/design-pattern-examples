Console.WriteLine("Same client code can work with different subclasses:");

Client.ClientCode(new PDFMiner());

Console.Write("\n");

Console.WriteLine("Same client code can work with different subclasses:");
Client.ClientCode(new DOCMiner());


abstract class DataMiner
{
    public void Mine()
    {
        this.OpenFile();
        this.ExtractData();
        this.ParseData();
        this.Hook1();
        this.AnalyzeData();
        this.SendReport();
        this.Hook2();
        this.CloseFile();
    }
    protected void CloseFile()
    {
        System.Console.WriteLine("Close file");
    }
    protected void OpenFile()
    {
        Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
    }

    protected void SendReport()
    {
        Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
    }

    protected void AnalyzeData()
    {
        Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");
    }

    // These operations have to be implemented in subclasses.
    protected abstract void ExtractData();

    protected abstract void ParseData();

    // These are "hooks." Subclasses may override them, but it's not
    // mandatory since the hooks already have default (but empty)
    // implementation. Hooks provide additional extension points in some
    // crucial places of the algorithm.
    protected virtual void Hook1() { }

    protected virtual void Hook2() { }
}

class DOCMiner : DataMiner
{
    protected override void ExtractData()
    {
        System.Console.WriteLine("Extract DOC Data");
    }

    protected override void ParseData()
    {
        System.Console.WriteLine("Parse DOC Data");
    }
}

class PDFMiner : DataMiner
{
    protected override void ExtractData()
    {
        System.Console.WriteLine("Extract PDF Data");
    }

    protected override void Hook1()
    {
        Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
    }

    protected override void ParseData()
    {
        System.Console.WriteLine("Parse PDF Data");
    }
}


class Client
{
    // The client code calls the template method to execute the algorithm.
    // Client code does not have to know the concrete class of an object it
    // works with, as long as it works with objects through the interface of
    // their base class.
    public static void ClientCode(DataMiner miner)
    {
        // ...
        miner.Mine();
        // ...
    }
}