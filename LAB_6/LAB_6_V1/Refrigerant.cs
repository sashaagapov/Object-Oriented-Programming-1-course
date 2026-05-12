namespace lab6agapov_v1
{
    /// <summary>
    /// Холодоагент у холодильній системі.
    /// </summary>
    public class Refrigerant
    {
        private string type;
        private double mass;

        /// <summary>
        /// Ініціалізує холодоагент заданими параметрами.
        /// </summary>
        public Refrigerant(string type, double mass)
        {
            this.type = type;
            this.mass = mass;
        }

        /// <summary>
        /// Тип холодоагенту.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Маса холодоагенту.
        /// </summary>
        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        /// <summary>
        /// Перевіряє рівень холодоагенту.
        /// </summary>
        public string CheckLevel()
        {
            return "Рівень холодоагенту: " + mass + " кг.";
        }

        /// <summary>
        /// Повертає тип холодоагенту.
        /// </summary>
        public string DetermineType()
        {
            return "Тип холодоагенту: " + type + ".";
        }
    }
}
