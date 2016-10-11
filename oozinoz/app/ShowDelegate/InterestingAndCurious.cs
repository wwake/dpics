using System;

public delegate void ChangeHandler();

/// <summary>
/// The Observer chapter uses this class, which wiggles sometimes.
/// </summary>
class Interesting
{
    // Observe that Change and Change2 are both instance variables whose
    // type is the ChangeHandler delegate type. The only difference is that
    // Change2 is marked as an event.
    public ChangeHandler Change;
    public event ChangeHandler Change2;
    public void Wiggle()
    {
        if (Change != null) Change();
        if (Change2 != null) Change2();
    }
}
/// <summary>
/// The Observer chapter uses this class to show how a client
/// can register for callbacks when an interesting class changes.
/// </summary>
class Curious
{
    public Curious(Interesting i)
    {
        i.Change += new ChangeHandler(React);
    }
    public void React()
    {
        Console.WriteLine("Something happened!");
    }
}