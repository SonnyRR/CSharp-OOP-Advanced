namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;


        protected Airplane(int seats, int baggageCompartments)
        {
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();

            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
        }


        public int BaggageCompartments { get; }
        public int Seats { get; }
        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();


        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var bagsToReturn = this.baggageCompartment
                .Where(x => x.Owner.Username == passenger.Username)
                .ToList();

            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);

            return bagsToReturn;
        }

        public void LoadBag(IBag bag)
        {
            // TODO
            //Check if >= and GetType();
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger passengerToReturn = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passengerToReturn;
        }
    }
}
