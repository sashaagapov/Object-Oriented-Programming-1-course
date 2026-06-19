namespace LAB_6_V4
{
    /// <summary>
    /// AI-модуль холодильника.
    /// </summary>
    public class AiModule
    {
        private string model;
        private string algorithmType;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public AiModule()
        {
            model = "FoodVision";
            algorithmType = "Pattern Analysis";
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="modelValue">Модель</param>
        /// <param name="algorithmTypeValue">Тип алгоритму</param>
        public AiModule(string modelValue, string algorithmTypeValue)
        {
            model = modelValue;
            algorithmType = algorithmTypeValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Model.
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості AlgorithmType.
        /// </summary>
        public string AlgorithmType
        {
            get { return algorithmType; }
            set { algorithmType = value; }
        }

        /// <summary>
        /// Імітує навчання на звичках користувача.
        /// </summary>
        /// <returns>Результат навчання</returns>
        public string Learn()
        {
            return "AI-модуль вивчає звички користувача.";
        }

        /// <summary>
        /// Імітує генерацію рекомендацій.
        /// </summary>
        /// <returns>Рекомендації</returns>
        public string GenerateRecommendations()
        {
            return "AI рекомендує додати овочі, молочні продукти та питну воду.";
        }

        /// <summary>
        /// Імітує аналіз споживання.
        /// </summary>
        /// <returns>Результат аналізу</returns>
        public string AnalyzeConsumptionData()
        {
            return "AI визначив, що запаси фруктів і йогуртів потрібно поповнити.";
        }
    }
}
