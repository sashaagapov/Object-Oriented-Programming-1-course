namespace lab6agapov_v1
{
    /// <summary>
    /// Електричне обладнання холодильника.
    /// </summary>
    public class ElectricalEquipment
    {
        private string systemType;
        private Compressor compressor;
        private ElectricMotor electricMotor;
        private Refrigerant refrigerant;
        private Evaporator evaporator;
        private Condenser condenser;
        private Thermoregulator thermoregulator;
        private AutomationDevices automationDevices;

        /// <summary>
        /// Ініціалізує електричне обладнання і створює його частини (композиція).
        /// </summary>
        public ElectricalEquipment(string systemType)
        {
            this.systemType = systemType;
            compressor = new Compressor(450);
            electricMotor = new ElectricMotor("Inverter", 320);
            refrigerant = new Refrigerant("R600a", 0.18);
            evaporator = new Evaporator(-7.0);
            condenser = new Condenser("AirCooling");
            thermoregulator = new Thermoregulator(-25, 8);
            automationDevices = new AutomationDevices("SensorsAndRelays");
        }

        /// <summary>
        /// Тип системи електрообладнання.
        /// </summary>
        public string SystemType
        {
            get { return systemType; }
            set { systemType = value; }
        }

        /// <summary>
        /// Доступ до компресора.
        /// </summary>
        public Compressor Compressor
        {
            get { return compressor; }
        }

        /// <summary>
        /// Доступ до електродвигуна.
        /// </summary>
        public ElectricMotor ElectricMotor
        {
            get { return electricMotor; }
        }

        /// <summary>
        /// Доступ до холодоагенту.
        /// </summary>
        public Refrigerant Refrigerant
        {
            get { return refrigerant; }
        }

        /// <summary>
        /// Доступ до випарника.
        /// </summary>
        public Evaporator Evaporator
        {
            get { return evaporator; }
        }

        /// <summary>
        /// Доступ до конденсатора.
        /// </summary>
        public Condenser Condenser
        {
            get { return condenser; }
        }

        /// <summary>
        /// Доступ до терморегулятора.
        /// </summary>
        public Thermoregulator Thermoregulator
        {
            get { return thermoregulator; }
        }

        /// <summary>
        /// Доступ до автоматики.
        /// </summary>
        public AutomationDevices AutomationDevices
        {
            get { return automationDevices; }
        }

        /// <summary>
        /// Запускає систему охолодження.
        /// </summary>
        public string StartSystem()
        {
            return compressor.Start() + " " + electricMotor.Start();
        }

        /// <summary>
        /// Зупиняє систему охолодження.
        /// </summary>
        public string StopSystem()
        {
            return compressor.Stop() + " Система охолодження зупинена.";
        }

        /// <summary>
        /// Виявляє несправність у системі.
        /// </summary>
        public string DetectFault()
        {
            return automationDevices.NotifyEvent("Критичних несправностей не виявлено.");
        }
    }
}
