namespace StorageMester.Tests.Structure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;

    [TestFixture]
    public class VehicleTests
    {

        [Test]
        public void ValidateThatClassIsAbstract()
        {
            var type = GetType("Vehicle");
            Assert.That(type.IsAbstract, Is.True, "Vehicle class is not abstract!");
        }

        [Test]
        public void ValidateAllVehicles()
        {
            string[] typesOfVehicles = new string[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in typesOfVehicles)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exist");
            }
        }

        [Test]
        public void ValidateAllProperties()
        {
            var expectedProperties = new Dictionary<string, Type>()
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>)},
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) },
            };

            var vehicleType = GetType("Vehicle");
            var properties = vehicleType
                .GetProperties();

            foreach (var prop in properties)
            {
                bool doesExist = expectedProperties.Any(x => x.Key == prop.Name
                && prop.PropertyType == x.Value);

                Assert.That(doesExist, $"{prop.Name} does not exist!");
            }
        }

        [Test]
        public void ValidateAllMethods()
        {

            var expectedMethods = new List<MethodArgs>()
            {
                { new MethodArgs(typeof(void), "LoadProduct", typeof(Product))},
                { new MethodArgs(typeof(Product), "Unload")},
            };

            var vehicleMethods = GetType("Vehicle").GetMethods();

            foreach (var method in expectedMethods)
            {
                bool isNameValid = vehicleMethods.Any(x => x.Name == method.Name);
                Assert.That(isNameValid, "Method name is Invalid");

                bool isReturnTypeValid = vehicleMethods.Any(x => x.ReturnType == method.ReturnType);
                Assert.That(isReturnTypeValid, "Method return type is invalid!");
                
                MethodInfo currentActualMethod = vehicleMethods
                    .FirstOrDefault(x => x.Name == method.Name);

                ParameterInfo[] currentActualMethodParams = currentActualMethod.GetParameters();

                MethodArgs currentExpectedMethod = expectedMethods
                    .FirstOrDefault(x => x.Name == method.Name
                    && x.Parameters.Length == currentActualMethodParams.Length);

                foreach (var paramType in currentExpectedMethod.Parameters)
                {
                    bool doesContain = currentActualMethodParams
                        .Any(x => x.ParameterType == paramType);
                    Assert.That(doesContain, Is.True, $"Method signature does not contain {paramType.Name} as parameter");
                }
            }
        }

        [Test]
        public void ValidateConstructors()
        {
            var constructorInfo = GetType("Vehicle")
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x=> x.GetParameters()[0].ParameterType == typeof(int));

            Assert.That(constructorInfo, Is.Not.Null, "Constructor that takes 1 param (int32) does not exist!");
        }

        [Test]
        public void ValidateChildClasses()
        {

            string[] typesOfVehicles = new string[]
            {
                "Semi",
                "Truck",
                "Van",
            };

            var typeToCompareTo = GetType("Vehicle");

            foreach (var typeName in typesOfVehicles)
            {
                var currentVehicleType = GetType(typeName);
                Assert.That(currentVehicleType.BaseType, Is.EqualTo(typeToCompareTo), $"{typeName} does not inherit the base class Vehicle!");
               
            }
        }

        private Type GetType(string typeName)
        {
            var type = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName);

            return type;
        }

        private class MethodArgs
        {
            public MethodArgs(Type returnType, string name, params Type[] parameters)
            {
                this.Name = name;
                this.ReturnType = returnType;
                this.Parameters = parameters;
            }

            public string Name { get; set; }
            public Type ReturnType { get; set; }

            public Type[] Parameters { get; set; }
        }
    }
}
