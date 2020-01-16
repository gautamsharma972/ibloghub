using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iBlogHub.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using static System.Net.WebRequestMethods;

namespace iBlogHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageHandlerController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageHandlerController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult Post(FileUploadModel model)
        {
            if (new FileExtensionContentTypeProvider().TryGetContentType(model.FileName, out var contentType))
            {
                string fileName = "";
                if (model.FileName != null)
                {
                    try
                    {
                        Random rnd = new Random();
                        string filename = model.FileName;
                        filename = _hostingEnvironment.WebRootPath + "\\Uploads" + $@"\{filename}";
                        if (!System.IO.File.Exists(filename))
                        {
                            System.IO.File.WriteAllBytes(filename, model.FileBytes);                           
                            fileName = model.FileName;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        return UnprocessableEntity(new { Message = $"Cannot determine content type for file '{model.FileName}'." });
                    }
                                 
                }
                string imageUrl =  Request.Scheme +"://"+ Request.Host + "/Uploads/"+fileName;
                return Ok(new { imageUrl });
            }

            return UnprocessableEntity(new { Message = $"Cannot determine content type for file '{model.FileName}'." });
        }
    }
}