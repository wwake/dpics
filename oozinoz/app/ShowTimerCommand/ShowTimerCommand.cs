using System;

delegate void Command();

/// <summary>
/// Show a service that returns the time it takes to execute
/// a supplied command.
/// </summary>
class ShowTimerCommand
{
    static void Main()
    {			
        Console.WriteLine(TimeThis(new Command(Snooze)));
    }

    static void Snooze()
    {
        System.Threading.Thread.Sleep(2000);
    }
    
    static TimeSpan TimeThis(Command c)
    {
        DateTime t1 = DateTime.Now;
        c();
        return DateTime.Now.Subtract(t1);
    }
}