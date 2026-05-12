namespace lab6agapov_v1
{
    /// <summary>
    /// Теплоізоляція шафи.
    /// </summary>
    public class Insulation
    {
        private string material;
        private double thickness;

        /// <summary>
        /// Ініціалізує теплоізоляцію матеріалом і товщиною.
        /// </summary>
        public Insulation(string material, double thickness)
        {
            this.material = material;
            this.thickness = thickness;
        }

        /// <summary>
        /// Матеріал теплоізоляції.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Товщина ізоляції.
        /// </summary>
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        /// <summary>
        /// Оцінює ефективність теплоізоляції.
        /// </summary>
        public string EvaluateEfficiency()
        {
            if (thickness >= 3.0)
            {
                return "Ефективність теплоізоляції висока.";
            }

            return "Ефективність теплоізоляції середня, рекомендовано посилення шару.";
        }
    }
}
