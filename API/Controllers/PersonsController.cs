using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService _service;
        private readonly IHostingEnvironment _hostingEnvironment;

        public string Path
        {
            get
            {  
                return _hostingEnvironment.ContentRootPath + @"\App_Data\data.csv"; 
            } 
        }

        public PersonsController(IService service, IHostingEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }
         
        [HttpGet]
        public IList<Person> Get()
        {
            return _service.Get(Path);
        }

         
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _service.GetById(Path, id);
        }

        [HttpGet("color/{color}")]
        public List<Person> Color(Color color)
        {
            return _service.GetByColor(Path, color);
        }
    }
}
