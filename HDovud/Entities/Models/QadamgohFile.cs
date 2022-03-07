using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDovud.Entities.Models
{
    public class QadamgohFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileSize { get; set; }
        public int QadangohId { get; set; }
        public bool IsMain { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("QadangohId")]
        public virtual Qadamgoh Qadamgoh { get; set; }
    }
}