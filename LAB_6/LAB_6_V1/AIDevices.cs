namespace lab6agapov_v1
{
    /// <summary>
    /// ШІ-пристрої холодильника.
    /// </summary>
    public class AIDevices
    {
        private string moduleType;
        private string manufacturer;
        private AiModule aiModule;
        private Camera camera;

        /// <summary>
        /// Ініціалізує ШІ-пристрої і створює їх складові (композиція).
        /// </summary>
        public AIDevices(string moduleType, string manufacturer)
        {
            this.moduleType = moduleType;
            this.manufacturer = manufacturer;
            aiModule = new AiModule("NutriMind", "HybridML");
            camera = new Camera("4K");
        }

        /// <summary>
        /// Тип модуля.
        /// </summary>
        public string ModuleType
        {
            get { return moduleType; }
            set { moduleType = value; }
        }

        /// <summary>
        /// Виробник пристроїв.
        /// </summary>
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        /// <summary>
        /// AI-модуль.
        /// </summary>
        public AiModule AiModule
        {
            get { return aiModule; }
        }

        /// <summary>
        /// Камера.
        /// </summary>
        public Camera Camera
        {
            get { return camera; }
        }

        /// <summary>
        /// Розпізнає продукти.
        /// </summary>
        public string RecognizeProducts()
        {
            return camera.TakeSnapshot() + " " + camera.IdentifyProducts();
        }

        /// <summary>
        /// Прогнозує потреби користувача.
        /// </summary>
        public string PredictNeeds()
        {
            return aiModule.GenerateRecommendations("Прогноз потреб харчування");
        }

        /// <summary>
        /// Аналізує звички харчування.
        /// </summary>
        public string AnalyzeUserHabits()
        {
            return aiModule.AnalyzeConsumptionData();
        }

        /// <summary>
        /// Рекомендує список покупок.
        /// </summary>
        public string RecommendProductsForPurchase()
        {
            return "Рекомендовано докупити: броколі, гречка, йогурт, лосось.";
        }
    }
}
