using System;
using System.Collections.Generic;
using System.Text;
 

namespace TextClassify
{
    class TestManager
    {
        object TargetO {
            set;
            get;
        }
        public static void main(String[] Args)
        {
            TestManager t = new TestManager();
            t.TargetO = new UsageHashTable();
            t.TargetO.ToString();
        }
    }
}
