using System;
using System.Collections.Generic;
using System.Text;
using TMS.BREW.API.Core.Interfaces;
using Flurl;
using Flurl.Http;
using TMS.BREW.API.Core.Models;
using System.Threading.Tasks;

namespace TMS.BREW.API.Core.Services
{
    public class RequestService : IRequest
    {
        private const string url = "https://api.openbrewerydb.org/";
        public async Task<IEnumerable<Brewery>> RequestDataByCity(string str)
        {
            var brewList = await url.AppendPathSegments("breweries")
                .SetQueryParam("by_city", str.ToLower())
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }
        public async Task<IEnumerable<Brewery>> RequestFullList()
        {
            var brewList = await url.AppendPathSegments("breweries")
                .GetJsonAsync<Brewery[]>();
            return brewList;
        }
        public async Task<IEnumerable<Brewery>> RequestByName(string str)
        {
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_name", str.ToLower())
                .GetJsonAsync<Brewery[]>();
        }
        public async Task<IEnumerable<Brewery>> RequestByType(string str)
        {
            return await url.AppendPathSegments("breweries")
                .SetQueryParam("by_type", str.ToLower())
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
