namespace lab4agapov_v2
{
    /// <summary>
    /// Базовий клас Person описує спільні дані людини в освітньому процесі.
    /// У другій версії він є abstract.
    /// </summary>
    public abstract class Person
    {
        private string name;
        private string subjectName;

        protected Person()
        {
            name = "";
            subjectName = "";
        }

        protected Person(string name, string subjectName)
        {
            this.name = name;
            this.subjectName = subjectName;
        }

        protected Person(Person other)
        {
            name = other.name;
            subjectName = other.subjectName;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public virtual string GetInfo()
        {
            return "Ім'я: " + name + "\nДисципліна: " + subjectName;
        }
    }
}
