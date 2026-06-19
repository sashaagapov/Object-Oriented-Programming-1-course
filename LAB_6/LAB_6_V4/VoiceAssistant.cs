namespace LAB_6_V4
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
            voiceType = "Жіночий"; // Базовий голос для демонстрації голосового сценарію.
            language = "Українська"; // Основна мова взаємодії.
            isActive = true; // Асистент стартує в активному стані.
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
            EnsureAssistantIsAvailable(); // Перевірка доступності модуля перед прослуховуванням.
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
            EnsureAssistantIsAvailable(); // Відразу відсікаємо сценарій, якщо асистент недоступний.

            if (command == "status")
            {
                return Speak("Показую поточний статус холодильника."); // Команда виведення статусу.
            }

            if (command == "cool")
            {
                return Speak("Запускаю цикл охолодження."); // Команда запуску охолодження.
            }

            if (command == "analyze")
            {
                return Speak("Аналізую наявні продукти."); // Команда AI-аналізу продуктів.
            }

            if (command == "update")
            {
                return Speak("Розпочинаю оновлення програмного забезпечення."); // Команда оновлення ПЗ.
            }

            throw new RefrigeratorException(
                "Помилка асистента: Команду '" + command + "' не розпізнано!",
                FridgeErrorType.InvalidVoiceCommand
            );
        }

        /// <summary>
        /// Перевіряє, чи готовий голосовий помічник до роботи.
        /// </summary>
        private void EnsureAssistantIsAvailable()
        {
            if (!isActive || voiceType == string.Empty || language == string.Empty)
            {
                throw new RefrigeratorException(
                    "Критичний збій: Модуль голосового помічника не відповідає!",
                    FridgeErrorType.VoiceAssistantFailure
                );
            }
        }
    }
}
