namespace lab6agapov_v1
{
    /// <summary>
    /// Корпус ізотермічної шафи.
    /// </summary>
    public class Body
    {
        private string material;
        private string color;

        /// <summary>
        /// Ініціалізує корпус заданим матеріалом і кольором.
        /// </summary>
        public Body(string material, string color)
        {
            this.material = material;
            this.color = color;
        }

        /// <summary>
        /// Матеріал корпусу.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Колір корпусу.
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Перевіряє цілісність корпусу.
        /// </summary>
        public string CheckIntegrity()
        {
            return "Цілісність корпусу перевірено: пошкоджень не виявлено.";
        }

        /// <summary>
        /// Очищує поверхню корпусу.
        /// </summary>
        public string CleanSurface()
        {
            return "Поверхню корпусу очищено.";
        }
    }
}
