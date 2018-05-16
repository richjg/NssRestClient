using NssRestClient.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NssRestClient.Services
{
    public class MachineService : IMachineService
    {
        private readonly IRestClient restClient;

        public MachineService(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public static MachineService Create(IRestClient restClient) => new MachineService(restClient);

        public Task<RestResult<List<Machine>>> GetComputers(int page, int numberOfMachines, string searchText) => this.restClient.GetAsync<List<Machine>>($"v6/machines?$filter=contains(DisplayName, '{searchText}')&$top={numberOfMachines}&$skip={numberOfMachines * (page - 1)}");
    }
}
