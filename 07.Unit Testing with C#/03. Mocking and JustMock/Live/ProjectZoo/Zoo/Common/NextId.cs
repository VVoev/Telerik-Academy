using System;
using Zoo.Common;

namespace Zoo.Abstract
{
    public  class NextId : INextID
    {
        private static int currentID = 0;

        int INextID.NextId()
        {
            return ++currentID;
        }
    }
}