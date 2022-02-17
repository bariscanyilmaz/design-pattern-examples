
new Application().Run();

class Application
{
    private List<Shape> _shapes = new List<Shape>();

    public Application()
    {
        var circle = new Circle();
        circle.Color = "Black";
        circle.X = 0;
        circle.Y = 0;
        circle.Radius = 10;

        _shapes.Add(circle);


        var bigCircle = (Circle)circle.Clone();
        bigCircle.Radius = 30;
        bigCircle.Color = "Red";
        _shapes.Add(bigCircle);


        var rectangle = new Rectangle();
        rectangle.Width = 10;
        rectangle.Height = 10;
        rectangle.Color = "Pink";
        _shapes.Add(rectangle);

        var smallRectangle = (Rectangle)rectangle.Clone();
        smallRectangle.Height = 2;
        smallRectangle.Width = 2;
        smallRectangle.Color = "Yellow";

        _shapes.Add(smallRectangle);



    }

    public void Run()
    {
        _shapes.ForEach((Shape item) => item.DisplayData());
    }


}




public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Color { get; set; }

    public Shape()
    {

    }

    public Shape(Shape source)
    {
        Color = source.Color;
        X = source.X;
        Y = source.Y;
    }

    public abstract Shape Clone();
    public abstract void DisplayData();
}


public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle()
    {

    }

    public Rectangle(Rectangle source) : base(source)
    {
        Width = source.Width;
        Height = source.Height;
    }

    public override Shape Clone()
    {
        return new Rectangle(this);
    }

    public override void DisplayData()
    {
        Console.WriteLine($"Rectangle Color:{this.Color}, X:{this.X}, Y:{this.Y}, Width:{this.Width}, Height:{this.Height} ");
    }
}



public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle()
    {

    }

    public Circle(Circle source) : base(source)
    {
        Radius = source.Radius;
    }

    public override Shape Clone()
    {
        return new Circle(this);
    }

    public override void DisplayData()
    {
        Console.WriteLine($"Circle Color:{this.Color}, X:{this.X}, Y:{this.Y}, Radius:{this.Radius}");
    }
}




