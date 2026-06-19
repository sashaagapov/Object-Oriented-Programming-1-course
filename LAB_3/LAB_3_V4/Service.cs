using System;
using System.IO;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Service відповідає за прості операції введення, виведення та роботу з файлами.
    /// Він не приймає рішень замість викладача чи студента і працює тільки з текстом та файлами.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Формат виведення даних, який зберігається як службова характеристика сервісу.
        /// </summary>
        private string outputFormat;

        /// <summary>
        /// Шлях до основного текстового файлу, у який сервіс записує звіт.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Текстові дані, підготовлені сервісом перед записом у файл.
        /// </summary>
        private string dataToProcess;

        /// <summary>
        /// Конструктор за замовчуванням створює порожній сервіс без заданого формату, шляху та даних.
        /// </summary>
        public Service()
        {
            outputFormat = "";
            filePath = "";
            dataToProcess = "";
        }

        /// <summary>
        /// Конструктор з параметрами створює сервіс із наперед заданими службовими даними.
        /// </summary>
        /// <param name="outputFormat">Текстове позначення формату виведення.</param>
        /// <param name="filePath">Шлях до файлу, куди потрібно зберігати звіт.</param>
        /// <param name="dataToProcess">Початковий текст, який сервіс може обробляти.</param>
        public Service(string outputFormat, string filePath, string dataToProcess)
        {
            this.outputFormat = outputFormat;
            this.filePath = filePath;
            this.dataToProcess = dataToProcess;
        }

        /// <summary>
        /// Конструктор копії створює новий об'єкт Service на основі вже існуючого сервісу.
        /// </summary>
        /// <param name="other">Інший об'єкт Service, з якого копіюються значення полів.</param>
        public Service(Service other)
        {
            outputFormat = other.outputFormat;
            filePath = other.filePath;
            dataToProcess = other.dataToProcess;
        }

        /// <summary>
        /// Властивість для читання та зміни формату виведення сервісу.
        /// </summary>
        public string OutputFormat
        {
            get { return outputFormat; }
            set { outputFormat = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни шляху до файлу звіту.
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни тексту, який сервіс готує до обробки або запису.
        /// </summary>
        public string DataToProcess
        {
            get { return dataToProcess; }
            set { dataToProcess = value; }
        }

        /// <summary>
        /// Виводить передане повідомлення в консоль без додаткової логіки предметної області.
        /// </summary>
        /// <param name="msg">Текст повідомлення, яке потрібно показати користувачу.</param>
        public void PrintToConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Читає один рядок з консолі та повертає його як текст.
        /// </summary>
        /// <returns>Рядок, введений користувачем у консолі.</returns>
        public string ReadFromConsole()
        {
            return Console.ReadLine() + "";
        }

        /// <summary>
        /// Записує готовий текст у файл, шлях до якого зберігається в полі filePath.
        /// </summary>
        /// <param name="text">Готовий текст для запису.</param>
        public void WriteToFile(string text)
        {
            dataToProcess = text;
            File.WriteAllText(filePath, dataToProcess);
        }

        /// <summary>
        /// Читає весь текст з основного файлу звіту, якщо такий файл існує.
        /// </summary>
        /// <returns>Вміст файлу або порожній рядок, якщо файл не знайдено.</returns>
        public string ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                // Читаємо звіт тільки після перевірки наявності файлу.
                return File.ReadAllText(filePath);
            }

            return "";
        }

        /// <summary>
        /// Читає всі рядки з указаного текстового файлу. Метод використовується, зокрема,
        /// для отримання списку тем дипломних проєктів.
        /// </summary>
        /// <param name="path">Шлях до файлу, з якого потрібно прочитати рядки.</param>
        /// <returns>Масив рядків з файлу або порожній масив, якщо файл не існує.</returns>
        public string[] ReadAllLines(string path)
        {
            if (File.Exists(path))
            {
                // Повертаємо всі рядки для подальшого поетапного аналізу в доменній логіці.
                return File.ReadAllLines(path);
            }

            return new string[0];
        }
    }
}
