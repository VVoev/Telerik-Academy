namespace _5.Decorator
{
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    public abstract class LibraryItem
    {
        public int CopiesCount { get; set; }

        public abstract void Display();
    }
}
