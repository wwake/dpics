using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using UserInterface;
using Functions;

/// <summary>
/// This class provides an example of Observer where a program
/// registers its interest in a slider's value. When the slider
/// moves, the program updates the affected components. We can
/// refactor this to let components independently register interest
/// in a changeable object.
/// </summary>
public class ShowBallistics : Form
{
    private int INITIAL_WIDTH = 800;
    private int INITIAL_HEIGHT = 400;
    private int NPOINT = 101; // points to plot with
    // control panel contains left control panel and slider
    private Panel _controlPanel;
    private TrackBar _slider;
    // left control panel contains lable and text box
    private Panel _leftControlPanel;
    private Label _tPeakLabel;
    private TextBox _valueTextBox;
    // upper panel contains burn rate and thrust boxes (that contain panels)
    private Panel _upperPanel;
    private Panel _burnRatePanel;
    private GroupBox _burnRateBox;
    private Panel _thrustPanel;
    private GroupBox _thrustBox;
    // functions
    private BurnRate _burnRate = new BurnRate(0);
    private Thrust _thrust = new Thrust(0);
    /// <summary>
    /// Create an instance, initializing the GUI components.
    /// </summary>
    public ShowBallistics()
    {            
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        Font = UI.NORMAL.Font;
        Controls.Add(UpperPanel());
        Controls.Add(ControlPanel());

        ClientSize = new System.Drawing.Size(INITIAL_WIDTH, INITIAL_HEIGHT);
        Text = "Effects of tPeak";
    }
    // the panel that holds the two plots
    private Panel UpperPanel() 
    {
        if (_upperPanel == null) 
        {
            _upperPanel = new Panel();
            _upperPanel.Dock = DockStyle.Fill;
            _upperPanel.DockPadding.All = UI.NORMAL.Pad;
            _upperPanel.Controls.Add(ThrustBox());
            _upperPanel.Controls.Add(BurnRateBox());
        }
        return _upperPanel;
    }	 
    // the group box that titles and contains the burn rate panel
    private GroupBox BurnRateBox()
    {
        if(_burnRateBox == null) 
        {
            _burnRateBox = UI.NORMAL.CreateGroupBox(" BurnRate", BurnRatePanel());
            // Subtle but important to dock left here; the normal pattern is
            // widget 1 docks left, then (optionally) splitter, then widget 2 
            // docks full.
            _burnRateBox.Dock = DockStyle.Left;
            _burnRateBox.Width = INITIAL_WIDTH / 2;
        }
        return _burnRateBox;
    }
    // the panel that displays the burn rate
    private Panel BurnRatePanel()
    {
        if (_burnRatePanel == null) 
        {
            _burnRatePanel = UI.NORMAL.CreatePaddedPanel(
                new PlotPanel(NPOINT, new Function(_burnRate.F)));
        }
        return _burnRatePanel;
    }
    private GroupBox ThrustBox()
    {
        if(_thrustBox == null) 
        {
            _thrustBox = UI.NORMAL.CreateGroupBox(" Thrust", ThrustPanel());
            _thrustBox.Dock = DockStyle.Fill;
        }
        return _thrustBox;
    }
    private Panel ThrustPanel()
    {
        if (_thrustPanel == null) 
        {
            _thrustPanel = UI.NORMAL.CreatePaddedPanel(
                new PlotPanel(NPOINT, new Function(_thrust.F)));
        }
        return _thrustPanel;
    }
    private Panel ControlPanel() 
    {
        if (_controlPanel == null)
        {
            _controlPanel = new Panel();
            _controlPanel.Controls.Add(Slider());
            _controlPanel.Controls.Add(LeftControlPanel());
            _controlPanel.Dock = DockStyle.Bottom;
            _controlPanel.DockPadding.All = 10;
        }
        return _controlPanel;
    }
    private Panel LeftControlPanel()
    {
        if (_leftControlPanel == null) 
        {
            _leftControlPanel = new Panel();
            _leftControlPanel.Controls.Add(TpeakLabel());
            _leftControlPanel.Controls.Add(ValueTextBox());
            _leftControlPanel.Dock = DockStyle.Left;
            _leftControlPanel.DockPadding.All = 10;
        }
        return _leftControlPanel;
    }
    private Label TpeakLabel()
    {
        if (_tPeakLabel == null) 
        {
            _tPeakLabel = new Label(); 
            _tPeakLabel.Text = "tPeak";
            _tPeakLabel.TextAlign = ContentAlignment.TopLeft;
            _tPeakLabel.Dock = DockStyle.Left;
            _tPeakLabel.Width = Font.Height / 2 * 5;
        }
        return _tPeakLabel;
    }
    private TextBox ValueTextBox()
    {
        if (_valueTextBox == null)
        {
            _valueTextBox = new TextBox(); 
            _valueTextBox.Dock = DockStyle.Right;
            _valueTextBox.TextAlign = HorizontalAlignment.Center;
            _valueTextBox.Text = "" + Slider().Minimum;
        }
        return _valueTextBox;
    }
    private TrackBar Slider() 
    {
        if (_slider == null)
        {
            _slider = new TrackBar();  
            _slider.Maximum = 100;
            _slider.Dock = DockStyle.Fill;
            _slider.TickFrequency = 5;
            _slider.Scroll += new EventHandler(SliderScroll);
        }
        return _slider;
    }
    /// <summary>
    /// Main entry point.
    /// </summary>
    static void Main() 
    {
        Application.Run(new ShowBallistics());
    }
    private void SliderScroll(object sender, EventArgs e)
    {
        double val = Slider().Value;
        double tp = (val - Slider().Minimum) / (Slider().Maximum - Slider().Minimum);
        ValueTextBox().Text = tp.ToString();
        _burnRate.Tpeak = tp;
        BurnRatePanel().Refresh();
        _thrust.Tpeak = tp;
        ThrustPanel().Refresh();
    }
    // Repaint the panel if the size changes.
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        BurnRateBox().Width = Width / 2;
        Refresh();
    }
}