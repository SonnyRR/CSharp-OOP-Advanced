namespace StorageMester.BusinessLogic.Tests
{
    using System;
    using System.Reflection;
    using StorageMaster;
    using NUnit.Framework;
    using System.Collections.Generic;
    using StorageMaster.Entities.Products;
    using System.Linq;
    using StorageMaster.Entities.Storage;

    [TestFixture]
    public class LogicTest
    {

        Type storageMasterType;
        Object instance;

        [SetUp]
        public void Setup()
        {
            storageMasterType = GetType("StorageMaster");
            instance = Activator.CreateInstance(storageMasterType);
        }

        [Test]
        public void AddMethodTest()
        {
            var AddMethodInfo = storageMasterType.GetMethod("AddProduct");

            var internalPool = (IDictionary<string, Stack<Product>>)storageMasterType
                .GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);

            var output = (string)AddMethodInfo.Invoke(instance, new object[] { "Gpu", 99.98d });

            Assert.That(internalPool["Gpu"].Count, Is.EqualTo(1));
            Assert.That(internalPool.ContainsKey("Gpu"), Is.EqualTo(true));
            Assert.That(output, Is.EqualTo("Added Gpu to pool"));

        }

        [Test]
        public void RegisterStorageMethodTest()
        {
            var registerStorageInfo = storageMasterType.GetMethod("RegisterStorage");

            var internalStorageRegistry = (IDictionary<string, Storage>)storageMasterType
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);

            var output = (string)registerStorageInfo
                .Invoke(instance, new object[] { "Warehouse", "TestName" });

            Assert.That(internalStorageRegistry.ContainsKey("TestName"), Is.EqualTo(true));
            Assert.That(internalStorageRegistry["TestName"].GetType().Name, Is.EqualTo("Warehouse"));
            Assert.AreEqual("Registered TestName", output);
        }

        [Test]
        public void SelectVehicleMethodTest()
        {

            var registerStorageInfo = storageMasterType.GetMethod("RegisterStorage");
            var selectVehicleInfo = storageMasterType.GetMethod("SelectVehicle");
            var internalStorageRegistry = (IDictionary<string, Storage>)storageMasterType
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);

            registerStorageInfo.Invoke(instance, new object[] { "DistributionCenter", "TestHouse" });
            var output = (string)selectVehicleInfo.Invoke(instance, new object[] { "TestHouse", 2 });

            var slotExpectedVehicle = internalStorageRegistry["TestHouse"]
                .Garage
                .ToArray()[2]
                .GetType();

            Assert.AreEqual("Selected Van", output);
            Assert.That(slotExpectedVehicle.Name, Is.EqualTo("Van"));

        }

        [Test]
        public void LoadVehicleMethodTest()
        {
            var AddMethodInfo = storageMasterType.GetMethod("AddProduct");
            var registerStorageInfo = storageMasterType.GetMethod("RegisterStorage");
            var selectVehicleInfo = storageMasterType.GetMethod("SelectVehicle");
            var loadVehicleInfo = storageMasterType.GetMethod("LoadVehicle");


            registerStorageInfo.Invoke(instance, new object[] { "DistributionCenter", "TestName" });
            AddMethodInfo.Invoke(instance, new object[] { "Gpu", 590.34d });
            AddMethodInfo.Invoke(instance, new object[] { "Ram", 114.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 100.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 101.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 105.98d });
            AddMethodInfo.Invoke(instance, new object[] { "SolidStateDrive", 360.99d });

            var currentVehicle = selectVehicleInfo.Invoke(instance, new object[] { "TestName", 1 });
            string[] names = new[] { "Gpu", "Ram", "HardDrive", "HardDrive", "HardDrive", "SolidStateDrive" };

            var output = (string)loadVehicleInfo.Invoke(instance, new object[] { names });

            Assert.AreEqual("Loaded 4/6 products into Van", output);
        }

        [Test]
        public void SendVehicleToMethod()
        {
            var instance = Activator.CreateInstance(storageMasterType);
            var registerStorageInfo = storageMasterType.GetMethod("RegisterStorage");
            var sendVehicleToInfo = storageMasterType.GetMethod("SendVehicleTo");

            var internalStorageRegistry = (IDictionary<string , Storage>)storageMasterType
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);

            registerStorageInfo.Invoke(instance, new object[] { "DistributionCenter", "TestCenter" });
            registerStorageInfo.Invoke(instance, new object[] { "Warehouse", "TestWarehouse" });

            var output = sendVehicleToInfo.Invoke(instance, new object[] { "TestCenter", 2, "TestWarehouse" });
            var typeOfVehicleSent = internalStorageRegistry["TestWarehouse"].Garage.ToArray()[3].GetType();

            Assert.AreEqual("Sent Van to TestWarehouse (slot 3)", output);
            Assert.That(typeOfVehicleSent.Name, Is.EqualTo("Van"));
        }

        [Test]
        public void UnloadVehicleMethodTest()
        {
            var AddMethodInfo = storageMasterType.GetMethod("AddProduct");
            var registerStorageInfo = storageMasterType.GetMethod("RegisterStorage");
            var selectVehicleInfo = storageMasterType.GetMethod("SelectVehicle");
            var loadVehicleInfo = storageMasterType.GetMethod("LoadVehicle");
            var unloadVehicleInfo = storageMasterType.GetMethod("UnloadVehicle");


            registerStorageInfo.Invoke(instance, new object[] { "DistributionCenter", "TestName" });
            AddMethodInfo.Invoke(instance, new object[] { "Gpu", 590.34d });
            AddMethodInfo.Invoke(instance, new object[] { "Ram", 114.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 100.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 101.98d });
            AddMethodInfo.Invoke(instance, new object[] { "HardDrive", 105.98d });
            AddMethodInfo.Invoke(instance, new object[] { "SolidStateDrive", 360.99d });

            var currentVehicle = selectVehicleInfo.Invoke(instance, new object[] { "TestName", 1 });
            string[] names = new[] { "Gpu", "Ram", "HardDrive", "HardDrive", "HardDrive", "SolidStateDrive" };

            loadVehicleInfo.Invoke(instance, new object[] { names });
            var output = (string)unloadVehicleInfo.Invoke(instance, new object[] { "TestName", 1 });

            Assert.AreEqual("Unloaded 2/4 products at TestName", output);
        }

        public Type GetType(string typeName)
        {
            var type = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName);

            return type;

        }
    }
}
