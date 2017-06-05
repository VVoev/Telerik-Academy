using System.Threading.Tasks;
using ThreadSafeSingleton;

namespace Thread_Save_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 6, x => LazyThreadSafeLogger.Instance.Save(x));
            var doubleLocker = DoubleLockingThreadSafeLogger.Instance;
            doubleLocker.SaveToLog("Hello");
            doubleLocker.SaveToLog("How are you?");
            doubleLocker.PrintLog();
        }
    }
}
