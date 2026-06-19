namespace lab4agapov_v4
{
    /// <summary>
    /// Клас Menu відповідає тільки за показ доступних команд
    /// і читання номера команди від користувача.
    /// </summary>
    public class Menu
    {
        public void PrintOptions(Service service)
        {
            service.PrintToConsole("\n--- Меню освітнього процесу ---");
            service.PrintToConsole("1. Показати інформацію про викладача, студента і групу");
            service.PrintToConsole("2. Викладач: змінити кількість годин навантаження");
            service.PrintToConsole("3. Викладач: передати навчальний матеріал студенту");
            service.PrintToConsole("4. Викладач: поставити оцінку студенту");
            service.PrintToConsole("5. Зберегти результати у файл");
            service.PrintToConsole("6. Показати студентів групи");
            service.PrintToConsole("7. Відсортувати студентів за рейтингом");
            service.PrintToConsole("8. Відсортувати студентів за кількістю виконаних робіт");
            service.PrintToConsole("0. Вийти");
        }

        public int ReadCommand(Service service)
        {
            int command;

            service.PrintToConsole("Оберіть пункт:");

            if (int.TryParse(service.ReadFromConsole(), out command))
            {
                return command;
            }

            return -1;
        }
    }
}
