using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    public static class MyExtensiuon
    {
        public static bool HasNumberOfType<T>(this IEnumerable<T> seq, int number,
            Func<T, bool> condition)
        {
            int found = 0;
            while (seq.Any() && (found < number))
            {
                seq = seq.SkipWhile(condition);
                found++;
                seq.Skip(1);
            }
            return seq.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> seq, System.Action<T> action){
            foreach (var item in seq)
                action(item);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Enumerable.Range(0, 300000000);
            bool exists = sequence
                .TakeWhile(n => n % 5 == 0)
                .Skip(3)
                .Any();

            bool ex2 = sequence.HasNumberOfType(5, n => n % 5 != 0);

            sequence.ForEach(i => Console.WriteLine(i));

            //foreach (var item in sequence) { Console.WriteLine(item); Console.ReadKey(); }

            Console.WriteLine(ex2);
            Console.ReadKey();

        }
    }
}
