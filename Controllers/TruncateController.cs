using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruncateController : Controller
    {

        private readonly IConfiguration _configuration;

        public TruncateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IEnumerable<Truncate> Get()
        {

            var log_file_path = _configuration["LOG_FILE_PATH"];

            if (System.IO.File.Exists(log_file_path))
            {
                StreamWriter ar = new StreamWriter(log_file_path, false);
                ar.Write(string.Empty);
                ar.Close();
            }


            return Enumerable.Range(1, 1).Select(index => new Truncate
            {
                Code = 200,
                Message = "log truncado"
            })
            .ToArray();
        }


    }
}
