namespace lab6agapov_v1
{
    /// <summary>
    /// Двері ізотермічної шафи.
    /// </summary>
    public class Door
    {
        private string openingType;
        private string sealingType;
        private bool isOpen;

        /// <summary>
        /// Ініціалізує двері параметрами відкривання та ущільнення.
        /// </summary>
        public Door(string openingType, string sealingType)
        {
            this.openingType = openingType;
            this.sealingType = sealingType;
            isOpen = false;
        }

        /// <summary>
        /// Тип відкривання.
        /// </summary>
        public string OpeningType
        {
            get { return openingType; }
            set { openingType = value; }
        }

        /// <summary>
        /// Тип ущільнення.
        /// </summary>
        public string SealingType
        {
            get { return sealingType; }
            set { sealingType = value; }
        }

        /// <summary>
        /// Ознака відкритих дверей.
        /// </summary>
        public bool IsOpen
        {
            get { return isOpen; }
        }

        /// <summary>
        /// Відкриває двері.
        /// </summary>
        public string OpenDoor()
        {
            isOpen = true;
            return "Двері холодильника відкрито.";
        }

        /// <summary>
        /// Закриває двері.
        /// </summary>
        public string CloseDoor()
        {
            isOpen = false;
            return "Двері холодильника закрито.";
        }

        /// <summary>
        /// Виконує контроль ущільнення дверей.
        /// </summary>
        public string ControlSealing()
        {
            return "Ущільнення " + sealingType + " працює коректно.";
        }
    }
}
