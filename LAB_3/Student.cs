using System;
using System.Collections.Generic;
namespace lab3agapov;

public class Student
{
    private string studentName = "";
    private string subjectName = "";
    private List<int> grades = new List<int>();
    private int tasksDone = 0;
/// <summary>
/// Конструктор за замовчуванням, конструктор з параметрами та конструктор копіювання для класу Student.
/// </summary>
/// <param name="studentName">Ім'я студента.</param>
/// <param name="subjectName">Назва предмету, який вивчає студент
/// </param> <param name="grades">Список оцінок студента.</param>
/// <param name="tasksDone">Кількість виконаних завдань студентом.</param>
    public Student()
    {
        studentName = string.Empty;
        subjectName = string.Empty;
        grades = new List<int>();
        tasksDone = 0;

    }
    /// <summary>
    /// Конструктор з параметрами для класу Student, який ініціалізує всі поля класу відповідно до переданих аргументів.
    /// </summary>
    /// <param name="studentName"></param>
    /// <param name="subjectName"></param>
    /// <param name="grades"></param>
    /// <param name="tasksDone"></param>
    public Student(string studentName, string subjectName, List<int> grades, int tasksDone)
    {
         this.studentName = studentName;
        this.subjectName = subjectName;
        this.grades = grades;
        this.tasksDone = tasksDone;
    }
    /// <summary>
    /// Конструктор копіювання для класу Student, який створює новий об'єкт на основі існуючого об'єкта Student, копіюючи всі його поля.
    /// </summary>
    /// <param name="previousStudent"></param>
        public Student(Student previousStudent)
    {
         this.studentName = previousStudent.studentName;
        this.subjectName = previousStudent.subjectName;
        this.grades = new List<int>(previousStudent.grades);
        this.tasksDone = previousStudent.tasksDone;
    }
/// <summary>
/// Властивості для доступу до полів класу Student: StudentName, SubjectName, Grades та TasksDone. Вони дозволяють отримувати та встановлювати значення відповідних полів.
/// </summary>
    public string StudentName
    {
        get{return studentName; }
        set{studentName = value; }
    }
    public string SubjectName
    {
        get{ return subjectName; }
        set{ subjectName = value; }
    }
    public List<int> Grades
    {
        get{return grades; }
        set{ grades = value; }
    }
    public int TasksDone
    {
        get{return tasksDone; }
        set{ tasksDone = value; }
    }
/// <summary>
/// Метод AddGrade, який приймає ціле число grade і додає його до списку оцінок студента, а також збільшує кількість виконаних завдань на 1. Цей метод використовується для додавання нової оцінки студенту та оновлення кількості виконаних завдань відповідно до цієї оцінки.
/// </summary>
/// <param name="grade"></param>
    public void AddGrade(int grade)
    {
        grades.Add(grade);
        tasksDone++;
    }
    /// <summary>
    /// Метод CalculateRating, який обчислює та повертає рейтинг студента на основі його оцінок та кількості виконаних завдань. Рейтинг розраховується як середнє значення оцінок, якщо студент має хоча б одну оцінку та виконав хоча б одне завдання. Якщо студент не має оцінок або не виконав жодного завдання, то рейтинг повертається як 0. Цей метод використовується для визначення поточного рейтингу студента на основі його успішності у навчанні.
    /// </summary>
    /// <returns></returns>
    public double CalculateRating()
    {
        ArgumentNullException.ThrowIfNull(grades);
       if (grades.Count == 0 || tasksDone == 0)
        {
            return 0;
        }
        double rating = 0;
        foreach(int grade in grades)
        {
            rating += grade;
        }
        return rating/tasksDone;
    }
}