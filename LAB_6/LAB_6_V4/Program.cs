using System;

namespace LAB_6_V4
{
    /// <summary>
    /// Точка входу для демонстрації четвертої версії лабораторної роботи.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Створює предметні об'єкти, підписує сервіс на події холодильника
        /// та запускає автоматичний demo-сценарій.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        private static void Main(string[] args)
        {
            Service service = new Service();
            ElectricalEquipment electricalEquipment = new ElectricalEquipment("No Frost");
            WiFiModule wiFiModule = new WiFiModule("Wi-Fi 6", 1200.0);
            Sensors sensors = new Sensors(4.0, 35.0, false, 55.0);
            VoiceAssistant assistant = new VoiceAssistant("Жіночий", "Українська");

            // Агреговані компоненти створюються окремо, щоб не плутати агрегацію з композицією.
            SmartRefrigerator refrigerator = new SmartRefrigerator(
                "SmartCool X1",
                1.4,
                420.0,
                "1.0.0",
                electricalEquipment,
                wiFiModule,
                sensors
            );

            // Сервіс отримує лише текстові сповіщення і не володіє предметними об'єктами.
            refrigerator.SubscribeService(service);
            refrigerator.RunDemoScenario(service, assistant);
        }
    }
}
