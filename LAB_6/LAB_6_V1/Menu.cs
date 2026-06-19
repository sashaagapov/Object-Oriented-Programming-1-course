using System;

namespace LAB_6_V1
{
    /// <summary>
    /// Технічний клас меню для інтерактивного режиму демонстрації.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Виводить доступні команди інтерактивного режиму.
        /// </summary>
        /// <param name="service">Технічний сервіс для узгодженого вводу й виводу.</param>
        public void PrintOptions(Service service)
        {
            Console.WriteLine();
            Console.WriteLine("1. Показати повну інформацію про холодильник");
            Console.WriteLine("2. Увімкнути холодильник");
            Console.WriteLine("3. Вимкнути холодильник");
            Console.WriteLine("4. Запустити самодіагностику");
            Console.WriteLine("5. Показати поточний статус");
            Console.WriteLine("6. Проаналізувати споживання продуктів");
            Console.WriteLine("7. Отримати рекомендації щодо завантаження");
            Console.WriteLine("8. Відкрити двері");
            Console.WriteLine("9. Закрити двері");
            Console.WriteLine("10. Виміряти температуру");
            Console.WriteLine("11. Проаналізувати продукти");
            Console.WriteLine("12. Рекомендувати здорове харчування");
            Console.WriteLine("13. Згенерувати рецепт");
            Console.WriteLine("14. Проаналізувати настрій користувача");
            Console.WriteLine("15. Мотивувати до здорового харчування");
            Console.WriteLine("16. Оновити програмне забезпечення");
            Console.WriteLine("17. Виконати голосову команду");
            Console.WriteLine("18. Зберегти протокол");
            Console.WriteLine("0. Вихід");
        }

        /// <summary>
        /// Зчитує номер вибраної користувачем команди.
        /// </summary>
        /// <param name="service">Технічний сервіс для читання числа.</param>
        /// <returns>Код команди меню.</returns>
        public int ReadCommand(Service service)
        {
            return service.ReadInt("Оберіть команду");
        }
    }
}
