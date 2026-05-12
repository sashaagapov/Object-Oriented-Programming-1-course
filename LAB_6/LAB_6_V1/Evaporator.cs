namespace lab6agapov_v1
{
    /// <summary>
    /// Випарник холодильника.
    /// </summary>
    public class Evaporator
    {
        private double temperature;

        /// <summary>
        /// Ініціалізує випарник заданою температурою.
        /// </summary>
        public Evaporator(double temperature)
        {
            this.temperature = temperature;
        }

        /// <summary>
        /// Температура випарника.
        /// </summary>
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        /// <summary>
        /// Контролює охолодження.
        /// </summary>
        public string ControlCooling()
        {
            return "Охолодження контролюється, t=" + temperature + " °C.";
        }
    }
}
