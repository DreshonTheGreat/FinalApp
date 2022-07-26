using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;


namespace FirstProjectApp_SANDERS.Pages
{
    public class WeatherAppModel : PageModel
    {
        public string ForecastResponseBody { get; set; }
        public string insightOneResults { get; set; }
        public string insightTwoResults { get; set; }

        public void OnGet(string result, string insightOne, string insightTwo)
        {
            ForecastResponseBody = result;
            insightOneResults = insightOne;
            insightTwoResults = insightTwo;
        }


        public async Task<IActionResult> OnPost()
        {
            string forecastContent = "[]";

            #region MainCall
            using var client = new HttpClient();
            var result = await client.GetAsync("https://localhost:44319/forecast");
            if (result.IsSuccessStatusCode)
            {
                forecastContent = await result.Content.ReadAsStringAsync();
            }
            #endregion

            return RedirectToPage("WeatherApp", new { result = forecastContent });
        }
    }
}
