using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionPredio
    {
        public string NumeroLiquidacion { get; set; }
        public decimal Avaluo { get; set; }
        public string CategoriaPredio { get; set; }
        public decimal Tarifa { get; set; }
        public decimal ValorImpuesto { get; set; }
        public Persona Persona { get; set; }

        public LiquidacionPredio(decimal avaluo)
        {
            Avaluo = avaluo;
        }

        public abstract decimal CalcularPredio();

        public void AgregarPersona(Persona persona)
        {
            Persona = persona;
        }
    }
}
