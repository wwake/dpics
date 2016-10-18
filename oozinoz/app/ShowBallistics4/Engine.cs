using System;

/// <summary>
/// A demo class for the Observer chapter. The role of this class
/// is to hold a property (namely a peak time property) that a GUI
/// applications wants to watch.
/// </summary>
class Engine
{
    private double _tPeak;

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
}