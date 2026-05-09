using System;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");
            service.PrintToConsole("Програму запущено.");

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            IPerson demoPerson = teacher;
            service.PrintToConsole("Демонстрація IPerson: " + demoPerson.Name);

            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            StudentGroup group = new StudentGroup();
            List<int> gradesOne = new List<int>();
            List<int> gradesTwo = new List<int>();
            List<int> gradesThree = new List<int>();

            gradesOne.Add(90);
            gradesOne.Add(95);
            gradesOne.Add(88);

            gradesTwo.Add(75);
            gradesTwo.Add(80);

            gradesThree.Add(100);
            gradesThree.Add(96);
            gradesThree.Add(98);
            gradesThree.Add(94);

            Student secondStudent = new Student("Іваненко Марія", "ООП", gradesOne, 3, "Матеріал до ЛР4", 0);
            Student thirdStudent = new Student("Петренко Назар", "ООП", gradesTwo, 2, "Матеріал до ЛР4", 0);
            Student fourthStudent = new Student("Сидоренко Олена", "ООП", gradesThree, 4, "Матеріал до ЛР4", 0);

            group.AddStudent(student);
            group.AddStudent(secondStudent);
            group.AddStudent(thirdStudent);
            group.AddStudent(fourthStudent);

            teacher.GiveMaterial(student);
            teacher.GradeStudent(student, 95);
            student.CalculateRating();
            service.PrintToConsole("Викладач передав матеріал і поставив оцінку основному студенту.");

            group.SortStudents();
            service.PrintToConsole("Групу відсортовано за рейтингом через IComparable<Student>.");

            group.SortByTasks();
            service.PrintToConsole("Групу відсортовано за кількістю робіт через IComparer<Student>.");

            Menu menu = new Menu(service, teacher, student, group);
            menu.Run();

            service.PrintToConsole("Фінальний звіт буде збережено у файл student_report.txt.");
            service.SaveReport(teacher, student);
        }
    }
}
