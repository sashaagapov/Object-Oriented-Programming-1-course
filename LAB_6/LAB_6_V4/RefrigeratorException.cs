using System;

namespace LAB_6_V4
{
    /// <summary>
    /// Предметний виняток розумного холодильника з явним типом помилки.
    /// </summary>
    public class RefrigeratorException : Exception
    {
        /// <summary>
        /// Ініціалізує виняток зі стандартним повідомленням.
        /// </summary>
        public RefrigeratorException()
            : this("Невідома помилка розумного холодильника.", FridgeErrorType.SoftwareFailure)
        {
        }

        /// <summary>
        /// Ініціалізує виняток із заданим повідомленням.
        /// </summary>
        /// <param name="message">Опис помилки.</param>
        public RefrigeratorException(string message)
            : this(message, FridgeErrorType.SoftwareFailure)
        {
        }

        /// <summary>
        /// Ініціалізує виняток із повідомленням та вкладеним винятком.
        /// </summary>
        /// <param name="message">Опис помилки.</param>
        /// <param name="innerException">Початкова причина помилки.</param>
        public RefrigeratorException(string message, Exception innerException)
            : this(message, FridgeErrorType.SoftwareFailure, innerException)
        {
        }

        /// <summary>
        /// Ініціалізує виняток із повідомленням та типом доменної помилки.
        /// </summary>
        /// <param name="message">Опис помилки.</param>
        /// <param name="errorType">Тип доменної помилки.</param>
        public RefrigeratorException(string message, FridgeErrorType errorType)
            : base(message)
        {
            ErrorType = errorType;
        }

        /// <summary>
        /// Ініціалізує виняток з повним набором даних про помилку.
        /// </summary>
        /// <param name="message">Опис помилки.</param>
        /// <param name="errorType">Тип доменної помилки.</param>
        /// <param name="innerException">Початкова причина помилки.</param>
        public RefrigeratorException(string message, FridgeErrorType errorType, Exception innerException)
            : base(message, innerException)
        {
            ErrorType = errorType;
        }

        /// <summary>
        /// Повертає тип предметної помилки холодильника.
        /// </summary>
        public FridgeErrorType ErrorType { get; }
    }
}
