/// <summary>
/// A demo that the Observer chapter uses.
/// </summary>
class ShowDelegate
{
    static void Main(string[] args)
    {
        Interesting i = new Interesting();
        Curious c = new Curious(i);
        i.Wiggle();
    }
}