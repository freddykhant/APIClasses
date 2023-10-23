using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BusinessWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private string DataWebServiceUrl = "http://localhost:5287";

        [HttpGet]
        public ActionResult<int> Get()
        {
            var client = new RestClient(DataWebServiceUrl);
            var request = new RestRequest("entries", Method.Get);

            var response = client.Execute<int>(request);

            return response.Data;
        }
    }
}
