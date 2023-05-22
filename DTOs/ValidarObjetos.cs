using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.DTOs
{
    public class ValidarObjetos
    {
        private readonly IConfiguration _configuration;

        public ValidarObjetos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ValidarObjetos()
        {
        }

        public bool NombreArchivotxt(string nombre)
        {
            string log_file_path = _configuration["LOG_FILE_PATH"];

            bool lverdad = log_file_path == nombre ? true : false;

            return lverdad;
        }

        public string CapacidadArchivotxt()
        {
            var log_file_path = _configuration["LOG_FILE_PATH"];

            return new System.IO.FileInfo(log_file_path).Length == 0 ? "Vacio": "Lleno";
        }
    }
}
