using System; 
/// <summary>
/// Show an interface that could, but doesn't, use
/// properties.
/// </summary>
public interface IAdvertisement
{
    int GetID();
    string GetAdCopy();
    void SetAdCopy (string text);
}