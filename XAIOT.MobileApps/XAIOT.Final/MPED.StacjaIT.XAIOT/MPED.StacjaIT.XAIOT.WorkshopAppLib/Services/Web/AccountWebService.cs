using MPED.StacjaIT.XAIOT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Services.Web
{
    public class AccountWebService
    {
        public async Task<UserAccountToken> GetToken(string userName, string password)
        {
            HouseWebClient client = new HouseWebClient();
            string result = await client.SendRequest(MPEDHttpMethodType.Post, "Token",
                null, string.Format("grant_type=password&username={0}&password={1}", userName, password), null);

            if (!string.IsNullOrEmpty(result))
                return JsonConvert.DeserializeObject<UserAccountToken>(result);

            return null;
        }
    }
}

