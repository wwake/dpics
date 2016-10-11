using System;
using Functions;
using UserInterface;

/// <summary>
/// This subclass of PlotPanel registers for "Change" events that come
/// from a ValueHolder object.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Create an alert plot panel.
    /// </summary>
    /// <param name="nPoint">the number of points to plot</param>
    /// <param name="tf">the function to plot</param>
    public AlertPlotPanel(int nPoint, TpeakFunction tf, Tpeak tp) : 
        base (nPoint, new Function(tf.F))
    {
        tp.Change += new ChangeHandler(FunctionChange);
    }
    private void FunctionChange()
    {
        Refresh();
    }
}