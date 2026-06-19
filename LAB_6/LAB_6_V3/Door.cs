namespace LAB_6_V3
{
    /// <summary>
    /// Двері холодильника.
    /// </summary>
    public class Door
    {
        private string openingType;
        private string sealType;
        private bool isOpen;

        /// <summary>
        /// Конструктор за замовчуванням.
        /// </summary>
        public Door()
        {
            openingType = "Права";
            sealType = "Магнітне ущільнення";
            isOpen = false;
        }

        /// <summary>
        /// Конструктор з параметрами.
        /// </summary>
        /// <param name="openingTypeValue">Тип відкривання</param>
        /// <param name="sealTypeValue">Тип ущільнення</param>
        /// <param name="isOpenValue">Стан дверей</param>
        public Door(string openingTypeValue, string sealTypeValue, bool isOpenValue)
        {
            openingType = openingTypeValue;
            sealType = sealTypeValue;
            isOpen = isOpenValue;
        }

        /// <summary>
        /// Повертає або задає значення властивості OpeningType.
        /// </summary>
        public string OpeningType
        {
            get { return openingType; }
            set { openingType = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості SealType.
        /// </summary>
        public string SealType
        {
            get { return sealType; }
            set { sealType = value; }
        }

        /// <summary>
        /// Повертає або задає значення властивості IsOpen.
        /// </summary>
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }

        /// <summary>
        /// Відкриває двері.
        /// </summary>
        /// <returns>Результат дії</returns>
        public string Open()
        {
            isOpen = true;
            return "Двері холодильника відкрито.";
        }

        /// <summary>
        /// Закриває двері.
        /// </summary>
        /// <returns>Результат дії</returns>
        public string Close()
        {
            isOpen = false;
            return "Двері холодильника закрито.";
        }

        /// <summary>
        /// Перевіряє стан ущільнення.
        /// </summary>
        /// <returns>Стан ущільнення</returns>
        public string CheckSeal()
        {
            return "Ущільнення дверей типу \"" + sealType + "\" працює нормально.";
        }
    }
}
