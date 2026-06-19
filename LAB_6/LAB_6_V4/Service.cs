using System;
using System.Collections.Generic;
using System.IO;

namespace LAB_6_V4
{
    /// <summary>
    /// Технічний сервіс для виводу, вводу, протоколювання та прийому текстових подій.
    /// </summary>
    public class Service
    {
        private readonly string versionTitle;
        private readonly List<string> protocolLines;
        private string protocolFilePath;

        /// <summary>
        /// Ініціалізує сервіс зі стандартним шляхом до протоколу.
        /// </summary>
        public Service()
        {
            versionTitle = "Версія 4: делегати та події";
            protocolFilePath = Path.Combine(Directory.GetCurrentDirectory(), "refrigerator_protocol_v4.txt");
            protocolLines = new List<string>();
        }

        /// <summary>
        /// Ініціалізує сервіс із заданим шляхом до файлу протоколу.
        /// </summary>
        /// <param name="filePath">Шлях до файлу протоколу.</param>
        public Service(string filePath)
        {
            versionTitle = "Версія 4: делегати та події";
            protocolFilePath = filePath;
            protocolLines = new List<string>();
        }

        /// <summary>
        /// Повертає або задає шлях до файлу протоколу.
        /// </summary>
        public string ProtocolFilePath
        {
            get { return protocolFilePath; }
            set { protocolFilePath = value; }
        }

        /// <summary>
        /// Друкує заголовок поточної версії та фіксує запуск у протоколі.
        /// </summary>
        public void PrintHeader()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("ЛАБОРАТОРНА РОБОТА №6 - SMART REFRIGERATOR");
            Console.WriteLine(versionTitle);
            Console.WriteLine("==============================================");
            AppendToProtocol("Програму запущено.");
        }

        /// <summary>
        /// Друкує інформаційне повідомлення.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        public void PrintInfo(string message)
        {
            WriteMessage(message, ConsoleColor.White);
        }

        /// <summary>
        /// Друкує статусне повідомлення.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        public void PrintStatus(string message)
        {
            WriteMessage(message, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Друкує повідомлення про успішне виконання.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        public void PrintSuccess(string message)
        {
            WriteMessage(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Друкує попередження.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        public void PrintWarning(string message)
        {
            WriteMessage(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Друкує повідомлення про помилку.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        public void PrintError(string message)
        {
            WriteMessage(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Зчитує рядок із консолі та додає його до протоколу.
        /// </summary>
        /// <param name="prompt">Підказка для користувача.</param>
        /// <returns>Введений рядок.</returns>
        public string ReadString(string prompt)
        {
            Console.Write(prompt + ": ");
            string value = Console.ReadLine() ?? string.Empty;
            AppendToProtocol("Ввід рядка [" + prompt + "] = " + value);
            return value;
        }

        /// <summary>
        /// Зчитує ціле число з перевіркою коректності.
        /// </summary>
        /// <param name="prompt">Підказка для користувача.</param>
        /// <returns>Введене ціле число.</returns>
        public int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": ");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int value))
                {
                    AppendToProtocol("Ввід числа [" + prompt + "] = " + value);
                    return value;
                }

                PrintWarning("Некоректне ціле число. Спробуйте ще раз.");
            }
        }

        /// <summary>
        /// Зчитує число з плаваючою комою з повторними спробами.
        /// </summary>
        /// <param name="prompt">Підказка для користувача.</param>
        /// <returns>Введене дійсне число.</returns>
        public double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": ");
                string input = Console.ReadLine() ?? string.Empty;

                if (double.TryParse(input, out double value))
                {
                    AppendToProtocol("Ввід числа з плаваючою комою [" + prompt + "] = " + value);
                    return value;
                }

                PrintWarning("Некоректне число з плаваючою комою. Спробуйте ще раз.");
            }
        }

        /// <summary>
        /// Додає повідомлення до протоколу з часовою позначкою.
        /// </summary>
        /// <param name="message">Повідомлення для протоколювання.</param>
        public void AppendToProtocol(string message)
        {
            string normalizedMessage = (message ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace('\r', '\n');

            string[] lines = normalizedMessage.Split('\n');

            foreach (string line in lines)
            {
                protocolLines.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + line);
            }
        }

        /// <summary>
        /// Зберігає накопичений протокол у файл.
        /// </summary>
        /// <param name="filePath">Шлях до цільового файлу.</param>
        public void SaveProtocol(string filePath)
        {
            SaveText(filePath, string.Join(Environment.NewLine, protocolLines));
        }

        /// <summary>
        /// Записує довільний текст у файл.
        /// </summary>
        /// <param name="filePath">Шлях до файлу.</param>
        /// <param name="text">Текст для запису.</param>
        public void SaveText(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }

        /// <summary>
        /// Обробляє подію холодильника у вигляді рядкового повідомлення.
        /// </summary>
        /// <param name="message">Текст події.</param>
        public void HandleRefrigeratorNotification(string message)
        {
            WriteMessage("Подія системи: " + message, ConsoleColor.Magenta);
        }

        /// <summary>
        /// Виводить повідомлення в заданому кольорі та одразу заносить його до протоколу.
        /// </summary>
        /// <param name="message">Текст повідомлення.</param>
        /// <param name="color">Колір повідомлення в консолі.</param>
        private void WriteMessage(string message, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
            AppendToProtocol(message);
        }
    }
}
