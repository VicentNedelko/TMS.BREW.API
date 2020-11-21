using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.BREW.API.Core.Models;

namespace TMS.BREW.API.Core.Interfaces
{
    public interface IRequest
    {
        public enum Types
        {
            micro = 1,
            nano,
            regional,
            brewpub,
            large,
            planning,
            bar,
            contract,
            proprietor,
            closed,
        }
        public Task<IEnumerable<Brewery>> RequestDataByCity(string s);
        public Task<IEnumerable<Brewery>> RequestFullList();
        public Task<IEnumerable<Brewery>> RequestByState(string s);
        public Task<IEnumerable<Brewery>> RequestByType(string s);
    }
}
