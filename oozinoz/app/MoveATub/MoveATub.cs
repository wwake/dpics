using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using UserInterface;

 /// <summary>
    /// This class is partially refactored, with a method for each
    /// control. The next step will be to create a mediator class,
    /// factoring the action logic out of this class.
    /// </summary>
public class MoveATub : Form
{
    private static Hashtable _tubMachine;
    private Label _machineLabel;
    private ListView _machineList;
    private ListViewItem _selectedMachine;
    private Label _tubLabel;
    private ListView _tubList;
    private ListViewItem _selectedTub;
    private Button _assignButton;
    private IList _boxes;
    private static Size IMAGE_SIZE = new Size(40, 40);
    private UI _ui = UI.NORMAL;
    /// <summary>
    /// Instantiating this app kicks of GUI layout and initialization.
    /// </summary>
    public MoveATub()
    {
        Font = _ui.Font;
        ClientSize = new Size(920, 334);
        foreach (Control c in Boxes()) 
        {
            Controls.Add(c);
            c.MouseHover += new  System.EventHandler(HoverBox);
        }
        Controls.AddRange(new Control[] {                                                        
                                            MachineList(), 
                                            TubList(),
                                            TubLabel(),
                                            AssignButton(),
                                            MachineLabel()});
        Text = "Move a Tub";
        foreach (string s in MachineNames())
        {
            MachineList().Items.Add(new ListViewItem(s, 0));
        }
    }
    // This is a temporary approach that has hard-coded literals
    // but avoids organizing the group boxes with docking.
    private IList Boxes()
    {
        if (_boxes == null) 
        {
            Size BOX_SIZE = new Size(152, 80);
            _boxes = new ArrayList();
            _boxes.Add(CreateBox("Mixer-2201", new Point(24, 24), BOX_SIZE));
            _boxes.Add(CreateBox("Mixer-2202", new Point(24, 128), BOX_SIZE));  
            _boxes.Add(CreateBox("Fuser-2101", new Point(24, 232), BOX_SIZE));
            _boxes.Add(CreateBox("StarPress-2401", new Point(200, 24), BOX_SIZE));    
            _boxes.Add(CreateBox("StarPress-2402", new Point(200, 128), BOX_SIZE));
            _boxes.Add(CreateBox("Assembler-2301", new Point(200, 232), BOX_SIZE));
        }
        return _boxes;
    }
    private ListView MachineList()
    {
        if (_machineList == null)
        {
            _machineList = _ui.CreateListView(IMAGE_SIZE, UI.GetImage("machine.png"));
            _machineList.View = View.Details;
            _machineList.Location = new Point(650, 72);
            _machineList.Size = new Size(240, 164);
            _machineList.SelectedIndexChanged += 
                new System.EventHandler(SelectChanged);
        }
        return _machineList;
    }
    private Label TubLabel()
    {  
        if (_tubLabel == null) 
        {
            _tubLabel = new Label();
            _tubLabel.Location = new Point(384, 24);
            _tubLabel.Size = new Size(100, 32);
            _tubLabel.Text = "Tubs";
        }
        return _tubLabel;  
    }
    private Label MachineLabel() 
    {
        if (_machineLabel == null) 
        {
            _machineLabel = new Label();
            _machineLabel.Location = new Point(608, 24);
            _machineLabel.Size = new Size(128, 32);
            _machineLabel.Text = "Machines";
        }
        return _machineLabel;
    }
    private ListView TubList ()
    {
        if (_tubList == null) 
        {
            _tubList = _ui.CreateListView(IMAGE_SIZE, UI.GetImage("tub.png"));
            _tubList.Scrollable = true;
            _tubList.Location = new Point(384, 72);
            _tubList.Size = new Size(190, 164);
            _tubList.SelectedIndexChanged += new System.EventHandler(SelectChanged);
            _tubList.MultiSelect = false;
        }
        return _tubList;
    }
    private Button AssignButton() 
    {
        if (_assignButton == null) 
        {
            _assignButton = new Button();
            _assignButton.Enabled = false;
            _assignButton.Location = new Point(590, 104);
            _assignButton.Size = new Size(40, 48);
            _assignButton.Text = ">";
            _assignButton.Click += new System.EventHandler(AssignClick);
        }
        return _assignButton;
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main() 
    {
        Application.Run(new MoveATub());
    }
    // initialize list of machine names
    private static IList MachineNames()
    {
        return new string[]{
                               "Mixer-2201",
                               "Mixer-2202",
                               "StarPress-2401",
                               "StarPress-2402",
                               "Assembler-2301",
                               "Fuser-2101"};
    }
    // initialize hash table of tubs at machines
    private static Hashtable TubMachine()
    {
        if (_tubMachine == null) 
        {
            _tubMachine = new Hashtable();
            _tubMachine["T502"] = "Mixer-2201";
            _tubMachine["T503"] = "Mixer-2201";
            _tubMachine["T504"] = "Mixer-2201";
            _tubMachine["T101"] = "StarPress-2402";
            _tubMachine["T102"] = "StarPress-2402";
        }
        return _tubMachine;
    } 
    // find tubs at a machine
    private static IList TubNames(string machineName)
    {
        ArrayList al = new ArrayList();
        IDictionaryEnumerator e = TubMachine().GetEnumerator();
        while (e.MoveNext()) 
        {
            if(e.Value.Equals(machineName))
            {
                al.Add(e.Key);
            }
        }
        return al;
    }

    /// <summary>
    /// When the mouse hovers over the calling control, unbold all
    /// the group box texts, and bold the text of the calling
    /// group box. Also, change the tub list to show the tubs that
    /// are at the machine that the hovered-over group box represents.
    /// </summary>
    /// <param name="sender">the hovered-over group box</param>
    /// <param name="e">ignored</param>
    private void HoverBox(object sender, EventArgs e)
    {
        foreach (Control x in Boxes()) 
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
        TubList().Items.Clear();
        foreach (string s in TubNames(machineName)) 
        {
            TubList().Items.Add(new ListViewItem(s, 0));
        } 
    }
    /// <summary>
    /// When the user selects a tub or machine, enable the "assign"
    /// button if both lists have an item selected.
    /// </summary>
    /// <param name="sender">ignored</param>
    /// <param name="e">ignored</param>
    private void SelectChanged(object sender, EventArgs e)
    { 
        ListView lv = (ListView) sender;
        ListView.SelectedListViewItemCollection c = lv.SelectedItems;
     
        foreach (ListViewItem i in lv.Items)
        {  
            if (c.Contains(i)) 
            {
                i.BackColor = SystemColors.Highlight;
                i.ForeColor = SystemColors.HighlightText;
                if (sender.Equals(MachineList())) _selectedMachine = i;
                if (sender.Equals(TubList())) _selectedTub = i;
            }
            else
            {
                i.BackColor = Color.Empty; 
                i.ForeColor = Color.Empty;
            }
        }
        AssignButton().Enabled = 
            MachineList().SelectedItems.Count > 0 && 
            TubList().SelectedItems.Count > 0;
    }
    /// <summary>
    /// Move the selected tub to selected machine.
    /// </summary>
    /// <param name="sender">ignored, but it's presumably the assign button</param>
    /// <param name="e">ignored</param>
    private void AssignClick(object sender, EventArgs e)
    {
        if (_selectedMachine == null || _selectedTub == null) return;
        string tubName = _selectedTub.Text;
        string fromMachineName = (string) TubMachine()[tubName];
        string toMachineName = _selectedMachine.Text;
        TubMachine()[tubName] = toMachineName;
        UpdateTubList(fromMachineName);
        AssignButton().Enabled = false;
    }
    // a little utility that builds a group box
    private static GroupBox CreateBox(string text, Point p, Size s)
    {
        GroupBox gb = new GroupBox();
        gb.Text = text;
        gb.Location = p;
        gb.Size = s;
        return gb;
    }
}