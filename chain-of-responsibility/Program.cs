var monkey = new MonkeyHandler();
var squirrel = new SquirrelHandler();
var dog = new DogHandler();

monkey.SetNext(squirrel).SetNext(dog);

System.Console.WriteLine("Chain: Monkey > Squirrel > Dog \n");
Client.ClientCode(monkey);
System.Console.WriteLine();

interface IHandler
{
    IHandler SetNext(IHandler handler);
    object Handle(object request);
}

abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;


    public virtual object Handle(object request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        else
        {
            return null;
        }
    }

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }
}

class MonkeyHandler : AbstractHandler
{

    public override object Handle(object request)
    {
        if ((request as string).Equals("Banana"))
        {
            return $"Monkey:I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class SquirrelHandler : AbstractHandler
{

    public override object Handle(object request)
    {
        if ((request as string).Equals("Nut"))
        {
            return $"Squirrel:I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class DogHandler : AbstractHandler
{

    public override object Handle(object request)
    {
        if ((request as string).Equals("MeatBall"))
        {
            return $"Monkey:I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class Client
{
    public static void ClientCode(AbstractHandler handler)
    {
        foreach (var food in new List<string>() { "Nut", "Banana", "Cup of Coffe" })
        {
            Console.WriteLine($"Client:Who wants a {food}?");

            var result = handler.Handle(food);
            if (result != null)
            {
                Console.WriteLine($" {result}");
            }
            else
            {
                Console.WriteLine($" {food} was left untouched.");
            }


        }
    }
}

