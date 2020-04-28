using System;
using System.Collections.Generic;
using AspNetCoreApp.API.Models;

namespace AspNetCoreApp.API.Dtos
{
    public class ResourceForDetailsDTO
    {
        
        public int ID { get; set; }
        public string rm_First_Name { get; set; }
        public string rm_Middle_Name { get; set; }
        public string rm_Last_Name { get; set; }
        public string rm_Login_Id { get; set; }
        public string rm_Email { get; set; }
        public int rm_Role_Id { get; set; }
        public int rm_Gender { get; set; }
        public int Age { get; set; }
        public string rm_address { get; set; }
        public string rm_Contactno { get; set; }
        public string rm_City { get; set; }
        public string rm_Country { get; set; }
        public string rm_Postalcode { get; set; }
        public byte rm_Active { get; set; }
        public DateTime craated_on { get; set; }
        public string craated_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
        public string  rm_KnownAS { get; set; }
        public DateTime rm_LastActive { get; set; }
        public string rm_Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<photoForDetailDTO> Photos { get; set; }
    }
}