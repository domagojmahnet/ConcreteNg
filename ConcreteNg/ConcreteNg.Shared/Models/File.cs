using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Project? Project { get; set; }

        public File()
        {

        }

        public File(string fileName, string filePath, Project? project)
        {
            FileName = fileName;
            FilePath = filePath;
            Project = project;
        }
    }
}
