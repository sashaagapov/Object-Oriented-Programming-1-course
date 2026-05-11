namespace lab4agapov_v2
{
    /// <summary>
    /// Інтерфейс IPerson описує спільні властивості людини.
    /// </summary>
    public interface IPerson
    {
        string Name { get; set; }

        string SubjectName { get; set; }

        void DisplayInfo();
    }
}
