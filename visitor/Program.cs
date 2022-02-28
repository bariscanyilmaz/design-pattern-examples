
var components = new List<IComponent>{
    new ConcreteComponentA(),
    new ConcreteComponentB()

};

Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
var visitor1 = new ConcreteVisitor1();
Client.ClientCode(components, visitor1);

Console.WriteLine("It allows the same client code to work with different types of visitors:");
var visitor2 = new ConcreteVisitor2();
Client.ClientCode(components, visitor2);


public interface IComponent
{
    void Accept(IVisitor visitor);
}

public class ConcreteComponentA : IComponent
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteComponentA(this);
    }

    public string ExclusiveMethodOfConcreteComonentA() => "A";

}

public class ConcreteComponentB : IComponent
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteComponentB(this);
    }

    public string ExclusiveMethodOfConcreteComonentB() => "B";

}

public interface IVisitor
{
    void VisitConcreteComponentA(ConcreteComponentA element);
    void VisitConcreteComponentB(ConcreteComponentB element);
}

class ConcreteVisitor1 : IVisitor
{
    public void VisitConcreteComponentA(ConcreteComponentA element)
    {
        System.Console.WriteLine(element.ExclusiveMethodOfConcreteComonentA() + " ConcreteVisitor1");
    }

    public void VisitConcreteComponentB(ConcreteComponentB element)
    {
        System.Console.WriteLine(element.ExclusiveMethodOfConcreteComonentB() + " ConcreteVisitor1");
    }
}

class ConcreteVisitor2 : IVisitor
{
    public void VisitConcreteComponentA(ConcreteComponentA element)
    {
        System.Console.WriteLine(element.ExclusiveMethodOfConcreteComonentA() + " ConcreteVisitor2");
    }

    public void VisitConcreteComponentB(ConcreteComponentB element)
    {
        System.Console.WriteLine(element.ExclusiveMethodOfConcreteComonentB() + " ConcreteVisitor2");
    }
}

public class Client
{
    public static void ClientCode(List<IComponent> components, IVisitor visitor)
    {
        foreach (var component in components)
        {
            component.Accept(visitor);
        }
    }
}










