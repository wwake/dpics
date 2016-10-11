using System;
using System.Reflection;
using Fireworks;

/// <summary>
/// Just a wee demo of using reflection to instantiate an object.
/// </summary>
public class ShowReflection
{
    /// <summary>
    /// Main entry point into the application.
    /// </summary>
    public static void Main()
    {
        Type t = typeof(Firework);
        ConstructorInfo c = t.GetConstructor(
            new Type[]{typeof(String), typeof(Double), typeof(Decimal)});
        Console.WriteLine(c.Invoke(new Object[]{"Titan", 6500, 31.95M}));
    }
}