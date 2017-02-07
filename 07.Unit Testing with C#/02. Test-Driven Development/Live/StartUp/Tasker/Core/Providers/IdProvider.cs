using System;

namespace Tasker.Core.Providers
{
    public class IdProvider
    {
        private static int currentId = 0;
        public int NextId()
        {
            return currentId++;
        }
    }
}
