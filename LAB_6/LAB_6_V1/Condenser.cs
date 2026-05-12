namespace lab6agapov_v1
{
    /// <summary>
    /// Конденсатор холодильника.
    /// </summary>
    public class Condenser
    {
        private string coolingType;

        /// <summary>
        /// Ініціалізує конденсатор типом охолодження.
        /// </summary>
        public Condenser(string coolingType)
        {
            this.coolingType = coolingType;
        }

        /// <summary>
        /// Тип охолодження конденсатора.
        /// </summary>
        public string CoolingType
        {
            get { return coolingType; }
            set { coolingType = value; }
        }

        /// <summary>
        /// Відводить тепло.
        /// </summary>
        public string DissipateHeat()
        {
            return "Конденсатор відводить тепло (" + coolingType + ").";
        }

        /// <summary>
        /// Діагностує стан конденсатора.
        /// </summary>
        public string DiagnoseState()
        {
            return "Стан конденсатора справний.";
        }
    }
}
