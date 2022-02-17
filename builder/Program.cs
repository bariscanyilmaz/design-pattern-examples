

var builder = new HouseBuilder();
var director = new Director(builder);
director.BuildGreatHouse();
Console.WriteLine("Greate House Parts");
builder.GetResult().ListParts();
Console.WriteLine("\nMinimal House Parts");
director.BuildMinimalHouse();
builder.GetResult().ListParts();


public interface IHouseBuilder
{
    void BuildRoof();
    void BuildWalls();
    void BuildWindows();
    void BuildDoor();
    void BuildPool();
    void BuildGarage();
    void BuildTennisChord();
    void BuildGarden();
    House GetResult();
}

public class HouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public HouseBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        _house = new House();
    }

    public void BuildDoor()
    {
        _house.Add("Door");
    }

    public void BuildGarage()
    {
        _house.Add("Garage");
    }

    public void BuildGarden()
    {
        _house.Add("Garden");
    }

    public void BuildPool()
    {
        _house.Add("Pool");
    }

    public void BuildRoof()
    {
        _house.Add("Roof");
    }

    public void BuildTennisChord()
    {
        _house.Add("Tennis Chord");
    }

    public void BuildWalls()
    {
        _house.Add("Walls");
    }

    public void BuildWindows()
    {
        _house.Add("Windows");
    }

    public House GetResult()
    {
        var result = this._house;
        this.Reset();
        return result;

    }
}

public class House
{
    private List<string> _parts = new List<string>();

    public void Add(string part) => _parts.Add(part);

    public void ListParts() => _parts.ForEach((string item) => Console.WriteLine(item));

}


public class Director
{
    private IHouseBuilder _builder;

    public Director(IHouseBuilder houseBuilder)
    {
        _builder = houseBuilder;
    }



    public void BuildMinimalHouse()
    {
        _builder.BuildRoof();
        _builder.BuildWalls();
        _builder.BuildDoor();
        _builder.BuildWindows();
        _builder.BuildGarage();
    }

    public void BuildGreatHouse()
    {
        _builder.BuildDoor();
        _builder.BuildRoof();
        _builder.BuildGarage();
        _builder.BuildTennisChord();
        _builder.BuildPool();
        _builder.BuildWalls();
        _builder.BuildWindows();
    }
}





