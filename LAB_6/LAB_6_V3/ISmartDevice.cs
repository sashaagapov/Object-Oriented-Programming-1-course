namespace LAB_6_V3
{
    /// <summary>
    /// Описує спільні операції розумного пристрою.
    /// </summary>
    public interface ISmartDevice
    {
        /// <summary>
        /// Увімкнути пристрій.
        /// </summary>
        /// <returns>Результат операції.</returns>
        string TurnOn();

        /// <summary>
        /// Вимкнути пристрій.
        /// </summary>
        /// <returns>Результат операції.</returns>
        string TurnOff();

        /// <summary>
        /// Запустити самодіагностику.
        /// </summary>
        /// <returns>Підсумок самодіагностики.</returns>
        string RunSelfDiagnostics();

        /// <summary>
        /// Отримати поточний статус пристрою.
        /// </summary>
        /// <returns>Статус у текстовому вигляді.</returns>
        string DetermineStatus();

        /// <summary>
        /// Оновити програмне забезпечення.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        string UpdateSoftware();
    }
}
