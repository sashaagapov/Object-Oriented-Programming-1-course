using System;

namespace Lab3;

public partial class Student
{
    public partial class DiplomaProject
    {
        public double CalculateGrade()
        {
            if (string.IsNullOrEmpty(Topic))
            {
                Console.WriteLine("Тему не обрано! Неможливо розрахувати оцінку.");
                return 0;
            }
            double grade = 50 + (AlgorithmsCount * 10) + (ComplexityLevel * 5);
            if (grade > 100) grade = 100;
            
            Console.WriteLine($"Оцінка за дипломний проєкт '{Topic}': {grade}");
            return grade;
        }
    }
}