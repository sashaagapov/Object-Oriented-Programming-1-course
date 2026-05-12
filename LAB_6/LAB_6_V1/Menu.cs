namespace lab6agapov_v1
{
    /// <summary>
    /// Консольне меню для демонстрації ЛР6 версії 1.
    /// </summary>
    public class Menu
    {
        private Service service;
        private SmartRefrigerator smartRefrigerator;

        /// <summary>
        /// Ініціалізує меню.
        /// </summary>
        public Menu(Service service, SmartRefrigerator smartRefrigerator)
        {
            this.service = service;
            this.smartRefrigerator = smartRefrigerator;
        }

        /// <summary>
        /// Запускає обробку команд користувача.
        /// </summary>
        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                service.PrintToConsole("\n--- ЛР6 V1: Розумний холодильник ---");
                service.PrintToConsole("1. Увімкнути холодильник");
                service.PrintToConsole("2. Самодіагностика і статус");
                service.PrintToConsole("3. Рекомендації здорового харчування");
                service.PrintToConsole("4. Персоналізований рецепт");
                service.PrintToConsole("5. Підтримка емоційного стану");
                service.PrintToConsole("6. Аналіз споживання і список закупівель");
                service.PrintToConsole("7. Оновлення ПЗ");
                service.PrintToConsole("8. Демонстрація зв'язків компонентів");
                service.PrintToConsole("9. Зберегти протокол у файл");
                service.PrintToConsole("0. Вимкнути і вийти");
                service.PrintToConsole("Оберіть команду:");

                string command = service.ReadFromConsole();

                switch (command)
                {
                    case "1":
                        service.PrintToConsole(smartRefrigerator.TurnOn());
                        break;
                    case "2":
                        service.PrintToConsole(smartRefrigerator.SelfDiagnose());
                        service.PrintToConsole(smartRefrigerator.DetermineStatus());
                        break;
                    case "3":
                        ExecuteHealthScenario();
                        break;
                    case "4":
                        ExecuteRecipeScenario();
                        break;
                    case "5":
                        ExecuteMoodScenario();
                        break;
                    case "6":
                        service.PrintToConsole(smartRefrigerator.AnalyzeConsumption());
                        service.PrintToConsole(smartRefrigerator.RecommendProductLoading());
                        break;
                    case "7":
                        service.PrintToConsole(smartRefrigerator.UpdateSoftware());
                        break;
                    case "8":
                        DemonstrateCompositionAggregationAssociation();
                        break;
                    case "9":
                        service.SaveProtocol();
                        service.PrintToConsole("Протокол збережено у refrigerator_report.txt");
                        break;
                    case "0":
                        service.PrintToConsole(smartRefrigerator.TurnOff());
                        isRunning = false;
                        break;
                    default:
                        service.PrintToConsole("Невідома команда.");
                        break;
                }
            }
        }

        /// <summary>
        /// Сценарій перевірки здоров'я і рекомендацій харчування.
        /// </summary>
        private void ExecuteHealthScenario()
        {
            service.PrintToConsole("Введіть короткий опис стану здоров'я:");
            string healthData = service.ReadFromConsole();
            service.PrintToConsole(smartRefrigerator.HealthCheckAndDiet(healthData));
        }

        /// <summary>
        /// Сценарій генерації персоналізованого рецепта.
        /// </summary>
        private void ExecuteRecipeScenario()
        {
            service.PrintToConsole("Введіть запит для рецепта:");
            string request = service.ReadFromConsole();
            service.PrintToConsole(smartRefrigerator.CreatePersonalizedRecipe(request));
        }

        /// <summary>
        /// Сценарій емоційної підтримки користувача.
        /// </summary>
        private void ExecuteMoodScenario()
        {
            service.PrintToConsole("Введіть емоційний стан:");
            string mood = service.ReadFromConsole();
            service.PrintToConsole(smartRefrigerator.SupportMood(mood));
        }

        /// <summary>
        /// Показує приклади композиції, агрегації та асоціації.
        /// </summary>
        private void DemonstrateCompositionAggregationAssociation()
        {
            service.PrintToConsole(smartRefrigerator.IsothermalCabinet.OpenDoor());
            service.PrintToConsole(smartRefrigerator.IsothermalCabinet.Door.ControlSealing());
            service.PrintToConsole(smartRefrigerator.IsothermalCabinet.CloseDoor());

            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.Compressor.MonitorParameters());
            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.Condenser.DiagnoseState());
            service.PrintToConsole(smartRefrigerator.ElectricalEquipment.Refrigerant.CheckLevel());

            service.PrintToConsole(smartRefrigerator.VoiceAssistant.PerformUserAction("Відкрити нотатки про дієту"));
            service.PrintToConsole(smartRefrigerator.AIDevices.RecognizeProducts());
        }
    }
}
