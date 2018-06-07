using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSamplesTesting
{
    class TestDynamic
    {
        public static void StartTest()
        {
            Console.WriteLine("DynamicTest\n---------");
            dynamic d = new Duck();
                d.Quack(); // Quack method was called
                d.Waddle(); // Waddle method was called
        }
        public class Duck : DynamicObject
        {
            public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine(binder.Name + " method was called");
                result = null;
                return true;
            }
            public void Quack()
            {
                Console.WriteLine("Method Quack is exist");
            }
        }
    }
}
