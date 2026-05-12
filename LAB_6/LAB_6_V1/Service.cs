using System;
using System.IO;

namespace lab6agapov_v1
{
    /// <summary>
    /// Технічний сервіс для консолі і збереження протоколу.
    /// </summary>
    public class Service
    {
        private string outputFormat;
        private string filePath;
        private string protocol;

        /// <summary>
        /// Ініціалізує сервіс.
        /// </summary>
        public Service(string outputFormat, string filePath)
        {
            this.outputFormat = outputFormat;
            this.filePath = filePath;
            protocol = "";
        }

        /// <summary>
        /// Формат виведення.
        /// </summary>
        public string OutputFormat
        {
            get { return outputFormat; }
            set { outputFormat = value; }
        }

        /// <summary>
        /// Шлях до файлу протоколу.
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        /// <summary>
        /// Виводить повідомлення в консоль і додає його в протокол.
        /// </summary>
        public void PrintToConsole(string message)
        {
            Console.WriteLine(message);
            protocol = protocol + message + "\n";
        }

        /// <summary>
        /// Зчитує рядок з консолі та додає введення в протокол.
        /// </summary>
        public string ReadFromConsole()
        {
            string value = Console.ReadLine() + "";
            protocol = protocol + "[INPUT] " + value + "\n";
            return value;
        }

        /// <summary>
        /// Зберігає поточний протокол у файл.
        /// </summary>
        public void SaveProtocol()
        {
            File.WriteAllText(filePath, protocol);
        }
    }
}
