namespace lab6agapov_v1
{
    /// <summary>
    /// Wi-Fi модуль холодильника.
    /// </summary>
    public class WifiModule
    {
        private string protocol;
        private int speed;
        private bool isConnected;

        /// <summary>
        /// Ініціалізує Wi-Fi модуль.
        /// </summary>
        public WifiModule(string protocol, int speed)
        {
            this.protocol = protocol;
            this.speed = speed;
            isConnected = false;
        }

        /// <summary>
        /// Протокол Wi-Fi.
        /// </summary>
        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        /// <summary>
        /// Швидкість з'єднання.
        /// </summary>
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Ознака підключення до мережі.
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
        }

        /// <summary>
        /// Підключається до мережі.
        /// </summary>
        public string Connect()
        {
            isConnected = true;
            return "Wi-Fi модуль підключено (" + protocol + ").";
        }

        /// <summary>
        /// Передає дані в мережу.
        /// </summary>
        public string TransferData(string payload)
        {
            if (!isConnected)
            {
                return "Передача даних неможлива: немає з'єднання.";
            }

            return "Дані передано: " + payload;
        }

        /// <summary>
        /// Отримує оновлення ПЗ.
        /// </summary>
        public string ReceiveUpdate()
        {
            if (!isConnected)
            {
                return "Оновлення недоступне: Wi-Fi не підключено.";
            }

            return "Оновлення ПЗ отримано через Wi-Fi.";
        }
    }
}
