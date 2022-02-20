new ImageEditor().Run();

class ImageEditor{
    private CompoundGraphic _all;
    public ImageEditor()
    {
        _all=new CompoundGraphic();

        _all.Add(new Dot(0,0));
        _all.Add(new Dot(1,2));
        _all.Add(new Dot(2,3));
        _all.Add(new Dot(4,5));

        _all.Add(new Circle(8,8,2));
        _all.Add(new Circle(10,10,1));
    }

    public void Run(){
        _all.Draw();
    }


}

interface IGraphic
{
    void Move(int x, int y);
    void Draw();

}

class Dot : IGraphic
{
    protected int X, Y;

    public Dot(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }


    public virtual void Draw()
    {
        Console.WriteLine($"Draw dot at {X},{Y}");
    }

    public virtual void Move(int x, int y)
    {
        this.X += x;
        this.Y += y;
    }
}

class Circle : Dot
{
    protected int Radius;
    public Circle(int x, int y, int radius) : base(x, y)
    {
        this.Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Cricle at {this.X} and {this.Y} with radius {this.Radius}");
    }


}

class CompoundGraphic : IGraphic
{
    protected List<IGraphic> Children;

    public CompoundGraphic()
    {
        Children=new List<IGraphic>();
    }


    public void Add(IGraphic child)=>Children.Add(child);
    public void Remove(IGraphic child)=>Children.Remove(child);

    public void Draw()
    {
        foreach (var item in Children)
        {
            item.Draw();
        }       
    }

    public void Move(int x, int y)
    {
        foreach (var item in Children)
        {
            item.Move(x,y);
        }       
    }
}