using APIClasses;
using DataWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BusinessWebAPI.Controllers
{
    [Route("api/getall")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
        private string DataWebServiceUrl = "http://localhost:5287";

        [HttpGet("{index}")]
        public ActionResult<DataIntermed> Get(int index)
        {
            var client = new RestClient(DataWebServiceUrl);
            var request = new RestRequest($"api/data/{index}", Method.Get);

            var response = client.Execute<DataStructDTO>(request);

            if (response.IsSuccessful)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest($"Error fetching data from DataWebAPI: {response.StatusDescription}");
            }
        }
    }
}
