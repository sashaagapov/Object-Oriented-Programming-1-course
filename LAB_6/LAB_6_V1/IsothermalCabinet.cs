namespace lab6agapov_v1
{
    /// <summary>
    /// Ізотермічна шафа холодильника.
    /// </summary>
    public class IsothermalCabinet
    {
        private string material;
        private double volume;
        private Body body;
        private Door door;
        private Insulation insulation;

        /// <summary>
        /// Ініціалізує шафу з композицією її частин.
        /// </summary>
        public IsothermalCabinet(string material, double volume)
        {
            this.material = material;
            this.volume = volume;
            body = new Body(material, "Silver");
            door = new Door("RightSide", "Magnetic");
            insulation = new Insulation("Polyurethane", 4.5);
        }

        /// <summary>
        /// Матеріал шафи.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Об'єм шафи.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        /// <summary>
        /// Корпус шафи (композиція).
        /// </summary>
        public Body Body
        {
            get { return body; }
        }

        /// <summary>
        /// Двері шафи (композиція).
        /// </summary>
        public Door Door
        {
            get { return door; }
        }

        /// <summary>
        /// Теплоізоляція шафи (композиція).
        /// </summary>
        public Insulation Insulation
        {
            get { return insulation; }
        }

        /// <summary>
        /// Відкриває двері шафи.
        /// </summary>
        public string OpenDoor()
        {
            return door.OpenDoor();
        }

        /// <summary>
        /// Закриває двері шафи.
        /// </summary>
        public string CloseDoor()
        {
            return door.CloseDoor();
        }

        /// <summary>
        /// Вимірює температуру в шафі.
        /// </summary>
        public double MeasureTemperature()
        {
            return 4.2;
        }
    }
}
