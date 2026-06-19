namespace LAB_6_V1
{
    /// <summary>
    /// Ізотермічна шафа холодильника.
    /// </summary>
    public class IsothermalCabinet
    {
        private string material;
        private double volume;
        private double currentTemperature;
        private Body body;
        private Door door;
        private ThermalInsulation thermalInsulation;

        /// <summary>
        /// Створює шафу за замовчуванням.
        /// </summary>
        public IsothermalCabinet()
        {
            material = "Пластик і метал";
            volume = 420.0;
            currentTemperature = 4.0;
            body = new Body();
            door = new Door();
            thermalInsulation = new ThermalInsulation();
        }

        /// <summary>
        /// Створює шафу з параметрами.
        /// </summary>
        /// <param name="materialValue">Матеріал</param>
        /// <param name="volumeValue">Об'єм</param>
        /// <param name="temperatureValue">Температура</param>
        public IsothermalCabinet(string materialValue, double volumeValue, double temperatureValue)
        {
            material = materialValue;
            volume = volumeValue;
            currentTemperature = temperatureValue;
            body = new Body();
            door = new Door();
            thermalInsulation = new ThermalInsulation();
        }

        /// <summary>
        /// Повертає або задає значення властивості Material.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості Volume.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості CurrentTemperature.
        /// </summary>
        public double CurrentTemperature
        {
            get { return currentTemperature; }
            set { currentTemperature = value; }
        }

        /// <summary>
        /// Повертає значення властивості Body.
        /// </summary>
        public Body Body
        {
            get { return body; }
        }

        /// <summary>
        /// Повертає значення властивості Door.
        /// </summary>
        public Door Door
        {
            get { return door; }
        }

        /// <summary>
        /// Повертає значення властивості ThermalInsulation.
        /// </summary>
        public ThermalInsulation ThermalInsulation
        {
            get { return thermalInsulation; }
        }

        /// <summary>
        /// Відкрити двері шафи.
        /// </summary>
        /// <returns>Результат дії</returns>
        public string OpenDoor()
        {
            return door.Open();
        }

        /// <summary>
        /// Закрити двері шафи.
        /// </summary>
        /// <returns>Результат дії</returns>
        public string CloseDoor()
        {
            return door.Close();
        }

        /// <summary>
        /// Вимірює температуру всередині шафи.
        /// </summary>
        /// <returns>Температура шафи</returns>
        public string MeasureTemperature()
        {
            return "Поточна температура в шафі: " + currentTemperature.ToString("F1") + " °C.";
        }

        /// <summary>
        /// Повертає узагальнений стан шафи.
        /// </summary>
        /// <returns>Стан шафи</returns>
        public string CheckCabinetState()
        {
            return body.CheckIntegrity() + " " + door.CheckSeal() + " " + thermalInsulation.EvaluateEfficiency();
        }

        /// <summary>
        /// Повертає коротку інформацію про шафу.
        /// </summary>
        /// <returns>Інформація про шафу</returns>
        public string GetCabinetInfo()
        {
            return "матеріал = " + material + ", об'єм = " + volume.ToString("F1") + " л";
        }
    }
}
