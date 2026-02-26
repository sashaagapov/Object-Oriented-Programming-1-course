using System;

namespace lab3agapov;
public class Teacher
{
    private string teacherName;
    private string subjectName;
    private int subjectHours = 0;
    private int quantityOfStudents = 0;
/// <summary>
/// Конструктор за замовчуванням, конструктор з параметрами та конструктор копіювання для класу Teacher.
/// </summary>
/// <param name="teacherName">Ім'я викладача.</param>
/// <param name="subjectName">Назва предмету, який викладає викладач.</param>
/// <param name="subjectHours">Кількість годин, відведених на викладання предмету.</param>
/// <param name="quantityOfStudents">Кількість студентів, які навчаються у викладача.</param>
    public Teacher()
    {
        teacherName = string.Empty;
        subjectName = string.Empty;
        subjectHours = 0;
        quantityOfStudents = 0;
    }
    /// <summary>
    /// Конструктор з параметрами для класу Teacher, який ініціалізує всі поля класу відповідно до переданих аргументів.
    /// </summary>
    /// <param name="teacherName"></param>
    /// <param name="subjectName"></param>
    /// <param name="subjectHours"></param>
    /// <param name="quantityOfStudents"></param>
    public Teacher(string teacherName, string subjectName, int subjectHours, int quantityOfStudents)
    {
        this.teacherName = teacherName;
        this.subjectName = subjectName;
        this.subjectHours = subjectHours;
        this.quantityOfStudents = quantityOfStudents;
    }
    /// <summary>
    /// Конструктор копіювання для класу Teacher, який створює новий об'єкт на основі існуючого об'єкта Teacher, копіюючи всі його поля.
    /// </summary>
    /// <param name="previousTeacher"></param>
    public Teacher(Teacher previousTeacher)
    {
        this.teacherName = previousTeacher.teacherName;
        this.subjectName = previousTeacher.subjectName;
        this.subjectHours = previousTeacher.subjectHours;
        this.quantityOfStudents = previousTeacher.quantityOfStudents;
    }
    /// <summary>
    /// Властивості для доступу до полів класу Teacher: TeacherName, SubjectName, SubjectHours та QuantityOfStudents. Вони дозволяють отримувати та встановлювати значення відповідних полів.
    /// </summary>
    public string TeacherName
    {
        get{ return teacherName; }
        set{ teacherName = value; }
    }
    public string SubjectName
    {
        get{ return subjectName; }
        set{ subjectName = value; }
    }
    public int SubjectHours
    {
        get{ return subjectHours; }
        set{ subjectHours = value; }
    }
    public int QuantityOfStudents
    {
        get{ return quantityOfStudents; }
        set{ quantityOfStudents = value;}
    }
/// <summary>
/// Метод UpdateStudentCount, який приймає ціле число difference і оновлює кількість студентів та години викладання відповідно до цього числа. Якщо difference додано до quantityOfStudents не призводить до від'ємного значення, то quantityOfStudents оновлюється на це нове значення. Якщо difference додано до quantityOfStudents не призводить до від'ємного значення, то subjectHours оновлюється на це нове значення, яке є поточним subjectHours плюс двічі difference. Якщо ж додавання difference до quantityOfStudents призводить до від'ємного значення, то метод просто повертається без змін.
/// </summary>
/// <param name="difference"></param>
    public void UpdateStudentCount(int difference)
    {
        if(quantityOfStudents + difference >= 0)
        {
            quantityOfStudents += difference;
            if(difference * 2 >= 0)
            {
                subjectHours += difference * 2;
            }
        }
        else
        {
            return;
        }
    }


}