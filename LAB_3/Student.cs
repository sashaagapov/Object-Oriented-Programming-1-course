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
    public DiplomaProject Diploma
    {
        get { return studentDiploma; }
        set { studentDiploma = value; }
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
        private string _nameOfTheme;
        private int _numOfCompletedAlgorithms;

        private int _dificultyOfTheme;
        private int _mark;
        private string _nameOfTeacher;
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
            _nameOfTheme = "";
            _numOfCompletedAlgorithms = 0;
            _dificultyOfTheme = 0;
            _mark = 0;
            _nameOfTeacher = "";
        }
        /// <summary>
        /// Властивості для доступу до полів класу DiplomaProject:
        ///  NameOfTheme, NumOfCompletedAlgorithms, NameOfTeacher,
        ///  DificultyOfTheme та Mark. Вони дозволяють отримувати 
        /// та встановлювати значення відповідних полів.
        /// </summary>
        public string NameOfTheme
        {
            get { return _nameOfTheme; }
            set { _nameOfTheme = value; }
        }
        /// <summary>
        /// Метод ChooseTheme, який дозволяє студенту вибрати тему 
        /// для дипломного проекту. Метод запитує у користувача 
        /// ключове слово для пошуку теми, а потім зчитує всі теми 
        /// з файлу "themes.txt" та виводить ті, які містять введене 
        /// ключове слово. Якщо файл не знайдено, виводиться повідомлення
        ///  про помилку. Якщо теми за таким ключовим словом не 
        /// знайдено, також виводиться відповідне повідомлення.
        ///  Цей метод використовується для допомоги студенту у 
        /// виборі теми для його дипломного проекту на основі 
        /// доступних тем у файлі.
        /// </summary>
        public int NumOfCompletedAlgorithms
        {
            get { return _numOfCompletedAlgorithms; }
            set { _numOfCompletedAlgorithms = value; }
        }
        /// <summary>
        /// Метод CalculateDifficulty, який обчислює складність теми 
        /// дипломного проекту на основі кількості реалізованих 
        /// алгоритмів та їх складності. Метод запитує у користувача 
        /// кількість реалізованих алгоритмів, а потім для 
        /// кожного алгоритму запитує його складність (від 1 до 10). 
        /// Загальна складність теми обчислюється як сума 
        /// складностей усіх алгоритмів. Цей метод використовується
        ///  для визначення загальної складності теми дипломного 
        /// проекту на основі реалізованих алгоритмів та їх складності.
        /// </summary>
        public string NameOfTeacher
        {
            get { return _nameOfTeacher; }
            set { _nameOfTeacher = value; }
        }
        /// <summary>
        /// Метод AssignMark, який призначає оцінку студенту на 
        /// основі складності теми дипломного проекту. 
        /// Оцінка розраховується як добуток складності теми та 
        /// коефіцієнта 4. Якщо розрахована оцінка перевищує 100,
        ///  то вона встановлюється на рівні 100. Цей метод 
        /// використовується для визначення оцінки студента за 
        /// його дипломний проект на основі складності вибраної теми.
        /// </summary>
        public int DificultyOfTheme
        {
            get { return _dificultyOfTheme; }
            set { _dificultyOfTheme = value; }
        }
        /// <summary>
        /// Метод AssignMark, який призначає оцінку студенту на
        ///  основі складності теми дипломного проекту. Оцінка 
        /// розраховується як добуток складності теми та коефіцієнта 
        /// 4. Якщо розрахована оцінка перевищує 100, то вона 
        /// встановлюється на рівні 100. Цей метод використовується 
        /// для визначення оцінки студента за його дипломний 
        /// проект на основі складності вибраної теми.
        /// </summary>
        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

    }

}