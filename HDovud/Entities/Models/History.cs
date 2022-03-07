using System;
using System.Collections.Generic;

namespace HDovud.Entities.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HisFile { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual IEnumerable<HistoryFiles> HistoryFiles { get; set; }
    }
}