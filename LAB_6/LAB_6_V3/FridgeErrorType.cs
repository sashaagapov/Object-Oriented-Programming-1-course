namespace LAB_6_V3
{
    /// <summary>
    /// Перелічує основні типи предметно-орієнтованих помилок розумного холодильника.
    /// </summary>
    public enum FridgeErrorType
    {
        /// <summary>Низька напруга живлення.</summary>
        LowVoltage,
        /// <summary>Завищена напруга живлення.</summary>
        HighVoltage,
        /// <summary>Застаріла версія програмного забезпечення.</summary>
        ObsoleteSoftware,
        /// <summary>Збій програмного забезпечення.</summary>
        SoftwareFailure,
        /// <summary>Відсутнє підключення до мережі.</summary>
        NoInternet,
        /// <summary>Перевищено допустиму температуру.</summary>
        TemperatureExceeded,
        /// <summary>Помилка дверей або механізму зачинення.</summary>
        DoorFailure,
        /// <summary>Помилка сенсорів.</summary>
        SensorFailure,
        /// <summary>Помилка вбудованого мікропроцесора.</summary>
        MicroprocessorFailure,
        /// <summary>Помилка AI-модуля.</summary>
        AiModuleFailure,
        /// <summary>Помилка голосового помічника.</summary>
        VoiceAssistantFailure,
        /// <summary>Некоректна голосова команда.</summary>
        InvalidVoiceCommand
    }
}
