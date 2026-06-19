using System;

namespace LAB_6_V4
{
    /// <summary>
    /// Головна предметна сутність четвертої версії з підтримкою подій та делегатів.
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

        /// <summary>Подія зміни температури.</summary>
        public event RefrigeratorNotificationHandler OnTemperatureChanged;
        /// <summary>Подія перевищення енергоспоживання.</summary>
        public event RefrigeratorNotificationHandler OnEnergyConsumptionExceeded;
        /// <summary>Подія довго відкритих дверей.</summary>
        public event RefrigeratorNotificationHandler OnDoorLeftOpen;
        /// <summary>Подія успішного оновлення ПЗ.</summary>
        public event RefrigeratorNotificationHandler OnSoftwareUpdated;
        /// <summary>Подія збою розумного пристрою.</summary>
        public event RefrigeratorNotificationHandler OnSmartDeviceFailure;
        /// <summary>Подія зміни загального стану системи.</summary>
        public event RefrigeratorNotificationHandler OnSystemStatusChanged;

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
        /// Повертає або задає версію програмного забезпечення.
        /// </summary>
        public string SoftwareVersion
        {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        /// <summary>
        /// Повертає або задає напругу живлення.
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
        /// Підписує технічний сервіс на всі текстові події холодильника.
        /// </summary>
        /// <param name="service">Технічний сервіс, який приймає повідомлення подій.</param>
        public void SubscribeService(Service service)
        {
            // Сервіс не керує холодильником, а лише слухає текстові події від предметної сутності.
            OnTemperatureChanged += service.HandleRefrigeratorNotification;
            OnEnergyConsumptionExceeded += service.HandleRefrigeratorNotification;
            OnDoorLeftOpen += service.HandleRefrigeratorNotification;
            OnSoftwareUpdated += service.HandleRefrigeratorNotification;
            OnSmartDeviceFailure += service.HandleRefrigeratorNotification;
            OnSystemStatusChanged += service.HandleRefrigeratorNotification;
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
            RaiseSystemStatusChanged("Холодильник " + model + " увімкнено.");

            if (powerConsumption > 1.3)
            {
                RaiseEnergyConsumptionExceeded(
                    "Енергоспоживання " + powerConsumption.ToString("F1") + " кВт перевищує навчальний поріг 1.3 кВт."
                );
            }

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
            RaiseSystemStatusChanged("Холодильник " + model + " вимкнено.");
            return "Холодильник " + model + " вимкнено.";
        }

        /// <summary>
        /// Запускає самодіагностику з підняттям подій у разі помилок або успіху.
        /// </summary>
        /// <returns>Підсумок діагностики.</returns>
        public string RunSelfDiagnostics()
        {
            try
            {
                ValidateVoltage();
                ValidateMicroprocessor();
                ValidateSensors();
                ValidateAiModule();
                ValidateSoftwareState();
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }

            string result = "Самодіагностика холодильника:" + Environment.NewLine;
            result += cabinet.CheckCabinetState() + Environment.NewLine;
            result += electricalEquipment.DetectFailure() + Environment.NewLine;
            result += builtInMicroprocessor.ExecuteAlgorithm() + Environment.NewLine;
            result += sensors.CollectData() + Environment.NewLine;
            result += wiFiModule.GetSummary();
            RaiseSystemStatusChanged("Самодіагностику завершено без критичних помилок.");
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
                + " °C, ПЗ = " + softwareVersion
                + ", напруга = " + supplyVoltage.ToString("F1") + " В.";
        }

        /// <summary>
        /// Аналізує споживання продуктів.
        /// </summary>
        /// <returns>Результат аналізу споживання.</returns>
        public string AnalyzeProductConsumption()
        {
            try
            {
                ValidateSensors();
                return "Аналіз споживання продуктів: "
                    + aiDevices.AiModule.AnalyzeConsumptionData()
                    + " "
                    + sensors.DetectPresence();
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Формує рекомендації щодо завантаження продуктів.
        /// </summary>
        /// <returns>Текст рекомендацій.</returns>
        public string RecommendProductLoading()
        {
            try
            {
                ValidateSoftwareIsUpToDate();
                ValidateAiModule();
                return aiDevices.PredictNeeds() + Environment.NewLine + aiDevices.RecommendProducts();
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
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
        /// Вимірює температуру й піднімає подію її зміни.
        /// </summary>
        /// <returns>Результат вимірювання.</returns>
        public string MeasureTemperature()
        {
            try
            {
                string result = cabinet.MeasureTemperature();
                RaiseTemperatureChanged("Поточна температура в камері: " + cabinet.CurrentTemperature.ToString("F1") + " °C.");

                if (cabinet.CurrentTemperature > 8.0)
                {
                    RaiseTemperatureChanged("Температура перевищила безпечну межу 8°C.");
                    throw new RefrigeratorException(
                        "Температура в камері перевищила безпечну межу 8°C.",
                        FridgeErrorType.TemperatureExceeded
                    );
                }

                return result;
            }
            catch (RefrigeratorException)
            {
                RaiseTemperatureChanged("Зафіксовано критичну зміну температури: " + cabinet.CurrentTemperature.ToString("F1") + " °C.");
                throw;
            }
        }

        /// <summary>
        /// Аналізує продукти та звички користувача.
        /// </summary>
        /// <returns>Результат аналізу продуктів.</returns>
        public string AnalyzeProducts()
        {
            try
            {
                ValidateSoftwareIsUpToDate();
                ValidateAiModule();
                return aiDevices.RecognizeProducts() + Environment.NewLine + aiDevices.AnalyzeUserHabits();
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Генерує рекомендацію щодо здорового харчування.
        /// </summary>
        /// <returns>Текст рекомендації.</returns>
        public string RecommendHealthyFood()
        {
            try
            {
                ValidateSoftwareIsUpToDate();
                ValidateAiModule();
                return "Рекомендація щодо здорового харчування: " + aiDevices.AiModule.GenerateRecommendations();
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Генерує рецепт на основі розпізнаних продуктів.
        /// </summary>
        /// <returns>Текст рецепта.</returns>
        public string GenerateRecipe()
        {
            try
            {
                ValidateSoftwareIsUpToDate();
                ValidateAiModule();
                string productInfo = aiDevices.Camera.IdentifyProducts();
                return productInfo + Environment.NewLine
                    + "Рецепт: запропоновано легкий овочевий салат або запечені овочі.";
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Імітує аналіз стану користувача.
        /// </summary>
        /// <returns>Результат аналізу.</returns>
        public string AnalyzeUserMood()
        {
            try
            {
                ValidateSensors();

                if (sensors.PresenceDetected)
                {
                    return "Користувач біля холодильника. Система припускає активний стан і готовність до взаємодії.";
                }

                return "Користувача не виявлено. Система радить повернутися до холодильника пізніше.";
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Повертає мотиваційне повідомлення.
        /// </summary>
        /// <returns>Мотиваційний текст.</returns>
        public string MotivateHealthyEating()
        {
            try
            {
                ValidateSoftwareIsUpToDate();
                return "Мотивація: обирайте більше овочів, стежте за балансом раціону і не відкладайте корисний перекус.";
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Оновлює програмне забезпечення й піднімає подію успішного оновлення.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        public string UpdateSoftware()
        {
            try
            {
                ValidateSoftwareState();
                string result = wiFiModule.ReceiveUpdate() + Environment.NewLine;
                softwareVersion = "1.0.1";
                RaiseSoftwareUpdated("Програмне забезпечення оновлено до версії " + softwareVersion + ".");
                RaiseSystemStatusChanged("Система перейшла на нову версію програмного забезпечення.");
                return result + "Програмне забезпечення оновлено до версії " + softwareVersion + ".";
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Обробляє голосову команду й у разі збою піднімає подію помилки.
        /// </summary>
        /// <param name="assistant">Голосовий помічник.</param>
        /// <param name="command">Команда користувача.</param>
        /// <returns>Результат виконання команди.</returns>
        public string HandleVoiceCommand(VoiceAssistant assistant, string command)
        {
            try
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
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
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

            if (cabinet.Door.IsOpen)
            {
                RaiseDoorLeftOpen("Двері холодильника залишилися відкритими під час запуску охолодження.");
                throw new RefrigeratorException(
                    "Аварія охолодження: двері холодильника відчинені.",
                    FridgeErrorType.DoorFailure
                );
            }

            try
            {
                ValidateVoltage();
                string result = electricalEquipment.StartSystem() + Environment.NewLine;
                result += electricalEquipment.RegulateCooling() + Environment.NewLine;
                result += MeasureTemperature();
                return result;
            }
            catch (RefrigeratorException ex)
            {
                RaiseSmartDeviceFailure(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Підключає холодильник до Wi-Fi.
        /// </summary>
        /// <returns>Результат підключення.</returns>
        public string ConnectToWiFi()
        {
            string result = wiFiModule.Connect();
            RaiseSystemStatusChanged("Wi-Fi модуль успішно підключено.");
            return result;
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
        /// Відновлює коректний стан після демонстрації подій і помилок.
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

            RaiseSystemStatusChanged("Стан холодильника відновлено до базового демонстраційного режиму.");
            return "Стан холодильника відновлено до базового демонстраційного режиму.";
        }

        /// <summary>
        /// Запускає автоматичний demo-сценарій четвертої версії.
        /// </summary>
        /// <param name="service">Технічний сервіс для виводу, протоколу та прийому подій.</param>
        /// <param name="assistant">Голосовий помічник.</param>
        public void RunDemoScenario(Service service, VoiceAssistant assistant)
        {
            service.PrintHeader();
            service.PrintInfo("=== Автоматичний демонстраційний сценарій V4 ===");

            // Demo-сценарій спеціально побудований так, щоб послідовно показати і звичайну роботу, і події, і винятки.
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

            PrintDemoStep(service, 4, "Підключення Wi-Fi");
            service.PrintSuccess(ConnectToWiFi());

            PrintDemoStep(service, 5, "Оновлення програмного забезпечення");
            try
            {
                service.PrintSuccess(UpdateSoftware());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 6, "Аналіз продуктів");
            try
            {
                service.PrintInfo(AnalyzeProducts());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 7, "Рекомендації здорового харчування");
            try
            {
                service.PrintInfo(RecommendHealthyFood());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 8, "Нормальна голосова команда");
            try
            {
                service.PrintInfo(HandleVoiceCommand(assistant, "status"));
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 9, "Відкриття дверей");
            service.PrintWarning(OpenDoor());

            PrintDemoStep(service, 10, "Вимірювання температури");
            try
            {
                service.PrintStatus(MeasureTemperature());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 11, "Сценарій відкритих дверей під час охолодження");
            try
            {
                service.PrintInfo(RunCoolingCycle());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 12, "Демонстрація збою через високу напругу");
            try
            {
                service.PrintWarning(SimulateHighVoltage());
                service.PrintInfo(RunSelfDiagnostics());
            }
            catch (RefrigeratorException ex)
            {
                service.PrintError("Код збою: " + ex.ErrorType);
                service.PrintError("Опис проблеми: " + ex.Message);
            }

            PrintDemoStep(service, 13, "Відновлення справного стану");
            service.PrintSuccess(RestoreDemoState(assistant));

            PrintDemoStep(service, 14, "Збереження протоколу");
            service.SaveProtocol(service.ProtocolFilePath);
            service.PrintSuccess("Протокол збережено у файл: " + service.ProtocolFilePath);

            PrintDemoStep(service, 15, "Фінальний статус");
            service.PrintStatus(DetermineStatus());
            service.SaveProtocol(service.ProtocolFilePath);
        }

        /// <summary>
        /// Запускає інтерактивний режим четвертої версії.
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
                    // Протокол фіксує завершення кожної інтерактивної команди незалежно від того, чи сталася помилка.
                    service.AppendToProtocol("Команду завершено.");
                }
            }
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
        /// Перевіряє, чи не застаріла поточна версія програмного забезпечення.
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
        /// Перевіряє цілісність стану програмного забезпечення.
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
        /// Перевіряє коректність показників сенсорів.
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
        /// Піднімає подію зміни температури.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseTemperatureChanged(string message)
        {
            OnTemperatureChanged?.Invoke(message);
        }

        /// <summary>
        /// Піднімає подію перевищення енергоспоживання.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseEnergyConsumptionExceeded(string message)
        {
            OnEnergyConsumptionExceeded?.Invoke(message);
        }

        /// <summary>
        /// Піднімає подію довго відкритих дверей.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseDoorLeftOpen(string message)
        {
            OnDoorLeftOpen?.Invoke(message);
        }

        /// <summary>
        /// Піднімає подію успішного оновлення програмного забезпечення.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseSoftwareUpdated(string message)
        {
            OnSoftwareUpdated?.Invoke(message);
        }

        /// <summary>
        /// Піднімає подію збою розумного пристрою.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseSmartDeviceFailure(string message)
        {
            OnSmartDeviceFailure?.Invoke(message);
        }

        /// <summary>
        /// Піднімає подію зміни загального стану системи.
        /// </summary>
        /// <param name="message">Текст повідомлення події.</param>
        private void RaiseSystemStatusChanged(string message)
        {
            OnSystemStatusChanged?.Invoke(message);
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
