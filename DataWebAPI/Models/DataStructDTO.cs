using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace DataWebAPI.Models
{
    public class DataStructDTO
    {
        public int bal { get; set; }
        public uint acct { get; set; }
        public uint pin { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        //public byte[] profileImage { get; set; }
    }
}
