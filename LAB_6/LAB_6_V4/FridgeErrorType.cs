namespace LAB_6_V4
{
    /// <summary>
    /// Перелічує предметні типи помилок для сценаріїв з винятками та подіями.
    /// </summary>
    public enum FridgeErrorType
    {
        /// <summary>Низька напруга живлення.</summary>
        LowVoltage,
        /// <summary>Завищена напруга живлення.</summary>
        HighVoltage,
        /// <summary>Застаріле програмне забезпечення.</summary>
        ObsoleteSoftware,
        /// <summary>Внутрішній збій програмного забезпечення.</summary>
        SoftwareFailure,
        /// <summary>Немає доступу до мережі.</summary>
        NoInternet,
        /// <summary>Температура перевищує допустиму межу.</summary>
        TemperatureExceeded,
        /// <summary>Помилка дверей або механізму закривання.</summary>
        DoorFailure,
        /// <summary>Збій сенсорів.</summary>
        SensorFailure,
        /// <summary>Збій вбудованого мікропроцесора.</summary>
        MicroprocessorFailure,
        /// <summary>Збій AI-модуля.</summary>
        AiModuleFailure,
        /// <summary>Помилка голосового асистента.</summary>
        VoiceAssistantFailure,
        /// <summary>Некоректна голосова команда.</summary>
        InvalidVoiceCommand
    }
}
