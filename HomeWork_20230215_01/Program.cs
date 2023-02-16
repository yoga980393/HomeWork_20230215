using CsvHelper;
using CsvHelper.Configuration;
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
            var reader = new StreamReader(@"D:\C#\HomeWork_20230215_01\product.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var data = csv.GetRecords<Product>();
            var list = data.ToList();

            Console.WriteLine($"商品的總價格為 {list.Sum(x => x.Price)} 元");
            Console.WriteLine($"\n商品的平均價格為 {list.Average(x => x.Price)} 元");
            Console.WriteLine($"\n商品的總數量為 {list.Sum(x => x.Quantity)} 個");
            Console.WriteLine($"\n商品的平均數量為 {list.Average(x => x.Quantity)} 個");

            //有問題
            Console.WriteLine($"\n最貴的商品為為 {list.Max(x => x.Price)}");
            Console.WriteLine($"\n最便宜的商品為 {list.Min(x => x.Price)}");

            Console.WriteLine($"\n3C類商品的總價為 {list.Where(x => x.Type == "3C").Sum(x => x.Price)}");
            Console.WriteLine($"\n食品及飲料類商品的總價為 {list.Where(x => x.Type == "食品" || x.Type == "飲料").Sum(x => x.Price)}");

            Console.WriteLine("\n商品類別為食品，且價格高於100元的有");
            var list2 = list.Where(x => x.Type == "食品" && x.Quantity > 100);
            foreach(var i in list2)
            {
                Console.WriteLine(i.Name);
            }

            var result =
                from o in list
                group o by o.Type into gp
                select gp;
            foreach(var t in result)
            {
                Console.WriteLine($"\n{t.Key}類中，價格高於1000元的有");
                if(t.Where(x => x.Price > 1000).Count() == 0)
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

            foreach (var t in result)
            {
                if(t.Where(x => x.Price > 1000).Count() == 0)
                {
                    Console.WriteLine($"\n{t.Key}類中，沒有價格高於1000元的商品");
                }
                else
                {
                    Console.WriteLine($"\n{t.Key}類中，價格高於1000元的商品價格平均為 {t.Where(x => x.Price > 1000).Average(x => x.Price)} 元");
                }
            }

            Console.WriteLine("\n所有商品由價格從高到低排序為");
            foreach (var item in list.OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{item.Name}，{item.Price} 元");
            }

            Console.WriteLine("\n所有商品由數量從低到高排序為");
            foreach (var item in list.OrderBy(x => x.Quantity))
            {
                Console.WriteLine($"{item.Name}，{item.Quantity} 個");
            }

            //有問題
            Console.WriteLine();
            foreach (var t in result)
            {
                var temp = t.OrderByDescending(x => x.Price).ToList();
                Console.WriteLine($"{t.Key}類中，最貴的商品是 {temp[0].Name}");
            }

            Console.WriteLine();
            foreach (var t in result)
            {
                var temp = t.OrderBy(x => x.Price).ToList();
                Console.WriteLine($"{t.Key}類中，最便宜的商品是 {temp[0].Name}");
            }

            Console.WriteLine("\n價格<=10000的商品為");
            foreach (var item in list.Where(x => x.Price <= 10000))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
