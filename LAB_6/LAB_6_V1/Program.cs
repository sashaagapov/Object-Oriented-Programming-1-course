using System;

namespace lab6agapov_v1
{
    /// <summary>
    /// Точка входу для запуску ЛР6 версії 1.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Створює модель розумного холодильника і запускає меню.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "refrigerator_report.txt");

            ElectricalEquipment electricalEquipment = new ElectricalEquipment("NoFrostCoolingSystem");
            WifiModule wifiModule = new WifiModule("Wi-Fi 6", 1200);
            Sensors sensors = new Sensors(4.0, 11.5, 63.0, true);
            VoiceAssistant voiceAssistant = new VoiceAssistant("Жіночий", "Українська");

            SmartRefrigerator smartRefrigerator = new SmartRefrigerator(
                "KNU Smart Fridge X",
                1.2,
                380,
                electricalEquipment,
                wifiModule,
                sensors,
                voiceAssistant);

            service.PrintToConsole("Розумний холодильник створено.");

            // Початкова демонстрація виклику ключових методів усіх сутностей V1.
            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.ElectricMotor.CheckLoad());
            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.AutomationDevices.ControlLoad());
            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.Evaporator.ControlCooling());
            service.PrintToConsole("Температура терморегулятора: " + smartRefrigerator.ElectricalEquipment.Thermoregulator.ReadTemperature());
            service.PrintToConsole(smartRefrigerator.Microprocessor.ExecuteAlgorithm("Оптимізація охолодження"));
            service.PrintToConsole(smartRefrigerator.Microprocessor.TransferData());
            service.PrintToConsole(smartRefrigerator.Microprocessor.ControlEquipment(smartRefrigerator.ElectricalEquipment));
            service.PrintToConsole(smartRefrigerator.AIDevices.AiModule.GenerateRecommendations("Стартовий аналіз"));
            service.PrintToConsole(smartRefrigerator.AIDevices.Camera.TakeSnapshot());
            service.PrintToConsole(smartRefrigerator.Sensors.SignalDeviation());
            service.PrintToConsole(smartRefrigerator.WifiModule.TransferData("Синхронізація недоступна без підключення"));

            Menu menu = new Menu(service, smartRefrigerator);
            menu.Run();
        }
    }
}
