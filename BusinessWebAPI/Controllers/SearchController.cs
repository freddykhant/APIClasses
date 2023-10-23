using APIClasses;
using DataWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BusinessWebAPI.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private string DataWebServiceUrl = "http://localhost:5287";

        [HttpPost]
        public ActionResult<DataIntermed> Post([FromBody] SearchData searchData)
        {
            var client = new RestClient(DataWebServiceUrl);
            var request = new RestRequest("api/data/search", Method.Post);
            request.AddJsonBody(searchData);

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
