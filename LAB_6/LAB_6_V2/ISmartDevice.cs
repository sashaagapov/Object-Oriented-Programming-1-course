namespace LAB_6_V2
{
    /// <summary>
    /// Узагальнює базові можливості розумного пристрою у другій версії роботи.
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
        /// Запустити самодіагностику пристрою.
        /// </summary>
        /// <returns>Підсумок діагностики.</returns>
        string RunSelfDiagnostics();

        /// <summary>
        /// Визначити поточний стан пристрою.
        /// </summary>
        /// <returns>Опис поточного стану.</returns>
        string DetermineStatus();

        /// <summary>
        /// Оновити програмне забезпечення пристрою.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        string UpdateSoftware();
    }
}
