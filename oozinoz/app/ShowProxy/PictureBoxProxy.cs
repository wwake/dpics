using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;
/// <summary>
/// This class shows the Proxy patterns; but note that the text of
/// the "Proxy" chapter argues that this design is not strong.
/// </summary>
public class PictureBoxProxy : Control
{
    private PictureBox _pictureBox;
    private string _imageName;
    private Image _image; 
    /// <summary>
    /// Create a proxy for a PictureBox object; the proxy delays loading
    /// the actual image.
    /// </summary>
    /// <param name="pictureBox">the PictureBox to proxy for</param>
    /// <param name="imageName">the name of the image</param>
    /// 
    public PictureBoxProxy(PictureBox pictureBox, string imageName)
    {
        _pictureBox = pictureBox;
        _imageName = imageName;
    }
    /// <summary>
    /// Return the underlying image.
    /// </summary>
    public Image Image 
    {
        get 
        {
            if (_image == null) 
                return _pictureBox.Image; 
            else 
                return _image;
        }
    }
    /// <summary>
    /// Incur the cost of loaded the desired image.
    /// </summary>
    public void Load() 
    {
        _image = UI.GetImage(_imageName);
    }
    protected override void OnPaint(PaintEventArgs pea) 
    {
        Graphics g = pea.Graphics;
        g.DrawImage(Image, 0, 0);
    }
}