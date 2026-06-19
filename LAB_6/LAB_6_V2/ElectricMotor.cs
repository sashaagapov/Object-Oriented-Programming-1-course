namespace LAB_6_V2
{
    /// <summary>
    /// Електродвигун компресора.
    /// </summary>
    public class ElectricMotor
    {
        private string type;
        private double power;
        private double currentLoad;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public ElectricMotor()
        {
            type = "Інверторний";
            power = 120.0;
            currentLoad = 35.0;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="typeValue">Тип двигуна</param>
        /// <param name="powerValue">Потужність</param>
        /// <param name="loadValue">Навантаження</param>
        public ElectricMotor(string typeValue, double powerValue, double loadValue)
        {
            type = typeValue;
            power = powerValue;
            currentLoad = loadValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Type.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Power.
        /// </summary>
        public double Power
        {
            get { return power; }
            set { power = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості CurrentLoad.
        /// </summary>
        public double CurrentLoad
        {
            get { return currentLoad; }
            set { currentLoad = value; }
        }

        /// <summary>
        /// Запускає двигун.
        /// </summary>
        /// <returns>Результат запуску</returns>
        public string Start()
        {
            return "Електродвигун типу " + type + " активовано.";
        }

        /// <summary>
        /// Повертає рівень навантаження.
        /// </summary>
        /// <returns>Інформація про навантаження</returns>
        public string CheckLoad()
        {
            return "Навантаження двигуна: " + currentLoad.ToString("F1") + "%.";
        }
    }
}
