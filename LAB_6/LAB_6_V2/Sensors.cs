namespace LAB_6_V2
{
    /// <summary>
    /// Сенсори холодильника.
    /// </summary>
    public class Sensors
    {
        private double temperature;
        private double weight;
        private bool presenceDetected;
        private double humidity;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Sensors()
        {
            temperature = 4.0;
            weight = 28.0;
            presenceDetected = false;
            humidity = 50.0;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="temperatureValue">Температура</param>
        /// <param name="weightValue">Вага продуктів</param>
        /// <param name="presenceDetectedValue">Наявність користувача</param>
        /// <param name="humidityValue">Вологість</param>
        public Sensors(
            double temperatureValue,
            double weightValue,
            bool presenceDetectedValue,
            double humidityValue
        )
        {
            temperature = temperatureValue;
            weight = weightValue;
            presenceDetected = presenceDetectedValue;
            humidity = humidityValue;
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
        /// Повертає або задає значення властивості Weight.
        /// </summary>
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості PresenceDetected.
        /// </summary>
        public bool PresenceDetected
        {
            get { return presenceDetected; }
            set { presenceDetected = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Humidity.
        /// </summary>
        public double Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        /// <summary>
        /// Повертає дані сенсорів.
        /// </summary>
        /// <returns>Опис поточних показників</returns>
        public string CollectData()
        {
            return "Сенсори: температура = "
                + temperature.ToString("F1")
                + " °C, вага продуктів = "
                + weight.ToString("F1")
                + " кг, вологість = "
                + humidity.ToString("F1")
                + " %.";
        }

        /// <summary>
        /// Імітує сигналізацію відхилень.
        /// </summary>
        /// <returns>Інформація про відхилення</returns>
        public string SignalDeviation()
        {
            return "Сенсори контролюють відхилення параметрів.";
        }

        /// <summary>
        /// Імітує виявлення присутності користувача.
        /// </summary>
        /// <returns>Опис виявлення</returns>
        public string DetectPresence()
        {
            if (presenceDetected)
            {
                return "Сенсори виявили користувача біля холодильника.";
            }

            return "Користувача біля холодильника не виявлено.";
        }

        /// <summary>
        /// Повертає коротку інформацію про сенсори.
        /// </summary>
        /// <returns>Короткий опис</returns>
        public string GetSummary()
        {
            return "температура = " + temperature.ToString("F1") + " °C, вологість = " + humidity.ToString("F1") + " %";
        }
    }
}
