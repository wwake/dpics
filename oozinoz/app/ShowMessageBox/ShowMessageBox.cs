using System.Windows.Forms;
/// <summary>
/// A minimal demo of using the MessageBox class. The question
/// here is: Is MessageBox a facade?
/// </summary>
public class ShowMessageBox
{
    public static void Main() 
    {
        DialogResult dr;
        do 
        {
            dr = MessageBox.Show(
                "Had enough?",
                " A Stubborn Dialog",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        } 
        while (dr == DialogResult.No);
    }
}