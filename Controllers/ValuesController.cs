using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace src.Controllers
{
    [Route("/")]
    public class RootController : Controller
    {

        [HttpPost("Submit")]
        public void Submit()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["Text1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["Text2"].ToString());
                ViewBag.Result = (num1 - num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            // return View();
        }

        // GET /
        [HttpGet("")]
        public IActionResult Index() {
            // var msg = Predict();
            // return new string[] { msg.Result };
            return View();
        }

        static async Task<string> Predict() {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>> () {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Id", "1"
                                            },
                                            {
                                                "MSSubClass", "1"
                                            },
                                            {
                                                "MSZoning", ""
                                            },
                                            {
                                                "LotFrontage", ""
                                            },
                                            {
                                                "LotArea", "8450"
                                            },
                                            {
                                                "Street", ""
                                            },
                                            {
                                                "Alley", ""
                                            },
                                            {
                                                "LotShape", ""
                                            },
                                            {
                                                "LandContour", ""
                                            },
                                            {
                                                "Utilities", ""
                                            },
                                            {
                                                "LotConfig", ""
                                            },
                                            {
                                                "LandSlope", ""
                                            },
                                            {
                                                "Neighborhood", ""
                                            },
                                            {
                                                "Condition1", ""
                                            },
                                            {
                                                "Condition2", ""
                                            },
                                            {
                                                "BldgType", ""
                                            },
                                            {
                                                "HouseStyle", ""
                                            },
                                            {
                                                "OverallQual", "1"
                                            },
                                            {
                                                "OverallCond", "1"
                                            },
                                            {
                                                "YearBuilt", "2003"
                                            },
                                            {
                                                "YearRemodAdd", "1"
                                            },
                                            {
                                                "RoofStyle", ""
                                            },
                                            {
                                                "RoofMatl", ""
                                            },
                                            {
                                                "Exterior1st", ""
                                            },
                                            {
                                                "Exterior2nd", ""
                                            },
                                            {
                                                "MasVnrType", ""
                                            },
                                            {
                                                "MasVnrArea", ""
                                            },
                                            {
                                                "ExterQual", ""
                                            },
                                            {
                                                "ExterCond", ""
                                            },
                                            {
                                                "Foundation", ""
                                            },
                                            {
                                                "BsmtQual", ""
                                            },
                                            {
                                                "BsmtCond", ""
                                            },
                                            {
                                                "BsmtExposure", ""
                                            },
                                            {
                                                "BsmtFinType1", ""
                                            },
                                            {
                                                "BsmtFinSF1", "1"
                                            },
                                            {
                                                "BsmtFinType2", ""
                                            },
                                            {
                                                "BsmtFinSF2", "1"
                                            },
                                            {
                                                "BsmtUnfSF", "1"
                                            },
                                            {
                                                "TotalBsmtSF", "1"
                                            },
                                            {
                                                "Heating", ""
                                            },
                                            {
                                                "HeatingQC", ""
                                            },
                                            {
                                                "CentralAir", ""
                                            },
                                            {
                                                "Electrical", ""
                                            },
                                            {
                                                "1stFlrSF", "1"
                                            },
                                            {
                                                "2ndFlrSF", "1"
                                            },
                                            {
                                                "LowQualFinSF", "1"
                                            },
                                            {
                                                "GrLivArea", "1"
                                            },
                                            {
                                                "BsmtFullBath", "1"
                                            },
                                            {
                                                "BsmtHalfBath", "1"
                                            },
                                            {
                                                "FullBath", "1"
                                            },
                                            {
                                                "HalfBath", "1"
                                            },
                                            {
                                                "BedroomAbvGr", "1"
                                            },
                                            {
                                                "KitchenAbvGr", "1"
                                            },
                                            {
                                                "KitchenQual", ""
                                            },
                                            {
                                                "TotRmsAbvGrd", "1"
                                            },
                                            {
                                                "Functional", ""
                                            },
                                            {
                                                "Fireplaces", "1"
                                            },
                                            {
                                                "FireplaceQu", ""
                                            },
                                            {
                                                "GarageType", ""
                                            },
                                            {
                                                "GarageYrBlt", ""
                                            },
                                            {
                                                "GarageFinish", ""
                                            },
                                            {
                                                "GarageCars", "1"
                                            },
                                            {
                                                "GarageArea", "1"
                                            },
                                            {
                                                "GarageQual", ""
                                            },
                                            {
                                                "GarageCond", ""
                                            },
                                            {
                                                "PavedDrive", ""
                                            },
                                            {
                                                "WoodDeckSF", "1"
                                            },
                                            {
                                                "OpenPorchSF", "1"
                                            },
                                            {
                                                "EnclosedPorch", "1"
                                            },
                                            {
                                                "3SsnPorch", "1"
                                            },
                                            {
                                                "ScreenPorch", "1"
                                            },
                                            {
                                                "PoolArea", "1"
                                            },
                                            {
                                                "PoolQC", ""
                                            },
                                            {
                                                "Fence", ""
                                            },
                                            {
                                                "MiscFeature", ""
                                            },
                                            {
                                                "MiscVal", "1"
                                            },
                                            {
                                                "MoSold", "1"
                                            },
                                            {
                                                "YrSold", "1"
                                            },
                                            {
                                                "SaleType", ""
                                            },
                                            {
                                                "SaleCondition", ""
                                            },
                                            {
                                                "SalePrice", "1"
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
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return string.Format("The request failed with status code: {0}", response.StatusCode);
                }

                }
        }
    }

    

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
