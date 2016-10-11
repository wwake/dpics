using System;
using Aster;
using BusinessCore;

public class OzAsterStarPress : AsterStarPress
{
    /// <summary>
    /// Override the superclass to have our robot collect the
    /// discharged paste before the star presses flushes
    /// itself with water.
    /// </summary>
    public override void DischargePaste()
    {
        base.DischargePaste();
        GetFactory().CollectPaste();
    }

    /// <summary>
    /// Get the material manager singleton.
    /// </summary>
    /// <returns>the material manager singleton</returns>
    public MaterialManager GetManager()
    {
        return MaterialManager.GetManager();
    }

    /// <summary>
    /// Let the Oozinoz material manager know that this
    /// mold is only partly processed.
    /// </summary>
    /// <param name="id">which mold</param>
    public override void MarkMoldIncomplete(int id)
    {
        GetManager().SetMoldIncomplete(id);
    }

    /// <summary>
    /// Get the factory singleton.
    /// </summary>
    /// <returns>the factory singleton; not actually implemented</returns>
    public Factory GetFactory()
    {
        return null;
    }
}