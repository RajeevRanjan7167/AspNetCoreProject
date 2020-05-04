using System;

namespace AspNetCoreApp.API.Dtos.cityDTO
{
    public class cityForCreateDTO
    {
        public string ct_Name { get; set; }       
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public byte is_active { get; set; }
        public cityForCreateDTO()
        {
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}