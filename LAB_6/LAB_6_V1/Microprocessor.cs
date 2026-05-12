namespace lab6agapov_v1
{
    /// <summary>
    /// Вбудований мікропроцесор холодильника.
    /// </summary>
    public class Microprocessor
    {
        private double frequency;
        private int memory;

        /// <summary>
        /// Ініціалізує мікропроцесор.
        /// </summary>
        public Microprocessor(double frequency, int memory)
        {
            this.frequency = frequency;
            this.memory = memory;
        }

        /// <summary>
        /// Частота процесора.
        /// </summary>
        public double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        /// <summary>
        /// Обсяг пам'яті в МБ.
        /// </summary>
        public int Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        /// <summary>
        /// Виконує алгоритм керування.
        /// </summary>
        public string ExecuteAlgorithm(string algorithmName)
        {
            return "Мікропроцесор виконав алгоритм: " + algorithmName + ".";
        }

        /// <summary>
        /// Передає службові дані між модулями.
        /// </summary>
        public string TransferData()
        {
            return "Дані передано між модулями керування.";
        }

        /// <summary>
        /// Керує обладнанням холодильника.
        /// </summary>
        public string ControlEquipment(ElectricalEquipment electricalEquipment)
        {
            return "Команда керування передана на " + electricalEquipment.SystemType + ".";
        }
    }
}
