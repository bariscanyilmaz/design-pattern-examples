var component1=new Component1();
var component2=new Component2();

new ConcreteMediator(component1,component2);

System.Console.WriteLine("Client triggers operation A.");
component1.DoA();

System.Console.WriteLine();

System.Console.WriteLine("Client triggers operation D.");
component2.DoD();




interface IMediator{
    void Notify(object sender,string env);
}

class ConcreteMediator : IMediator
{
    private Component1 _component1;
    private Component2 _component2;

    public ConcreteMediator(Component1 component1,Component2 component2)
    {
        _component1=component1;
        _component1.SetMediator(this);
        _component2=component2;
        _component2.SetMediator(this);

    }

    public void Notify(object sender, string env)
    {
        if(env.Equals("A")){
            System.Console.WriteLine("Mediator reacts on A and triggers following operations:");
            _component2.DoC();
        }

        if (env.Equals("D"))
        {
            System.Console.WriteLine("Mediator reacts on D and triggers following operations:");           
            _component1.DoB();
            _component2.DoC();
        }
    }
}

class BaseComponent{
    protected IMediator _mediator;
    public BaseComponent(IMediator mediator=null)
    {
        _mediator=mediator;
    }

    public void SetMediator(IMediator mediator)=>_mediator=mediator;
}

class Component1:BaseComponent{
    public void DoA(){
        Console.WriteLine("Component 1 does A.");
        _mediator.Notify(this,"A");
    }

    public void DoB(){
        Console.WriteLine("Component 1 does B.");
        _mediator.Notify(this,"B");
    }
}

class Component2:BaseComponent{
    public void DoC(){
        System.Console.WriteLine("Component 2 does C.");
        _mediator.Notify(this,"C");
    }

    public void DoD(){
        System.Console.WriteLine("Component 2 does D.");
        _mediator.Notify(this,"D");
    }
}