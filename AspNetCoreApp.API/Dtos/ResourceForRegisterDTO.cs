using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.API.Dtos
{
    public class ResourceForRegisterDTO
    {
        [Required]
        public string rm_Login_Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must be specify password between 4 to 20")]
        public string password { get; set; }
        [Required]
        public string rm_Gender { get; set; }
        [Required]
        public string rm_Email { get; set; }
        [Required]
        public DateTime rm_DateOfBirth { get; set; }
        public DateTime rm_LastActive { get; set; }
        public DateTime created_on { get; set;}
        public string created_by { get; set; }

        public ResourceForRegisterDTO()
        {
            rm_LastActive = DateTime.Now;
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}