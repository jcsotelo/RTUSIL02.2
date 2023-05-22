using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        
        public LogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public string[] Get()
        {
            var log_file_path = _configuration["LOG_FILE_PATH"];

            String fila;
            string[] texto = new string[1000];
            int index = 0;

            using (StreamReader ar = new StreamReader(log_file_path))
            {
                fila = ar.ReadLine();

                while (fila != null)
                {
                    texto[index] = fila;

                    fila = ar.ReadLine();
                    index++;
                }

                Array.Resize(ref texto, index);

                ar.Close();
            }

            return texto;
        }
    }
}
