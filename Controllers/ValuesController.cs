using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using src.Models;
using System.Globalization;

namespace src.Controllers
{
    [Route("/")]
    public class RootController : Controller
    {
        [HttpPost("Submit")]
        public ActionResult Submit(Form model)
        {
            string prediction = "";
            try
            {
                Console.WriteLine($"Submitted house area: {model.houseArea}, build year: {model.buildYear}");
                prediction = Predict(model.houseArea, model.buildYear).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            ViewData["Prediction"]  = prediction;
            return View("Submit");
        }

        // GET /
        [HttpGet("")]
        public IActionResult Index() {
            return View();
        }
        static async Task<string> Predict(int houseArea, int buildYear) {
            using (var client = new HttpClient())
            {
                var scoreRequest = new 
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>> () {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "LotArea", houseArea.ToString()
                                            },
                                            {
                                                "YearBuilt", buildYear.ToString()
                                            },
                                            {
                                                "SalePrice", "0"
                                            },

                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>() {
                    }
                };

                const string apiKey = "gRmL+AtuKnj1GUgAGgpHhIpg9ROJRzfk6WpUwn6eMBxzVt/rGTMWmhpo1vehyN9W68J+OcAR8ZpGNUvWZpS2Ow=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/c9d75f957bf54c309caf9d580620beb4/services/15eedb04f50a46febd8b8804ffd48ea7/execute?api-version=2.0&format=swagger");

                HttpResponseMessage response = await client
                    .PostAsync("", new StringContent(JsonConvert.SerializeObject(scoreRequest), Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string score = await response.Content.ReadAsStringAsync();
                    Data z = JsonConvert.DeserializeObject<Data>(score);
                
                    double result;
                    double.TryParse(z.Results.output1.First()["Scored Labels"], NumberStyles.Number, CultureInfo.CurrentCulture, out result);
                    return String.Format("{0:0.00}", result);
                }
                else
                {
                    return "";
                }

            }
        }

        public class Data {
                public Results Results { get; set; }
        }

        public class Results {
             public IEnumerable<IDictionary<string, string>> output1 { get; set; }
        }
    }
}
