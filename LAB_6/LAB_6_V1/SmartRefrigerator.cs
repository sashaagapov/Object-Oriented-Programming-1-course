namespace lab6agapov_v1
{
    /// <summary>
    /// Головна сутність розумного холодильника.
    /// </summary>
    public class SmartRefrigerator
    {
        private string model;
        private double energyConsumption;
        private double volume;

        private IsothermalCabinet isothermalCabinet;
        private ElectricalEquipment electricalEquipment;
        private Microprocessor microprocessor;
        private AIDevices aiDevices;
        private WifiModule wifiModule;
        private Sensors sensors;
        private VoiceAssistant voiceAssistant;

        private bool isTurnedOn;

        /// <summary>
        /// Ініціалізує холодильник і налаштовує композицію/агрегацію/асоціацію.
        /// </summary>
        public SmartRefrigerator(
            string model,
            double energyConsumption,
            double volume,
            ElectricalEquipment electricalEquipment,
            WifiModule wifiModule,
            Sensors sensors,
            VoiceAssistant voiceAssistant)
        {
            this.model = model;
            this.energyConsumption = energyConsumption;
            this.volume = volume;

            isothermalCabinet = new IsothermalCabinet("Steel", volume);
            microprocessor = new Microprocessor(2.8, 2048);
            aiDevices = new AIDevices("SmartNutrient", "KNU Labs");

            this.electricalEquipment = electricalEquipment;
            this.wifiModule = wifiModule;
            this.sensors = sensors;

            this.voiceAssistant = voiceAssistant;
            isTurnedOn = false;
        }

        /// <summary>
        /// Модель холодильника.
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// Енергоспоживання.
        /// </summary>
        public double EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        /// <summary>
        /// Об'єм холодильника.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        /// <summary>
        /// Доступ до ізотермічної шафи.
        /// </summary>
        public IsothermalCabinet IsothermalCabinet
        {
            get { return isothermalCabinet; }
        }

        /// <summary>
        /// Доступ до електрообладнання.
        /// </summary>
        public ElectricalEquipment ElectricalEquipment
        {
            get { return electricalEquipment; }
        }

        /// <summary>
        /// Доступ до мікропроцесора.
        /// </summary>
        public Microprocessor Microprocessor
        {
            get { return microprocessor; }
        }

        /// <summary>
        /// Доступ до ШІ-пристроїв.
        /// </summary>
        public AIDevices AIDevices
        {
            get { return aiDevices; }
        }

        /// <summary>
        /// Доступ до Wi-Fi модуля.
        /// </summary>
        public WifiModule WifiModule
        {
            get { return wifiModule; }
        }

        /// <summary>
        /// Доступ до сенсорів.
        /// </summary>
        public Sensors Sensors
        {
            get { return sensors; }
        }

        /// <summary>
        /// Доступ до голосового помічника.
        /// </summary>
        public VoiceAssistant VoiceAssistant
        {
            get { return voiceAssistant; }
        }

        /// <summary>
        /// Вмикає холодильник.
        /// </summary>
        public string TurnOn()
        {
            isTurnedOn = true;
            return "Холодильник увімкнено. " + electricalEquipment.StartSystem();
        }

        /// <summary>
        /// Вимикає холодильник.
        /// </summary>
        public string TurnOff()
        {
            isTurnedOn = false;
            return electricalEquipment.StopSystem() + " Холодильник вимкнено.";
        }

        /// <summary>
        /// Виконує самодіагностику систем.
        /// </summary>
        public string SelfDiagnose()
        {
            return electricalEquipment.DetectFault() + " "
                + isothermalCabinet.Body.CheckIntegrity() + " "
                + isothermalCabinet.Insulation.EvaluateEfficiency() + " "
                + sensors.SignalDeviation();
        }

        /// <summary>
        /// Визначає загальний статус холодильника.
        /// </summary>
        public string DetermineStatus()
        {
            return "Статус: " + (isTurnedOn ? "увімкнений" : "вимкнений")
                + "; t шафи=" + isothermalCabinet.MeasureTemperature()
                + "°C; " + sensors.CollectData();
        }

        /// <summary>
        /// Оновлює програмне забезпечення холодильника.
        /// </summary>
        public string UpdateSoftware()
        {
            return wifiModule.Connect() + " " + wifiModule.ReceiveUpdate();
        }

        /// <summary>
        /// Аналізує споживання продуктів.
        /// </summary>
        public string AnalyzeConsumption()
        {
            return aiDevices.AiModule.Learn() + " " + aiDevices.AnalyzeUserHabits();
        }

        /// <summary>
        /// Рекомендує, що завантажити до холодильника.
        /// </summary>
        public string RecommendProductLoading()
        {
            return aiDevices.PredictNeeds() + " " + aiDevices.RecommendProductsForPurchase();
        }

        /// <summary>
        /// Перевіряє стан здоров'я і формує рекомендації харчування.
        /// </summary>
        public string HealthCheckAndDiet(string healthData)
        {
            return "Дані здоров'я: " + healthData + ". "
                + aiDevices.AiModule.GenerateRecommendations("Здорове харчування");
        }

        /// <summary>
        /// Створює персоналізований рецепт.
        /// </summary>
        public string CreatePersonalizedRecipe(string request)
        {
            return "Рецепт для запиту '" + request + "': запечена курка з овочами. "
                + "Попередження: перевірте наявність броколі.";
        }

        /// <summary>
        /// Аналізує емоційний стан і активує голосову підтримку.
        /// </summary>
        public string SupportMood(string mood)
        {
            return voiceAssistant.PerformUserAction("Підтримка настрою: " + mood)
                + " Рекомендація: теплий чай і фрукти.";
        }
    }
}
