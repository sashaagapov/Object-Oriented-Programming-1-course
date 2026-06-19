namespace LAB_6_V1
{
    /// <summary>
    /// Електрообладнання холодильника.
    /// </summary>
    public class ElectricalEquipment
    {
        private string systemType;
        private bool isRunning;
        private Compressor compressor;
        private ElectricMotor electricMotor;
        private Refrigerant refrigerant;
        private Evaporator evaporator;
        private Condenser condenser;
        private TemperatureController temperatureController;
        private AutomationDevices automationDevices;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public ElectricalEquipment()
        {
            systemType = "Standard Cooling";
            isRunning = false;
            compressor = new Compressor();
            electricMotor = new ElectricMotor();
            refrigerant = new Refrigerant();
            evaporator = new Evaporator();
            condenser = new Condenser();
            temperatureController = new TemperatureController();
            automationDevices = new AutomationDevices();
        }

        /// <summary>
        /// Конструктор з параметром типу системи.
        /// </summary>
        /// <param name="systemTypeValue">Тип системи</param>
        public ElectricalEquipment(string systemTypeValue)
        {
            systemType = systemTypeValue;
            isRunning = false;
            compressor = new Compressor();
            electricMotor = new ElectricMotor();
            refrigerant = new Refrigerant();
            evaporator = new Evaporator();
            condenser = new Condenser();
            temperatureController = new TemperatureController();
            automationDevices = new AutomationDevices();
        }

        /// <summary>
        /// Повертає або задає значення властивості SystemType.
        /// </summary>
        public string SystemType
        {
            get { return systemType; }
            set { systemType = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості IsRunning.
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        /// <summary>
        /// Повертає значення властивості Compressor.
        /// </summary>
        public Compressor Compressor
        {
            get { return compressor; }
        }

        /// <summary>
        /// Повертає значення властивості ElectricMotor.
        /// </summary>
        public ElectricMotor ElectricMotor
        {
            get { return electricMotor; }
        }

        /// <summary>
        /// Повертає значення властивості Refrigerant.
        /// </summary>
        public Refrigerant Refrigerant
        {
            get { return refrigerant; }
        }

        /// <summary>
        /// Повертає значення властивості Evaporator.
        /// </summary>
        public Evaporator Evaporator
        {
            get { return evaporator; }
        }

        /// <summary>
        /// Повертає значення властивості Condenser.
        /// </summary>
        public Condenser Condenser
        {
            get { return condenser; }
        }

        /// <summary>
        /// Повертає значення властивості TemperatureController.
        /// </summary>
        public TemperatureController TemperatureController
        {
            get { return temperatureController; }
        }

        /// <summary>
        /// Повертає значення властивості AutomationDevices.
        /// </summary>
        public AutomationDevices AutomationDevices
        {
            get { return automationDevices; }
        }

        /// <summary>
        /// Запускає систему охолодження.
        /// </summary>
        /// <returns>Результат запуску</returns>
        public string StartSystem()
        {
            isRunning = true;
            return compressor.Start() + " " + electricMotor.Start();
        }

        /// <summary>
        /// Зупиняє систему охолодження.
        /// </summary>
        /// <returns>Результат зупинки</returns>
        public string StopSystem()
        {
            isRunning = false;
            return compressor.Stop() + " Система охолодження зупинена.";
        }

        /// <summary>
        /// Повертає базовий стан електрообладнання.
        /// </summary>
        /// <returns>Стан електрообладнання</returns>
        public string DetectFailure()
        {
            return "Електрообладнання справне. " + automationDevices.ControlLoad();
        }

        /// <summary>
        /// Імітує регулювання охолодження.
        /// </summary>
        /// <returns>Результат регулювання</returns>
        public string RegulateCooling()
        {
            return evaporator.ControlCooling()
                + " "
                + condenser.RemoveHeat()
                + " "
                + temperatureController.ReadTemperature();
        }

        /// <summary>
        /// Повертає коротку інформацію про електрообладнання.
        /// </summary>
        /// <returns>Короткий опис</returns>
        public string GetSummary()
        {
            string state = "зупинено";

            if (isRunning)
            {
                state = "працює";
            }

            return "тип = " + systemType + ", стан = " + state;
        }
    }
}
