using System;
using System.Windows.Forms;

/// <summary>
/// This version of TpeakFunction keeps track of a slider.
/// </summary>
public abstract class TpeakFunction
{
    private double _tPeak;
    private TrackBar _slider;
    public event EventHandler Change;

    /// <summary>
    /// Create a function that will update itself and notify
    /// listeners when a slider moves.
    /// </summary>
    /// <param name="tPeak">an initial value for the tPeak</param>
    /// <param name="slider">the slider to watch</param>
    public TpeakFunction(double tPeak, TrackBar slider)
    {
        Tpeak = tPeak;
        _slider = slider;
        slider.Scroll += new EventHandler(SliderScroll);
    }
    public double Tpeak 
    {
        get 
        {
            return _tPeak;
        }
        set
        {
            _tPeak = value;
            if (Change != null) 
            {
                Change(this, EventArgs.Empty);
            }
        }
    }
    private void SliderScroll(object sender, EventArgs e)
    {
        double val = _slider.Value;
        Tpeak = (val - _slider.Minimum) / (_slider.Maximum - _slider.Minimum);
    }
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
    public BurnRate(double tPeak, TrackBar slider) : base(tPeak, slider)
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
    public Thrust(double tPeak, TrackBar slider) : base(tPeak, slider)
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