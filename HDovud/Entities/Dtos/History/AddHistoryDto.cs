using System;
using Microsoft.AspNetCore.Http;

namespace HDovud.Entities.Dtos.History
{
    public class AddHistoryDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public IFormFile[] File { get; set; }
    }
}