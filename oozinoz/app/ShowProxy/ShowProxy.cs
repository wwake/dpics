using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;
  /// <summary>	
    /// This class, along with PictureBoxProxy, shows the Proxy 
    /// pattern. But note that the text of the "Proxy" chapter 
    /// argues that this design is not strong.
	/// </summary>
public class ShowProxy : Form
{
    private Button _button;
    private Panel _buttonPanel;
    private UI _ui;
    private PictureBoxProxy _pictureProxy; 
    private static readonly String IMAGE_ABSENT = "absent.gif";
    private static readonly String IMAGE_FEST   = "fest.gif";
    /// <summary>
    /// Add controls to this application.
    /// </summary>
    public ShowProxy(UI ui)
    {
        _ui = ui;
        Text = "Show Proxy";
        Controls.Add(PictureBoxProxy());
        Controls.Add(ButtonPanel()); 
    }

    private Panel ButtonPanel()
    {
        if (_buttonPanel == null)
        {
            _buttonPanel = new Panel();
            _buttonPanel.Dock = DockStyle.Bottom;
            _buttonPanel.Controls.Add(Button());
        }
        return _buttonPanel;
    }
	 
    private Button Button ()
    {
        if (_button == null)
        {
            _button = _ui.CreateButtonOk();  
            _button.Dock = DockStyle.Right;
            _button.Text = "Test";
            _button.Click += new System.EventHandler(LoadImage);
        }
        return _button;
    }
    private PictureBoxProxy PictureBoxProxy ()
    {
        if (_pictureProxy == null) 
        {
            PictureBox under = new PictureBox();
            under.Image = UI.GetImage(IMAGE_ABSENT);
            _pictureProxy = new PictureBoxProxy(under, IMAGE_FEST);
            _pictureProxy.Dock = DockStyle.Fill;
        }
        return _pictureProxy;
    } 

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main() 
    {
        Application.Run(new ShowProxy(UI.NORMAL));
    }

    // Clicking the button loads the new, large image,
    // and resizes the application area.
    private void LoadImage(object sender, System.EventArgs e)
    {
        _pictureProxy.Load();
        int w = _pictureProxy.Image.Width;
        int h = _pictureProxy.Image.Height;
        ClientSize = new Size(w, h + _button.Height);
        _button.Enabled = false;
        Refresh();
    }
}