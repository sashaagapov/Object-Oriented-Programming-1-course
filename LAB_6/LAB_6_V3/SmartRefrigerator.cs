using System;

namespace LAB_6_V3
{
    /// <summary>
    /// Головна предметна сутність третьої версії з підтримкою користувацьких винятків.
    /// </summary>
    public class SmartRefrigerator : ISmartDevice
    {
        private string model;
        private double powerConsumption;
        private double volume;
        private bool isPoweredOn;
        private string softwareVersion;
        private double supplyVoltage;
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
            supplyVoltage = 220.0;
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
            supplyVoltage = 220.0;
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
        /// Повертає або задає напругу живлення для перевірки виняткових ситуацій.
        /// </summary>
        public double SupplyVoltage
        {
            get { return supplyVoltage; }
            set { supplyVoltage = value; }
        }

        /// <summary>
        /// Повертає ізотермічну шафу холодильника.
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
        /// Повертає модуль Wi-Fi.
        /// </summary>
        public WiFiModule WiFiModule
        {
            get { return wiFiModule; }
        }

        /// <summary>
        /// Повертає набір сенсорів холодильника.
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
        /// Запускає самодіагностику з перевіркою виняткових ситуацій.
        /// </summary>
        /// <returns>Підсумок діагностики.</returns>
        public string RunSelfDiagnostics()
        {
            ValidateVoltage();
            ValidateMicroprocessor();
            ValidateSensors();
            ValidateAiModule();
            ValidateSoftwareState();

            string result = "Самодіагностика холодильника:" + Environment.NewLine;
            result += cabinet.CheckCabinetState() + Environment.NewLine;
            result += electricalEquipment.DetectFailure() + Environment.NewLine;
            result += builtInMicroprocessor.ExecuteAlgorithm() + Environment.NewLine;
            result += sensors.CollectData() + Environment.NewLine;
            result += wiFiModule.GetSummary();
            return result;
        }

        /// <summary>
        /// Формує поточний статус холодильника разом із напругою живлення.
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
                + " °C, ПЗ = " + softwareVersion
                + ", напруга = " + supplyVoltage.ToString("F1") + " В.";
        }

        /// <summary>
        /// Аналізує споживання продуктів.
        /// </summary>
        /// <returns>Результат аналізу споживання.</returns>
        public string AnalyzeProductConsumption()
        {
            ValidateSensors();
            return "Аналіз споживання продуктів: "
                + aiDevices.AiModule.AnalyzeConsumptionData()
                + " "
                + sensors.DetectPresence();
        }

        /// <summary>
        /// Формує рекомендації щодо завантаження продуктів.
        /// </summary>
        /// <returns>Текст рекомендацій.</returns>
        public string RecommendProductLoading()
        {
            ValidateSoftwareIsUpToDate();
            ValidateAiModule();
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
        /// Вимірює температуру та перевіряє перевищення допустимої межі.
        /// </summary>
        /// <returns>Результат вимірювання.</returns>
        public string MeasureTemperature()
        {
            string result = cabinet.MeasureTemperature();

            if (cabinet.CurrentTemperature > 8.0)
            {
                throw new RefrigeratorException(
                    "Температура в камері перевищила безпечну межу 8°C.",
                    FridgeErrorType.TemperatureExceeded
                );
            }

            return result;
        }

        /// <summary>
        /// Аналізує продукти та звички користувача.
        /// </summary>
        /// <returns>Результат аналізу продуктів.</returns>
        public string AnalyzeProducts()
        {
            ValidateSoftwareIsUpToDate();
            ValidateAiModule();
            return aiDevices.RecognizeProducts() + Environment.NewLine + aiDevices.AnalyzeUserHabits();
        }

        /// <summary>
        /// Генерує рекомендацію щодо здорового харчування.
        /// </summary>
        /// <returns>Текст рекомендації.</returns>
        public string RecommendHealthyFood()
        {
            ValidateSoftwareIsUpToDate();
            ValidateAiModule();
            return "Рекомендація щодо здорового харчування: " + aiDevices.AiModule.GenerateRecommendations();
        }

        /// <summary>
        /// Генерує рецепт на основі розпізнаних продуктів.
        /// </summary>
        /// <returns>Текст рецепта.</returns>
        public string GenerateRecipe()
        {
            ValidateSoftwareIsUpToDate();
            ValidateAiModule();
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
            ValidateSensors();

            if (sensors.PresenceDetected)
            {
                return "Користувач біля холодильника. Система припускає активний стан і готовність до взаємодії.";
            }

            return "Користувача не виявлено. Система радить повернутися до холодильника пізніше.";
        }

        /// <summary>
        /// Повертає мотиваційне повідомлення.
        /// </summary>
        /// <returns>Мотиваційний текст.</returns>
        public string MotivateHealthyEating()
        {
            ValidateSoftwareIsUpToDate();
            return "Мотивація: обирайте більше овочів, стежте за балансом раціону і не відкладайте корисний перекус.";
        }

        /// <summary>
        /// Оновлює програмне забезпечення з перевіркою актуальності та підключення.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        public string UpdateSoftware()
        {
            ValidateSoftwareState();
            string result = wiFiModule.ReceiveUpdate() + Environment.NewLine;
            softwareVersion = "1.0.1";
            result += "Програмне забезпечення оновлено до версії " + softwareVersion + ".";
            return result;
        }

        /// <summary>
        /// Обробляє голосову команду й може кинути доменний виняток.
        /// </summary>
        /// <param name="assistant">Голосовий помічник.</param>
        /// <param name="command">Команда користувача.</param>
        /// <returns>Результат виконання команди.</returns>
        public string HandleVoiceCommand(VoiceAssistant assistant, string command)
        {
            assistant.Listen();
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

            return assistant.InterpretCommand(normalizedCommand);
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

            if (cabinet.Door.IsOpen)
            {
                throw new RefrigeratorException(
                    "Аварія охолодження: двері холодильника відчинені.",
                    FridgeErrorType.DoorFailure
                );
            }

            ValidateVoltage();
            string result = electricalEquipment.StartSystem() + Environment.NewLine;
            result += electricalEquipment.RegulateCooling() + Environment.NewLine;
            result += MeasureTemperature();
            return result;
        }

        /// <summary>
        /// Підключає холодильник до Wi-Fi.
        /// </summary>
        /// <returns>Результат підключення.</returns>
        public string ConnectToWiFi()
        {
            return wiFiModule.Connect();
        }

        /// <summary>
        /// Штучно моделює сценарій низької напруги.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateLowVoltage()
        {
            supplyVoltage = 170.0;
            return "Для демонстрації встановлено низьку напругу 170 В.";
        }

        /// <summary>
        /// Штучно моделює сценарій високої напруги.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateHighVoltage()
        {
            supplyVoltage = 260.0;
            return "Для демонстрації встановлено високу напругу 260 В.";
        }

        /// <summary>
        /// Штучно моделює помилку сенсорів.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateSensorFailure()
        {
            sensors.Humidity = 150.0;
            return "Для демонстрації пошкоджено дані сенсорів.";
        }

        /// <summary>
        /// Штучно моделює помилку мікропроцесора.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateMicroprocessorFailure()
        {
            builtInMicroprocessor.IsWorking = false;
            return "Для демонстрації вимкнено вбудований мікропроцесор.";
        }

        /// <summary>
        /// Штучно моделює помилку AI-модуля.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateAiModuleFailure()
        {
            aiDevices.AiModule.Model = string.Empty;
            return "Для демонстрації пошкоджено AI-модуль.";
        }

        /// <summary>
        /// Штучно моделює помилку голосового помічника.
        /// </summary>
        /// <param name="assistant">Голосовий помічник.</param>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateVoiceAssistantFailure(VoiceAssistant assistant)
        {
            assistant.IsActive = false;
            return "Для демонстрації деактивовано голосового помічника.";
        }

        /// <summary>
        /// Штучно моделює збій програмного забезпечення.
        /// </summary>
        /// <returns>Текстова позначка сценарію.</returns>
        public string SimulateSoftwareFailure()
        {
            softwareVersion = "BROKEN";
            return "Для демонстрації пошкоджено стан програмного забезпечення.";
        }

        /// <summary>
        /// Відновлює коректний стан після демонстрації помилок.
        /// </summary>
        /// <param name="assistant">Голосовий помічник, який також повертається в активний стан.</param>
        /// <returns>Результат відновлення.</returns>
        public string RestoreDemoState(VoiceAssistant assistant)
        {
            supplyVoltage = 220.0;
            softwareVersion = "1.0.0";
            cabinet.CurrentTemperature = 4.0;
            cabinet.Door.IsOpen = false;
            sensors.Humidity = 55.0;
            builtInMicroprocessor.IsWorking = true;
            aiDevices.AiModule.Model = "FoodAI";
            assistant.IsActive = true;
            wiFiModule.IsConnected = false;
            electricalEquipment.IsRunning = false;

            return "Стан холодильника відновлено до базового демонстраційного режиму.";
        }

        /// <summary>
        /// Запускає автоматичний demo-сценарій з послідовною демонстрацією винятків.
        /// </summary>
        /// <param name="service">Технічний сервіс для виводу та протоколу.</param>
        /// <param name="assistant">Голосовий помічник.</param>
        public void RunDemoScenario(Service service, VoiceAssistant assistant)
        {
            service.PrintHeader();
            service.PrintInfo("=== Автоматичний демонстраційний сценарій V3 ===");

            PrintDemoStep(service, 1, "Початковий статус");
            service.PrintStatus(DetermineStatus());

            PrintDemoStep(service, 2, "Увімкнення холодильника");
            service.PrintSuccess(TurnOn());

            PrintDemoStep(service, 3, "Самодіагностика");
            try
            {
                service.PrintInfo(RunSelfDiagnostics());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 3 завершено.");
            }

            PrintDemoStep(service, 4, "Поточний мережевий стан");
            service.PrintStatus(wiFiModule.GetSummary());

            PrintDemoStep(service, 5, "Спроба оновлення ПЗ без Wi-Fi");
            try
            {
                service.PrintInfo(UpdateSoftware());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 5 завершено.");
            }

            PrintDemoStep(service, 6, "Нормальна голосова команда");
            try
            {
                service.PrintInfo(HandleVoiceCommand(assistant, "status"));
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 6 завершено.");
            }

            // Кожна помилка демонструється окремо, щоб у протоколі було видно її причину та обробку.
            PrintDemoStep(service, 7, "Помилка LowVoltage");
            try
            {
                SimulateLowVoltage();
                service.PrintInfo(RunSelfDiagnostics());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 7 завершено.");
            }

            PrintDemoStep(service, 8, "Помилка HighVoltage");
            try
            {
                RestoreDemoState(assistant);
                SimulateHighVoltage();
                service.PrintInfo(RunSelfDiagnostics());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 8 завершено.");
            }

            PrintDemoStep(service, 9, "Помилка NoInternet");
            try
            {
                RestoreDemoState(assistant);
                service.PrintInfo(UpdateSoftware());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 9 завершено.");
            }

            PrintDemoStep(service, 10, "Помилка ObsoleteSoftware");
            try
            {
                RestoreDemoState(assistant);
                service.PrintInfo(AnalyzeProducts());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 10 завершено.");
            }

            PrintDemoStep(service, 11, "Помилка TemperatureExceeded");
            try
            {
                RestoreDemoState(assistant);
                OpenDoor();
                service.PrintInfo(MeasureTemperature());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 11 завершено.");
            }

            PrintDemoStep(service, 12, "Помилка DoorFailure");
            try
            {
                RestoreDemoState(assistant);
                OpenDoor();
                service.PrintInfo(RunCoolingCycle());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 12 завершено.");
            }

            PrintDemoStep(service, 13, "Помилка SensorFailure");
            try
            {
                RestoreDemoState(assistant);
                SimulateSensorFailure();
                service.PrintInfo(AnalyzeUserMood());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 13 завершено.");
            }

            PrintDemoStep(service, 14, "Помилка MicroprocessorFailure");
            try
            {
                RestoreDemoState(assistant);
                SimulateMicroprocessorFailure();
                service.PrintInfo(RunSelfDiagnostics());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 14 завершено.");
            }

            PrintDemoStep(service, 15, "Помилка InvalidVoiceCommand");
            try
            {
                RestoreDemoState(assistant);
                service.PrintInfo(HandleVoiceCommand(assistant, "invalid"));
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }
            finally
            {
                service.AppendToProtocol("Крок 15 завершено.");
            }

            PrintDemoStep(service, 16, "Відновлення справного стану");
            service.PrintSuccess(RestoreDemoState(assistant));

            PrintDemoStep(service, 17, "Збереження протоколу");
            service.SaveProtocol(service.ProtocolFilePath);
            service.PrintSuccess("Протокол збережено у файл: " + service.ProtocolFilePath);

            PrintDemoStep(service, 18, "Фінальний статус");
            service.PrintStatus(DetermineStatus());
            service.SaveProtocol(service.ProtocolFilePath);
        }

        /// <summary>
        /// Запускає інтерактивний режим третьої версії.
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

                try
                {
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
                        case 19:
                            service.PrintSuccess(ConnectToWiFi());
                            break;
                        case 20:
                            service.PrintWarning(SimulateLowVoltage());
                            break;
                        case 21:
                            service.PrintWarning(SimulateHighVoltage());
                            break;
                        case 22:
                            service.PrintWarning(SimulateSensorFailure());
                            break;
                        case 23:
                            service.PrintWarning(SimulateMicroprocessorFailure());
                            break;
                        case 24:
                            service.PrintWarning(SimulateAiModuleFailure());
                            break;
                        case 25:
                            service.PrintWarning(SimulateVoiceAssistantFailure(assistant));
                            break;
                        case 26:
                            service.PrintWarning(SimulateSoftwareFailure());
                            break;
                        case 27:
                            service.PrintSuccess(RestoreDemoState(assistant));
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
                catch (RefrigeratorException ex)
                {
                    service.PrintError("Код збою: " + ex.ErrorType);
                    service.PrintError("Опис проблеми: " + ex.Message);
                }
                finally
                {
                    // Протокол фіксує завершення кожної інтерактивної команди незалежно від результату.
                    service.AppendToProtocol("Команду завершено.");
                }
            }
        }

        /// <summary>
        /// Повертає повний опис холодильника та його складових.
        /// </summary>
        /// <returns>Розгорнута інформація про стан системи.</returns>
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
        /// Перевіряє допустимість напруги живлення.
        /// </summary>
        private void ValidateVoltage()
        {
            if (supplyVoltage < 180.0)
            {
                throw new RefrigeratorException(
                    "Напруга нижча за 180 В. Холодильник не може працювати безпечно.",
                    FridgeErrorType.LowVoltage
                );
            }

            if (supplyVoltage > 250.0)
            {
                throw new RefrigeratorException(
                    "Напруга перевищує 250 В. Є ризик пошкодження електроніки.",
                    FridgeErrorType.HighVoltage
                );
            }
        }

        /// <summary>
        /// Перевіряє, чи не застаріла версія програмного забезпечення.
        /// </summary>
        private void ValidateSoftwareIsUpToDate()
        {
            if (softwareVersion == "1.0.0")
            {
                throw new RefrigeratorException(
                    "AI-функції недоступні: встановлено застаріле ПЗ версії 1.0.0.",
                    FridgeErrorType.ObsoleteSoftware
                );
            }
        }

        /// <summary>
        /// Перевіряє, чи не перебуває програмне забезпечення в аварійному стані.
        /// </summary>
        private void ValidateSoftwareState()
        {
            if (softwareVersion == "BROKEN" || softwareVersion == string.Empty)
            {
                throw new RefrigeratorException(
                    "Стан програмного забезпечення пошкоджено. Потрібне відновлення або перевстановлення.",
                    FridgeErrorType.SoftwareFailure
                );
            }
        }

        /// <summary>
        /// Перевіряє коректність роботи сенсорів.
        /// </summary>
        private void ValidateSensors()
        {
            if (sensors.Humidity < 0.0 || sensors.Humidity > 100.0 || sensors.Temperature < -30.0 || sensors.Temperature > 60.0)
            {
                throw new RefrigeratorException(
                    "Сенсори повернули некоректні дані. Неможливо продовжити роботу зі станом середовища.",
                    FridgeErrorType.SensorFailure
                );
            }
        }

        /// <summary>
        /// Перевіряє працездатність мікропроцесора.
        /// </summary>
        private void ValidateMicroprocessor()
        {
            if (!builtInMicroprocessor.IsWorking || builtInMicroprocessor.Memory <= 0)
            {
                throw new RefrigeratorException(
                    "Вбудований мікропроцесор недоступний або працює нестабільно.",
                    FridgeErrorType.MicroprocessorFailure
                );
            }
        }

        /// <summary>
        /// Перевіряє працездатність AI-модуля.
        /// </summary>
        private void ValidateAiModule()
        {
            if (aiDevices.AiModule.Model == string.Empty || aiDevices.Manufacturer == string.Empty)
            {
                throw new RefrigeratorException(
                    "AI-модуль пошкоджено або його конфігурація неповна.",
                    FridgeErrorType.AiModuleFailure
                );
            }
        }

        /// <summary>
        /// Друкує заголовок кроку demo-сценарію.
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
