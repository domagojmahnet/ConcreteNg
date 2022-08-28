using ConcreteNg.Repositories;
using ConcreteNg.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using File = ConcreteNg.Shared.Models.File;

namespace ConcreteNg.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;

        public FileService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public List<File> GetFiles(int projectId)
        {
            return unitOfWork.fileRepository.FindAll().Where(x => x.Project.ProjectId == projectId).ToList();
        }

        public int UploadFiles(List<IFormFile> files, int projectId)
        {
            var project = unitOfWork.projectRepository.Read(projectId);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    unitOfWork.fileRepository.Create(new File(formFile.FileName, filePath, project));

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }
            return unitOfWork.Complete();
        }

        public File DownloadFile(int id)
        {
            return unitOfWork.fileRepository.Read(id);
        }
    }
}
