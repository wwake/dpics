using System;

public delegate void ChangeHandler();
/// <summary>
/// The Observer chapter uses this class briefly while refactoring to
/// MVC. This class is quickly refactored to the ValueHolder class.
/// </summary>
public class Tpeak
{
    private double _value = 0;
    public event ChangeHandler Change;

    public double Value 
    {
        get 
        { 
            return _value; 
        }
        set
        {
            _value = value;
            if (Change != null) 
            {
                Change();
            }
        }
    }
}