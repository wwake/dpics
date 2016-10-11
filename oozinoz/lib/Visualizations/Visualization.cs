using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

namespace Visualizations
{
    /// <summary>
    /// This class provides a visualization of a factory that contains
    /// machines and through which material flows. At present the only
    /// functionality is the ability to create and drag machines. In the
    /// future we'll add operational modeling functions.
    /// </summary>
    public class Visualization : Form
    {
        protected UI _ui;
        protected Panel _machinePanel;
        protected Panel _buttonPanel;
        protected Button _addButton;
        protected Button _undoButton;         
        protected Image _image = UI.GetImage("machine.png"); 
        protected FactoryModel _factoryModel = new FactoryModel();
        protected VisMediator _mediator; 

        /// <summary>
        /// Create a new visualization of a simulated factory.
        /// </summary>
        public Visualization(UI ui)
        { 
            _ui = ui;
            _factoryModel.AddEvent += new AddHandler(HandleAdd);
            _factoryModel.DragEvent += new DragHandler(HandleDrag);
            _factoryModel.RebuildEvent += new RebuildHandler(HandleUndo);
            _mediator = new VisMediator(_factoryModel);
            Controls.Add(MachinePanel());
            Controls.Add(ButtonPanel());
            Text = "Operational Model";
        } 

        // the panel on which we'll drag around machines
        protected Panel MachinePanel()
        {
            if (_machinePanel == null)
            {
                _machinePanel = new Panel();
                _machinePanel.BackColor = Color.White;            
                _machinePanel.Dock = DockStyle.Fill;
            }
            return _machinePanel;
        }
	 
        // the panel that holds the app's buttons
        protected Panel ButtonPanel()
        {
            if (_buttonPanel == null) 
            {
                _buttonPanel = new Panel();
                _buttonPanel.Controls.Add(AddButton());
                _buttonPanel.Controls.Add(UndoButton());
                _buttonPanel.Dock = DockStyle.Bottom;
                _buttonPanel.Height = (int)(AddButton().Height * 1.10);
            }
            return _buttonPanel;
        }

        // the "Add" button
        protected Button AddButton()
        {
            if (_addButton == null)
            {
                _addButton = _ui.CreateButtonOk();
                _addButton.Dock = DockStyle.Left;
                _addButton.Text = "Add";
                _addButton.Click += new System.EventHandler(_mediator.Add);
            }
            return _addButton;
        }

        // the "Undo" button
        protected Button UndoButton()
        {
            if (_undoButton == null)
            {
                _undoButton = _ui.CreateButtonCancel();
                _undoButton.Dock = DockStyle.Right;
                _undoButton.Text = "Undo";
                _undoButton.Click += new System.EventHandler(_mediator.Undo);
                _undoButton.Enabled = false;
            }
            return _undoButton;
        }


        // Add a new machine at the given location
        protected void HandleAdd(Point p)
        {
            PictureBox pb = CreatePictureBox(p);
            MachinePanel().Controls.Add(pb);
            pb.BringToFront();
            UndoButton().Enabled = true;
        }

        // Dragging a machine brings it to the front of the controls
        // in the machine panel, and updates the machine's location         
        protected void HandleDrag(Point oldP, Point newP)
        { 
            foreach (PictureBox pb in MachinePanel().Controls)
            {
                if (pb.Location.Equals(newP)) 
                {
                    pb.BringToFront();
                    return;
                } 
            }
        }

        // When the user clicks Undo, we rebuild the factory
        // from the model.
        protected void HandleUndo()
        { 
            MachinePanel().Controls.Clear();      
            foreach (Point p in _factoryModel.Locations)
            {   
                MachinePanel().Controls.Add(CreatePictureBox(p));
            }       
            UndoButton().Enabled = _factoryModel.MementoCount > 1;
        }

        // Create a standard picture of a machine
        protected PictureBox CreatePictureBox(Point p)
        { 
            PictureBox pb = new PictureBox();
            pb.Image = _image;
            pb.Size = _image.Size; 
            pb.MouseDown += new MouseEventHandler(_mediator.MouseDown); 
            pb.MouseMove += new MouseEventHandler(_mediator.MouseMove);
            pb.MouseUp   += new MouseEventHandler(_mediator.MouseUp);
            pb.Location = p; 
            return pb;
        }
    }
}