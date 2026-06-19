using System;
using System.IO;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Service відповідає за консольне введення, консольне виведення,
    /// читання з файлу та запис тексту у файл.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Формат виведення або збереження даних.
        /// </summary>
        private string outputFormat;
        /// <summary>
        /// Шлях до файлу, з яким працює сервіс.
        /// </summary>
        private string filePath;
        /// <summary>
        /// Дані, які сервіс підготував до запису у файл.
        /// </summary>
        private string dataToProcess;

        /// <summary>
        /// Конструктор за замовчуванням створює сервіс з порожніми текстовими полями.
        /// </summary>
        public Service()
        {
            outputFormat = "";
            filePath = "";
            dataToProcess = "";
        }

        /// <summary>
        /// Конструктор з параметрами задає формат, шлях до файлу і початкові дані для обробки.
        /// </summary>
        /// <param name="outputFormat">Формат виведення.</param>
        /// <param name="filePath">Шлях до файлу.</param>
        /// <param name="dataToProcess">Початкові дані для обробки.</param>
        public Service(string outputFormat, string filePath, string dataToProcess)
        {
            this.outputFormat = outputFormat;
            this.filePath = filePath;
            this.dataToProcess = dataToProcess;
        }

        /// <summary>
        /// Конструктор копії створює сервіс з такими самими службовими полями, як в іншого сервісу.
        /// </summary>
        /// <param name="other">Сервіс, з якого копіюються дані.</param>
        public Service(Service other)
        {
            this.outputFormat = other.outputFormat;
            this.filePath = other.filePath;
            this.dataToProcess = other.dataToProcess;
        }

        /// <summary>
        /// Властивість для читання та зміни формату виведення.
        /// </summary>
        public string OutputFormat
        {
            get { return outputFormat; }
            set { outputFormat = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни шляху до файлу.
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни даних, підготовлених до обробки.
        /// </summary>
        public string DataToProcess
        {
            get { return dataToProcess; }
            set { dataToProcess = value; }
        }

        /// <summary>
        /// Виводить повідомлення в консоль.
        /// </summary>
        /// <param name="msg">Текст повідомлення для користувача.</param>
        public void PrintToConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Читає один рядок з консолі.
        /// </summary>
        /// <returns>Рядок, введений користувачем.</returns>
        public string ReadFromConsole()
        {
            return Console.ReadLine() + "";
        }

        /// <summary>
        /// Записує переданий текст у файл, шлях до якого зберігається в полі filePath.
        /// </summary>
        /// <param name="text">Готовий текст для запису.</param>
        public void WriteToFile(string text)
        {
            dataToProcess = text;
            File.WriteAllText(filePath, dataToProcess);
        }

        /// <summary>
        /// Читає весь текст з основного файлу, якщо він існує.
        /// </summary>
        /// <returns>Вміст файлу або порожній рядок, якщо файл не знайдено.</returns>
        public string ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return "";
        }
    }
}
