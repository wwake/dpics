using System;
using System.Collections;

	/// <summary>
	/// A mock database that the ShowMediator examples use.
	/// </summary>
public class NameBase
{
    private static Hashtable _tubMachine;
    // a list of machine names
    internal static IList MachineNames()
    {
        return new string[]{
                               "Mixer-2201",
                               "Mixer-2202",
                               "StarPress-2401",
                               "StarPress-2402",
                               "Assembler-2301",
                               "Fuser-2101"};
    }
    // a table of tub->machine
    internal static Hashtable TubMachine()
    {
        if (_tubMachine == null) 
        {
            _tubMachine = new Hashtable();
            _tubMachine["T502"] = "Mixer-2201";
            _tubMachine["T503"] = "Mixer-2201";
            _tubMachine["T504"] = "Mixer-2201";
            _tubMachine["T101"] = "StarPress-2402";
            _tubMachine["T102"] = "StarPress-2402";
        }
        return _tubMachine;
    } 
    // find machine for a tub
    internal static string Machine(string tubName)
    {
        return (string) _tubMachine[tubName];
    }
    // find tubs at a machine
    internal static IList TubNames(string machineName)
    {
        ArrayList al = new ArrayList();
        IDictionaryEnumerator e = TubMachine().GetEnumerator();
        while (e.MoveNext()) 
        {
            if(e.Value.Equals(machineName))
            {
                al.Add(e.Key);
            }
        }
        return al;
    }
}