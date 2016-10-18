using System;
using System.Windows.Forms;
using System.Drawing;

   /// <summary>
    /// This class handles the actions for a MoveATub application object.
    /// </summary>
public class MoveATubMediator
{
    private MoveATub2 _gui;
    private String _selectedMachineName;
    private String _selectedTubName;

    /// <summary>
    /// Create a mediator for the given MoveATub application.
    /// </summary>
    /// <param name="gui">the application object</param>
    public MoveATubMediator(MoveATub2 gui)
    {
        _gui = gui;
    }

    /// <summary>
    /// When the mouse hovers over the calling control, unbold all
    /// the group box texts, and bold the text of the calling
    /// group box. Also, change the tub list to show the tubs that
    /// are at the machine that the hovered-over group box represents.
    /// </summary>
    /// <param name="sender">the hovered-over group box</param>
    /// <param name="e">ignored</param>
    internal void HoverBox(object sender, EventArgs e)
    {
        foreach (Control x in _gui.Boxes()) 
        {
            if (x.Font.Bold) 
            {
                x.Font = new Font(x.Font, FontStyle.Regular);
            }
        }
        Control c = (Control)sender;
        c.Font = new Font(c.Font, c.Font.Style | FontStyle.Bold);

        UpdateTubList(c.Text);
    }

    // make the tub list show the tubs at the selected machine
    private void UpdateTubList(string machineName)
    {
        _gui.TubList().Items.Clear();
        foreach (string s in NameBase.TubNames(machineName)) 
        {
            _gui.TubList().Items.Add(new ListViewItem(s, 0));
        } 
    }

    /// <summary>
    /// Move the selected tub to selected machine.
    /// </summary>
    /// <param name="sender">ignored, but it's presumably the assign button</param>
    /// <param name="e">ignored</param>
    internal void AssignClick(object sender, EventArgs e)
    {
        if (_selectedMachineName == null || _selectedTubName == null) return;
        string fromMachineName = (string) NameBase.TubMachine()[_selectedTubName];
        NameBase.TubMachine()[_selectedTubName] = _selectedMachineName;
        UpdateTubList(fromMachineName);
        _gui.AssignButton().Enabled = false;
    }

    /// <summary>
    /// When the user selects a tub or machine, enable the "assign"
    /// button if both lists have an item selected.
    /// </summary>
    /// <param name="sender">ignored</param>
    /// <param name="e">ignored</param>
    internal void SelectChanged(object sender, EventArgs e)
    { 
        ListView lv = (ListView) sender;
        ListView.SelectedListViewItemCollection c = lv.SelectedItems;
     
        foreach (ListViewItem i in lv.Items)
        {  
            if (c.Contains(i)) 
            {
                i.BackColor = SystemColors.Highlight;
                i.ForeColor = SystemColors.HighlightText;
                if (sender.Equals(_gui.MachineList())) _selectedMachineName = i.Text;
                if (sender.Equals(_gui.TubList())) _selectedTubName = i.Text;
            }
            else
            {
                i.BackColor = Color.Empty; 
                i.ForeColor = Color.Empty;
            }
        }
        _gui.AssignButton().Enabled = 
            _gui.MachineList().SelectedItems.Count > 0 && 
            _gui.TubList().SelectedItems.Count > 0;
    }
}