using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NUnit.Framework;

[TestFixture]
[SuppressMessage("ReSharper", "CheckNamespace")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Structure_006_InterfaceMethods
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(FestivalManager.StartUp).Assembly;

    [Test]
    public void ValidateInterfaceMethodsHaveExactMethodCount()
    {
        var types = ProjectAssembly.GetTypes()
            .Where(t => !t.GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any())
            .ToArray();

        var interfaces = types.Where(t => t.IsInterface && t.Name == "IStage").ToArray();

        var objectMethods = typeof(object).GetMethods();
        foreach (var @interface in interfaces)
        {
            var derivedTypes = types.Where(t => @interface.IsAssignableFrom(t)).ToArray();
            var interfaceMethods = @interface.GetMethods();

            foreach (var type in derivedTypes)
            {
                var methods = type.GetMethods()
                    .Where(mi => objectMethods.All(x => x.Name != mi.Name))
                    .ToArray();

                Assert.That(methods, Has.Exactly(interfaceMethods.Length).Items, $"{type.Name} has more public methods than defined in the interface!");
            }
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return type;
    }
}