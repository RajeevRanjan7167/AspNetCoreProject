using System;

namespace AspNetCoreApp.API.Dtos.fieldDTO
{
    public class fieldForUpdateDTO
    {
        public string fi_Name { get; set; }
        public decimal fi_Amount { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
        public fieldForUpdateDTO()
        {
            modified_on = DateTime.Now;
            modified_by = "Admin";
        }
    }
}