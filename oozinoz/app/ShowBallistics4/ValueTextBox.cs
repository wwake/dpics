using System;
using System.Windows.Forms;

/// <summary>
/// A text box that watches and displays a ValueHolder object's value.
/// </summary>
public class ValueTextBox : TextBox
{
    private PropertyHolder _ph;
    public ValueTextBox(PropertyHolder ph)
    {
        _ph = ph;
        _ph.Change += new ChangeHandler(PropertyChange);
    }
    private void PropertyChange()
    {
        Text = _ph.Value.ToString();
    }
}