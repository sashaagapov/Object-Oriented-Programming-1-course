namespace lab6agapov_v1
{
    /// <summary>
    /// Сенсори холодильника.
    /// </summary>
    public class Sensors
    {
        private double temperature;
        private double weight;
        private double humidity;
        private bool presence;

        /// <summary>
        /// Ініціалізує сенсори стартовими показниками.
        /// </summary>
        public Sensors(double temperature, double weight, double humidity, bool presence)
        {
            this.temperature = temperature;
            this.weight = weight;
            this.humidity = humidity;
            this.presence = presence;
        }

        /// <summary>
        /// Температура сенсорів.
        /// </summary>
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        /// <summary>
        /// Вага продуктів.
        /// </summary>
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Вологість.
        /// </summary>
        public double Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        /// <summary>
        /// Наявність руху/присутності біля холодильника.
        /// </summary>
        public bool Presence
        {
            get { return presence; }
            set { presence = value; }
        }

        /// <summary>
        /// Збирає поточні дані сенсорів.
        /// </summary>
        public string CollectData()
        {
            return "Сенсори: t=" + temperature + "°C, вага=" + weight + " кг, вологість=" + humidity + "%, присутність=" + (presence ? "так" : "ні") + ".";
        }

        /// <summary>
        /// Сигналізує про відхилення параметрів.
        /// </summary>
        public string SignalDeviation()
        {
            if (temperature > 8 || humidity > 80)
            {
                return "Попередження: параметри вийшли за безпечні межі.";
            }

            return "Критичних відхилень сенсорів не виявлено.";
        }
    }
}
