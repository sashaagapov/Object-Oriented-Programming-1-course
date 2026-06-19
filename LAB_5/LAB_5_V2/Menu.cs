namespace lab5agapov_v2
{
    /// <summary>
    /// Клас Menu відповідає тільки за показ команд і читання вибору користувача.
    /// </summary>
    public class Menu
    {
        public void PrintOptions(Service service)
        {
            service.PrintToConsole("\n--- Меню освітнього процесу ---");
            service.PrintToConsole("1. Показати інформацію про викладача, студента і дипломний проєкт");
            service.PrintToConsole("2. Викладач: змінити кількість годин навантаження");
            service.PrintToConsole("3. Викладач: передати навчальний матеріал студенту");
            service.PrintToConsole("4. Викладач: поставити оцінку студенту");
            service.PrintToConsole("5. Зберегти результати у файл");
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
