using System;
using System.Windows.Forms;
namespace UserInterface
{
    /// <summary>
    /// This class just shows that a class can easily provide a Copy()
    /// method; However, as implemented in this class the method is
    /// far too dangerous, because of the many instance variables that
    /// GroupBox inherits.
    /// </summary>
    public class OzGroupBox : GroupBox
    {
        // dangerous!
        public OzGroupBox Copy()
        {
            return (OzGroupBox) this.MemberwiseClone();
        }
        public OzGroupBox Copy2()
        {
            OzGroupBox gb = new OzGroupBox();
            gb.BackColor = BackColor;
            gb.Dock = Dock;
            gb.Font = Font;
            gb.ForeColor = ForeColor;
            return gb;
        }
    }
}
