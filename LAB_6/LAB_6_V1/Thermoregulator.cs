namespace lab6agapov_v1
{
    /// <summary>
    /// Терморегулятор холодильника.
    /// </summary>
    public class Thermoregulator
    {
        private int minTemperature;
        private int maxTemperature;
        private int currentTemperature;

        /// <summary>
        /// Ініціалізує терморегулятор робочим діапазоном.
        /// </summary>
        public Thermoregulator(int minTemperature, int maxTemperature)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            currentTemperature = minTemperature;
        }

        /// <summary>
        /// Діапазон температур у вигляді рядка.
        /// </summary>
        public string TemperatureRange
        {
            get { return minTemperature + ".." + maxTemperature; }
        }

        /// <summary>
        /// Встановлює температуру в межах дозволеного діапазону.
        /// </summary>
        public void SetTemperature(int temperature)
        {
            if (temperature < minTemperature)
            {
                currentTemperature = minTemperature;
                return;
            }

            if (temperature > maxTemperature)
            {
                currentTemperature = maxTemperature;
                return;
            }

            currentTemperature = temperature;
        }

        /// <summary>
        /// Зчитує поточну температуру.
        /// </summary>
        public int ReadTemperature()
        {
            return currentTemperature;
        }
    }
}
