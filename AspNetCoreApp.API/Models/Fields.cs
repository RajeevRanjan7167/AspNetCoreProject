using System;

namespace AspNetCoreApp.API.Models
{
    public class Fields
    {
        public int id { get; set; }
        public string fi_Name { get; set; }
        public decimal fi_Amount { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
    }
}