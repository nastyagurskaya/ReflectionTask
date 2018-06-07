using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSamplesTesting
{
    class TestDelagate
    {
        delegate object ObjectRetriever();
        static double Square(double х) => х * х;
        public static void StartTest()
        {
            ObjectRetriever о = new ObjectRetriever(GetString);
            object result = о();
            Console.WriteLine(result); // !hello
            double[] values = { 3.4, 1.6, 5.9 };
            Console.Write("DelegateTest\n---------\nValues before: ");
            foreach (double v in values) Console.Write(v + " ");
            Transform<double>(values, Square);
            Console.Write("\nValues after: ");
            foreach (double v in values) Console.Write(v+" ");
        }
        static string GetString() => "hello";
        public static void Transform<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }
    }
}
