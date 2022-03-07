using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDovud.Entities.Models
{
    public class RestZoneFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestZoneId { get; set; }
        public bool IsMain { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("RestZoneId")]
        public virtual RestZone RestZone { get; set; }
    }
}