namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;

    //using TheTankGame.Entities.Miscellaneous;
    //using TheTankGame.Entities.Miscellaneous.Contracts;
    //using TheTankGame.Entities.Parts;
    //using TheTankGame.Entities.Parts.Contracts;
    //using TheTankGame.Entities.Vehicles;
    //using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {

        [Test]
        public void ModelShouldThrowException()
        {
            //string vehicleType = arguments[0];
            //string model = arguments[1];
            //double weight = double.Parse(arguments[2]);
            //decimal price = decimal.Parse(arguments[3]);
            //int attack = int.Parse(arguments[4]);
            //int defense = int.Parse(arguments[5]);
            //int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Vanguard("", 3.3, 3.3m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Model cannot be null or white space!"));

            Assert.That(() => vehicle = new Revenger(null, 3.3, 3.3m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Model cannot be null or white space!"));
        }

        [Test]
        public void WeightShouldThrowException()
        {
            //Weight cannot be less or equal to zero!
            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Vanguard("IDK", 0, 3.3m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Weight cannot be less or equal to zero!"));

            Assert.That(() => vehicle = new Revenger("IDK", -1, 3.3m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Weight cannot be less or equal to zero!"));
        }

        [Test]
        public void PriceShouldThrowException()
        {
            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Revenger("IDK", 33, 0m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Price cannot be less or equal to zero!"));

            Assert.That(() => vehicle = new Vanguard("IDK", 33, -23.4m, 3, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Price cannot be less or equal to zero!"));

        }

        [Test]
        public void ValidateProperties()
        {
            IAssembler assembler = new VehicleAssembler();

            IVehicle vanguard = new Vanguard("idk", 323.33, 232.32m, 22, 33, 13, assembler);

            var totalWeight = vanguard.TotalWeight;
            var totalPrice = vanguard.TotalPrice;
            var totalPoints = vanguard.TotalHitPoints;
            var totalAttack = vanguard.TotalAttack;
            var totalDefense = vanguard.TotalDefense;

            var expectedWeight = 323.33d;
            var expectedPrice = 232.32m;
            var expectedAttack = 22;
            var expectedDefense = 33;
            var expectedHitpoints = 13;

            Assert.AreEqual(expectedWeight, totalWeight);
            Assert.AreEqual(expectedPrice, totalPrice);
            Assert.AreEqual(expectedHitpoints, totalPoints);
            Assert.AreEqual(expectedAttack, totalAttack);
            Assert.AreEqual(expectedDefense, totalDefense);

        }

        [Test]
        public void AttackShouldThrowException()
        {
            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Revenger("IDK", 33, 3m, -512, 3, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Attack cannot be less than zero!"));

        }

        [Test]
        public void DefenseShouldThrowException()
        {
            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Revenger("IDK", 33, 3m, 12, -2, 3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("Defense cannot be less than zero!"));
        }

        [Test]
        public void HitPointsShouldThrowException()
        {
            IVehicle vehicle;
            IAssembler assembler = new VehicleAssembler();

            Assert.That(() => vehicle = new Revenger("IDK", 33, 3m, 12, 2, -3, assembler), Throws.ArgumentException
                .With.Message.EqualTo("HitPoints cannot be less than zero!"));
        }

        [Test]
        public void TestOutputOfClass()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("SomeModl", 22.22, 33.33m, 43, 54, 22, assembler);

            IPart part = new ArsenalPart("idk", 22.45, 55.33m, 2);
            vehicle.AddArsenalPart(part);

            var currentOutput = vehicle.ToString();
            var expected = "Revenger - SomeModl\r\nTotal Weight: 44.670\r\nTotal Price: 88.660\r\nAttack: 45\r\nDefense: 54\r\nHitPoints: 22\r\nParts: idk";

            Assert.AreEqual(expected, currentOutput);
        }
    }
}