namespace LAB_6_V3
{
    /// <summary>
    /// Камера для розпізнавання продуктів.
    /// </summary>
    public class Camera
    {
        private string resolution;
        private string lastDetectedProduct;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Camera()
        {
            resolution = "1920x1080";
            lastDetectedProduct = "Молоко";
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="resolutionValue">Роздільна здатність</param>
        /// <param name="lastDetectedProductValue">Останній продукт</param>
        public Camera(string resolutionValue, string lastDetectedProductValue)
        {
            resolution = resolutionValue;
            lastDetectedProduct = lastDetectedProductValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості Resolution.
        /// </summary>
        public string Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості LastDetectedProduct.
        /// </summary>
        public string LastDetectedProduct
        {
            get { return lastDetectedProduct; }
            set { lastDetectedProduct = value; }
        }

        /// <summary>
        /// Імітує створення знімка.
        /// </summary>
        /// <returns>Результат зйомки</returns>
        public string TakePhoto()
        {
            return "Камера зробила знімок внутрішнього простору холодильника.";
        }

        /// <summary>
        /// Імітує розпізнавання продуктів.
        /// </summary>
        /// <returns>Результат розпізнавання</returns>
        public string IdentifyProducts()
        {
            return TakePhoto() + " Виявлено продукт: " + lastDetectedProduct + ".";
        }
    }
}
