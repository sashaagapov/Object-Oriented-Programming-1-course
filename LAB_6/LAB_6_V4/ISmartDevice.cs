namespace LAB_6_V4
{
    /// <summary>
    /// Узагальнює базовий контракт розумного пристрою.
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
        /// <returns>Підсумок перевірки.</returns>
        string RunSelfDiagnostics();

        /// <summary>
        /// Визначити поточний стан пристрою.
        /// </summary>
        /// <returns>Опис поточного стану.</returns>
        string DetermineStatus();

        /// <summary>
        /// Оновити програмне забезпечення.
        /// </summary>
        /// <returns>Результат оновлення.</returns>
        string UpdateSoftware();
    }
}
