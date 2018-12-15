namespace StorageMester.Tests.Structure
{
    using System;
    using StorageMaster;
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductsTests
    {
        [Test]
        public void ValidateConstructors()
        {
            var constructorInfo = GetType("Product")
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            bool isValid = true;

            foreach (var ctor in constructorInfo)
            {
                if (ctor.GetParameters().Count() != 2)
                {
                    isValid = false;
                }
            }


            //var constructorParams = constructorInfo[0]
            //  .GetParameters();

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void ValidateThatClassIsAbstract()
        {
            Type storageType = GetType("Product");

            Assert.That(storageType.IsAbstract, Is.EqualTo(true), "Storage class is not abstract!");
        }
        
        [Test]
        public void ValidateChildClasses()
        {
            string[] typeOfStorages = new string[]
            {
                "Gpu",
                "HardDrive",
                "Ram",
                "SolidStateDrive",
            };

            var typeToCompareTo = GetType("Product");

            foreach (var typeName in typeOfStorages)
            {
                var currentStorageType = GetType(typeName);
                Assert.That(currentStorageType.BaseType, Is.EqualTo(typeToCompareTo), $"{typeName} does not inherit the base class Product!");
            }
        }

        [Test]
        public void ValidateAllProperties()
        {
            var expectedProperties = new Dictionary<string, Type>()
            {
                { "Price", typeof(double) },
                { "Weight", typeof(double) },
            };

            var productType = GetType("Product");
            var properties = productType
                .GetProperties();

            foreach (var prop in properties)
            {
                bool doesExist = expectedProperties.Any(x => x.Key == prop.Name
                && prop.PropertyType == x.Value);

                Assert.That(doesExist, $"{prop.Name} does not exist!");
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
    }
}
