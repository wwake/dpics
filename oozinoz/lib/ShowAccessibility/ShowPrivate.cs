/// <summary>
/// This class just supports an accessibility exercise in 
/// "Introducing Responsibility".
/// </summary>
public class Firework
{
    private double price = 0;
    private double compare(Firework f) 
    {
        return price - f.price;
    }
}