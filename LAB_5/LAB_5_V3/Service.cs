using System;
using System.IO;
using System.Collections.Generic;

namespace lab5agapov_v3
{
    /// <summary>
    /// Клас Service відповідає за консольне введення, консольне виведення,
    /// читання з файлу та формування текстового звіту.
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
        private List<string> protocol;

        /// <summary>
        /// Конструктор за замовчуванням створює сервіс з порожніми текстовими полями.
        /// </summary>
        public Service()
        {
            outputFormat = "";
            filePath = "";
            dataToProcess = "";
            protocol = new List<string>();
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
            protocol = new List<string>();
        }

        /// <summary>
        /// Конструктор копії створює сервіс з такими самими службовими полями, як в іншого сервісу.
        /// </summary>
        /// <param name="other">Сервіс, з якого копіюються дані.</param>
        public Service(Service other)
        {
            outputFormat = other.outputFormat;
            filePath = other.filePath;
            dataToProcess = other.dataToProcess;
            protocol = new List<string>(other.protocol);
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
        /// Формує звіт про викладача і студента та записує його у файл.
        /// </summary>
        /// <param name="teacher">Викладач, дані якого додаються до звіту.</param>
        /// <param name="student">Студент, дані якого додаються до звіту.</param>
        public void SaveReport(Teacher teacher, Student student)
        {
            dataToProcess = "--- ЗВІТ ПРО ОСВІТНІЙ ПРОЦЕС ---\n";
            dataToProcess = dataToProcess + "Викладач: " + teacher.TeacherName + "\n";
            dataToProcess = dataToProcess + "Дисципліна: " + teacher.SubjectName + "\n";
            dataToProcess = dataToProcess + "Навантаження: " + teacher.StudyHours + " год.\n";
            dataToProcess = dataToProcess + "Студентів у групі: " + teacher.QuantityOfStudents + "\n";
            dataToProcess = dataToProcess + "Матеріал: " + teacher.StudyMaterial + "\n";
            dataToProcess = dataToProcess + "Журнал оцінок:\n" + teacher.GradesJournal + "\n";
            dataToProcess = dataToProcess + "Студент: " + student.StudentName + "\n";
            dataToProcess = dataToProcess + "Оцінки: " + student.ViewGrades() + "\n";
            dataToProcess = dataToProcess + "Виконано робіт: " + student.TasksDone + "\n";
            dataToProcess = dataToProcess + "Рейтинг: " + student.CalculateRating() + "\n";
            dataToProcess = dataToProcess + "Матеріал у студента: " + student.DownloadedMaterial + "\n";

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
        /// <summary>
        /// Одночасно виводить рядок у консоль і додає його до протоколу.
        /// </summary>
        /// <param name="text">Рядок для виводу та збереження.</param>
        public void PrintAndSave(string text)
        {
            // Єдина точка для формування консольного виводу і журналу запуску.
            Console.WriteLine(text);
            protocol.Add(text);
        }

        /// <summary>
        /// Записує накопичений протокол запуску у текстовий файл.
        /// </summary>
        /// <param name="fileName">Назва файлу протоколу.</param>
        public void SaveProtocolToFile(string fileName)
        {
            File.WriteAllLines(fileName, protocol);
        }
    }
}
