using System;

namespace LAB_6_V2
{
    /// <summary>
    /// Головна предметна сутність другої версії, яка реалізує інтерфейс ISmartDevice.
    /// </summary>
    public class SmartRefrigerator : ISmartDevice
    {
        private string model;
        private double powerConsumption;
        private double volume;
        private bool isPoweredOn;
        private string softwareVersion;
        private IsothermalCabinet cabinet;
        private ElectricalEquipment electricalEquipment;
        private BuiltInMicroprocessor builtInMicroprocessor;
        private AiDevices aiDevices;
        private WiFiModule wiFiModule;
        private Sensors sensors;

        /// <summary>
        /// Ініціалізує холодильник зі стандартними параметрами.
        /// </summary>
        public SmartRefrigerator()
        {
            model = "Default Refrigerator";
            powerConsumption = 1.0;
            volume = 300.0;
            isPoweredOn = false;
            softwareVersion = "1.0.0";
            cabinet = new IsothermalCabinet();
            builtInMicroprocessor = new BuiltInMicroprocessor();
            aiDevices = new AiDevices();
            electricalEquipment = new ElectricalEquipment();
            wiFiModule = new WiFiModule();
            sensors = new Sensors();
        }

        /// <summary>
        /// Ініціалізує холодильник із заданими характеристиками та агрегованими компонентами.
        /// </summary>
        /// <param name="modelValue">Назва моделі.</param>
        /// <param name="powerConsumptionValue">Енергоспоживання.</param>
        /// <param name="volumeValue">Корисний об'єм.</param>
        /// <param name="softwareVersionValue">Версія ПЗ.</param>
        /// <param name="electricalEquipmentValue">Агреговане електрообладнання.</param>
        /// <param name="wiFiModuleValue">Агрегований модуль Wi-Fi.</param>
        /// <param name="sensorsValue">Агреговані сенсори.</param>
        public SmartRefrigerator(
            string modelValue,
            double powerConsumptionValue,
            double volumeValue,
            string softwareVersionValue,
            ElectricalEquipment electricalEquipmentValue,
            WiFiModule wiFiModuleValue,
            Sensors sensorsValue
        )
        {
            model = modelValue;
            powerConsumption = powerConsumptionValue;
            volume = volumeValue;
            isPoweredOn = false;
            softwareVersion = softwareVersionValue;
            cabinet = new IsothermalCabinet();
            builtInMicroprocessor = new BuiltInMicroprocessor();
            aiDevices = new AiDevices();
            electricalEquipment = electricalEquipmentValue;
            wiFiModule = wiFiModuleValue;
            sensors = sensorsValue;
        }

        /// <summary>
        /// Повертає або задає модель холодильника.
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// Повертає або задає енергоспоживання холодильника.
        /// </summary>
        public double PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }

        /// <summary>
        /// Повертає або задає об'єм холодильника.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        /// <summary>
        /// Повертає або задає стан живлення.
        /// </summary>
        public bool IsPoweredOn
        {
            get { return isPoweredOn; }
            set { isPoweredOn = value; }
        }

        /// <summary>
        /// Повертає або задає версію ПЗ.
        /// </summary>
        public string SoftwareVersion
        {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        /// <summary>
        /// Повертає ізотермічну шафу, створену композиційно.
        /// </summary>
        public IsothermalCabinet Cabinet
        {
            get { return cabinet; }
        }

        /// <summary>
        /// Повертає агреговане електрообладнання.
        /// </summary>
        public ElectricalEquipment ElectricalEquipment
        {
            get { return electricalEquipment; }
        }

        /// <summary>
        /// Повертає вбудований мікропроцесор.
        /// </summary>
        public BuiltInMicroprocessor BuiltInMicroprocessor
        {
            get { return builtInMicroprocessor; }
        }

        /// <summary>
        /// Повертає набір AI-пристроїв.
        /// </summary>
        public AiDevices AiDevices
        {
            get { return aiDevices; }
        }

        /// <summary>
        /// Повертає агрегований модуль Wi-Fi.
        /// </summary>
        public WiFiModule WiFiModule
        {
            get { return wiFiModule; }
        }

        /// <summary>
        /// Повертає агрегований набір сенсорів.
        /// </summary>
        public Sensors Sensors
        {
            get { return sensors; }
        }

        /// <summary>
        /// Увімкнути холодильник.
        /// </summary>
        /// <returns>Результат увімкнення.</returns>
        public string TurnOn()
        {
            if (isPoweredOn)
            {
                return "Холодильник уже увімкнений.";
            }

            isPoweredOn = true;
            return "Холодильник " + model + " увімкнено.";
        }

        /// <summary>
        /// Вимкнути холодильник.
        /// </summary>
        /// <returns>Результат вимкнення.</returns>
        public string TurnOff()
        {
            if (!isPoweredOn)
            {
                return "Холодильник уже вимкнений.";
            }

            isPoweredOn = false;
            electricalEquipment.StopSystem();
            return "Холодильник " + model + " вимкнено.";
        }

        /// <summary>
        /// Запускає самодіагностику холодильника.
        /// </summary>
        /// <returns>Підсумок діагностики.</returns>
        public string RunSelfDiagnostics()
        {
            string result = "Самодіагностика холодильника:" + Environment.NewLine;
            result += cabinet.CheckCabinetState() + Environment.NewLine;
            result += electricalEquipment.DetectFailure() + Environment.NewLine;
            result += builtInMicroprocessor.ExecuteAlgorithm() + Environment.NewLine;
            result += sensors.CollectData() + Environment.NewLine;
            result += wiFiModule.GetSummary();
            return result;
        }

        /// <summary>
        /// Формує поточний статус холодильника.
        /// </summary>
        /// <returns>Статус у текстовому вигляді.</returns>
        public string DetermineStatus()
        {
            string powerState = isPoweredOn ? "увімкнений" : "вимкнений";
            string doorState = cabinet.Door.IsOpen ? "відкриті" : "закриті";
            string wifiState = wiFiModule.IsConnected ? "підключено" : "не підключено";

            return "Статус: " + powerState
                + ", двері " + doorState
                + ", Wi-Fi " + wifiState
                + ", температура = " + cabinet.CurrentTemperature.ToString("F1")
                + " °C, ПЗ = " + softwareVersion + ".";
        }

        /// <summary>
        /// Аналізує споживання продуктів.
        /// </summary>
        /// <returns>Результат аналізу споживання.</returns>
        public string AnalyzeProductConsumption()
        {
            return "Аналіз споживання продуктів: "
                + aiDevices.AiModule.AnalyzeConsumptionData()
                + " "
                + sensors.DetectPresence();
        }

        /// <summary>
        /// Формує рекомендації щодо завантаження продуктів.
        /// </summary>
        /// <returns>Рекомендації системи.</returns>
        public string RecommendProductLoading()
        {
            return aiDevices.PredictNeeds() + Environment.NewLine + aiDevices.RecommendProducts();
        }

        /// <summary>
        /// Відкриває двері холодильника.
        /// </summary>
        /// <returns>Результат відкриття дверей.</returns>
        public string OpenDoor()
        {
            return cabinet.OpenDoor();
        }

        /// <summary>
        /// Закриває двері холодильника.
        /// </summary>
        /// <returns>Результат закриття дверей.</returns>
        public string CloseDoor()
        {
            return cabinet.CloseDoor();
        }

        /// <summary>
        /// Вимірює температуру всередині холодильника.
        /// </summary>
        /// <returns>Результат вимірювання.</returns>
        public string MeasureTemperature()
        {
            return cabinet.MeasureTemperature();
        }

        /// <summary>
        /// Аналізує продукти та звички користувача.
        /// </summary>
        /// <returns>Результат аналізу продуктів.</returns>
        public string AnalyzeProducts()
        {
            return aiDevices.RecognizeProducts() + Environment.NewLine + aiDevices.AnalyzeUserHabits();
        }

        /// <summary>
        /// Генерує рекомендації щодо здорового харчування.
        /// </summary>
        /// <returns>Текст рекомендації.</returns>
        public string RecommendHealthyFood()
        {
            return "Рекомендація щодо здорового харчування: " + aiDevices.AiModule.GenerateRecommendations();
        }

        /// <summary>
        /// Генерує рецепт на основі розпізнаних продуктів.
        /// </summary>
        /// <returns>Текст рецепта.</returns>
        public string GenerateRecipe()
        {
            string productInfo = aiDevices.Camera.IdentifyProducts();
            return productInfo + Environment.NewLine
                + "Рецепт: запропоновано легкий овочевий салат або запечені овочі.";
        }

        /// <summary>
        /// Імітує аналіз стану користувача.
        /// </summary>
        /// <returns>Результат аналізу.</returns>
        public string AnalyzeUserMood()
        {
            if (sensors.PresenceDetected)
            {
                return "Користувач біля холодильника. Система припускає активний стан і готовність до взаємодії.";
            }

            return "Користувача не виявлено. Система радить повернутися до холодильника пізніше.";
        }

        /// <summary>
        /// Повертає мотиваційне повідомлення для здорового харчування.
        /// </summary>
        /// <returns>Мотиваційний текст.</returns>
        public string MotivateHealthyEating()
        {
            return "Мотивація: обирайте більше овочів, стежте за балансом раціону і не відкладайте корисний перекус.";
        }

        /// <summary>
        /// Оновлює програмне забезпечення холодильника.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        public string UpdateSoftware()
        {
            string result = wiFiModule.Connect() + Environment.NewLine;
            result += wiFiModule.ReceiveUpdate() + Environment.NewLine;
            softwareVersion = "1.0.1";
            result += "Програмне забезпечення оновлено до версії " + softwareVersion + ".";
            return result;
        }

        /// <summary>
        /// Обробляє голосову команду через асоційований помічник.
        /// </summary>
        /// <param name="assistant">Голосовий помічник.</param>
        /// <param name="command">Команда користувача.</param>
        /// <returns>Результат виконання команди.</returns>
        public string HandleVoiceCommand(VoiceAssistant assistant, string command)
        {
            string normalizedCommand = (command ?? string.Empty).Trim().ToLowerInvariant();

            if (normalizedCommand == "status")
            {
                return assistant.InterpretCommand("status") + Environment.NewLine + DetermineStatus();
            }

            if (normalizedCommand == "cool")
            {
                return assistant.InterpretCommand("cool") + Environment.NewLine + RunCoolingCycle();
            }

            if (normalizedCommand == "analyze")
            {
                return assistant.InterpretCommand("analyze") + Environment.NewLine + AnalyzeProducts();
            }

            if (normalizedCommand == "update")
            {
                return assistant.InterpretCommand("update") + Environment.NewLine + UpdateSoftware();
            }

            return assistant.Speak("Команда не підтримується в другій версії лабораторної роботи.");
        }

        /// <summary>
        /// Запускає автоматичний демонстраційний сценарій для другої версії.
        /// </summary>
        /// <param name="service">Технічний сервіс для виводу й протоколу.</param>
        /// <param name="assistant">Голосовий помічник.</param>
        public void RunDemoScenario(Service service, VoiceAssistant assistant)
        {
            ISmartDevice device = this;

            service.PrintHeader();
            service.PrintInfo("=== Автоматичний демонстраційний сценарій V2 ===");

            // Окремо демонструємо, що холодильник можна використовувати через інтерфейс.
            PrintDemoStep(service, 1, "Початковий статус");
            service.PrintStatus(DetermineStatus());

            PrintDemoStep(service, 2, "Увімкнення холодильника");
            service.PrintSuccess(TurnOn());

            PrintDemoStep(service, 3, "Поліморфний виклик DetermineStatus через ISmartDevice");
            service.PrintStatus(device.DetermineStatus());

            PrintDemoStep(service, 4, "Повна інформація про холодильник");
            service.PrintInfo(GetFullInformation());

            PrintDemoStep(service, 5, "Поліморфний виклик RunSelfDiagnostics через ISmartDevice");
            service.PrintInfo(device.RunSelfDiagnostics());

            PrintDemoStep(service, 6, "Аналіз споживання продуктів");
            service.PrintInfo(AnalyzeProductConsumption());

            PrintDemoStep(service, 7, "Рекомендації щодо завантаження продуктів");
            service.PrintInfo(RecommendProductLoading());

            PrintDemoStep(service, 8, "Відкриття дверей");
            service.PrintWarning(OpenDoor());

            PrintDemoStep(service, 9, "Вимірювання температури");
            service.PrintStatus(MeasureTemperature());

            PrintDemoStep(service, 10, "Закриття дверей");
            service.PrintSuccess(CloseDoor());

            PrintDemoStep(service, 11, "Аналіз продуктів");
            service.PrintInfo(AnalyzeProducts());

            PrintDemoStep(service, 12, "Рекомендації здорового харчування");
            service.PrintInfo(RecommendHealthyFood());

            PrintDemoStep(service, 13, "Генерація рецепта");
            service.PrintInfo(GenerateRecipe());

            PrintDemoStep(service, 14, "Аналіз настрою користувача");
            service.PrintInfo(AnalyzeUserMood());

            PrintDemoStep(service, 15, "Мотивація до здорового харчування");
            service.PrintSuccess(MotivateHealthyEating());

            PrintDemoStep(service, 16, "Голосова команда через VoiceAssistant");
            service.PrintInfo(HandleVoiceCommand(assistant, "status"));

            PrintDemoStep(service, 17, "Поліморфний виклик UpdateSoftware через ISmartDevice");
            service.PrintSuccess(device.UpdateSoftware());

            PrintDemoStep(service, 18, "Збереження протоколу");
            service.SaveProtocol(service.ProtocolFilePath);
            service.PrintSuccess("Протокол збережено у файл: " + service.ProtocolFilePath);

            PrintDemoStep(service, 19, "Фінальний статус");
            service.PrintStatus(DetermineStatus());
            service.SaveProtocol(service.ProtocolFilePath);
        }

        /// <summary>
        /// Запускає інтерактивний сценарій через технічне меню.
        /// </summary>
        /// <param name="service">Технічний сервіс.</param>
        /// <param name="menu">Технічне меню.</param>
        /// <param name="assistant">Голосовий помічник.</param>
        public void RunScenario(Service service, Menu menu, VoiceAssistant assistant)
        {
            bool isRunning = true;

            service.PrintHeader();
            service.PrintStatus(DetermineStatus());

            while (isRunning)
            {
                menu.PrintOptions(service);
                int command = menu.ReadCommand(service);

                switch (command)
                {
                    case 1:
                        service.PrintInfo(GetFullInformation());
                        break;
                    case 2:
                        service.PrintSuccess(TurnOn());
                        break;
                    case 3:
                        service.PrintWarning(TurnOff());
                        break;
                    case 4:
                        service.PrintInfo(RunSelfDiagnostics());
                        break;
                    case 5:
                        service.PrintStatus(DetermineStatus());
                        break;
                    case 6:
                        service.PrintInfo(AnalyzeProductConsumption());
                        break;
                    case 7:
                        service.PrintInfo(RecommendProductLoading());
                        break;
                    case 8:
                        service.PrintWarning(OpenDoor());
                        break;
                    case 9:
                        service.PrintSuccess(CloseDoor());
                        break;
                    case 10:
                        service.PrintStatus(MeasureTemperature());
                        break;
                    case 11:
                        service.PrintInfo(AnalyzeProducts());
                        break;
                    case 12:
                        service.PrintInfo(RecommendHealthyFood());
                        break;
                    case 13:
                        service.PrintInfo(GenerateRecipe());
                        break;
                    case 14:
                        service.PrintInfo(AnalyzeUserMood());
                        break;
                    case 15:
                        service.PrintSuccess(MotivateHealthyEating());
                        break;
                    case 16:
                        service.PrintSuccess(UpdateSoftware());
                        break;
                    case 17:
                        string voiceCommand = service.ReadString("Введіть голосову команду (status/cool/analyze/update)");
                        service.PrintInfo(HandleVoiceCommand(assistant, voiceCommand));
                        break;
                    case 18:
                        service.SaveProtocol(service.ProtocolFilePath);
                        service.PrintSuccess("Протокол збережено у файл: " + service.ProtocolFilePath);
                        break;
                    case 0:
                        isRunning = false;
                        service.SaveProtocol(service.ProtocolFilePath);
                        service.PrintWarning("Роботу програми завершено.");
                        break;
                    default:
                        service.PrintWarning("Невідома команда меню.");
                        break;
                }
            }
        }

        /// <summary>
        /// Запускає цикл охолодження.
        /// </summary>
        /// <returns>Результат роботи системи охолодження.</returns>
        public string RunCoolingCycle()
        {
            if (!isPoweredOn)
            {
                return "Неможливо запустити охолодження: холодильник вимкнений.";
            }

            string result = electricalEquipment.StartSystem() + Environment.NewLine;
            result += electricalEquipment.RegulateCooling() + Environment.NewLine;
            result += cabinet.MeasureTemperature();
            return result;
        }

        /// <summary>
        /// Повертає повну інформацію про холодильник і його складові.
        /// </summary>
        /// <returns>Розгорнутий опис об'єкта.</returns>
        public string GetFullInformation()
        {
            string result = "Модель: " + model + Environment.NewLine;
            result += "Енергоспоживання: " + powerConsumption.ToString("F1") + " кВт" + Environment.NewLine;
            result += "Об'єм: " + volume.ToString("F1") + " л" + Environment.NewLine;
            result += DetermineStatus() + Environment.NewLine;
            result += "Шафа: " + cabinet.GetCabinetInfo() + Environment.NewLine;
            result += "Електрообладнання: " + electricalEquipment.GetSummary() + Environment.NewLine;
            result += "Мікропроцесор: " + builtInMicroprocessor.GetSummary() + Environment.NewLine;
            result += "AI-пристрої: " + aiDevices.GetSummary() + Environment.NewLine;
            result += "Wi-Fi: " + wiFiModule.GetSummary() + Environment.NewLine;
            result += "Сенсори: " + sensors.GetSummary();
            return result;
        }

        /// <summary>
        /// Друкує заголовок поточного кроку demo-сценарію.
        /// </summary>
        /// <param name="service">Технічний сервіс.</param>
        /// <param name="stepNumber">Номер кроку.</param>
        /// <param name="title">Назва кроку.</param>
        private void PrintDemoStep(Service service, int stepNumber, string title)
        {
            service.PrintStatus("--- Крок " + stepNumber + ". " + title + " ---");
        }
    }
}
