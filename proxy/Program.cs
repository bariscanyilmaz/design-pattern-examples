new Application().Init();


interface ThirdPartyYouTubeLib
{
    List<int> ListVideos();
    int GetVideoInfo(int id);
    void DonwloadVideo(int id);
}

class ThirdPartyYouTubeClass : ThirdPartyYouTubeLib
{
    public void DonwloadVideo(int id)
    {

    }

    public int GetVideoInfo(int id)
    {
        return 1;
    }

    public List<int> ListVideos()
    {
        return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}

class CachedYouTubeClass : ThirdPartyYouTubeLib
{
    private ThirdPartyYouTubeLib _service;
    private List<int>? _listCahce;
    private int? _videoCache;
    private bool _needReset;
    public CachedYouTubeClass(ThirdPartyYouTubeLib service)
    {
        _service = service;
        _needReset=true;
    }


    public void DonwloadVideo(int id)
    {
        if (!DonwloadExist(id) || _needReset)
        {
            _service.DonwloadVideo(id);
        }
    }

    private bool DonwloadExist(int id) => id % 2 == 0;

    public int GetVideoInfo(int id)
    {
        if (_videoCache == null || _needReset)
        {
            _videoCache = _service.GetVideoInfo(id);
        }

        return (int)_videoCache;
    }

    public List<int> ListVideos()
    {
        if (_listCahce == null || _needReset)
        {
            _listCahce = _service.ListVideos();
        }
        return _listCahce;
    }

}

class YouTubeManager{

    protected ThirdPartyYouTubeLib Service;

    public YouTubeManager(ThirdPartyYouTubeLib service)
    {
        Service=service;
    }

    public void RenderVideoPage(int id){
        var info= Service.GetVideoInfo(id);
        Console.WriteLine($"Render Vide Info: {id}");
    }

    public void RenderListPanel(){
        var list=Service.ListVideos();
        list.ForEach((int item)=>Console.WriteLine(item));
    }

    public void ReactOnUserInput(){
        RenderVideoPage(1);
        RenderListPanel();
    }
}

class Application{

    public void Init(){
        var ytService=new ThirdPartyYouTubeClass();
        var ytProxy=new CachedYouTubeClass(ytService);

        var manager=new YouTubeManager(ytProxy);
        manager.ReactOnUserInput();
    }
}
