using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.API.Dtos
{
    public class ResourceForListDTO
    {
        public int ID { get; set; }
        public string rm_Login_Id { get; set; }
        public string rm_Email { get; set; }
        public int Age { get; set; }
        public string rm_First_Name { get; set; }
        public string rm_Middle_Name { get; set; }
        public string rm_Last_Name { get; set; }
        public int rm_Role_Id { get; set; }
        public string rm_Gender { get; set; }
        public DateTime rm_DateOfBirth { get; set; }        
        public int rm_age { get; set; }
        public string rm_address { get; set; }
        public string rm_Contactno { get; set; }
        public string rm_City { get; set; }
        public string rm_Country { get; set; }
        public string rm_Postalcode { get; set; }
        public byte rm_Active { get; set; }
        public string rm_Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime CREATEDON { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public string PhotoUrl { get; set; }
    }
}