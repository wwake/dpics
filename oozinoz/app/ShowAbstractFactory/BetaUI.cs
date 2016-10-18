using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

/// <summary>
/// Shows an Abstract Factory where a GUI kit can introduce a small change
/// to look-and-feel.
/// </summary>
public class BetaUI : UI
{        
    public BetaUI ()
    {
        Font f = Font;
        _font = new Font(f, f.Style ^ FontStyle.Italic);
    }

    /// <summary>
    /// Create a standard Ok! (or affirmation) button.
    /// </summary>
    /// <returns>a standard Ok! (or affirmation) button</returns>
    public override Button CreateButtonOk()
    {
        Button b = base.CreateButtonOk();
        b.Image = GetImage("cherry-large.gif");
        return b;
    }
    
    /// <summary>
    /// Create a standard Cancel! (or negation) button.
    /// </summary>
    /// <returns>a standard Cancel! (or negation) button</returns>
    public override Button CreateButtonCancel()
    {
        Button b = base.CreateButtonCancel();
        b.Image = GetImage("cherry-large-down.gif");
        return b;
    }
}