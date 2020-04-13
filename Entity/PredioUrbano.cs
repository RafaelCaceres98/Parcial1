using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PredioUrbano : LiquidacionPredio
    {
        public PredioUrbano(decimal avaluo) : base(avaluo)
        {
            CategoriaPredio = "URBANO";
        }

        public override decimal CalcularPredio()
        {
            CalcularTarifa();
            return ValorImpuesto = (Avaluo * Tarifa) / 1000;
        }

        public decimal CalcularTarifa()
        {
            if (Persona.Estrato == 1)
            {
                Tarifa = 2;
            }
            if(Persona.Estrato==2 || Persona.Estrato == 3)
            {
                Tarifa = 3;
            }
            if(Persona.Estrato==4 || Persona.Estrato == 5)
            {
                Tarifa = 6;
            }
            return Tarifa;
        }
    }
}
