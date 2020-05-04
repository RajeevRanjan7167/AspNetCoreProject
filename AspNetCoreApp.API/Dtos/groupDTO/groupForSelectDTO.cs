using System;

namespace AspNetCoreApp.API.Dtos.groupDTO
{
    public class groupForSelectDTO
    {
        public int id { get; set; }
        public string group_Name { get; set; }   
        public int rolesId { get; set; }     
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; } 
    }
}