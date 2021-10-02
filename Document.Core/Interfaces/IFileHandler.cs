using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Core.Interfaces
{
     public interface IFileHandler
    {
        string getFileName(IFormFile file);
        string getFileUrl(IFormFile file);
        string pathToSave(string folderName);
        string pathToSave(string folderName1, string folderName2);
    }
}
