using System;
using System.Collections.Generic;

namespace HDovud.Entities.Models
{
    public class RestZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool BestRestZone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<RestZoneFiles> Files { get; set; }
    }
}