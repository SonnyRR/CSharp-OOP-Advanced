namespace Travel.Entities.Airplanes
{
    using Travel.Entities.Airplanes.Contracts;

    public class LightAirplane : Airplane, IAirplane
    {
        public LightAirplane() 
            : base(seats:5, baggageCompartments:8)
        {

        }
    }
}
