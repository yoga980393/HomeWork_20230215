using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20230215_01
{
    internal class Product
    {
        [Name("商品編號")] public string Id { get; set; }
        [Name("商品名稱")] public string Name { get; set; }
        [Name("商品數量")] public int Quantity { get; set; }
        [Name("價格")] public int Price { get; set; }
        [Name("商品類別")] public string Type { get; set; }

        public void setting(string i, string n, string q, string p, string t)
        {
            Id = i;
            Name = n;
            Quantity = int.Parse(q);
            Price = int.Parse(p);
            Type= t;
        }

    }
}
