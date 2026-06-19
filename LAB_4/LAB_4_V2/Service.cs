using System;
using System.Collections.Generic;
using System.IO;

namespace lab4agapov_v2
{
    /// <summary>
    /// Клас Service відповідає тільки за консольний ввід/вивід,
    /// текстовий протокол і роботу з файлами.
    /// </summary>
    public class Service
    {
        private string outputFormat;
        private string filePath;
        private string dataToProcess;
        private List<string> protocol;

        public Service()
        {
            outputFormat = "";
            filePath = "";
            dataToProcess = "";
            protocol = new List<string>();
        }

        public Service(string outputFormat, string filePath, string dataToProcess)
        {
            this.outputFormat = outputFormat;
            this.filePath = filePath;
            this.dataToProcess = dataToProcess;
            protocol = new List<string>();
        }

        public Service(Service other)
        {
            outputFormat = other.outputFormat;
            filePath = other.filePath;
            dataToProcess = other.dataToProcess;
            protocol = new List<string>(other.protocol);
        }

        public string OutputFormat
        {
            get { return outputFormat; }
            set { outputFormat = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string DataToProcess
        {
            get { return dataToProcess; }
            set { dataToProcess = value; }
        }

        public void PrintToConsole(string msg)
        {
            Console.WriteLine(msg);
            protocol.Add(msg);
        }

        public string ReadFromConsole()
        {
            string input = Console.ReadLine() + "";

            protocol.Add("> " + input);
            return input;
        }

        public void WriteToFile(string text)
        {
            dataToProcess = text;
            File.WriteAllText(filePath, dataToProcess);
        }

        public string AppendProtocol(string text)
        {
            string result = text + "\n--- ПРОТОКОЛ РОБОТИ ПРОГРАМИ ---\n";
            int i;

            for (i = 0; i < protocol.Count; i++)
            {
                result += protocol[i] + "\n";
            }

            return result;
        }

        public void SaveProtocolToFile(string fileName)
        {
            File.WriteAllLines(fileName, protocol);
        }

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
