using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDovud.Entities.Models
{
    public class HistoryFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileSize { get; set; }
        public int HistoryId { get; set; }
        public bool IsMain { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("HistoryId")]
        public virtual History History { get; set; }
    }
}