namespace lab4agapov_v1
{
    /// <summary>
    /// Клас Menu відповідає тільки за показ доступних команд
    /// і читання номера команди від користувача.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Показує доступні команди першої версії лабораторної роботи.
        /// </summary>
        public void PrintOptions(Service service)
        {
            service.PrintToConsole("\n--- Меню освітнього процесу ---");
            service.PrintToConsole("1. Показати інформацію про викладача та студента");
            service.PrintToConsole("2. Викладач: змінити кількість годин навантаження");
            service.PrintToConsole("3. Викладач: передати навчальний матеріал студенту");
            service.PrintToConsole("4. Викладач: поставити оцінку студенту");
            service.PrintToConsole("5. Зберегти результати у файл");
            service.PrintToConsole("0. Вийти");
        }

        /// <summary>
        /// Читає номер команди з консолі.
        /// </summary>
        /// <param name="service">Сервіс для читання з консолі.</param>
        /// <returns>Номер команди або -1, якщо введення некоректне.</returns>
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
