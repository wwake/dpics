using System;
using System.Windows.Forms;

/// <summary>
/// This version of TpeakFunction depends on a ValueHolder object instead
/// of a slider.
/// </summary>
public abstract class TpeakFunction
{
    protected PropertyHolder _ph;

    /// <summary>
    /// Create a function that depends on a peak value.
    /// </summary>
    /// <param name="tPeak">an initial value for the tPeak</param>
    public TpeakFunction(PropertyHolder ph)
    {
        _ph = ph;
    }

    public abstract double F(double t);
}

/// <summary>
/// This is the MVC version of BurnRate.
/// </summary>
public class BurnRate : TpeakFunction
{
    public BurnRate(PropertyHolder ph) : base(ph)
    {
    }

    /// <summary>
    /// Burn rate as a function of time.
    /// </summary>
    /// <param name="t">Time (goes 0 to 1 as fuel burns)</param>
    /// <returns>Burn Rate</returns>
    public override double F(double t) 
    {
        return F(t, (double) _ph.Value);
    }

    /// <summary>
    /// Burn rate as a function of time and tPeak.
    /// </summary>
    /// <param name="t">Time</param>
    /// <param name="tPeak">tPeak (when burn area maximizes)</param>
    /// <returns>Burn rate</returns>
    public static double F(double t, double tPeak)
    {
        return .5 * Math.Pow(25, -Math.Pow((t - tPeak), 2));
    }
}
/// <summary>
/// The thrust for a rocket is a chemical equation (from
/// the Observer chapter.)
/// </summary>
public class Thrust : TpeakFunction
{
    public Thrust(PropertyHolder ph) : base(ph)
    {
    }

    /// <summary>
    /// Thrust as a function of time.
    /// </summary>
    /// <param name="t">Time (goes 0 to 1 as fuel burns)</param>
    /// <returns>Thrust</returns>
    public override double F(double t) 
    {
        return F(t, (double) _ph.Value);
    }

    /// <summary>
    /// Thrust as a function of time and tPeak.
    /// </summary>
    /// <param name="t">Time</param>
    /// <param name="tPeak">tPeak (when burn area maximizes)</param>
    /// <returns>Thrust</returns>
    public static double F(double t, double tPeak) 
    {
        return 1.7 * Math.Pow((BurnRate.F(t, tPeak) / .6), (1 / .3));
    }
}