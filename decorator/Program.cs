
new Application().Run();

class Application{
    private IDataSource _source;
    public void Run(){
        _source=new FileDataSource("file.txt");
        _source.WriteData("data");

        _source=new EncryptionDecorator(_source);
        _source.WriteData("data");

        _source=new CompressionDecorator(_source);
        _source.WriteData("data");
    
    }
}


interface  IDataSource{
    void WriteData(string data);
    string ReadData();
}

class FileDataSource : IDataSource
{
    public FileDataSource(string fileName){

    }

    public string ReadData()
    {
        return "Read Data from File Data Source";
    }

    public void WriteData(string data)
    {
        Console.WriteLine("Write Data");
    }
}

class DataSourceDecorator : IDataSource
{
    protected IDataSource wrappee;
    public DataSourceDecorator(IDataSource source)
    {
        wrappee=source;
    }

    public string ReadData()
    {
        return wrappee.ReadData();
    }

    public void WriteData(string data)
    {
        wrappee.WriteData(data);
    }
}

class EncryptionDecorator : IDataSource
{
    protected IDataSource wrappee;
    public EncryptionDecorator(IDataSource source)
    {
        wrappee=source;
    }

    public string ReadData()
    {
        return wrappee.ReadData();
    }

    public void WriteData(string data)
    {
        wrappee.WriteData(data);
    }
}

class CompressionDecorator : IDataSource
{
    protected IDataSource wrappee;
    public CompressionDecorator(IDataSource source)
    {
        wrappee=source;
    }

    public string ReadData()
    {
        return wrappee.ReadData();
    }

    public void WriteData(string data)
    {
        wrappee.WriteData(data);
    }
}