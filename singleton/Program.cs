
new Application().Run();

class Application
{
    public void Run()
    {

        Thread process1 = new Thread(() =>
        {
            TestSingleton("One");
        });

        Thread process2 = new Thread(() =>
        {
            TestSingleton("Two");
        });

        process1.Start();
        process2.Start();

        process1.Join();
        process2.Join();

    }

    public static void TestSingleton(string value)
    {
        var instance = Singleton.GetInstance(value);
        Console.WriteLine(instance.Value);
    }
}



class Singleton
{
    private static Singleton _instance;

    private static readonly object _lock = new object();

    public string Value { get; set; }

    private Singleton()
    {

    }

    public static Singleton GetInstance(string value)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }

        }

        return _instance;
    }

}