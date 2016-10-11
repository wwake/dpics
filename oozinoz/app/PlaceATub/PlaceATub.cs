using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

namespace rubadub
{
    /// <summary>
    /// Show an application that acts as a mediator.
    /// </summary>
    public class PlaceATub : Form
    {
        private TextBox _textBox;
        private Panel _buttonPanel;
        private Button _button;
        private ListBox _listBox;

        /// <summary>
        /// This constructor creates and lays out the GUI.
        /// </summary>
        public PlaceATub()
        {
            Font = UI.NORMAL.Font;
            Controls.Add(ListBox());
            Controls.Add(ButtonPanel());
            Controls.Add(TextBox());
            Text = "Place a Tub";
        }
        private TextBox TextBox()
        {
            if (_textBox == null) 
            {
                _textBox = new TextBox();
                _textBox.Dock = DockStyle.Top;
                _textBox.TabIndex = 1;
                _textBox.Text = "T230502";
            }
            return _textBox;
        }
        private ListBox ListBox() 
        {
            if (_listBox == null) 
            {
                _listBox = new ListBox();
                _listBox.Dock = DockStyle.Fill;
                _listBox.TabIndex = 2;
                _listBox.Items.AddRange(MachineList());
            }
            return _listBox;
        }
        private Panel ButtonPanel()
        {
            if (_buttonPanel == null) 
            {
                _buttonPanel = new Panel();
                _buttonPanel.Controls.Add(Button());
                _buttonPanel.Dock = DockStyle.Bottom;
                _buttonPanel.DockPadding.All = UI.NORMAL.Pad;
                _buttonPanel.Height = Font.Height * 2;
                _buttonPanel.TabIndex = 3;
            }
            return _buttonPanel;
        }
        private Button Button()
        {
            if (_button == null) 
            {
                _button = new Button();
                _button.Dock = DockStyle.Right;
                _button.TabIndex = 3;
                _button.Text = "Ok";
                _button.Click += new EventHandler(AssignTub);
            }
            return _button;
        }

        // In a real application, we would update the relevant business objects 
        // and probably post changes to a data base.
        private void AssignTub(object sender, EventArgs args)
        {
            Application.Exit();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            Application.Run(new PlaceATub());
        }
        private static string[] MachineList()
        {
            return new string[]{
                "Mixer-2201",
                "Mixer-2202",
                "StarPress-2401",
                "StarPress-2402",
                "ShellAssembler-2301",
                "Fuser-2101"};
        }
    }
}
