using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos.History;
using HDovud.Entities.Models;
using Microsoft.AspNetCore.Http;

namespace HDovud.Service
{
    public class HistoryService : IHistoryService
    {
        public async Task<Response> CreateHistoryAsync(AddHistoryDto model)
        {
            History history = new History()
            {
                Description = model.Description,
                Title = model.Title,
                CreateDate = DateTime.Now
            };
            if (model.File != null)
                await CreateHistoryFiles(model.File, history.Id);
        }

        private async Task CreateHistoryFiles(IFormFile[] modelFile,int historyId)
        {
            var images = new List<HistoryFiles>();
            if (modelFile != null)
            {
                foreach (var img in modelFile)
                {
                    string path = Path.GetFullPath("wwwroot/images/historyImage");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileExtension = Path.GetExtension(img.Name);
                    var fileName = $"{Guid.NewGuid()}{fileExtension}";
                    var finalFileName = Path.Combine(path, fileName);

                    using (var steram = System.IO.File.Create(finalFileName))
                    {
                        await img.CopyToAsync(steram);
                    }
                    
                    images.Add(new HistoryFiles
                    {
                        Name = fileName,
                        HistoryId = historyId,
                        CreateDate = DateTime.Now,
                        FileSize = (img.Length / 1024).ToString()
                    });
                }
            }
            
        }
    }
}