using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace dotnet_capstone_project
{
    class Program
    {
        static void Main(string[] args)
        {//can't use ! in C# so set = null
            if (args[0] == null)
            {// use first Console.Writeline then use return in void
                Console.WriteLine("Please input a make or type of a car.");
                return;
            }// ElementAtOrDefault accesses an element
            // It handles an out-of-range access without throwing an exception 
            var args2 = args.ElementAtOrDefault(1);
            using (StreamReader r = new StreamReader("./cars.json"))
            {
                var jsonString = r.ReadToEnd();
                var carOfList = JsonSerializer.Deserialize<List<Car>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                foreach (var i in carOfList)
                {
                    if (args[0].ToLower() == i.Make.ToLower() && args2 == null)
                    {
                        Console.WriteLine(i.Model);
                    }
                    if (args[0].ToLower() == i.Type.ToLower())
                    {
                        Console.WriteLine(i.Model);
                    }
                    if (args[0].ToLower() == i.Make.ToLower() && args2 == i.Type.ToLower())
                    {
                        Console.WriteLine(i.Model);
                    }
                }
            }
        }
    }
}
