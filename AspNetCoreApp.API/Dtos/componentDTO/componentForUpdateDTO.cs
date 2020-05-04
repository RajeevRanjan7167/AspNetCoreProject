using System;

namespace AspNetCoreApp.API.Dtos.componentDTO
{
    public class componentForUpdateDTO
    {
        public string com_Name { get; set; }
        public string com_Ext_Name { get; set; }
        public int groupId { get; set; }
        public int rolesId { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_on { get; set; }
        public byte is_active { get; set; }
        public componentForUpdateDTO()
        {
            modified_on = DateTime.Now;
            modified_by = "Admin";
        }
    }
}