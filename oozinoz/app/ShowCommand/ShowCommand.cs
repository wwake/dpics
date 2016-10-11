using System;
using System.Windows.Forms;

/// <summary>
/// Show how to compose a menu (and show the Command pattern
/// at work.)
/// </summary>
public class ShowCommand : Form
{
    public ShowCommand()
    {
        MenuItem exitItem = new MenuItem();
        exitItem.Text = "Exit";
        exitItem.Click += new EventHandler(ExitApp);

        MenuItem fileItem = new MenuItem();
        fileItem.Text = "File";
        fileItem.MenuItems.Add(exitItem);
 
        Menu = new MainMenu();
        Menu.MenuItems.Add(fileItem);
        Text = "Show Command";
    }
 
    static void Main() 
    {
        Application.Run(new ShowCommand());
    }

    private void ExitApp(object o, EventArgs e)
    {
        Application.Exit();            
    }
}