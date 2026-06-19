namespace LAB_6_V4
{
    /// <summary>
    /// Компресор холодильника.
    /// </summary>
    public class Compressor
    {
        private double power;
        private bool isWorking;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Compressor()
        {
            power = 180.0;
            isWorking = false;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="powerValue">Потужність</param>
        /// <param name="isWorkingValue">Стан роботи</param>
        public Compressor(double powerValue, bool isWorkingValue)
        {
            power = powerValue;
            isWorking = isWorkingValue;
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
        /// Повертає або задає значення властивості IsWorking.
        /// </summary>
        public bool IsWorking
        {
            get { return isWorking; }
            set { isWorking = value; }
        }

        /// <summary>
        /// Запускає компресор.
        /// </summary>
        /// <returns>Результат запуску</returns>
        public string Start()
        {
            isWorking = true;
            return "Компресор запущено.";
        }

        /// <summary>
        /// Зупиняє компресор.
        /// </summary>
        /// <returns>Результат зупинки</returns>
        public string Stop()
        {
            isWorking = false;
            return "Компресор зупинено.";
        }
    }
}
