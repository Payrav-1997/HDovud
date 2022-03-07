using System;
using System.Collections.Generic;

namespace HDovud.Entities.Models
{
    public class Qadamgoh
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<QadamgohFile> File { get; set; }  

    }
}