
var game = new Game();
game.AddCommand(new FireCommand(new Vector3(0, 0, 3)));
game.AddCommand(new FireCommand(new Vector3(3, 4, 5)));
game.AddCommand(new MoveCommand(new Vector3(-1, -1, -3)));
game.AddCommand(new JumpCommand());

game.Play();

System.Console.WriteLine("Rewind Game");

game.Rewind();




class Game
{

    private List<ICommand> _commands;
    public Game()
    {
        _commands = new List<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void Play()
    {
        _commands.ForEach((ICommand command) => command.Execute());
    }

    public void Rewind()
    {
        (_commands as IEnumerable<ICommand>).Reverse().ToList().ForEach((ICommand command) => command.Execute());

    }
}





interface ICommand
{
    void Execute();
}

struct Vector3
{
    public Vector3(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }
}

class MoveCommand : ICommand
{
    private Vector3 _dir;
    public MoveCommand(Vector3 dir)
    {
        _dir = dir;
    }
    public void Execute()
    {
        Console.WriteLine($"Move To X:{_dir.X} Y:{_dir.Y} Z:{_dir.Z}");
    }
}

class JumpCommand : ICommand
{
    public void Execute()
    {
        System.Console.WriteLine("Jump");
    }
}

class FireCommand : ICommand
{
    private Vector3 _target;
    public FireCommand(Vector3 target)
    {
        _target = target;
    }
    public void Execute()
    {
        System.Console.WriteLine($"Fire To X:{_target.X} Y:{_target.Y} Z:{_target.Z}");
    }
}