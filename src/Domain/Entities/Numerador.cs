using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Domain.Entities
{
    public class Numerador
    {
        public int id { get; set; } 
        public int ultimoNumero {  get; set; }
        public int fechaHoraUltimoNumero { get; set; }
    }
}
