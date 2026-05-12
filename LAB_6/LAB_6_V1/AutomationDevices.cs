namespace lab6agapov_v1
{
    /// <summary>
    /// Прилади автоматики (датчики, реле).
    /// </summary>
    public class AutomationDevices
    {
        private string type;

        /// <summary>
        /// Ініціалізує прилади автоматики.
        /// </summary>
        public AutomationDevices(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// Тип приладів автоматики.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Реагує на подію.
        /// </summary>
        public string ReactToEvent(string eventName)
        {
            return "Автоматика відреагувала на подію: " + eventName + ".";
        }

        /// <summary>
        /// Формує повідомлення про подію.
        /// </summary>
        public string NotifyEvent(string message)
        {
            return "Оповіщення автоматики: " + message;
        }

        /// <summary>
        /// Контролює навантаження.
        /// </summary>
        public string ControlLoad()
        {
            return "Навантаження в межах норми.";
        }
    }
}
