/// <summary>
/// This class just supports an accessiblity exercise in 
/// "Introducing Responsibility".
/// </summary>
public class Machine
{
    protected void Unload() {}
}

/// <summary>
/// This class just supports an accessiblity exercise in 
/// "Introducing Responsibility".
/// </summary>
public class Hopper : Machine
{
    public void Show()
    {
        Hopper h = new Hopper();
        h.Unload();
        Machine m = new Machine();
        //m.Unload();
    }
}