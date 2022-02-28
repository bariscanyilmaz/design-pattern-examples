using System.Text;

var context=new Context();
System.Console.WriteLine("Client:Strategy is set to normal sorting.");
context.SetStrategy(new ConcreteStrategyA());
context.DoSomeBusinessLogic();

System.Console.WriteLine("Client:Strategy is set to reverse sorting");
context.SetStrategy(new ConcreteStrategyB());
context.DoSomeBusinessLogic();

class Context
{
    private IStrategy _strategy;
    public Context()
    {

    }

    public Context(IStrategy strategy) => _strategy = strategy;


    public void SetStrategy(IStrategy strategy) => _strategy = strategy;


    public void DoSomeBusinessLogic()
    {
        System.Console.WriteLine("Context:Sorting data using the strategy ()");
        var result=_strategy.DoSomething(new List<string>(){"a","b","c","d","e"});
        StringBuilder sb=new StringBuilder();

        foreach (var element in (result as List<string>))
        {
            sb.Append(element);
        }

        System.Console.WriteLine(sb.ToString());
    }
}

interface IStrategy
{
    object DoSomething(object data);

}

class ConcreteStrategyA : IStrategy
{
    public object DoSomething(object data)
    {
        var list = data as List<string>;
        list.Sort();
        return list;
    }
}

class ConcreteStrategyB : IStrategy
{
    public object DoSomething(object data)
    {
        var list = data as List<string>;
        list.Sort();
        list.Reverse();
        return list;
    }
}


