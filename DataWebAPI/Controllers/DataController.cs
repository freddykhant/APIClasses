using APIClasses;
using Database;
using DataWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DataWebAPI.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DatabaseClass _database;

        public DataController()
        {
            _database = new DatabaseClass();
        }

        [HttpGet("entries")]
        public IActionResult GetNumEntries()
        {
            return Ok(_database.GetNumEntries());
        }

        [HttpGet("{index}")]
        public IActionResult GetValuesForEntry(int index)
        {
            try
            {
                var entry = new DataStructDTO
                {
                    acct = _database.GetAcctNoByIndex(index),
                    pin = _database.GetPINByIndex(index),
                    bal = _database.GetBalanceByIndex(index),
                    fname = _database.GetFirstNameByIndex(index),
                    lname = _database.GetLastNameByIndex(index),
                    //profileImage = _database.GetProfileImageByIndex(index)
                };
                return Ok(entry);
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest("Index is out of range");
            }
        }

        [HttpPost("search")]
        public IActionResult SearchRecords([FromBody] SearchData searchData)
        {
            var record = _database.SearchRecords(searchData.searchStr);

            if (record != null)
            {
                var recordDTO = new DataStructDTO
                {
                    acct = record.acctNo,
                    pin = record.pin,
                    bal = record.balance,
                    fname = record.firstName,
                    lname = record.lastName,
                    //profileImage = record.profileImage
                };
                return Ok(recordDTO);
            }
            else
            {
                return NotFound("No record found for the given search criteria");
            }
        }
    }
}
