namespace lab4agapov_v3
{
    /// <summary>
    /// Інтерфейс IPerson описує спільний контракт людини.
    /// </summary>
    public interface IPerson
    {
        string Name { get; set; }

        string SubjectName { get; set; }

        string GetInfo();
    }
}
