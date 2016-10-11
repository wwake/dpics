using System;
using System.Windows.Forms;

/// <summary>
/// A text box that watches and displays a slider's value.
/// </summary>
public class ValueTextBox : TextBox
{
    private TrackBar _slider;
    public ValueTextBox(TrackBar slider)
    {
        _slider = slider;
        _slider.Scroll += new EventHandler(SliderScroll);
    }
    private void SliderScroll(object sender, EventArgs e)
    {
        double val = _slider.Value;
        double tp = (val - _slider.Minimum) / (_slider.Maximum - _slider.Minimum);
        Text = tp.ToString();
    }
}