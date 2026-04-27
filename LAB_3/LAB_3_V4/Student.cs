using System;
using System.Collections.Generic;
namespace lab3agapov;
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
    /// Порожній конструктор — усі поля ініціалізуються нулями або порожніми значеннями.
    /// </summary>
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
    /// <param name="studentName">Ім'я студента.</param>
    /// <param name="subjectName">Назва предмета.</param>
    /// <param name="grades">Список поточних оцінок студента.</param>
    /// <param name="tasksDone">Кількість виконаних завдань.</param>
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
    /// <param name="previousStudent">Існуючий об'єкт студента для копіювання.</param>
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
    /// <summary>
    /// Назва дисципліни, з якою пов'язаний поточний об'єкт. Властивість відкриває контрольований доступ до внутрішнього поля.
    /// </summary>
    public string SubjectName
    {
        get { return subjectName; }
        set { subjectName = value; }
    }
    /// <summary>
    /// Колекція поточних оцінок студента, що використовується для обчислення рейтингу.
    /// </summary>
    public List<int> Grades
    {
        get { return grades; }
        set { grades = value; }
    }
    /// <summary>
    /// Кількість виконаних завдань студента. Використовується разом зі списком оцінок при розрахунку рейтингу.
    /// </summary>
    public int TasksDone
    {
        get { return tasksDone; }
        set { tasksDone = value; }
    }
    /// <summary>
    /// Дані дипломного проєкту, пов'язаного з поточним студентом.
    /// </summary>
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
    /// <param name="grade">Оцінка, яку потрібно додати до списку.</param>
    public void AddGrade(int grade)
    {
        grades.Add(grade);
        tasksDone++;
    }
    /// <summary>
    /// Метод CalculateRating, який обчислює та повертає рейтинг 
    /// студента на основі його оцінок та кількості виконаних завдань. Рейтинг розраховується як середнє значення оцінок, якщо студент має хоча б одну оцінку та виконав хоча б одне завдання. Якщо студент не має оцінок або не виконав жодного завдання, то рейтинг повертається як 0. Цей метод використовується для визначення поточного рейтингу студента на основі його успішності у навчанні.
    /// </summary>
    /// <returns>Повертає середній рейтинг студента або 0, якщо оцінки відсутні.</returns>
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
    /// Вкладений partial-клас DiplomaProject зберігає дані дипломного проєкту студента.
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
        /// <summary>
        /// Кількість реалізованих алгоритмів у дипломному проекті.
        /// </summary>
        public int NumOfCompletedAlgorithms
        {
            get { return numOfCompletedAlgorithms; }
            set { numOfCompletedAlgorithms = value; }
        }
        /// <summary>
        /// Ім'я наукового керівника дипломного проекту.
        /// </summary>
        public string NameOfTeacher
        {
            get { return nameOfTeacher; }
            set { nameOfTeacher = value; }
        }
        /// <summary>
        /// Складність теми дипломного проекту.
        /// </summary>
        public int DificultyOfTheme
        {
            get { return dificultyOfTheme; }
            set { dificultyOfTheme = value; }
        }
        /// <summary>
        /// Оцінка за дипломний проект.
        /// </summary>
        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

    }

}
