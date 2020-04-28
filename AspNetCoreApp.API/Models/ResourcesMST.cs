using System;
using System.Collections.Generic;

namespace AspNetCoreApp.API.Models
{
    public class ResourcesMST
    {
        public int ID { get; set; }
        public string rm_First_Name { get; set; }
        public string rm_Middle_Name { get; set; }
        public string rm_Last_Name { get; set; }
        public string rm_Login_Id { get; set; }
        public string rm_Email { get; set; }
        public int rm_Role_Id { get; set; }
        public string rm_Gender { get; set; }
        public DateTime rm_DateOfBirth { get; set; }
        public string rm_address { get; set; }
        public string rm_Contactno { get; set; }
        public string rm_City { get; set; }
        public string rm_Country { get; set; }
        public string rm_Postalcode { get; set; }
        public byte rm_Active { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public string  rm_KnownAS { get; set; }
        public DateTime rm_LastActive { get; set; }
        public string rm_Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}