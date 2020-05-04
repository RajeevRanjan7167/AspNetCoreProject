using System;

namespace AspNetCoreApp.API.Dtos.fieldDTO
{
    public class filedForCreateDTO
    {
        public string fi_Name { get; set; }
        public decimal fi_Amount { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public byte is_active { get; set; }
        public filedForCreateDTO()
        {
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}