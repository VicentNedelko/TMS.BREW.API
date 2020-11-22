using System;
using System.Collections.Generic;
using System.Text;
using TMS.BREW.API.Core.Interfaces;
using Flurl;
using Flurl.Http;
using TMS.BREW.API.Core.Models;
using System.Threading.Tasks;
using static TMS.BREW.API.Core.Interfaces.IRequest;

namespace TMS.BREW.API.Core.Services
{
    public class RequestService : IRequest
    {
        private const string url = "https://api.openbrewerydb.org/";
        public async Task<IEnumerable<Brewery>> RequestDataByCity(string str)
        {
            var brewList = await url.AppendPathSegment("breweries")
                .SetQueryParam("by_city", str.ToLower())
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }
        public async Task<IEnumerable<Brewery>> RequestFullList()
        {
            var brewList = await url.AppendPathSegment("breweries")
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }
        public async Task<IEnumerable<Brewery>> RequestByName(string str)
        {
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_name", str.ToLower())
                .GetJsonAsync<Brewery[]>();
        }
        public async Task<IEnumerable<Brewery>> RequestByType()
        {
            Types type = Types.bar;
            Console.WriteLine("Enter type : ");
            Console.WriteLine(  "micro - m" + "; " +
                                "nano - n"  + "; " +
                                "regional - r" + "; " +
                                "brewpub - b" + "; " +
                                "large - l" + "; " +
                                "planning - p" + "; " +
                                "bar - a" + "; " +
                                "contract - c" + "; " +
                                "proprietor - h" + "; " +
                                "closed - x");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.M:
                    type = Types.micro;
                    break;
                case ConsoleKey.N:
                    type = Types.nano;
                    break;
                case ConsoleKey.R:
                    type = Types.regional;
                    break;
                case ConsoleKey.B:
                    type = Types.brewpub;
                    break;
                case ConsoleKey.L:
                    type = Types.large;
                    break;
                case ConsoleKey.P:
                    type = Types.planning;
                    break;
                case ConsoleKey.A:
                    type = Types.bar;
                    break;
                case ConsoleKey.C:
                    type = Types.contract;
                    break;
                case ConsoleKey.H:
                    type = Types.proprietor;
                    break;
                case ConsoleKey.X:
                    type = Types.closed;
                    break;
            }
            Console.WriteLine(type.ToString());
            Console.ReadKey();
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_type", type.ToString())
                .GetJsonAsync<Brewery[]>();
        }
        public async Task<IEnumerable<Brewery>> RequestByState(string str)
        {
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_state", str.ToLower())
                .GetJsonAsync<Brewery[]>();
        }
    }
}
