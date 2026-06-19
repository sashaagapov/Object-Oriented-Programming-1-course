namespace LAB_6_V4
{
    /// <summary>
    /// Теплоізоляція холодильника.
    /// </summary>
    public class ThermalInsulation
    {
        private string material;
        private double thickness;
        private double efficiency;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public ThermalInsulation()
        {
            material = "Пінополіуретан";
            thickness = 4.5;
            efficiency = 92.0;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="materialValue">Матеріал</param>
        /// <param name="thicknessValue">Товщина</param>
        /// <param name="efficiencyValue">Ефективність</param>
        public ThermalInsulation(string materialValue, double thicknessValue, double efficiencyValue)
        {
            material = materialValue;
            thickness = thicknessValue;
            efficiency = efficiencyValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Material.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Thickness.
        /// </summary>
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Efficiency.
        /// </summary>
        public double Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        /// <summary>
        /// Оцінює ефективність теплоізоляції.
        /// </summary>
        /// <returns>Опис ефективності</returns>
        public string EvaluateEfficiency()
        {
            return "Ефективність теплоізоляції: " + efficiency.ToString("F1") + "%.";
        }
    }
}
