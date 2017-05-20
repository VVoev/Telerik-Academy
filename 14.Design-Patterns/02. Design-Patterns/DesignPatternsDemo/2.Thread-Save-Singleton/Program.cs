using System.Threading.Tasks;

namespace _2.Thread_Save_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 6, x => LazyThreadSafeLogger.Instance.SaveToLog(x));
            LazyThreadSafeLogger.Instance.PrintLog();
        }
    }
}
