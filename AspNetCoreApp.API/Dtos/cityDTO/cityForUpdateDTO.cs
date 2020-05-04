using System;

namespace AspNetCoreApp.API.Dtos.cityDTO
{
    public class cityForUpdateDTO
    {
        public string ct_Name { get; set; }       
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
        public cityForUpdateDTO()
        {
            modified_on = DateTime.Now;
            modified_by = "Admin";
        }
    }
}