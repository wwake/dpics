using System; 
using System.Windows.Forms;
using DataLayer;
using Fireworks;
using UserInterface;

/// <summary>
/// Show the effects of populating a data grid from a
/// list of rockets.
/// </summary>
public class ShowRocketsFromList : Form
{

    public ShowRocketsFromList()
    {
        DataGrid g = UI.NORMAL.CreateGrid();
        Controls.Add(g);     
        g.DataSource = DataServices.FindAll(typeof(Rocket));     
        Font = UI.NORMAL.Font;
        Text = "Show Manual Grid Rockets";    
    } 
    public static void Main()
    {
        Application.Run(new ShowRocketsFromList());
    }
}