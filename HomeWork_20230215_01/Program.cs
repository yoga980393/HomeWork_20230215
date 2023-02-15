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
            var records = csv.GetRecords<Product>();

            foreach (var record in records)
            {
                Console.WriteLine($"Id: {record.Id}, Name: {record.Name}");
                // Id: 1, Name: Ruyut
                // Id: 2, Name: 小明
            }
        }
    }
}
