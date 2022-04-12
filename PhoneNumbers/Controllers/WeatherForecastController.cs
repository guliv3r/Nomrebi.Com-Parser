using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace PhoneNumbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public async Task<NomrebiResponse> Get(string phoneNumber)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://simpleapi.info/apps/numbers-info/info.php?results=json"))
                {
                    request.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Pragma", "no-cache");
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/javascript, */*; q=0.01");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
                    request.Headers.TryAddWithoutValidation("Host", "simpleapi.info");
                    request.Headers.TryAddWithoutValidation("Referer", "https://simpleapi.info/apps/numbers-info/info.php?results=json");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:60.0) Gecko/20100101 Firefox/60.0");
                    request.Headers.TryAddWithoutValidation("Origin", "http://simpleapi.info");
                    request.Content = new StringContent($"number={phoneNumber}&u_id=227607&u_token=OAbjfTEqCKDho8fo9xuYIEeS6WOdNY", Encoding.UTF8, "application/x-www-form-urlencoded");
                    request.Content.Headers.Add("Cookie", "__cf_bm=OPKdZikrC_sBjr3hleLEYzfyq6lgCnPCWg7.Df7_E9o-1649674063-0-AYyF1c3zmNRi1R3f8ZxjBJEgDDM9VIj/bIqy+W8Dl7wuBA4Vnrtct6B/P3lfhE0DGKpFRH0JIDdCuUwjpH+Gt8U=; path=/; expires=Mon, 11-Apr-22 11:17:43 GMT; domain=.simpleapi.info; HttpOnly; Secure; SameSite=None");

                    var response = await httpClient.SendAsync(request);
                    string content = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<NomrebiResponse>(content);
                    return responseObject;
                }
            }
        }

    }

    public class NomrebiResponse
    {
        public string res { get; set; }
        public string valid_number { get; set; }
        public string locked { get; set; }
        public List<string> items { get; set; }
    }

}