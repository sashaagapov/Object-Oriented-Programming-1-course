using System;
using System.Collections.Generic;

namespace lab5agapov_v3
{
    /// <summary>
    /// Точка входу для демонстрації функціоналу лабораторної роботи (Версія 3).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Запускає демонстрацію V2-функціоналу і додаткових можливостей V3.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Service service = new Service();

            Person teacherPerson = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "Журнал оцінок з ООП", "Методичка з ООП");
            Person studentPerson = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "Методичка з ООП", 85.0);

            service.PrintAndSave("--- Демонстрація динамічного поліморфізму ---");
            service.PrintAndSave(teacherPerson.GetInfo());
            service.PrintAndSave("");
            service.PrintAndSave(studentPerson.GetInfo());

            service.PrintAndSave("");
            service.PrintAndSave("--- Демонстрація статичного поліморфізму: перевантаження операторів ---");

            DiplomaProject project1 = new DiplomaProject("Система обліку навчальних результатів", 3, "Середня", 85, "Ковалюк Т.В.");
            DiplomaProject project2 = new DiplomaProject("Інформаційна система кафедри", 5, "Висока", 95, "Ковалюк Т.В.");

            service.PrintAndSave("");
            service.PrintAndSave("Оператори DiplomaProject:");
            service.PrintAndSave("Початковий project1: " + project1.GetInfo());
            service.PrintAndSave("Початковий project2: " + project2.GetInfo());

            project1 = project1 + 2;
            service.PrintAndSave("Після project1 + 2: " + project1.GetInfo());

            project1 = project1 - 1;
            service.PrintAndSave("Після project1 - 1: " + project1.GetInfo());

            project1++;
            service.PrintAndSave("Після project1++: " + project1.GetInfo());

            project1--;
            service.PrintAndSave("Після project1--: " + project1.GetInfo());

            service.PrintAndSave("project1 > project2: " + (project1 > project2));
            service.PrintAndSave("project1 < project2: " + (project1 < project2));
            service.PrintAndSave("project1 == project2: " + (project1 == project2));
            service.PrintAndSave("project1 != project2: " + (project1 != project2));

            Student student1 = new Student("Агапов Олександр", "ООП", new List<int> { 90, 95 }, 2, "Методичка з ООП", 85.0);
            Student student2 = new Student("Інший студент", "ООП", new List<int> { 70, 75 }, 2, "Конспект з ООП", 70.0);

            service.PrintAndSave("");
            service.PrintAndSave("Оператори Student:");
            service.PrintAndSave("Початковий student1:");
            service.PrintAndSave(student1.GetInfo());

            service.PrintAndSave("Початковий student2:");
            service.PrintAndSave(student2.GetInfo());

            student1 = student1 + 100;
            service.PrintAndSave("Після student1 + 100:");
            service.PrintAndSave(student1.GetInfo());

            student1 = student1 - 90;
            service.PrintAndSave("Після student1 - 90:");
            service.PrintAndSave(student1.GetInfo());

            student1++;
            service.PrintAndSave("Після student1++:");
            service.PrintAndSave(student1.GetInfo());

            student1--;
            service.PrintAndSave("Після student1--:");
            service.PrintAndSave(student1.GetInfo());

            service.PrintAndSave("student1 > student2: " + (student1 > student2));
            service.PrintAndSave("student1 < student2: " + (student1 < student2));
            service.PrintAndSave("student1 == student2: " + (student1 == student2));
            service.PrintAndSave("student1 != student2: " + (student1 != student2));

            Teacher teacher1 = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "Журнал оцінок з ООП", "Методичка з ООП");
            Teacher teacher2 = new Teacher("Інший викладач", "ООП", 80, 1, "Журнал оцінок з ООП", "Конспект з ООП");

            service.PrintAndSave("");
            service.PrintAndSave("Оператори Teacher:");
            service.PrintAndSave("Початковий teacher1:");
            service.PrintAndSave(teacher1.GetInfo());

            service.PrintAndSave("Початковий teacher2:");
            service.PrintAndSave(teacher2.GetInfo());

            teacher1 = teacher1 + 3;
            service.PrintAndSave("Після teacher1 + 3:");
            service.PrintAndSave(teacher1.GetInfo());

            teacher1 = teacher1 - 1;
            service.PrintAndSave("Після teacher1 - 1:");
            service.PrintAndSave(teacher1.GetInfo());

            teacher1++;
            service.PrintAndSave("Після teacher1++:");
            service.PrintAndSave(teacher1.GetInfo());

            teacher1--;
            service.PrintAndSave("Після teacher1--:");
            service.PrintAndSave(teacher1.GetInfo());

            service.PrintAndSave("teacher1 > teacher2: " + (teacher1 > teacher2));
            service.PrintAndSave("teacher1 < teacher2: " + (teacher1 < teacher2));
            service.PrintAndSave("teacher1 == teacher2: " + (teacher1 == teacher2));
            service.PrintAndSave("teacher1 != teacher2: " + (teacher1 != teacher2));

            service.PrintAndSave("");
            service.PrintAndSave("--- Демонстрація Версії 3: StudentGroup та індексатор ---");

            StudentGroup group = new StudentGroup();
            group.AddStudent(student1);
            group.AddStudent(student2);

            service.PrintAndSave("Кількість студентів у групі: " + group.Count);
            service.PrintAndSave("group[0]:");
            service.PrintAndSave(group[0].GetInfo());
            service.PrintAndSave("group[1]:");
            service.PrintAndSave(group[1].GetInfo());

            // Через set індексатора замінюємо студента за конкретною позицією.
            group[1] = new Student("Замінений студент", "ООП", new List<int> { 88, 92 }, 2, "Новий конспект", 0);
            service.PrintAndSave("Після заміни group[1]:");
            service.PrintAndSave(group[1].GetInfo());

            service.PrintAndSave("");
            service.PrintAndSave("--- Демонстрація конструктора копії DiplomaProject ---");

            DiplomaProject originalProject = new DiplomaProject("Аналітика освітніх процесів", 4, "Середня", 90, "Ковалюк Т.В.");
            DiplomaProject copiedProject = new DiplomaProject(originalProject);

            service.PrintAndSave("Оригінал (до змін копії): " + originalProject.GetInfo());
            service.PrintAndSave("Копія (до змін): " + copiedProject.GetInfo());

            // Міняємо лише копію і перевіряємо, що оригінал лишається без змін.
            copiedProject.ThemeName = "Модифікована тема копії";
            copiedProject.Mark = 75;

            service.PrintAndSave("Оригінал (після змін копії): " + originalProject.GetInfo());
            service.PrintAndSave("Копія (після змін): " + copiedProject.GetInfo());

            service.SaveProtocolToFile("lab5_v3_protocol.txt");
        }
    }
}
