using System;
using System.Data;
using DataLayer;

/// <summary>
/// Show that we know get our hooks into access to a data reader
/// </summary>
public class LimitingReader : DataReaderProxy
{
    /// <summary>
    /// Just here to capture the subject
    /// </summary>
    /// <param name="subject">the reader we are a proxy for</param>
    public LimitingReader(IDataReader subject) : base (subject)
    {
    }
    /// <summary>
    /// Show that we can intercept requests for apogee information.
    /// </summary>
    public override object this [string name]
    {
        get
        {
            if (String.Compare(name, "apogee", true) == 0) // same 
            {
                return 0;
            }
            else 
            {
                return base [name];
            }
        }
    }
}