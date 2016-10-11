using System.Windows.Forms;
using DataLayer;
using UserInterface;

/// <summary>
/// Show the effects of populating a data grid from a
/// table of rockets.
/// </summary>
public class ShowRocketsFromTable : Form
{
    public ShowRocketsFromTable()
    {  
        DataGrid g = UI.NORMAL.CreateGrid();
        g.DataSource = DataServices.CreateTable(
            "SELECT Name, Apogee, Price, Thrust FROM Rocket");
        Controls.Add(g);  
   
        Text = "Show Facade"; 
        Font = UI.NORMAL.Font;
    } 

    public static void Main()
    {
        Application.Run(new ShowRocketsFromTable());
    }
}