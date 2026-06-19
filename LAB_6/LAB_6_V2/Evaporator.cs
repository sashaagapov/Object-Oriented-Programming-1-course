namespace LAB_6_V2
{
    /// <summary>
    /// Випарник холодильника.
    /// </summary>
    public class Evaporator
    {
        private double temperature;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Evaporator()
        {
            temperature = -12.0;
        }

        /// <summary>
        /// Конструктор з параметром.
        /// </summary>
        /// <param name="temperatureValue">Температура випарника</param>
        public Evaporator(double temperatureValue)
        {
            temperature = temperatureValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Temperature.
        /// </summary>
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        /// <summary>
        /// Імітує керування охолодженням.
        /// </summary>
        /// <returns>Результат роботи</returns>
        public string ControlCooling()
        {
            return "Випарник підтримує температуру " + temperature.ToString("F1") + " °C.";
        }
    }
}
