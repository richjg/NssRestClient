using System.Collections.Generic;
using System.Threading.Tasks;
using NssRestClient.Dto;

namespace NssRestClient.Services
{
    public interface IMachineService
    {
        Task<RestResult<List<Machine>>> GetComputers(int page, int numberOfMachines, string searchText);
    }
}