
new Application().Run();

class Application
{
    public void Run()
    {

        var hole = new RoundHole(5);
        var rpeg = new RoundPeg(10);
        Console.WriteLine(hole.Fits(rpeg));//returns false

        var small_sqpeg = new SquarePeg(5);
        var large_sqpeg = new SquarePeg(10);

        var small_adapter = new SquarePegAdapter(small_sqpeg);
        var large_adapter = new SquarePegAdapter(large_sqpeg);

        Console.WriteLine(hole.Fits(small_adapter));//True
        Console.WriteLine(hole.Fits(large_adapter));//False

    }
}

interface IRoundPeg
{
    double GetRadius();
}

class RoundHole
{
    public double Radius { get; private set; }

    public RoundHole(double radius)
    {
        Radius = radius;
    }

    public bool Fits(IRoundPeg peg) => Radius >= peg.GetRadius();

}

class RoundPeg : IRoundPeg
{
    private double _radius;

    public RoundPeg(double radius) => _radius = radius;

    public double GetRadius() => _radius;

}

class SquarePeg
{
    public double Width { get; private set; }

    public SquarePeg(double width) => Width = width;
}


class SquarePegAdapter : IRoundPeg
{
    private SquarePeg _peg;
    public SquarePegAdapter(SquarePeg peg) => _peg = peg;

    public double GetRadius() => _peg.Width * Math.Sqrt(2) / 2;

}