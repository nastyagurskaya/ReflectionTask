using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSamplesTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDelagate.StartTest();
            TestEvent.StartTest();
            TestDynamic.StartTest();
            Console.ReadKey();
        }
    }
}
