using System;

namespace AspNetCoreApp.API.Dtos.groupDTO
{
    public class groupForUpdateDTO
    {
        public string group_Name { get; set; }   
        public int rolesId { get; set; }     
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }  

        public groupForUpdateDTO()
        {
            modified_on = DateTime.Now;
            modified_by = "Admin";
        } 
        
    }
}