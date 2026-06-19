namespace LAB_6_V1
{
    /// <summary>
    /// Терморегулятор холодильника.
    /// </summary>
    public class TemperatureController
    {
        private double minTemperature;
        private double maxTemperature;
        private double currentTemperature;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public TemperatureController()
        {
            minTemperature = 2.0;
            maxTemperature = 8.0;
            currentTemperature = 4.0;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="minTemperatureValue">Мінімальна температура</param>
        /// <param name="maxTemperatureValue">Максимальна температура</param>
        /// <param name="currentTemperatureValue">Поточна температура</param>
        public TemperatureController(
            double minTemperatureValue,
            double maxTemperatureValue,
            double currentTemperatureValue
        )
        {
            minTemperature = minTemperatureValue;
            maxTemperature = maxTemperatureValue;
            currentTemperature = currentTemperatureValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості MinTemperature.
        /// </summary>
        public double MinTemperature
        {
            get { return minTemperature; }
            set { minTemperature = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості MaxTemperature.
        /// </summary>
        public double MaxTemperature
        {
            get { return maxTemperature; }
            set { maxTemperature = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості CurrentTemperature.
        /// </summary>
        public double CurrentTemperature
        {
            get { return currentTemperature; }
            set { currentTemperature = value; }
        }

        /// <summary>
        /// Встановлює нову температуру.
        /// </summary>
        /// <param name="value">Нове значення</param>
        /// <returns>Результат встановлення</returns>
        public string SetTemperature(double value)
        {
            currentTemperature = value;
            return "Температуру встановлено на " + currentTemperature.ToString("F1") + " °C.";
        }

        /// <summary>
        /// Повертає поточну температуру.
        /// </summary>
        /// <returns>Опис температури</returns>
        public string ReadTemperature()
        {
            return "Терморегулятор показує " + currentTemperature.ToString("F1") + " °C.";
        }
    }
}
