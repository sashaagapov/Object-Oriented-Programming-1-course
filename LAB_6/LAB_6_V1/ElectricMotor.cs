namespace lab6agapov_v1
{
    /// <summary>
    /// Електродвигун холодильника.
    /// </summary>
    public class ElectricMotor
    {
        private string type;
        private int power;

        /// <summary>
        /// Ініціалізує двигун параметрами типу і потужності.
        /// </summary>
        public ElectricMotor(string type, int power)
        {
            this.type = type;
            this.power = power;
        }

        /// <summary>
        /// Тип двигуна.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Потужність двигуна.
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        /// <summary>
        /// Запускає двигун.
        /// </summary>
        public string Start()
        {
            return "Електродвигун запущено.";
        }

        /// <summary>
        /// Перевіряє навантаження двигуна.
        /// </summary>
        public string CheckLoad()
        {
            return "Навантаження двигуна в межах норми.";
        }
    }
}
