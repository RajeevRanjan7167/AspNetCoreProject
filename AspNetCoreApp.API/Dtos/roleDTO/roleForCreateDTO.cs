using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.API.Dtos.roleDTO
{
    public class roleForCreateDTO
    {
        [Required]
        public string role_Name { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public byte is_active { get; set; }

        public roleForCreateDTO()
        {
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}