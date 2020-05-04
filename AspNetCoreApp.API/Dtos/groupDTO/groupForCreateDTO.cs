using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.API.Dtos.groupDTO
{
    public class groupForCreateDTO
    {
        [Required]
        public string group_Name { get; set; }   
        public int rolesId { get; set; }     
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public byte is_active { get; set; }    
        public groupForCreateDTO()
        {
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}