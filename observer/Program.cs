
var subject=new Subject();
var observerA=new ConcreteObserverA();
subject.Attach(observerA);

var observerB=new ConcreteObserverB();
subject.Attach(observerB);

subject.SomeBusinessLogic();
subject.SomeBusinessLogic();

//subject.Detach(observerB);
subject.SomeBusinessLogic();


interface IObserver
{
    void Update(ISubject subject);
}

interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

class Subject : ISubject
{

    public int State { get; set; }

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        System.Console.WriteLine("Subject: Attached an observer.");
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        System.Console.WriteLine("Subject: Detached an observer.");
    }

    public void Notify()
    {
        System.Console.WriteLine("Subject: Notifying observer...");
        _observers.ForEach((IObserver observer) => observer.Update(this));
    }

    public void SomeBusinessLogic()
    {
        System.Console.WriteLine("\nSubject:I'm doing something important.");
        State = new Random().Next(0, 10);
        System.Console.WriteLine($"Subject:My state has just changed to:{State}");
        Notify();
    }

}

class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State<3)
        {
            System.Console.WriteLine("ConcreteObserverA:Reacted to the event.");
        }
    }
}

class ConcreteObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State==0 || (subject as Subject).State>=2)
        {
            System.Console.WriteLine("ConcreteObserverB:Reacted to the event.");
        }
    }
}


