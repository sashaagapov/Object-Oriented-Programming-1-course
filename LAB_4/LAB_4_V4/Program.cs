/*
 * Лабораторна робота №4 — Версія 4 (Фінальна)
 * Суть версії: Стандартні інтерфейси .NET для колекцій, сортування, перебору та глибокого копіювання об'єктів.
 */
using System;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> gradesOne = new List<int>();
            List<int> gradesTwo = new List<int>();
            List<int> gradesThree = new List<int>();
            Teacher teacher;
            Student student;
            Student secondStudent;
            Student thirdStudent;
            Student fourthStudent;
            StudentGroup group;
            Service service;
            Menu menu;

            Console.Clear();

            service = new Service("text", "student_report.txt", "");
            teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 4, "", "Матеріали до лабораторної роботи 4");
            student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            gradesOne.Add(90);
            gradesOne.Add(95);
            gradesOne.Add(88);

            gradesTwo.Add(75);
            gradesTwo.Add(80);

            gradesThree.Add(100);
            gradesThree.Add(96);
            gradesThree.Add(98);
            gradesThree.Add(94);

            secondStudent = new Student("Іваненко Марія", "ООП", gradesOne, 3, "Матеріал до ЛР4", 0);
            thirdStudent = new Student("Петренко Назар", "ООП", gradesTwo, 2, "Матеріал до ЛР4", 0);
            fourthStudent = new Student("Сидоренко Олена", "ООП", gradesThree, 4, "Матеріал до ЛР4", 0);

            group = new StudentGroup();
            group.AddStudent(student);
            group.AddStudent(secondStudent);
            group.AddStudent(thirdStudent);
            group.AddStudent(fourthStudent);

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student, group);

            menu = new Menu();
            teacher.RunScenario(service, menu, student, group);
        }
    }
}
