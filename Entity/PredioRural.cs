using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PredioRural : LiquidacionPredio
    {
        public PredioRural(decimal avaluo) : base(avaluo)
        {
            CategoriaPredio = "RURAL";
        }

        public override decimal CalcularPredio()
        {
            Tarifa = 2;
            return ValorImpuesto = (Avaluo * Tarifa) / 1000;
        }
    }
}
