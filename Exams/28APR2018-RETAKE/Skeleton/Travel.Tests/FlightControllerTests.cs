// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private IAirplane airplane;
        private IAirport airport;
        private IFlightController fController;
        private ITrip trip;

        [SetUp]
        public void Setup()
        {
            airport = new Airport();
            airplane = new LightAirplane();
            fController = new FlightController(airport);
            trip = new Trip("Sofia", "Vidin", airplane);
            airport.AddTrip(trip);
        }

        [Test]
        public void Test_TakeOff()
        {

            IPassenger passenger = new Passenger("Doko");
            IBag bag = new Bag(passenger, new IItem[] { new Laptop() });
            passenger.Bags.Add(bag);
            airplane.AddPassenger(passenger);

            string result = fController.TakeOff();
            string expected = "Successfully transported 1 passengers from Sofia to Vidin.\r\nConfiscated bags: 0 (0 items) => $0";
            Assert.That(result.Contains(expected), Is.True);
        }

        [Test]
        public void Test_TripIsCompleted()
        {
            trip.Complete();
            IAirplane montanaPlane = new MediumAirplane();
            ITrip anotherTrip = new Trip("Vidin", "Montana", montanaPlane);
            IPassenger passenger = new Passenger("Doko");
            IBag bag = new Bag(passenger, new IItem[] { new Laptop() });

            airport.AddTrip(anotherTrip);
            passenger.Bags.Add(bag);
            airplane.AddPassenger(passenger);
            montanaPlane.AddPassenger(passenger);

            string result = fController.TakeOff();
            string expected = "Successfully transported 1 passengers from Vidin to Montana.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.That(result.Contains(expected), Is.True);
            Assert.True(trip.IsCompleted);
        }

        [Test]
        public void Test_Overbooked()
        {
            for (int i = 0; i < 7; i++)
            {
                var passenger = new Passenger($"Passenger_{i}");
                var bag = new Bag(passenger, new IItem[] { new Laptop(), new Colombian() });
                passenger.Bags.Add(bag);
                airplane.AddPassenger(passenger);
            }

            string result = fController.TakeOff();
            string expected = "SofiaVidin1:\r\nOverbooked! Ejected Passenger_1, Passenger_0\r\nConfiscated 2 bags ($106000)\r\nSuccessfully transported 5 passengers from Sofia to Vidin.\r\nConfiscated bags: 2 (4 items) => $106000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test_CarryOn()
        {
            for (int i = 0; i < 10; i++)
            {
                var passenger = new Passenger($"Passenger_{i}");
                var bag = new Bag(passenger, new IItem[] { new Laptop(), new Colombian() });
                passenger.Bags.Add(bag);
                airplane.AddPassenger(passenger);
            }
        }
    }
}
