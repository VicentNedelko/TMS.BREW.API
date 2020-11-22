using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMS.BREW.API.Core.Models;
using TMS.BREW.API.Core.Services;
using TMS.BREW.API.Core.Commons;
using System.Linq;

namespace TMS.BREW.API.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowUserMenu();
            RequestService reqService = new RequestService();
            Parameters commons = new Parameters();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    Console.Write("Enter Name : ");
                    var nameBrewery =
                        reqService.RequestByName(Console.ReadLine()).Result;
                    if (nameBrewery.Count() != 0)
                    {
                        MoveToBinFile(nameBrewery, commons.filePathName);
                        PrintList(nameBrewery);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No items found.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case ConsoleKey.C:
                    Console.Write("Enter city : ");
                    var cityBrewery = reqService.RequestDataByCity(Console.ReadLine()).Result;
                    if (cityBrewery.Count() != 0)
                    {
                        MoveToBinFile(cityBrewery, commons.filePathCity);
                        PrintList(cityBrewery);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No items found.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case ConsoleKey.T:
                    var typeBrewery = reqService.RequestByType().Result;
                    if (typeBrewery.Count() != 0)
                    {
                        MoveToBinFile(typeBrewery, commons.filePathType);
                        PrintList(typeBrewery);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No items found.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case ConsoleKey.F:
                    var fullList = reqService.RequestFullList().Result;
                    MoveToBinFile(fullList, commons.filePathFull);
                    PrintList(fullList);
                    break;
            }
                Console.ReadKey();
        }
        public static void ShowUserMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------User Menu-------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search by Name - \"N\"");
            Console.WriteLine("Search by City - \"C\"");
            Console.WriteLine("Search by Type - \"T\"");
            Console.WriteLine("Show full list - \"F\"");
        }
        public static void MoveToBinFile(IEnumerable<Brewery> brewList, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, brewList);
            }
        }
        public static void PrintList(IEnumerable<Brewery> listToPrint)
        {
            foreach(Brewery brewery in listToPrint)
            {
                Console.WriteLine("-------");
                Console.WriteLine($"ID : {brewery.id}");
                Console.WriteLine($"Name : {brewery.name}");
                Console.WriteLine($"City : {brewery.city}");
                Console.WriteLine($"Type - {brewery.brewery_type}");
                Console.WriteLine();
            }
        }
    }
}
