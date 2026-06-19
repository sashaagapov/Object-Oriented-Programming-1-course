namespace LAB_6_V1
{
    /// <summary>
    /// Контейнер AI-пристроїв холодильника.
    /// </summary>
    public class AiDevices
    {
        private string moduleType;
        private string manufacturer;
        private AiModule aiModule;
        private Camera camera;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public AiDevices()
        {
            moduleType = "AI Food Assistant";
            manufacturer = "SmartTech";
            aiModule = new AiModule();
            camera = new Camera();
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="moduleTypeValue">Тип модуля</param>
        /// <param name="manufacturerValue">Виробник</param>
        public AiDevices(string moduleTypeValue, string manufacturerValue)
        {
            moduleType = moduleTypeValue;
            manufacturer = manufacturerValue;
            aiModule = new AiModule();
            camera = new Camera();
        }

        /// <summary>
        /// Повертає або задає значення властивості ModuleType.
        /// </summary>
        public string ModuleType
        {
            get { return moduleType; }
            set { moduleType = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        /// <summary>
        /// Повертає значення властивості AiModule.
        /// </summary>
        public AiModule AiModule
        {
            get { return aiModule; }
        }

        /// <summary>
        /// Повертає значення властивості Camera.
        /// </summary>
        public Camera Camera
        {
            get { return camera; }
        }

        /// <summary>
        /// Імітує розпізнавання продуктів.
        /// </summary>
        /// <returns>Результат розпізнавання</returns>
        public string RecognizeProducts()
        {
            return camera.IdentifyProducts();
        }

        /// <summary>
        /// Імітує прогнозування потреб користувача.
        /// </summary>
        /// <returns>Рекомендація по продуктах</returns>
        public string PredictNeeds()
        {
            return aiModule.AnalyzeConsumptionData();
        }

        /// <summary>
        /// Імітує аналіз звичок користувача.
        /// </summary>
        /// <returns>Результат аналізу</returns>
        public string AnalyzeUserHabits()
        {
            return aiModule.Learn();
        }

        /// <summary>
        /// Імітує рекомендації до закупівлі.
        /// </summary>
        /// <returns>Рекомендації</returns>
        public string RecommendProducts()
        {
            return aiModule.GenerateRecommendations();
        }

        /// <summary>
        /// Повертає коротку інформацію про AI-пристрої.
        /// </summary>
        /// <returns>Короткий опис</returns>
        public string GetSummary()
        {
            return "тип = " + moduleType + ", виробник = " + manufacturer;
        }
    }
}
