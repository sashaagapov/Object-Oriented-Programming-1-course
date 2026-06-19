namespace LAB_6_V1
{
    /// <summary>
    /// Голосовий помічник, асоційований із холодильником.
    /// </summary>
    public class VoiceAssistant
    {
        private string voiceType;
        private string language;
        private bool isActive;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public VoiceAssistant()
        {
            voiceType = "Жіночий"; // Базовий тип голосу для демонстрації.
            language = "Українська"; // Базова локалізація асистента.
            isActive = true; // У V1 асистент відразу доступний для команд.
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="voiceTypeValue">Тип голосу</param>
        /// <param name="languageValue">Мова</param>
        public VoiceAssistant(string voiceTypeValue, string languageValue)
        {
            voiceType = voiceTypeValue;
            language = languageValue;
            isActive = true;
        }

        /// <summary>
        /// Повертає або задає значення властивості VoiceType.
        /// </summary>
        public string VoiceType
        {
            get { return voiceType; }
            set { voiceType = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Language.
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості IsActive.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        /// <summary>
        /// Імітує прослуховування команди.
        /// </summary>
        /// <returns>Текст реакції</returns>
        public string Listen()
        {
            return "Голосовий помічник очікує команду.";
        }

        /// <summary>
        /// Імітує озвучування відповіді.
        /// </summary>
        /// <param name="message">Повідомлення</param>
        /// <returns>Озвучене повідомлення</returns>
        public string Speak(string message)
        {
            return "Помічник (" + voiceType + ", " + language + "): " + message;
        }

        /// <summary>
        /// Інтерпретує просту команду користувача.
        /// </summary>
        /// <param name="command">Команда</param>
        /// <returns>Тлумачення команди</returns>
        public string InterpretCommand(string command)
        {
            if (command == "status")
            {
                return Speak("Показую поточний статус холодильника."); // Команда перегляду стану.
            }

            if (command == "cool")
            {
                return Speak("Запускаю цикл охолодження."); // Команда запуску охолодження.
            }

            if (command == "analyze")
            {
                return Speak("Аналізую наявні продукти.");
            }

            if (command == "update")
            {
                return Speak("Розпочинаю оновлення програмного забезпечення.");
            }

            return Speak("Команду отримано, але для неї немає окремого сценарію.");
        }
    }
}
