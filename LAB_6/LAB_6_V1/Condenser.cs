namespace LAB_6_V1
{
    /// <summary>
    /// Конденсатор холодильника.
    /// </summary>
    public class Condenser
    {
        private string coolingType;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Condenser()
        {
            coolingType = "Повітряний";
        }

        /// <summary>
        /// Конструктор з параметром.
        /// </summary>
        /// <param name="coolingTypeValue">Тип охолодження</param>
        public Condenser(string coolingTypeValue)
        {
            coolingType = coolingTypeValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості CoolingType.
        /// </summary>
        public string CoolingType
        {
            get { return coolingType; }
            set { coolingType = value; }
        }

        /// <summary>
        /// Імітує відведення тепла.
        /// </summary>
        /// <returns>Результат роботи</returns>
        public string RemoveHeat()
        {
            return "Конденсатор відводить тепло через " + coolingType + " охолодження.";
        }

        /// <summary>
        /// Повертає стан конденсатора.
        /// </summary>
        /// <returns>Стан конденсатора</returns>
        public string DiagnoseState()
        {
            return "Стан конденсатора нормальний.";
        }
    }
}
