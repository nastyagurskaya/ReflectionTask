using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookSamplesTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assem = typeof(Program).Assembly;
            //Console.WriteLine("Assembly name: {0}", assem.FullName);
            Type[] types = assem.GetTypes();
            foreach (Type t in types)
            {
                //Console.WriteLine("--> " + t);
                MethodInfo theMethod = t.GetMethod("StartTest");
                if(theMethod!=null)theMethod.Invoke(assem, null);
            }
            Console.ReadKey();
        }
    }
}
