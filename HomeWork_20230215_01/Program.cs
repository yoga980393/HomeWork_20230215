using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20230215_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var reader = new StreamReader(File.OpenRead(@".//..//..//../product.csv"));
            var list = new List<Product>();
            var title = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var product = new Product();
                product.setting(values[0], values[1], values[2], values[3], values[4]);
                list.Add(product);
            }

            var result =
                from o in list
                group o by o.Type into gp
                select gp;

            while (true)
            {
                Console.WriteLine("輸入想看的題數(1~17)(輸入0離開程式)：");
                int QN = int.Parse(Console.ReadLine());

                if(QN == 0)
                {
                    break;
                }
                else if(QN == 1)
                {
                    Console.WriteLine($"商品的總價格為 {list.Sum(x => x.Price)} 元");
                }
                else if(QN == 2)
                {
                    Console.WriteLine($"商品的平均價格為 {list.Average(x => x.Price)} 元");
                }
                else if (QN == 3)
                {
                    Console.WriteLine($"商品的總數量為 {list.Sum(x => x.Quantity)} 個");
                }
                else if (QN == 4)
                {
                    Console.WriteLine($"商品的平均數量為 {list.Average(x => x.Quantity)} 個");
                }
                else if (QN == 5)
                {
                    Console.WriteLine($"最貴的商品為為 {list.OrderByDescending(x => x.Price).First().Name}");
                }
                else if (QN == 6)
                {
                    Console.WriteLine($"最便宜的商品為 {list.OrderBy(x => x.Price).First().Name}");
                }
                else if (QN == 7)
                {
                    Console.WriteLine($"3C類商品的總價為 {list.Where(x => x.Type == "3C").Sum(x => x.Price)} 元");
                }
                else if (QN == 8)
                {
                    Console.WriteLine($"食品及飲料類商品的總價為 {list.Where(x => x.Type == "食品" || x.Type == "飲料").Sum(x => x.Price)} 元");
                }
                else if (QN == 9)
                {
                    Console.WriteLine("商品類別為食品，且數量大於100的有");
                    foreach (var i in list.Where(x => x.Type == "食品" && x.Quantity > 100))
                    {
                        Console.WriteLine(i.Name);
                    }
                }
                else if (QN == 10)
                {
                    foreach (var t in result)
                    {
                        Console.WriteLine($"{t.Key}類中，價格高於1000元的有");
                        if (t.Where(x => x.Price > 1000).Count() == 0)
                        {
                            Console.WriteLine("此類無高於1000元的商品");
                        }
                        else
                        {
                            foreach (var p in t.Where(x => x.Price > 1000))
                            {
                                Console.WriteLine(p.Name);
                            }
                        }
                    }
                }
                else if (QN == 11)
                {
                    foreach (var t in result)
                    {
                        if (t.Where(x => x.Price > 1000).Count() == 0)
                        {
                            Console.WriteLine($"{t.Key}類中，沒有價格高於1000元的商品");
                        }
                        else
                        {
                            Console.WriteLine($"{t.Key}類中，價格高於1000元的商品價格平均為 {t.Where(x => x.Price > 1000).Average(x => x.Price)} 元");
                        }
                    }
                }
                else if (QN == 12)
                {
                    Console.WriteLine("所有商品由價格從高到低排序為");
                    foreach (var item in list.OrderByDescending(x => x.Price))
                    {
                        Console.WriteLine($"{item.Name}，{item.Price} 元");
                    }
                }
                else if (QN == 13)
                {
                    Console.WriteLine("所有商品由數量從低到高排序為");
                    foreach (var item in list.OrderBy(x => x.Quantity))
                    {
                        Console.WriteLine($"{item.Name}，{item.Quantity} 個");
                    }
                }
                else if (QN == 14)
                {
                    foreach (var t in result)
                    {
                        Console.WriteLine($"{t.Key}類中，最貴的商品是 {t.OrderByDescending(x => x.Price).First().Name}");
                    }
                }
                else if (QN == 15)
                {
                    foreach (var t in result)
                    {
                        Console.WriteLine($"{t.Key}類中，最便宜的商品是 {t.OrderBy(x => x.Price).First().Name}");
                    }
                }
                else if (QN == 16)
                {
                    foreach (var item in list.Where(x => x.Price <= 10000))
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (QN == 17)
                {
                    while (true)
                    {
                        Console.WriteLine("輸入想看的頁數(1~5)(輸入0返回上一頁)：");
                        int n = int.Parse(Console.ReadLine());

                        if (n == 0)
                        {
                            break;
                        }

                        foreach (var item in list.Skip((n - 1) * 4).Take(4))
                        {
                            Console.WriteLine($"{item.Id} {item.Name} {item.Quantity} {item.Price} {item.Type}");
                        }

                        Console.WriteLine("無此頁");
                    }
                }
                else
                {
                    Console.WriteLine("無此題");
                }

                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
