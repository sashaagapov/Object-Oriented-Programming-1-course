namespace lab6agapov_v1
{
    /// <summary>
    /// Камера в складі ШІ-пристроїв.
    /// </summary>
    public class Camera
    {
        private string resolution;

        /// <summary>
        /// Ініціалізує камеру.
        /// </summary>
        public Camera(string resolution)
        {
            this.resolution = resolution;
        }

        /// <summary>
        /// Роздільна здатність камери.
        /// </summary>
        public string Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        /// <summary>
        /// Робить знімок внутрішнього вмісту.
        /// </summary>
        public string TakeSnapshot()
        {
            return "Камера зробила знімок вмісту холодильника.";
        }

        /// <summary>
        /// Ідентифікує продукти на знімку.
        /// </summary>
        public string IdentifyProducts()
        {
            return "Ідентифіковано продукти: молоко, яблука, курка, сир.";
        }
    }
}
