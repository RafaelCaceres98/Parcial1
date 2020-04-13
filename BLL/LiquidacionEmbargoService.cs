using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class LiquidacionEmbargoService
    {
        public LiquidacionEmbargoRepository LiquidacionRepositorio;

        public LiquidacionEmbargoService()
        {
            LiquidacionRepositorio = new LiquidacionEmbargoRepository();
        }

        public string GuardarLiquidacion(LiquidacionPredio liquidacion)
        {
            if (LiquidacionRepositorio.Buscar(liquidacion.NumeroLiquidacion) == null)
            {
                LiquidacionRepositorio.GuardarLiquidacion(liquidacion);
                return $"Se ha guardado la liquidacion {liquidacion.NumeroLiquidacion} ";
            }
            else
            {
                return $"Ya existe la liquidacion. ";
            }
        }

        public string ModificarLiquidacion(LiquidacionPredio liquidacion)
        {
            if (LiquidacionRepositorio.Buscar(liquidacion.NumeroLiquidacion) == null)
            {
                return $"No existe la liquidacion. ";
            }
            else
            {
                LiquidacionRepositorio.ModificarLiquidacion(liquidacion);
                return $"Se ha modificado la liquidacion: {liquidacion.NumeroLiquidacion} ";
            }
        }

        public string EliminarLiquidacion(LiquidacionPredio liquidacion)
        {
            if (LiquidacionRepositorio.Buscar(liquidacion.NumeroLiquidacion) == null)
            {
                return $"No existe la liquidacion. ";
            }
            else
            {
                LiquidacionRepositorio.EliminarLiquidacion(liquidacion);
                return $"Se ha eliminado la liquidacion: {liquidacion.NumeroLiquidacion} ";
            }
        }


        public List<LiquidacionPredio> Consultar()
        {
            return LiquidacionRepositorio.Consultar();
        }

        public LiquidacionPredio Buscar(string numero)
        {
            return LiquidacionRepositorio.Buscar(numero);
        }
         
    }
}
