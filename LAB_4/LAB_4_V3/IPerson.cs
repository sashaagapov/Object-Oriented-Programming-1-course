namespace lab4agapov;

public interface IPerson
{
    string Name { get; set; }
    string SubjectName { get; set; }
    void DisplayInfo(); // Метод, який мають реалізувати всі
}