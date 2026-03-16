namespace lab3agapov;

public class Person
{
    protected string name;
    protected string subjectName;

    // Конструктор за замовчуванням
    protected Person()
    {
        name = string.Empty;
        subjectName = string.Empty;
    }

    // Конструктор з параметрами
    protected Person(string name, string subjectName)
    {
        this.name = name;
        this.subjectName = subjectName;
    }

    // Властивості для доступу
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
}