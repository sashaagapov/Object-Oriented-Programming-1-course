namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Menu керує сценаріями третьої версії програми.
    /// Він працює з викладачем, студентом і дипломним проєктом, а сам лише координує виклики методів.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Сервіс для введення, виведення та збереження звіту.
        /// </summary>
        private Service service;
        /// <summary>
        /// Викладач, який взаємодіє зі студентом.
        /// </summary>
        private Teacher teacher;
        /// <summary>
        /// Студент, для якого ведуться оцінки, матеріали та дипломний проєкт.
        /// </summary>
        private Student student;

        /// <summary>
        /// Конструктор за замовчуванням створює меню з новими порожніми об'єктами.
        /// </summary>
        public Menu()
        {
            service = new Service();
            teacher = new Teacher();
            student = new Student();
        }

        /// <summary>
        /// Конструктор з параметрами створює меню для вже підготовлених об'єктів.
        /// </summary>
        /// <param name="service">Сервіс для консолі та файлів.</param>
        /// <param name="teacher">Викладач освітнього процесу.</param>
        /// <param name="student">Студент освітнього процесу.</param>
        public Menu(Service service, Teacher teacher, Student student)
        {
            this.service = service;
            this.teacher = teacher;
            this.student = student;
        }

        /// <summary>
        /// Конструктор копії створює меню з копіями сервісу, викладача і студента.
        /// </summary>
        /// <param name="other">Меню, з якого копіюються об'єкти.</param>
        public Menu(Menu other)
        {
            service = new Service(other.service);
            teacher = new Teacher(other.teacher);
            student = new Student(other.student);
        }

        /// <summary>
        /// Запускає цикл меню та виконує команди, які обирає користувач.
        /// </summary>
        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                service.PrintToConsole("\n--- Меню освітнього процесу ---");
                service.PrintToConsole("1. Показати інформацію про викладача та студента");
                service.PrintToConsole("2. Викладач: змінити кількість годин навантаження");
                service.PrintToConsole("3. Викладач: передати навчальний матеріал студенту");
                service.PrintToConsole("4. Викладач: поставити оцінку студенту");
                service.PrintToConsole("5. Зберегти результати у файл");
                service.PrintToConsole("6. Викладач: збільшити кількість студентів");
                service.PrintToConsole("7. Викладач: зменшити кількість студентів");
                service.PrintToConsole("8. Робота з дипломним проєктом");
                service.PrintToConsole("0. Вийти");
                service.PrintToConsole("Оберіть пункт:");

                string choice = service.ReadFromConsole();

                switch (choice)
                {
                    case "1":
                        ShowInformation();
                        break;
                    case "2":
                        ChangeTeacherHours();
                        break;
                    case "3":
                        GiveMaterialToStudent();
                        break;
                    case "4":
                        GradeStudent();
                        break;
                    case "5":
                        SaveData();
                        break;
                    case "6":
                        IncreaseStudents();
                        break;
                    case "7":
                        DecreaseStudents();
                        break;
                    case "8":
                        WorkWithDiplomaProject();
                        break;
                    case "0":
                        isRunning = false;
                        service.PrintToConsole("Програму завершено");
                        break;
                    default:
                        service.PrintToConsole("Невідома команда");
                        break;
                }
            }
        }

        /// <summary>
        /// Показує поточну інформацію про викладача, студента і дипломний проєкт.
        /// </summary>
        private void ShowInformation()
        {
            service.PrintToConsole("\nВикладач: " + teacher.TeacherName);
            service.PrintToConsole("Дисципліна викладача: " + teacher.SubjectName);
            service.PrintToConsole("Навчальне навантаження: " + teacher.StudyHours);
            service.PrintToConsole("Кількість студентів: " + teacher.QuantityOfStudents);
            service.PrintToConsole("Навчальний матеріал викладача: " + teacher.StudyMaterial);
            service.PrintToConsole("Журнал оцінок:\n" + teacher.GradesJournal);
            service.PrintToConsole("Студент: " + student.StudentName);
            service.PrintToConsole("Дисципліна студента: " + student.SubjectName);
            service.PrintToConsole("Оцінки студента: " + student.ViewGrades());
            service.PrintToConsole("Обсяг виконаних робіт: " + student.TasksDone);
            service.PrintToConsole("Рейтинг студента: " + student.CalculateRating());
            service.PrintToConsole("Отриманий матеріал: " + student.DownloadedMaterial);
            service.PrintToConsole("Тема дипломного проєкту: " + student.Diploma.ThemeName);
            service.PrintToConsole("Оцінка за дипломний проєкт: " + student.Diploma.Grade);
        }

        /// <summary>
        /// Змінює навчальне навантаження викладача після коректного числового введення.
        /// </summary>
        private void ChangeTeacherHours()
        {
            int newHours;

            newHours = ReadNumberInRange("Введіть нову кількість годин навчального навантаження", 0, 300);
            teacher.ChangeStudyHours(newHours);
            service.PrintToConsole("Години успішно змінено");
        }

        /// <summary>
        /// Організовує передачу навчального матеріалу від викладача до студента.
        /// </summary>
        private void GiveMaterialToStudent()
        {
            string material;

            material = ReadNotEmptyText("Введіть назву матеріалу");
            teacher.StudyMaterial = material;
            teacher.GiveMaterial(student);
            service.PrintToConsole("Матеріал передано студенту");
        }

        /// <summary>
        /// Запускає виставлення оцінки студенту через викладача.
        /// </summary>
        private void GradeStudent()
        {
            int grade;

            grade = ReadNumberInRange("Введіть оцінку студента", 0, 100);
            teacher.GradeStudent(student, grade);
            service.PrintToConsole("Оцінку виставлено і записано в журнал");
        }

        /// <summary>
        /// Передає сервісу поточні об'єкти для формування та збереження звіту.
        /// </summary>
        private void SaveData()
        {
            service.SaveReport(teacher, student);
            service.PrintToConsole("Дані збережено у файл");
        }

        /// <summary>
        /// Збільшує кількість студентів у викладача, не допускаючи перевищення межі 120.
        /// </summary>
        private void IncreaseStudents()
        {
            int count;
            int maxStudents = 120;
            bool isCorrect = false;

            if (teacher.QuantityOfStudents >= maxStudents)
            {
                service.PrintToConsole("Кількість студентів уже максимальна: " + maxStudents + ". Збільшення неможливе.");
                return;
            }

            while (!isCorrect)
            {
                count = ReadNumberInRange("На скільки збільшити кількість студентів", 1, 100);

                if (teacher.QuantityOfStudents + count <= maxStudents)
                {
                    teacher.IncreaseStudents(count);
                    service.PrintToConsole("Кількість студентів збільшено. Поточна кількість: " + teacher.QuantityOfStudents);
                    isCorrect = true;
                }
                else
                {
                    service.PrintToConsole("Не можна перевищити максимальну кількість студентів: " + maxStudents + ".");
                    service.PrintToConsole("Поточна кількість: " + teacher.QuantityOfStudents + ". Можна додати не більше: " + (maxStudents - teacher.QuantityOfStudents) + ".");
                }
            }
        }

        /// <summary>
        /// Зменшує кількість студентів у викладача без переходу нижче нуля.
        /// </summary>
        private void DecreaseStudents()
        {
            int count;
            bool isCorrect = false;

            while (!isCorrect)
            {
                count = ReadNumberInRange("На скільки зменшити кількість студентів", 1, 100);

                if (count <= teacher.QuantityOfStudents)
                {
                    teacher.DecreaseStudents(count);
                    service.PrintToConsole("Кількість студентів зменшено");
                    isCorrect = true;
                }
                else
                {
                    service.PrintToConsole("Не можна зменшити більше, ніж є студентів зараз. Поточна кількість: " + teacher.QuantityOfStudents);
                }
            }
        }

        /// <summary>
        /// Виконує сценарій роботи з дипломним проєктом: вибір теми, складність і оцінювання викладачем.
        /// </summary>
        private void WorkWithDiplomaProject()
        {
            service.PrintToConsole("--- Робота з дипломним проєктом ---");
            student.Diploma.ChooseTheme(service, "themes.txt");
            student.Diploma.DetermineComplexity(service);
            teacher.EvaluateDiploma(student);

            service.PrintToConsole("Тема дипломного проєкту: " + student.Diploma.ThemeName);
            service.PrintToConsole("Складність теми: " + student.Diploma.ThemeComplexity);
            service.PrintToConsole("Оцінка за дипломний проєкт: " + student.Diploma.Grade);
        }

        /// <summary>
        /// Читає ціле число в заданих межах і повторює запит до правильного введення.
        /// </summary>
        /// <param name="message">Текст запиту до користувача.</param>
        /// <param name="min">Мінімальне допустиме значення.</param>
        /// <param name="max">Максимальне допустиме значення.</param>
        /// <returns>Коректне ціле число.</returns>
        private int ReadNumberInRange(string message, int min, int max)
        {
            int number;

            while (true)
            {
                service.PrintToConsole(message + " (" + min + "-" + max + "):");

                if (int.TryParse(service.ReadFromConsole(), out number))
                {
                    if (number >= min && number <= max)
                    {
                        return number;
                    }
                }

                service.PrintToConsole("Некоректне введення. Введіть ціле число в межах від " + min + " до " + max + ".");
            }
        }

        /// <summary>
        /// Читає непорожній текст і повідомляє користувача, якщо рядок порожній.
        /// </summary>
        /// <param name="message">Повідомлення перед введенням тексту.</param>
        /// <returns>Непорожній текстовий рядок.</returns>
        private string ReadNotEmptyText(string message)
        {
            string text;

            while (true)
            {
                service.PrintToConsole(message + ":");
                text = service.ReadFromConsole();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }

                service.PrintToConsole("Поле не може бути порожнім. Введіть текст ще раз.");
            }
        }
    }
}
