using System;

namespace AspNetCoreApp.API.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public bool ismain { get; set; }
        public ResourcesMST ResourcesMST { get; set; }
        public int ResourcesMSTID { get; set; }
    }
}