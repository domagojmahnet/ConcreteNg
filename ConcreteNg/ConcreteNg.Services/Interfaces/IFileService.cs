using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = ConcreteNg.Shared.Models.File;

namespace ConcreteNg.Services.Interfaces
{
    public interface IFileService
    {
        List<File> GetFiles(int projectId);
        int UploadFiles(List<IFormFile> files, int projectId);
        File DownloadFile(int id);
    }
}
