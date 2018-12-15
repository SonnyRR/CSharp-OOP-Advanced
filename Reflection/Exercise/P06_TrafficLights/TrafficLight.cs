namespace P06_TrafficLights
{
    using System;
    public class TrafficLight
    {
        private enum Light
        {
            Red,
            Green,
            Yellow
        }

        private Light _currentLight;

        public TrafficLight(string signal)
        {
            this.CurrentLight = signal;
        }

        public string CurrentLight
        {
            get { return _currentLight.ToString(); }
            set
            {
                Light.TryParse(value, out _currentLight);
            }
        }

        public void ChangeSingal()
        {
            var enumNames = typeof(Light).GetEnumValues();

            _currentLight = (Light)enumNames
                .GetValue((int)(_currentLight + 1) % enumNames.Length);
        }

        public override string ToString()
        {
            return this.CurrentLight;
        }

    }
}
