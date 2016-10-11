using System;
using System.Collections;
using System.Windows.Forms;
using UserInterface;

namespace Visualizations
{
    /// <summary>
    /// This version of the visualization adds a menu that
    /// provides for saving and restoring mememtos from a file.
    /// </summary>
    public class Visualization2 : Visualization
    {
        public Visualization2(UI ui) : base (ui)
        {
            Menu = ApplicationMenu();
        }
        protected MainMenu ApplicationMenu()
        {
            MenuItem fileMenu = new MenuItem("File", new MenuItem[]
            {
                new MenuItem(
                "Save As...", 
                new EventHandler(_mediator.Save)),
                new MenuItem(
                "Restore From...", 
                new EventHandler(_mediator.Restore))             
            });
            return new MainMenu(new MenuItem[]{fileMenu});
        }
    }
}