using System;

namespace AspNetCoreApp.API.Dtos.componentDTO
{
    public class componentForCreateDTO
    {
        public string com_Name { get; set; }
        public string com_Ext_Name { get; set; }
        public int groupId { get; set; }
        public int rolesId { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public byte is_active { get; set; }
        public componentForCreateDTO()
        {
            created_on = DateTime.Now;
            created_by = "Admin";
        }
    }
}