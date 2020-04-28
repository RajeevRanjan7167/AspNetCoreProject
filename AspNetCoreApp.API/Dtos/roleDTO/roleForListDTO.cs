using System;

namespace AspNetCoreApp.API.Dtos.roleDTO
{
    public class roleForListDTO
    {
        public int id { get; set; }
        public string role_Name { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }        
        public byte is_active { get; set; }
    }
}