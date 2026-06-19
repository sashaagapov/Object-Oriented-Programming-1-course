namespace LAB_6_V3
{
    /// <summary>
    /// Wi-Fi модуль холодильника.
    /// </summary>
    public class WiFiModule
    {
        private string protocol;
        private double speed;
        private bool isConnected;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public WiFiModule()
        {
            protocol = "Wi-Fi 5";
            speed = 600.0;
            isConnected = false;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="protocolValue">Протокол</param>
        /// <param name="speedValue">Швидкість</param>
        public WiFiModule(string protocolValue, double speedValue)
        {
            protocol = protocolValue;
            speed = speedValue;
            isConnected = false;
        }

        /// <summary>
        /// Повертає або задає значення властивості Protocol.
        /// </summary>
        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Speed.
        /// </summary>
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості IsConnected.
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        /// <summary>
        /// Імітує підключення до мережі.
        /// </summary>
        /// <returns>Результат підключення</returns>
        public string Connect()
        {
            isConnected = true;
            return "Wi-Fi модуль підключено через " + protocol + ".";
        }

        /// <summary>
        /// Імітує передачу даних.
        /// </summary>
        /// <returns>Результат передачі</returns>
        public string SendData()
        {
            return "Wi-Fi модуль передав дані зі швидкістю " + speed.ToString("F1") + " Мбіт/с.";
        }

        /// <summary>
        /// Імітує отримання оновлення.
        /// </summary>
        /// <returns>Результат отримання</returns>
        public string ReceiveUpdate()
        {
            if (!isConnected)
            {
                throw new RefrigeratorException(
                    "Оновлення програмного забезпечення неможливе: відсутнє з'єднання з Інтернетом.",
                    FridgeErrorType.NoInternet
                );
            }

            return "Оновлення програмного забезпечення успішно отримано.";
        }

        /// <summary>
        /// Повертає коротку інформацію про модуль.
        /// </summary>
        /// <returns>Короткий опис</returns>
        public string GetSummary()
        {
            string state = "не підключено";

            if (isConnected)
            {
                state = "підключено";
            }

            return "протокол = " + protocol + ", стан = " + state;
        }
    }
}
