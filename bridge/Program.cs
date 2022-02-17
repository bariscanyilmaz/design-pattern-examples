new Application().Run();



class Application
{
    public void Run()
    {
        var tv=new TV();
        var remote=new RemoteControl(tv);

        remote.ToggelPower();
        Console.WriteLine(tv.IsEnabled);
        remote.VolumeUp();
        Console.WriteLine(tv.Volume);


        var radio=new Radio();
        var advancedRemote=new AdvancedRemoteControl(radio);
        advancedRemote.ToggelPower();
        Console.WriteLine(radio.IsEnabled);
        advancedRemote.VolumeUp();
        Console.WriteLine(radio.Volume);
        advancedRemote.Mute();
        Console.WriteLine(radio.Volume);
    }
}





interface IDevice
{
    bool IsEnabled { get; set; }
    int Volume { get; set; }
    int Channel { get; set; }
}

class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice device) => _device = device;

    public void ToggelPower() => _device.IsEnabled = !_device.IsEnabled;

    public void VolumeDown() => _device.Volume -= 10;
    public void VolumeUp() => _device.Volume += 10;
    public void ChannelDown() => _device.Channel -= 1;
    public void ChannelUp() => _device.Channel += 1;
}

class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device)
    {

    }

    public void Mute() => _device.Volume = 0;
}

class TV : IDevice
{
    public bool IsEnabled { get; set; }
    public int Volume { get; set; }
    public int Channel { get; set; }
}

class Radio : IDevice
{
    public bool IsEnabled { get; set; }
    public int Volume { get; set; }
    public int Channel { get; set; }
}