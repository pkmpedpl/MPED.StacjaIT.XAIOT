using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Services.Web
{
    public class HouseWebClient
    {
        private static string WEB_SERVICE_URL = "http://mp-electronics.com.pl:8080/xaiotstacjait";

        private HttpClient _httpClient = null;
        private string _token = null;
        private readonly CookieContainer _cookieContainer;
        public HouseWebClient()
        {
            _httpClient = new HttpClient();
            _cookieContainer = new CookieContainer();

            var messageHandler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer
            };

            _httpClient = new HttpClient(messageHandler);
        }

        public HouseWebClient(string token)
            : this()
        {
            _token = token;
        }

        public async Task<string> SendRequest(MPEDHttpMethodType httpMethod, string controller, string action, Dictionary<string, string> urlParams)
        {
            return await SendRequest(httpMethod, controller, action, null, urlParams);
        }

        public async Task<string> SendRequest(MPEDHttpMethodType httpMethod, string controller, string action, object body, Dictionary<string, string> urlParams)
        {
            if (!string.IsNullOrEmpty(_token))
                AddAuthorizationHeader(_token);

            string url = CreateFullUrl(controller, action, urlParams);

            switch (httpMethod)
            {
                case MPEDHttpMethodType.Get: return await Get(url);
                case MPEDHttpMethodType.Post: return await Post(body, url);
                case MPEDHttpMethodType.Put: return await Put(body, url);
                case MPEDHttpMethodType.Delete: return await Delete(url);
                default: return await Get(url);
            }
        }

        private string CreateFullUrl(string controller, string action, Dictionary<string, string> urlParams)
        {
            string url = string.Format("{0}/{1}", WEB_SERVICE_URL, controller);
            if (!string.IsNullOrEmpty(action))
                url += string.Format("/{0}", action);
            url += ConvertUrlParams(urlParams);

            return url;
        }

        private async Task<string> Get(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> Put(object body, string url)
        {
            if (body.GetType().Equals(typeof(string)))
            {
                var response = await _httpClient.PutAsync(url, new StringContent((string)body));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var response = await _httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> Post(object body, string url)
        {
            if (body == null)
            {
                var response = await _httpClient.PostAsync(url, new StringContent(""));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            else if (body.GetType().Equals(typeof(string)))
            {
                var response = await _httpClient.PostAsync(url, new StringContent((string)body));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var response = await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> Delete(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string ConvertUrlParams(Dictionary<string, string> urlParams)
        {
            if (urlParams == null)
                return string.Empty;

            List<string> list = new List<string>();

            string idValue = null;
            if (urlParams.ContainsKey("id"))
            {
                idValue = urlParams["id"];
                urlParams.Remove("id");
            }

            foreach (var item in urlParams)
            {
                list.Add(string.Format("{0}={1}", item.Key, item.Value));
            }

            string result = string.IsNullOrEmpty(idValue) ? "" : string.Format("/{0}", idValue);
            if (list.Count > 0)
            {
                result += string.Format("?{0}", string.Join("&", list));
            }

            return result;
        }

        protected void AddAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Remove(HttpHeaders.Authorization);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.Authorization, string.Format("Bearer {0}", token));
        }

        internal class HttpHeaders
        {
            public const string ContentType = "Content-Type";
            public const string AcceptEncoding = "Accept-Encoding";
            public const string Accept = "Accept";
            public const string AcceptLanguage = "Accept-Language";
            public const string UserAgent = "User-Agent";
            public const string Authorization = "Authorization";
        }

        internal class NonStandardHttpHeaders
        {
            public const string MethodOverride = "X-HTTP-Method-Override";
        }

    }

    public enum MPEDHttpMethodType
    {
        Get,
        Post,
        Put,
        Delete
    }
}
