namespace StorageMester.Tests.Structure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;

    [TestFixture]
    public class StorageTests
    {
        [Test]
        public void ValidateAllStorages()
        {
            string[] storageTypeNames = new string[]
            {
                "Storage",
                "DistributionCenter",
                "AutomatedWarehouse",
                "Warehouse"
            };

            var currentAssemblyTypes = typeof(StartUp)
                .Assembly
                .GetTypes();

            foreach (var type in storageTypeNames)
            {
                var currentType = GetType(type);
                Assert.That(currentType, Is.Not.Null, $"{type} does not exist!");
            }

        }

        [Test]
        public void ValidateAllMethods()
        {
            var expectedMethods = new List<MethodArgs>()
            {
                { new MethodArgs(typeof(Vehicle), "GetVehicle", typeof(int))},
                { new MethodArgs(typeof(int), "UnloadVehicle", typeof(int))},
                { new MethodArgs(typeof(int), "SendVehicleTo", typeof(int), typeof(Storage))},
            };

            var storageMethods = GetType("Storage").GetMethods();

            foreach (var method in expectedMethods)
            {
                bool isNameValid = storageMethods.Any(x => x.Name == method.Name);
                Assert.That(isNameValid, "Method name is Invalid");

                bool isReturnTypeValid = storageMethods.Any(x => x.ReturnType == method.ReturnType);
                Assert.That(isReturnTypeValid, "Method return type is invalid!");

                MethodInfo currentActualMethod = storageMethods
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
        public void ValidateChildClasses()
        {
            string[] typeOfStorages = new string[]
            {
                "Warehouse",
                "DistributionCenter",
                "AutomatedWarehouse",
            };

            var typeToCompareTo = GetType("Storage");

            foreach (var typeName in typeOfStorages)
            {
                var currentStorageType = GetType(typeName);
                Assert.That(currentStorageType.BaseType, Is.EqualTo(typeToCompareTo), $"{typeName} does not inherit the base class Storage!");
            }
        }

        [Test]
        public void ValidateThatClassIsAbstract()
        {
            Type storageType = GetType("Storage");

            Assert.That(storageType.IsAbstract, Is.EqualTo(true), "Storage class is not abstract!");
        }

        [Test]
        public void ValidateAllProperties()
        {
            var expectedProperties = new Dictionary<string, Type>()
            {
                { "Capacity", typeof(int) },
                { "Name", typeof(string) },
                { "GarageSlots", typeof(int) },
                { "Products", typeof(IReadOnlyCollection<Product>)},
                { "Garage", typeof(IReadOnlyCollection<Vehicle>)},
                { "IsFull", typeof(bool) },
            };

            var storageType = GetType("Storage");
            var properties = storageType
                .GetProperties();

            foreach (var prop in properties)
            {
                bool doesExist = expectedProperties.Any(x => x.Key == prop.Name
                && prop.PropertyType == x.Value);

                Assert.That(doesExist, $"{prop.Name} does not exist!");
            }
        }

        [Test]
        public void ValidateConstructors()
        {
            var constructorInfo = GetType("Storage")
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            bool isValid = true;

            foreach (var ctor in constructorInfo)
            {
                if (ctor.GetParameters().Count() != 4)
                {
                    isValid = false;
                }
            }


            //var constructorParams = constructorInfo[0]
            //  .GetParameters();

            Assert.That(isValid, Is.True);
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
