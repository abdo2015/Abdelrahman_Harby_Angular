using Document.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Document.EF.Repository
{
    class FileHandler : IFileHandler
    {
        public string getFileName(IFormFile file)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            return fileName;
        }
        public string pathToSave(string folderName)
        {
            
            return Path.Combine(Directory.GetCurrentDirectory(), folderName);
        }
        public string pathToSave( string folderName1 , string folderName2)
        {
            var folderName = Path.Combine(folderName1, folderName2);
            return Path.Combine(Directory.GetCurrentDirectory(), folderName);
        }

        public string getFileUrl(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
