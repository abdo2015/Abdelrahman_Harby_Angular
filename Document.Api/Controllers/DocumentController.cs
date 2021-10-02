using Document.Core;
using Document.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Document.Api.Controllers
{
    public class model{
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        public DocumentController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        // GET: api/<DocumentController>
        [HttpGet]
        public ActionResult GetAllDocuments()
        {
            try
            {
                var AllDocuments = _UnitOfWork.DocumentRepository.GetAll().OrderByDescending(date => date.CreationDate).ToList();

                return Ok(AllDocuments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Documents> GetDocumentByID(int id)
        {
            try {
                var Document = _UnitOfWork.DocumentRepository.GetById(id);
                if (Document == null)
                    return NotFound("Document is not found");
                return Document;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        // POST api/<DocumentController>
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadDocument()
        {
            try {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "data");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    Documents doc = new Documents
                    {
                        DocumentTitle = fileName,
                        DocumentURL = dbPath,
                        Description = Request.Form["description"]
                    };
                    var uploadedDocument = _UnitOfWork.DocumentRepository.Add(doc);
                    var checker = _UnitOfWork.DocumentRepository.GetAll().Where(x => x.DocumentTitle == doc.DocumentTitle).SingleOrDefault();
                    if (checker != null)
                    {
                        ModelState.AddModelError("Title", "the title is already taken");
                        return BadRequest(ModelState);
                    }
                    _UnitOfWork.Complete();
                    return Ok(uploadedDocument);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }



        // DELETE api/<DocumentController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _UnitOfWork.DocumentRepository.Delete(id);
                _UnitOfWork.Complete();
                return  Ok(GetAllDocuments()) ;
            }
            catch (Exception ex)
            {

                return NotFound("Ducoment is not Found");
            }
        }
    

    // DELETE api/<DocumentController>/5
    [HttpGet("{String}")]
    public IActionResult CheckTitle(string Title)
    {
        if (_UnitOfWork.DocumentRepository.GetAll().Where(x=>x.DocumentTitle == Title)!=null)
            return Ok();
        else
            return NotFound();

    }

    }
}
