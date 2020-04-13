using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;

namespace DAL
{
    public class LiquidacionEmbargoRepository
    {
        private List<LiquidacionPredio> liquidaciones;
        private const string ruta = "Liquidaciones.txt";
        public LiquidacionEmbargoRepository()
        {
            liquidaciones = new List<LiquidacionPredio>();  
        } 

        public void GuardarLiquidacion(LiquidacionPredio liquidacion)
        {
            FileStream stream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(liquidacion.NumeroLiquidacion +";"+ liquidacion.Persona.Cedula + ";" + liquidacion.Persona.Nombre + ";" + liquidacion.CategoriaPredio + ";" + liquidacion.Persona.Estrato + ";" + liquidacion.Avaluo + ";" + liquidacion.Tarifa + ";" + liquidacion.ValorImpuesto);
            writer.Close();
            stream.Close();
        }

        public void ModificarLiquidacion(LiquidacionPredio liquidacion)
        {
            Consultar();
            FileStream stream = new FileStream(ruta, FileMode.Create);
            stream.Close();
            foreach (var item in liquidaciones)
            {
                if (liquidacion.NumeroLiquidacion.Equals(item.NumeroLiquidacion))
                {
                    GuardarLiquidacion(liquidacion);
                }
                else
                {
                    GuardarLiquidacion(item);
                }
            }
        }

        public void EliminarLiquidacion(LiquidacionPredio liquidacion)
        {
            Consultar();
            FileStream stream = new FileStream(ruta, FileMode.Create);
            stream.Close();
            foreach (var item in liquidaciones)
            {
                if (liquidacion.NumeroLiquidacion!=item.NumeroLiquidacion)
                {
                    GuardarLiquidacion(item);
                }
                
            }
        }

        public List<LiquidacionPredio> Consultar()
        {
            liquidaciones.Clear();
            FileStream stream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);
            string contadorLinea = string.Empty;
            while ((contadorLinea = reader.ReadLine()) != null)
            {
                string[] datos = contadorLinea.Split(';');
                LiquidacionPredio liquidacion=null;
                Persona persona;
                string nombre, cedula;
                int estrato;
                if (datos[3].Equals("RURAL"))
                {
                    liquidacion = new PredioRural(0);
                }
                else
                {
                    liquidacion = new PredioUrbano(0);
                }
                liquidacion.NumeroLiquidacion = datos[0];
                cedula = datos[1];
                nombre = datos[2];
                liquidacion.CategoriaPredio = datos[3];
                estrato = int.Parse(datos[4]);
                liquidacion.Avaluo = decimal.Parse(datos[5]);
                liquidacion.Tarifa = decimal.Parse(datos[6]);
                liquidacion.ValorImpuesto = decimal.Parse(datos[7]);
                persona = new Persona(cedula, nombre, estrato);
                liquidacion.AgregarPersona(persona);
                liquidaciones.Add(liquidacion);
            }
            reader.Close();
            stream.Close();
            return liquidaciones;
        }


        public LiquidacionPredio Buscar(string numero)
        {
            Consultar();
            LiquidacionPredio liquidacion = null;
            return liquidacion=liquidaciones.Find(L => L.NumeroLiquidacion.Equals(numero));
        }
        
    }
}
