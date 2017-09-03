namespace SortingHomework
{
    public class Startup
    {
        public static void Main()
        {
            var sortableCollection = new SortableCollection<int>();

            for (int i = 0; i < 40; i++)
            {
                sortableCollection.Items.Add(i);
            }

            sortableCollection.Shuffle();

            sortableCollection.PrintAllItemsOnConsole();
        }
    }
}
