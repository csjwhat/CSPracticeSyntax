using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sex = new List<Sex> {
                new Sex { Id = 0, Text = "未登録" },
                new Sex { Id = 1, Text = "男性" },
                new Sex { Id = 2, Text = "女性" }
               };

            var member = new List<Member>
            {
                new Member {Id = 1, Name="Tatsuya", SexId = 1},
                new Member {Id = 2, Name="Akiko", SexId = 2},
                new Member {Id = 3, Name="Ai", SexId = 0},
                new Member {Id = 4, Name="Hiroshi", SexId = 1},
                new Member {Id = 5, Name="Yoko", SexId = 2}
            };

            var q =
                from m in member
                join s in sex on m.SexId equals s.Id
                let sid = m.SexId
                where m.SexId > 0
                orderby m.Name descending
                select
                new { Text = $"{m.Id}:{m.Name}({s.Text}){sid}", Sex = s.Text } into v
                group v by v.Sex;

            foreach(var g in q)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(g.Key);
                Console.WriteLine("---------------------------------------");
                foreach(var x in g)
                {
                    Console.WriteLine(x.Text);
                }
            }
            Console.ReadLine();
        }
    }


    class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SexId { get; set; }
    }

    class Sex
    {
        // Property
        public int Id { get; set; } // Id
        public string Text { get; set; } // 性別（文字列）
    }

}
