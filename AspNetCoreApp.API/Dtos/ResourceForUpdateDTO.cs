using System;

namespace AspNetCoreApp.API.Dtos
{
    public class ResourceForUpdateDTO
    {
        public string rm_First_Name { get; set; }
        public string rm_Last_Name { get; set; }
        public int rm_Role_Id { get; set; }
        public string rm_address { get; set; }
        public string rm_Contactno { get; set; }
        public string rm_City { get; set; }
        public string rm_Country { get; set; }
        public string rm_Postalcode { get; set; }
        public byte rm_Active { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public string rm_Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public ResourceForUpdateDTO()
        {
            modified_on = DateTime.Now;
            modified_by = "Admin";
        }

    }
}