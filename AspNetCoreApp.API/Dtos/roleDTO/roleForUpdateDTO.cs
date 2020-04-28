using System;

namespace AspNetCoreApp.API.Dtos.roleDTO
{
    public class roleForUpdateDTO
    {
        public string role_Name { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
        public roleForUpdateDTO()
        {
            modified_by = "Admin";
            modified_on = DateTime.Now;
        }        
    }
}