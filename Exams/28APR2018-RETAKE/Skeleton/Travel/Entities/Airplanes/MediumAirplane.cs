namespace Travel.Entities.Airplanes
{
    using Travel.Entities.Airplanes.Contracts;

    public class MediumAirplane : Airplane, IAirplane
    {
        public MediumAirplane()
            : base(seats:10, baggageCompartments:14)
        {

        }
    }
}
