using System;

   /// <summary>
    /// This abstract class defines a function that depends not only
    /// on time, but also on "tPeak," the time at which the burn area
    /// and burn rate of a solid rocket peaks.
    /// </summary>
public abstract class TpeakFunction
{
    private double _tPeak;

    /// <summary>
    /// Create a function that depends on a tPeak value.
    /// </summary>
    /// <param name="tPeak">initial value</param>
    public TpeakFunction(double tPeak)
    {
        Tpeak = tPeak;
    }

    /// <summary>
    /// The value of tPeak, the point at which the burn area and
    /// burn rate are at a maximum.
    /// </summary>
    public double Tpeak 
    {
        get 
        {
            return _tPeak;
        }
        set
        {
            _tPeak = value;
        }
    }

    /// <summary>
    /// The function for concrete subclasses to fill in.
    /// </summary>
    /// <param name="t">parameterized time</param>
    /// <returns>the function value</returns>
    public abstract double F(double t);
}

    /// <summary>
    /// The burn rate for a rocket is a chemical equation (from
    /// the Observer chapter.) This class also provides an example
    /// of how to provide a standard function of (just) time when
    /// the equation depends on a second parameter, tPeak. 
    /// We have want to use a delegate (called Function) that 
    /// expects a signature with just one double, but the burn
    /// rate function depends on both time and tPeak. So, we store
    /// tPeak as an instance variable that the burn rate function
    /// references. See "ShowBallistics" for an example of 
    /// instantiating a delegate with an object reference.
    /// </summary>
public class BurnRate : TpeakFunction
{
    /// <summary>
    /// Create a burn rate object.
    /// </summary>
    /// <param name="tPeak">initial value</param>
    public BurnRate(double tPeak) : base(tPeak)
    {
    }

    /// <summary>
    /// Burn rate as a function of time.
    /// </summary>
    /// <param name="t">Time (goes 0 to 1 as fuel burns)</param>
    /// <returns>Burn Rate</returns>
    public override double F(double t) 
    {
        return F(t, Tpeak);
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
    /// <summary>
    /// Create a thrust object.
    /// </summary>
    /// <param name="tPeak">initial value</param>
    public Thrust(double tPeak) : base(tPeak)
    {
    }

    /// <summary>
    /// Thrust as a function of time.
    /// </summary>
    /// <param name="t">Time (goes 0 to 1 as fuel burns)</param>
    /// <returns>Thrust</returns>
    public override double F(double t) 
    {
        return F(t, Tpeak);
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