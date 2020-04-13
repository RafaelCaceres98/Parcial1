using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Estrato { get; set; }

        public Persona(string cedula,string nombre,int estrato)
        {
            Cedula = cedula;
            Nombre = nombre;
            Estrato = estrato;
        }
    }
}
