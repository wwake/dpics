using System;
using Functions;
using UserInterface;

/// <summary>
/// This subclass of PlotPanel registers for "Change" events that come
/// from a TpeakFunction.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Create an alert plot panel.
    /// </summary>
    /// <param name="nPoint">the number of points to plot</param>
    /// <param name="tf">the function to plot</param>
    public AlertPlotPanel(int nPoint, TpeakFunction tf) : 
        base (nPoint, new Function(tf.F))
    {
        tf.Change += new EventHandler(FunctionChange);
    }
    private void FunctionChange(object sender, EventArgs e)
    {
        Refresh();
    }
}