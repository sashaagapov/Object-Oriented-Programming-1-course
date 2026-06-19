using System;

namespace LAB_6_V3
{
    /// <summary>
    /// Точка входу для демонстрації третьої версії лабораторної роботи.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Створює об'єкти та запускає автоматичний demo-сценарій
        /// з демонстрацією обробки винятків.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        private static void Main(string[] args)
        {
            Service service = new Service();
            ElectricalEquipment electricalEquipment = new ElectricalEquipment("No Frost");
            WiFiModule wiFiModule = new WiFiModule("Wi-Fi 6", 1200.0);
            Sensors sensors = new Sensors(4.0, 35.0, false, 55.0);
            VoiceAssistant assistant = new VoiceAssistant("Жіночий", "Українська");

            // Агрегація реалізована передаванням готових технічних вузлів у конструктор.
            SmartRefrigerator refrigerator = new SmartRefrigerator(
                "SmartCool X1",
                1.4,
                420.0,
                "1.0.0",
                electricalEquipment,
                wiFiModule,
                sensors
            );

            refrigerator.RunDemoScenario(service, assistant);
        }
    }
}
