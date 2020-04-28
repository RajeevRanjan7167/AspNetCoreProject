using System;

namespace AspNetCoreApp.API.Models
{
    public class city
    {
        public int id { get; set; }
        public string ct_Name { get; set; }       
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }

    }
}