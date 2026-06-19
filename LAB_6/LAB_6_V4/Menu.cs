using System;

namespace LAB_6_V4
{
    /// <summary>
    /// Технічний клас меню для інтерактивного режиму четвертої версії.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Виводить перелік команд ручного сценарію.
        /// </summary>
        /// <param name="service">Технічний сервіс, який узгоджує інтерфейс консолі.</param>
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
            Console.WriteLine("18. Підключити Wi-Fi");
            Console.WriteLine("19. Змоделювати низьку напругу");
            Console.WriteLine("20. Змоделювати високу напругу");
            Console.WriteLine("21. Змоделювати помилку сенсорів");
            Console.WriteLine("22. Змоделювати помилку мікропроцесора");
            Console.WriteLine("23. Змоделювати помилку AI-модуля");
            Console.WriteLine("24. Змоделювати помилку голосового помічника");
            Console.WriteLine("25. Зберегти протокол");
            Console.WriteLine("26. Відновити демонстраційний стан");
            Console.WriteLine("0. Вихід");
        }

        /// <summary>
        /// Зчитує номер команди інтерактивного меню.
        /// </summary>
        /// <param name="service">Технічний сервіс для читання числа.</param>
        /// <returns>Вибраний код команди.</returns>
        public int ReadCommand(Service service)
        {
            return service.ReadInt("Оберіть команду");
        }
    }
}
