namespace lab6agapov_v1
{
    /// <summary>
    /// Компресор холодильника.
    /// </summary>
    public class Compressor
    {
        private int power;
        private bool isRunning;

        /// <summary>
        /// Ініціалізує компресор потужністю.
        /// </summary>
        public Compressor(int power)
        {
            this.power = power;
            isRunning = false;
        }

        /// <summary>
        /// Потужність компресора.
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        /// <summary>
        /// Запускає компресор.
        /// </summary>
        public string Start()
        {
            isRunning = true;
            return "Компресор запущено.";
        }

        /// <summary>
        /// Зупиняє компресор.
        /// </summary>
        public string Stop()
        {
            isRunning = false;
            return "Компресор зупинено.";
        }

        /// <summary>
        /// Моніторить параметри компресора.
        /// </summary>
        public string MonitorParameters()
        {
            return "Компресор: потужність " + power + " Вт, стан: " + (isRunning ? "працює" : "зупинено") + ".";
        }
    }
}
