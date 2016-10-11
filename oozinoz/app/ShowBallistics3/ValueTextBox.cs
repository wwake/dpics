using System;
using System.Windows.Forms;

/// <summary>
/// A text box that watches and displays a Tpeak object's value.
/// </summary>
public class ValueTextBox : TextBox
{
    private Tpeak _tPeak;
    public ValueTextBox(Tpeak valueHolder)
    {
        _tPeak = valueHolder;
        _tPeak.Change += new ChangeHandler(ValueChange);
    }
    private void ValueChange()
    {
        Text = _tPeak.Value.ToString();
    }
}