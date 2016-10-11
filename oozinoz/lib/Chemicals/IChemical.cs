namespace Chemicals
{
	/// <summary>
	/// Part of the Flyweight chapter, this interface is related to 
	/// restricting the ability to create flyweights.
	/// </summary>
	public interface IChemical
    {
        string Name { get; }
        string Symbol { get; }
        double AtomicWeight { get; }
	}
}
