using MPED.StacjaIT.XAIOT.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Services.Web
{
    public class BuildingWebService
    {
        public async Task<BuildingViewModel> GetBuilding(string token, Guid id)
        {
            HouseWebClient client = new HouseWebClient(token);
            Dictionary<string, string> uriParams = new Dictionary<string, string>();
            uriParams.Add("id", id.ToString());
            string result = await client.SendRequest(MPEDHttpMethodType.Get, "api/Buildings",
                null, null, uriParams);

            if (!string.IsNullOrEmpty(result))
                return JsonConvert.DeserializeObject<BuildingViewModel>(result);

            return null;
        }

        public async Task<BuildingViewModel> FindBuildingFullData(string token, Guid id)
        {
            HouseWebClient client = new HouseWebClient(token);
            Dictionary<string, string> uriParams = new Dictionary<string, string>();
            uriParams.Add("buildingId", id.ToString());
            string result = await client.SendRequest(MPEDHttpMethodType.Get, "api/Buildings",
                "FindBuildingFullData", null, uriParams);

            if (!string.IsNullOrEmpty(result))
                return JsonConvert.DeserializeObject<BuildingViewModel>(result);

            return null;
        }

        public async Task UpdateSensorsData(string token, UpdateSensorsDataViewModel model)
        {
            HouseWebClient client = new HouseWebClient(token);
            string result = await client.SendRequest(MPEDHttpMethodType.Post, "api/ControlCircuits",
                "UpdateSensorsData", model, null);
        }
    }
}
