namespace lab4agapov;

public class Person : IPerson // 1. Прибрали abstract, 2. Додали IPerson
{
    protected string name;
    protected string subjectName;

    protected Person()
    {
        name = string.Empty;
        subjectName = string.Empty;
    }

    protected Person(string name, string subjectName)
    {
        this.name = name;
        this.subjectName = subjectName;
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

    // 3. Реалізація методу з інтерфейсу (virtual дозволяє перевизначення у спадкоємцях)
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Особа: {Name}, Предмет: {SubjectName}");
    }
}