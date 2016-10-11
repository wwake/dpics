using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using UserInterface;
 /// <summary>
    /// This class contains just the GUI elements of the MoveATub 
    /// application. GUI control interaction has been refactored out into
    /// MoveATubMediator.
    /// </summary>
public class MoveATub2 : Form
{
    private Label _machineLabel;
    private ListView _machineList;
    private Label _tubLabel;
    private ListView _tubList;
    private Button _assignButton;
    private MoveATubMediator _mediator; 
    private IList _boxes;
    private static Size IMAGE_SIZE = new Size(40, 40);
    private UI _ui = UI.NORMAL;

    public MoveATub2()
    {
        _mediator = new MoveATubMediator(this);
        Font = _ui.Font;
        ClientSize = new Size(920, 334);
        foreach (Control c in Boxes()) 
        {
            Controls.Add(c);
            c.MouseHover += new  System.EventHandler(_mediator.HoverBox);
        }
        Controls.AddRange(new Control[] {                                                        
                                            MachineList(), 
                                            TubList(),
                                            TubLabel(),
                                            AssignButton(),
                                            MachineLabel()});
        Text = "Move a Tub";
        foreach (string s in NameBase.MachineNames())
        {
            MachineList().Items.Add(new ListViewItem(s, 0));
        }
    }
    // This is a temporary approach that has hard-coded literals
    // but avoids organizing the group boxes with docking.
    internal IList Boxes()
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
    internal ListView MachineList()
    {
        if (_machineList == null)
        {
            _machineList = _ui.CreateListView(IMAGE_SIZE, UI.GetImage("machine.png"));
            _machineList.View = View.Details;
            _machineList.Location = new Point(660, 72);
            _machineList.Size = new Size(242, 164);
            _machineList.SelectedIndexChanged += 
                new System.EventHandler(_mediator.SelectChanged);
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
    internal ListView TubList ()
    {
        if (_tubList == null) 
        {
            _tubList = _ui.CreateListView(IMAGE_SIZE, UI.GetImage("tub.png"));
            _tubList.Scrollable = true;
            _tubList.Location = new Point(384, 72);
            _tubList.Size = new Size(200, 164);
            _tubList.SelectedIndexChanged += new System.EventHandler(_mediator.SelectChanged);
            _tubList.MultiSelect = false;
        }
        return _tubList;
    }
    internal Button AssignButton() 
    {
        if (_assignButton == null) 
        {
            _assignButton = new Button();
            _assignButton.Enabled = false;
            _assignButton.Location = new Point(600, 104);
            _assignButton.Size = new Size(40, 48);
            _assignButton.Text = ">";
            _assignButton.Click += new System.EventHandler(_mediator.AssignClick);
        }
        return _assignButton;
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main() 
    {
        Application.Run(new MoveATub2());
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