using System;

namespace LAB_6_V1
{
    /// <summary>
    /// Головна предметна сутність першої версії, яка моделює розумний холодильник.
    /// </summary>
    public class SmartRefrigerator
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
        /// Ініціалізує холодильник зі стандартними параметрами та внутрішньою композицією.
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
        /// <param name="modelValue">Назва моделі холодильника.</param>
        /// <param name="powerConsumptionValue">Споживана потужність.</param>
        /// <param name="volumeValue">Корисний об'єм.</param>
        /// <param name="softwareVersionValue">Версія програмного забезпечення.</param>
        /// <param name="electricalEquipmentValue">Агреговане електрообладнання.</param>
        /// <param name="wiFiModuleValue">Агрегований Wi-Fi модуль.</param>
        /// <param name="sensorsValue">Агрегований набір сенсорів.</param>
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
        /// Повертає або задає рівень енергоспоживання.
        /// </summary>
        public double PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }

        /// <summary>
        /// Повертає або задає корисний об'єм холодильника.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        /// <summary>
        /// Повертає або задає стан живлення холодильника.
        /// </summary>
        public bool IsPoweredOn
        {
            get { return isPoweredOn; }
            set { isPoweredOn = value; }
        }

        /// <summary>
        /// Повертає або задає версію програмного забезпечення.
        /// </summary>
        public string SoftwareVersion
        {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        /// <summary>
        /// Повертає ізотермічну шафу, яка створюється композиційно всередині холодильника.
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
        /// Повертає AI-пристрої холодильника.
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
        /// <returns>Результат операції увімкнення.</returns>
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
        /// <returns>Результат операції вимкнення.</returns>
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
        /// Запускає самодіагностику ключових підсистем.
        /// </summary>
        /// <returns>Текстовий звіт самодіагностики.</returns>
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
        /// <returns>Короткий опис поточного стану системи.</returns>
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
        /// Аналізує споживання продуктів на основі AI та сенсорів.
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
        /// Генерує рекомендації щодо оптимального завантаження холодильника.
        /// </summary>
        /// <returns>Текст рекомендацій.</returns>
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
        /// <returns>Результат вимірювання температури.</returns>
        public string MeasureTemperature()
        {
            return cabinet.MeasureTemperature();
        }

        /// <summary>
        /// Аналізує наявні продукти та звички користувача.
        /// </summary>
        /// <returns>Результат аналізу продуктів.</returns>
        public string AnalyzeProducts()
        {
            return aiDevices.RecognizeProducts() + Environment.NewLine + aiDevices.AnalyzeUserHabits();
        }

        /// <summary>
        /// Формує рекомендації щодо здорового харчування.
        /// </summary>
        /// <returns>Текст рекомендації.</returns>
        public string RecommendHealthyFood()
        {
            return "Рекомендація щодо здорового харчування: " + aiDevices.AiModule.GenerateRecommendations();
        }

        /// <summary>
        /// Генерує простий рецепт на основі виявлених продуктів.
        /// </summary>
        /// <returns>Текст рецепта.</returns>
        public string GenerateRecipe()
        {
            string productInfo = aiDevices.Camera.IdentifyProducts();
            return productInfo + Environment.NewLine
                + "Рецепт: запропоновано легкий овочевий салат або запечені овочі.";
        }

        /// <summary>
        /// Імітує аналіз активності користувача біля холодильника.
        /// </summary>
        /// <returns>Повідомлення про припущення щодо стану користувача.</returns>
        public string AnalyzeUserMood()
        {
            if (sensors.PresenceDetected)
            {
                return "Користувач біля холодильника. Система припускає активний стан і готовність до взаємодії.";
            }

            return "Користувача не виявлено. Система радить повернутися до холодильника пізніше.";
        }

        /// <summary>
        /// Повертає мотиваційне повідомлення щодо здорового харчування.
        /// </summary>
        /// <returns>Мотиваційне повідомлення.</returns>
        public string MotivateHealthyEating()
        {
            return "Мотивація: обирайте більше овочів, стежте за балансом раціону і не відкладайте корисний перекус.";
        }

        /// <summary>
        /// Оновлює програмне забезпечення холодильника.
        /// </summary>
        /// <returns>Результат оновлення ПЗ.</returns>
        public string UpdateSoftware()
        {
            string result = wiFiModule.Connect() + Environment.NewLine;
            result += wiFiModule.ReceiveUpdate() + Environment.NewLine;
            softwareVersion = "1.0.1";
            result += "Програмне забезпечення оновлено до версії " + softwareVersion + ".";
            return result;
        }

        /// <summary>
        /// Обробляє голосову команду через асоційований голосовий помічник.
        /// </summary>
        /// <param name="assistant">Голосовий помічник.</param>
        /// <param name="command">Команда користувача.</param>
        /// <returns>Результат інтерпретації та виконання команди.</returns>
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

            return assistant.Speak("Команда не підтримується в першій версії лабораторної роботи.");
        }

        /// <summary>
        /// Запускає автоматичний демонстраційний сценарій без участі користувача.
        /// </summary>
        /// <param name="service">Технічний сервіс для виводу та протоколювання.</param>
        /// <param name="assistant">Асоційований голосовий помічник.</param>
        public void RunDemoScenario(Service service, VoiceAssistant assistant)
        {
            service.PrintHeader();
            service.PrintInfo("=== Автоматичний демонстраційний сценарій V1 ===");

            // У demo-сценарії холодильник послідовно показує ключові можливості предметної області.
            PrintDemoStep(service, 1, "Початковий статус");
            service.PrintStatus(DetermineStatus());

            PrintDemoStep(service, 2, "Увімкнення холодильника");
            service.PrintSuccess(TurnOn());

            PrintDemoStep(service, 3, "Повна інформація про холодильник");
            service.PrintInfo(GetFullInformation());

            PrintDemoStep(service, 4, "Самодіагностика");
            service.PrintInfo(RunSelfDiagnostics());

            PrintDemoStep(service, 5, "Аналіз споживання продуктів");
            service.PrintInfo(AnalyzeProductConsumption());

            PrintDemoStep(service, 6, "Рекомендації щодо завантаження продуктів");
            service.PrintInfo(RecommendProductLoading());

            PrintDemoStep(service, 7, "Відкриття дверей");
            service.PrintWarning(OpenDoor());

            PrintDemoStep(service, 8, "Вимірювання температури");
            service.PrintStatus(MeasureTemperature());

            PrintDemoStep(service, 9, "Закриття дверей");
            service.PrintSuccess(CloseDoor());

            PrintDemoStep(service, 10, "Аналіз продуктів");
            service.PrintInfo(AnalyzeProducts());

            PrintDemoStep(service, 11, "Рекомендації здорового харчування");
            service.PrintInfo(RecommendHealthyFood());

            PrintDemoStep(service, 12, "Генерація рецепта");
            service.PrintInfo(GenerateRecipe());

            PrintDemoStep(service, 13, "Аналіз настрою користувача");
            service.PrintInfo(AnalyzeUserMood());

            PrintDemoStep(service, 14, "Мотивація до здорового харчування");
            service.PrintSuccess(MotivateHealthyEating());

            PrintDemoStep(service, 15, "Голосова команда через VoiceAssistant");
            service.PrintInfo(HandleVoiceCommand(assistant, "status"));

            PrintDemoStep(service, 16, "Збереження протоколу");
            service.SaveProtocol(service.ProtocolFilePath);
            service.PrintSuccess("Протокол збережено у файл: " + service.ProtocolFilePath);

            PrintDemoStep(service, 17, "Фінальний статус");
            service.PrintStatus(DetermineStatus());
            service.SaveProtocol(service.ProtocolFilePath);
        }

        /// <summary>
        /// Запускає інтерактивний режим керування холодильником через технічне меню.
        /// </summary>
        /// <param name="service">Технічний сервіс для вводу, виводу і протоколювання.</param>
        /// <param name="menu">Технічне меню для вибору команд.</param>
        /// <param name="assistant">Асоційований голосовий помічник.</param>
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
        /// Запускає цикл охолодження за умови, що холодильник увімкнений.
        /// </summary>
        /// <returns>Результат роботи контуру охолодження.</returns>
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
        /// Повертає повний опис холодильника та його складових.
        /// </summary>
        /// <returns>Розгорнута інформація про об'єкт.</returns>
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
        /// Друкує службовий заголовок кроку demo-сценарію.
        /// </summary>
        /// <param name="service">Технічний сервіс для виводу.</param>
        /// <param name="stepNumber">Номер кроку.</param>
        /// <param name="title">Назва кроку.</param>
        private void PrintDemoStep(Service service, int stepNumber, string title)
        {
            service.PrintStatus("--- Крок " + stepNumber + ". " + title + " ---");
        }
    }
}
