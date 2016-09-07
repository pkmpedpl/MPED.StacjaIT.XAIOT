using MPED.StacjaIT.XAIOT.Models.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Services.Web
{
    public class SystemTasksWebService
    {
        public async Task<List<SystemTask>> GetTasks(string token)
        {
            HouseWebClient client = new HouseWebClient(token);
            Dictionary<string, string> uriParams = new Dictionary<string, string>();
            string result = await client.SendRequest(MPEDHttpMethodType.Get, "api/SystemTasks",
                null, null, uriParams);

            if (!string.IsNullOrEmpty(result))
                return JsonConvert.DeserializeObject<List<SystemTask>>(result);

            return null;
        }

        public async Task PostSystemTask(string token, SystemTask model)
        {
            HouseWebClient client = new HouseWebClient(token);
            Dictionary<string, string> uriParams = new Dictionary<string, string>();
            string result = await client.SendRequest(MPEDHttpMethodType.Post, "api/SystemTasks",
                null, model, uriParams);
        }
    }
}
