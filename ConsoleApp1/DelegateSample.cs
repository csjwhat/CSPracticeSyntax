using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DelegateSample
    {

        // Delegate
        public delegate int Keisan(int x, int y);

        static void Main22(string[] args)
        {
            DelegateSample dl = new DelegateSample();
            dl.execute2();

            // 拡張メソッドを試す
            Console.WriteLine("aaa" + StringExc.AddInfo("aaa"));

            "aaa".AddInfoString();

            Console.WriteLine(dl.DelegateSampleAddMethod());

            Console.ReadLine();

            List<string> list = new List<string> { "Tatsuya", "akiko", "ai", "hiroshi", "yoko" };
            IEnumerable<string> q =
                from p in list
                where p.Length < 5
                select p;

            IEnumerable<string> q2 = list.Where(p => (p.Length <= 5)).Select(p => p);


            foreach (var x in q)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }

        private string whereClouse(string p)
        {
            if (p.Length <= 5)
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        public void execute()
        {
            List<Keisan> keisan = new List<Keisan>();
            keisan.Add(Tashizan);
            keisan.Add(Hikizan);
            keisan.Add(Kakezan);
            keisan.Add(Warizan);

            //PrintKeisan(keisan);
        }

        private static void PrintKeisan(List<Func<int, int, int>> keisan)
        {
            foreach (var k in keisan)
            {
                int r = k(6, 3);
                Console.WriteLine(r);
                Console.ReadLine();
            }
        }

        private int Tashizan(int a, int b) { return a + b; }
        private int Hikizan(int a, int b) { return a - b; }
        private int Kakezan(int a, int b) { return a * b; }
        private int Warizan(int a, int b) { return a / b; }

        public void execute2()
        {
            List<Func<int, int, int>> keisan = new List<Func<int, int, int>>();
            keisan.Add((a, b) => (a + b));
            keisan.Add((a, b) => (a - b));
            keisan.Add((a, b) => (a * b));
            keisan.Add((a, b) => (a / b));
            PrintKeisan(keisan);
        }
    }

    static class StringExc
    {
        public static string AddInfo(string value)
        {
            return value + ":AddInfo";
        }

        public static string AddInfoString(this string value)
        {
            return value + ":AddInfoString";
        }

        public static string DelegateSampleAddMethod(this DelegateSample value)
        {
            return "delegateSampleAddMethod";
        }
    }

    public class TestAsync
    {
        static async Task OutputStringAs(string value)
        {
            Action a = () => { Console.WriteLine("aaaaaa"); };
            await Task.Run(a);
        }
    }

}
