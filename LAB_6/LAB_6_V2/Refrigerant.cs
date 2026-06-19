namespace LAB_6_V2
{
    /// <summary>
    /// Холодоагент холодильника.
    /// </summary>
    public class Refrigerant
    {
        private string type;
        private double mass;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Refrigerant()
        {
            type = "R600a";
            mass = 0.08;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="typeValue">Тип холодоагенту</param>
        /// <param name="massValue">Маса</param>
        public Refrigerant(string typeValue, double massValue)
        {
            type = typeValue;
            mass = massValue;
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
        /// Повертає або задає значення властивості Mass.
        /// </summary>
        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        /// <summary>
        /// Перевіряє рівень холодоагенту.
        /// </summary>
        /// <returns>Опис рівня</returns>
        public string CheckLevel()
        {
            return "Рівень холодоагенту в нормі. Маса = " + mass.ToString("F2") + " кг.";
        }

        /// <summary>
        /// Повертає тип холодоагенту.
        /// </summary>
        /// <returns>Тип холодоагенту</returns>
        public string DetermineType()
        {
            return "Тип холодоагенту: " + type + ".";
        }
    }
}
