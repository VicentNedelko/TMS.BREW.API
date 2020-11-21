using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMS.BREW.API.Core.Services;

namespace TMS.BREW.API.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\User\Desktop\breweryByName.dat";

            RequestService reqService = new RequestService();
            var fullList = reqService.RequestFullList().Result;
            Console.Write("Enter by name : ");
            var nameBrewery =
                reqService.RequestByName(Console.ReadLine()).Result;
            Console.Write("Enter city : ");
            var cityBrewery = reqService.RequestDataByCity(Console.ReadLine()).Result;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, nameBrewery);
            }
                Console.ReadKey();
        }
    }
}
