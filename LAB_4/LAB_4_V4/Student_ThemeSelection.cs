
namespace lab4agapov;

public partial class Student
{
    /// <summary>
    /// Метод SelectTheme, який реалізує пошук та вибір теми дипломного проєкту
    /// за ключовим словом із файлу. Логіку вибору теми перенесено сюди з Service
    /// відповідно до принципу розділення відповідальності (часткові класи, Версія 4).
    /// </summary>
    /// <param name="filePath">Шлях до файлу з переліком тем.</param>
    public void SelectTheme(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Помилка: Файл 'themes.txt' не знайдено!");
            return;
        }

        string[] allThemes = File.ReadAllLines(filePath);
        bool themeSelected = false;

        while (!themeSelected)
        {
            Console.WriteLine("\n--- Пошук теми дипломного проєкту ---");
            Console.Write("Введіть ключове слово для пошуку теми (або '0' для відміни): ");
            string keyword = Console.ReadLine()?.ToLower() ?? "";

            if (keyword == "0")
            {
                return; // Вихід, якщо користувач передумав
            }

            var matched = new List<string>();
            Console.WriteLine("\nЗнайдені варіанти:");
            for (int i = 0; i < allThemes.Length; i++)
            {
                if (allThemes[i].ToLower().Contains(keyword))
                {
                    matched.Add(allThemes[i]);
                    Console.WriteLine($"{matched.Count}. {allThemes[i]}");
                }
            }

            if (matched.Count == 0)
            {
                Console.WriteLine("За вашим запитом нічого не знайдено. Спробуйте інше слово.");
            }
            else
            {
                Console.Write("\nОберіть номер теми: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= matched.Count)
                {
                    Diploma.NameOfTheme = matched[choice - 1];
                    Console.WriteLine($"Тема '{Diploma.NameOfTheme}' успішно закріплена!");
                    themeSelected = true; // Завершуємо цикл
                }
                else
                {
                    Console.WriteLine("Некоректний вибір номера. Спробуйте ще раз.");
                }
            }
        }
    }
}
