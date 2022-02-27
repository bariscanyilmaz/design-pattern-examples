using System.Text;

Originator originator = new Originator("Super-duper-super-puper-super.");
CareTaker careTaker = new CareTaker(originator);

careTaker.Backup();
originator.DoSomething();

careTaker.Backup();
originator.DoSomething();

careTaker.Backup();
originator.DoSomething();

System.Console.WriteLine();
careTaker.ShowHistory();

System.Console.WriteLine("\nClient:Now, let's rollback!\n");
careTaker.Undo();

System.Console.WriteLine("\nClient:Once more\n");
careTaker.Undo();

System.Console.WriteLine();


class Originator
{
    private string _state;
    public Originator(string state)
    {
        _state = state;
        System.Console.WriteLine($"Originator:My initial state is:{_state}");
    }

    private string GenerateRandomString(int length = 10)
    {
        string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder sb = new StringBuilder();
        while (length > 0)
        {
            sb.Append(allowedSymbols[new Random().Next(0, allowedSymbols.Length)]);
            length--;

        }

        return sb.ToString();
    }

    public IMemento Save() => new ConcreteMemento(this._state);
    public void Restore(IMemento memento)
    {
        if (!(memento is ConcreteMemento))
        {
            throw new Exception($"Unknown memento class {memento.ToString()}");
        }

        _state = memento.GetState();

        System.Console.WriteLine($"Originator:My state has changed to:{_state}");

    }

    public void DoSomething()
    {
        Console.WriteLine("Originator: I'm doing something important.");
        this._state = this.GenerateRandomString(30);
        Console.WriteLine($"Originator: and my state has changed to: {_state}");
    }
}

public interface IMemento
{
    string GetName();
    string GetState();
    DateTime GetDate();

}

class ConcreteMemento : IMemento
{
    private string _state;
    private DateTime _date;

    public ConcreteMemento(string state)
    {
        _state = state;
        _date = DateTime.Now;
    }

    public DateTime GetDate() => _date;


    public string GetName() => $"{_date}/{(_state.Substring(0, 9))}...";


    public string GetState() => _state;

}

class CareTaker
{
    private List<IMemento> _mementos = new List<IMemento>();

    private Originator _originator;

    public CareTaker(Originator originator)
    {
        _originator = originator;
    }

    public void Backup()
    {
        System.Console.WriteLine("\n Caretaker:Saving Originator's state...");

        _mementos.Add(_originator.Save());

    }

    public void Undo()
    {
        if (_mementos.Count == 0) return;

        var memento = _mementos.Last();
        _mementos.Remove(memento);
        System.Console.WriteLine($"Caretaker: Restoring state to:{memento.GetName()}");

        try
        {
            _originator.Restore(memento);
        }
        catch (System.Exception)
        {

            this.Undo();
        }

    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Here's the list of mementos:");

        foreach (var memento in this._mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }

}
