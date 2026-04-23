using System;
using System.Collections.Generic;
namespace lab3agapov_v1;

/// <summary>
/// Клас Student, який містить поля для зберігання інформації про студента
/// та методи для роботи з цією інформацією.
/// </summary>
public class Student
{
    private string studentName = "";
    private string subjectName = "";
    private List<int> grades = new List<int>();
    private int tasksDone = 0;

    public Student()
    {
        studentName = string.Empty;
        subjectName = string.Empty;
        grades = new List<int>();
        tasksDone = 0;
    }

    public Student(string studentName, string subjectName, List<int> grades, int tasksDone)
    {
        this.studentName = studentName;
        this.subjectName = subjectName;
        this.grades = grades;
        this.tasksDone = tasksDone;
    }

    public Student(Student previousStudent)
    {
        this.studentName = previousStudent.studentName;
        this.subjectName = previousStudent.subjectName;
        this.grades = new List<int>(previousStudent.grades);
        this.tasksDone = previousStudent.tasksDone;
    }

    public string StudentName
    {
        get { return studentName; }
        set { studentName = value; }
    }
    public string SubjectName
    {
        get { return subjectName; }
        set { subjectName = value; }
    }
    public List<int> Grades
    {
        get { return grades; }
        set { grades = value; }
    }
    public int TasksDone
    {
        get { return tasksDone; }
        set { tasksDone = value; }
    }

    /// <summary>Додає оцінку та збільшує лічильник виконаних завдань.</summary>
    public void AddGrade(int grade)
    {
        grades.Add(grade);
        tasksDone++;
    }

    /// <summary>Середнє арифметичне оцінок. Якщо оцінок немає — повертає 0.</summary>
    public double CalculateRating()
    {
        if (grades.Count == 0 || tasksDone == 0)
            return 0;
        double rating = 0;
        foreach (int grade in grades)
            rating += grade;
        return rating / tasksDone;
    }
}