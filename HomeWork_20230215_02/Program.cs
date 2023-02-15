using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20230215_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("歡迎來到1A2B遊戲");

            while (true)
            {
                var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                char temp;
                Random random = new Random();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int r = random.Next(numbers.Length);
                    temp = numbers[i];
                    numbers[i] = numbers[r];
                    numbers[r] = temp;
                }

                Console.WriteLine($"{numbers[0]}{numbers[1]}{numbers[2]}{numbers[3]}");

                while (true)
                {
                    Console.WriteLine("請輸入猜測的數字");
                    string sul = Console.ReadLine();

                    int a = 0;
                    for(int i = 0; i < sul.Length; i++)
                    {
                        if (sul[i] == numbers[i]) 
                        {
                            a++;
                        }
                    }

                    int b = numbers.Take(4).Intersect(sul).Count() - a;

                    Console.WriteLine(a + "A" + b + "B");
                    if (a == 4)
                    {
                        Console.WriteLine("正確答案");
                        break;
                    }
                }

                Console.WriteLine("是否再次進行遊戲(y/n)");
                if (Console.ReadLine() == "n")
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
