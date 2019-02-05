using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ASP_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
    
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Backend.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        // GET api/<controller>/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return name;
        }

        // POST api/<controller>
        [HttpPost]
        public Task<HttpResponseMessage> PostFile()
        {
            //HttpRequestMessage request = this.Request;
            //if (!request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            //string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
            //var provider = new MultipartFormDataStreamProvider(root);

            //var task = request.Content.ReadAsMultipartAsync(provider).
            //    ContinueWith<HttpResponseMessage>(o =>
            //    {

            //        string file1 = provider.BodyPartFileNames.First().Value;
            //// this is the file name on the server where the file was saved 

            //return new HttpResponseMessage()
            //        {
            //            Content = new StringContent("File uploaded.")
            //        };
            //    }
            //);
            //return task;
            return null;
        }
    }
}
