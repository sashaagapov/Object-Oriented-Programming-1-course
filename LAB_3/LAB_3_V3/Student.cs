using System;
using System.Collections.Generic;
namespace lab3agapov_v3;
/// <summary>
/// Клас Student, який містить поля для зберігання інформації про студента
/// та методи для роботи з цією інформацією, включаючи вкладений клас DiplomaProject для зберігання інформації про дипломний проект студента.
/// </summary>
public partial class Student
{
    private string studentName = "";
    private string subjectName = "";
    private List<int> grades = new List<int>();
    private int tasksDone = 0;
    private DiplomaProject studentDiploma;// Поле для зберігання інформації про дипломний проект студента


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
        studentDiploma = new DiplomaProject();
    }
    /// <summary>
    /// Конструктор з параметрами для класу Student,
    /// який ініціалізує всі поля класу відповідно до переданих аргументів.
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
        studentDiploma = new DiplomaProject();
    }
    /// <summary>
    /// Конструктор копіювання для класу Student,
    ///  який створює новий об'єкт на основі існуючого об'єкта Student, копіюючи всі його поля.
    /// </summary>
    /// <param name="previousStudent"></param>
    public Student(Student previousStudent)
    {
        this.studentName = previousStudent.studentName;
        this.subjectName = previousStudent.subjectName;
        this.grades = new List<int>(previousStudent.grades);
        this.tasksDone = previousStudent.tasksDone;
        this.studentDiploma = previousStudent.studentDiploma;
    }
    /// <summary>
    /// Властивості для доступу до полів класу Student: StudentName, 
    /// SubjectName, Grades та TasksDone. Вони дозволяють отримувати та встановлювати значення відповідних полів.
    /// </summary>
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
    public DiplomaProject Diploma
    {
        get { return studentDiploma; }
        set { studentDiploma = value; }
    }


    /// <summary>
    /// Метод AddGrade, який приймає ціле число grade і додає його до 
    /// списку оцінок студента, а також збільшує кількість виконаних 
    /// завдань на 1. Цей метод використовується для додавання нової 
    /// оцінки студенту та оновлення кількості виконаних завдань відповідно до цієї оцінки.
    /// </summary>
    /// <param name="grade"></param>
    public void AddGrade(int grade)
    {
        grades.Add(grade);
        tasksDone++;
    }
    /// <summary>
    /// Метод CalculateRating, який обчислює та повертає рейтинг 
    /// студента на основі його оцінок та кількості виконаних завдань. Рейтинг розраховується як середнє значення оцінок, якщо студент має хоча б одну оцінку та виконав хоча б одне завдання. Якщо студент не має оцінок або не виконав жодного завдання, то рейтинг повертається як 0. Цей метод використовується для визначення поточного рейтингу студента на основі його успішності у навчанні.
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
        foreach (int grade in grades)
        {
            rating += grade;
        }
        return rating / tasksDone;
    }
    /// <summary>
    /// Метод UpdateSubject, який приймає рядок newSubject і 
    /// оновлює назву предмету, який вивчає студент, на це нове значення.
    ///  Цей метод використовується для зміни назви предмету, який вивчає
    ///  студент, відповідно до переданого аргументу.
    /// </summary>
    public partial class DiplomaProject
    {
        private string nameOfTheme;
        private int numOfCompletedAlgorithms;

        private int dificultyOfTheme;
        private int mark;
        private string nameOfTeacher;
        /// <summary>
        /// Конструктор за замовчуванням для класу DiplomaProject, 
        /// який ініціалізує всі поля класу значеннями за замовчуванням. 
        /// Поля ініціалізуються порожніми рядками або нулями відповідно 
        /// до їх типів даних. Цей конструктор використовується для 
        /// створення об'єкта DiplomaProject з початковими значеннями,
        ///  які можуть бути змінені пізніше за допомогою властивостей або методів класу.
        /// </summary>
        public DiplomaProject()
        {
            nameOfTheme = "";
            numOfCompletedAlgorithms = 0;
            dificultyOfTheme = 0;
            mark = 0;
            nameOfTeacher = "";
        }
        /// <summary>
        /// Властивості для доступу до полів класу DiplomaProject:
        ///  NameOfTheme, NumOfCompletedAlgorithms, NameOfTeacher,
        ///  DificultyOfTheme та Mark. Вони дозволяють отримувати 
        /// та встановлювати значення відповідних полів.
        /// </summary>
        public string NameOfTheme
        {
            get { return nameOfTheme; }
            set { nameOfTheme = value; }
        }
        // ВИПРАВЛЕНО: XML-коментарі до властивостей у вкладеному класі DiplomaProject
        // замінено на короткі та коректні (V3).
        /// <summary>Кількість реалізованих алгоритмів у дипломному проекті.</summary>
        public int NumOfCompletedAlgorithms
        {
            get { return numOfCompletedAlgorithms; }
            set { numOfCompletedAlgorithms = value; }
        }
        /// <summary>Ім'я наукового керівника дипломного проекту.</summary>
        public string NameOfTeacher
        {
            get { return nameOfTeacher; }
            set { nameOfTeacher = value; }
        }
        /// <summary>Складність теми дипломного проекту.</summary>
        public int DificultyOfTheme
        {
            get { return dificultyOfTheme; }
            set { dificultyOfTheme = value; }
        }
        /// <summary>Оцінка за дипломний проект.</summary>
        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

    }

}