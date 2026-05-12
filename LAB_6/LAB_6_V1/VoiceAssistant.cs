namespace lab6agapov_v1
{
    /// <summary>
    /// Голосовий помічник холодильника.
    /// </summary>
    public class VoiceAssistant
    {
        private string voiceType;
        private string language;

        /// <summary>
        /// Ініціалізує голосовий помічник.
        /// </summary>
        public VoiceAssistant(string voiceType, string language)
        {
            this.voiceType = voiceType;
            this.language = language;
        }

        /// <summary>
        /// Тип голосу.
        /// </summary>
        public string VoiceType
        {
            get { return voiceType; }
            set { voiceType = value; }
        }

        /// <summary>
        /// Мова взаємодії.
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        /// <summary>
        /// Виконує дію за командою користувача.
        /// </summary>
        public string PerformUserAction(string action)
        {
            return "Голосовий помічник виконав дію: " + action + ".";
        }
    }
}
