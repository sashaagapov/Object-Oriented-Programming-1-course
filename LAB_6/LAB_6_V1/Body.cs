namespace LAB_6_V1
{
    /// <summary>
    /// Корпус холодильника.
    /// </summary>
    public class Body
    {
        private string material;
        private string color;
        private bool isDamaged;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Body()
        {
            material = "Метал";
            color = "Сріблястий";
            isDamaged = false;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="materialValue">Матеріал</param>
        /// <param name="colorValue">Колір</param>
        /// <param name="isDamagedValue">Пошкодження</param>
        public Body(string materialValue, string colorValue, bool isDamagedValue)
        {
            material = materialValue;
            color = colorValue;
            isDamaged = isDamagedValue;
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
        /// Повертає або задає значення властивості Color.
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості IsDamaged.
        /// </summary>
        public bool IsDamaged
        {
            get { return isDamaged; }
            set { isDamaged = value; }
        }

        /// <summary>
        /// Перевіряє цілісність корпусу.
        /// </summary>
        /// <returns>Стан корпусу</returns>
        public string CheckIntegrity()
        {
            if (isDamaged)
            {
                return "Корпус має пошкодження.";
            }

            return "Корпус цілий.";
        }

        /// <summary>
        /// Повертає повідомлення про очищення поверхні.
        /// </summary>
        /// <returns>Результат очищення</returns>
        public string CleanSurface()
        {
            return "Поверхню корпусу очищено.";
        }
    }
}
