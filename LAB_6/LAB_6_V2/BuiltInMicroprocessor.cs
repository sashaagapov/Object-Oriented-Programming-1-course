namespace LAB_6_V2
{
    /// <summary>
    /// Вбудований мікропроцесор холодильника.
    /// </summary>
    public class BuiltInMicroprocessor
    {
        private double frequency;
        private int memory;
        private bool isWorking;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public BuiltInMicroprocessor()
        {
            frequency = 1.8;
            memory = 2048;
            isWorking = true;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="frequencyValue">Частота</param>
        /// <param name="memoryValue">Пам'ять</param>
        /// <param name="isWorkingValue">Стан роботи</param>
        public BuiltInMicroprocessor(double frequencyValue, int memoryValue, bool isWorkingValue)
        {
            frequency = frequencyValue;
            memory = memoryValue;
            isWorking = isWorkingValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Frequency.
        /// </summary>
        public double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Memory.
        /// </summary>
        public int Memory
        {
            get { return memory; }
            set { memory = value; }
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
        /// Імітує виконання алгоритму.
        /// </summary>
        /// <returns>Результат виконання</returns>
        public string ExecuteAlgorithm()
        {
            return "Мікропроцесор виконав базовий алгоритм керування.";
        }

        /// <summary>
        /// Імітує передачу даних.
        /// </summary>
        /// <returns>Результат передачі</returns>
        public string TransferData()
        {
            return "Мікропроцесор передав дані до внутрішніх модулів.";
        }

        /// <summary>
        /// Повертає коротку інформацію про модуль.
        /// </summary>
        /// <returns>Короткий опис</returns>
        public string GetSummary()
        {
            return "частота = " + frequency.ToString("F1") + " ГГц, пам'ять = " + memory + " МБ";
        }
    }
}
