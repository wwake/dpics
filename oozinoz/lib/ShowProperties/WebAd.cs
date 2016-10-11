/// <summary>
/// A class that might look better if it used C# properties.
/// </summary>
public class WebAd : IAdvertisement
{
    private int _id;
    private string _adCopy = "";
    public WebAd (int id) 
    {
        _id = id;
    } 
    public int GetID()
    {
        return _id;
    }
    public string GetAdCopy() 
    {
        return _adCopy;
    }
    public void SetAdCopy(string s)
    {
        _adCopy = s;
    }
}