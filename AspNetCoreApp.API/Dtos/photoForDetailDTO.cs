using System;

namespace AspNetCoreApp.API.Dtos
{
    public class photoForDetailDTO
    {
        public int ID { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public bool ismain { get; set; }
    }
}