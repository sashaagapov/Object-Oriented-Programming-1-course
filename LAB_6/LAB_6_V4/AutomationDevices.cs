namespace LAB_6_V4
{
    /// <summary>
    /// Прилади автоматики холодильника.
    /// </summary>
    public class AutomationDevices
    {
        private string type;
        private bool eventDetected;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public AutomationDevices()
        {
            type = "Датчики та реле";
            eventDetected = false;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="typeValue">Тип автоматики</param>
        /// <param name="eventDetectedValue">Ознака події</param>
        public AutomationDevices(string typeValue, bool eventDetectedValue)
        {
            type = typeValue;
            eventDetected = eventDetectedValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Type.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості EventDetected.
        /// </summary>
        public bool EventDetected
        {
            get { return eventDetected; }
            set { eventDetected = value; }
        }

        /// <summary>
        /// Реагує на зміну стану.
        /// </summary>
        /// <returns>Результат реакції</returns>
        public string ReactToEvent()
        {
            eventDetected = true;
            return "Автоматика відреагувала на зміну стану.";
        }

        /// <summary>
        /// Контролює навантаження.
        /// </summary>
        /// <returns>Інформація про навантаження</returns>
        public string ControlLoad()
        {
            return "Автоматика контролює навантаження системи.";
        }
    }
}
