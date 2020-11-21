using System;
using TMS.BREW.API.Core.Services;

namespace TMS.BREW.API.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestService reqService = new RequestService();
            var fullList = reqService.RequestFullList().Result;
            Console.Write("Enter by name : ");
            var nameBrewery =
                reqService.RequestByName(Console.ReadLine()).Result;
            Console.Write("Enter city : ");
            var cityBrewery = reqService.RequestDataByCity(Console.ReadLine()).Result;
            Console.ReadKey();
        }
    }
}
