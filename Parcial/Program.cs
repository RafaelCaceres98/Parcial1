using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionPredio liquidacion=null;
            Persona persona;
            LiquidacionEmbargoService liquidacionservice = new LiquidacionEmbargoService();
            string cedula, nombre;
            int estrato;
            decimal avaluo;
            char opcion = 's';

            while (opcion == 's')
            {
                Console.Clear();
                Console.WriteLine("Menu: ");
                Console.WriteLine(" 1 - Registrar liquidacion.  ");
                Console.WriteLine(" 2 - Consultar liquidaciones. ");
                Console.WriteLine(" 3 - Consulta individual. ");
                Console.WriteLine(" 4 - Modificar liquidacion. ");
                Console.WriteLine(" 5 - Eliminar liquidacion.  ");
                Console.WriteLine(" 6 - Salir. ");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Registrar Liquidacion: ");
                        Console.WriteLine("Cedula: ");
                        cedula = Console.ReadLine();
                        Console.WriteLine("Nombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Estrato: ");
                        estrato = int.Parse(Console.ReadLine());
                        persona = new Persona(cedula, nombre, estrato);
                        Console.WriteLine("Avaluo: ");
                        avaluo = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Seleccione el tipo de Predio: ");
                        Console.WriteLine(" 1 - Urbano");
                        Console.WriteLine(" 2 - Rural ");
                        int predio = int.Parse(Console.ReadLine());
                        switch (predio)
                        {
                            case 1:
                                liquidacion = new PredioUrbano(avaluo);
                                break;
                            case 2:
                                liquidacion = new PredioRural(avaluo);
                                break;
                        }
                        liquidacion.AgregarPersona(persona);
                        liquidacion.CalcularPredio();
                        liquidacion.NumeroLiquidacion=(liquidacionservice.Consultar().Count+1).ToString();
                        Console.WriteLine(liquidacionservice.GuardarLiquidacion(liquidacion));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Consulta. ");
                        foreach (var item in liquidacionservice.Consultar())
                        {
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine($"numero de liquidacion: {item.NumeroLiquidacion}");
                            Console.WriteLine($"Cedula: {item.Persona.Cedula} ");
                            Console.WriteLine($"Nombre: {item.Persona.Nombre} ");
                            Console.WriteLine($"Categoria: {item.CategoriaPredio} ");
                            Console.WriteLine($"Estracto: {item.Persona.Estrato} ");
                            Console.WriteLine($"Avaluo: {item.Avaluo} ");
                            Console.WriteLine($"Tarifa: {item.Tarifa} ");
                            Console.WriteLine($"Impuesto: {item.ValorImpuesto}");
                            Console.WriteLine("----------------------------------------------------------------");

                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Consulta indivual. ");
                        Console.WriteLine("Digite el numero de liquidacion. ");
                        string numero = Console.ReadLine();
                        if (liquidacionservice.Buscar(numero) == null)
                        {
                            Console.WriteLine("No existe la liquidacion ");
                        }
                        else
                        {
                            liquidacion = liquidacionservice.Buscar(numero);

                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine($"numero de liquidacion: {liquidacion.NumeroLiquidacion}");
                            Console.WriteLine($"Cedula: {liquidacion.Persona.Cedula} ");
                            Console.WriteLine($"Nombre: {liquidacion.Persona.Nombre} ");
                            Console.WriteLine($"Categoria: {liquidacion.CategoriaPredio} ");
                            Console.WriteLine($"Estracto: {liquidacion.Persona.Estrato} ");
                            Console.WriteLine($"Avaluo: {liquidacion.Avaluo} ");
                            Console.WriteLine($"Tarifa: {liquidacion.Tarifa} ");
                            Console.WriteLine($"Impuesto: {liquidacion.ValorImpuesto}");
                            Console.WriteLine("----------------------------------------------------------------");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Modificar. ");

                        Console.WriteLine("Digite el numero de liquidacion. ");
                        string numeroliquidacion = Console.ReadLine();
                        if (liquidacionservice.Buscar(numeroliquidacion) == null)
                        {
                            Console.WriteLine("No existe la liquidacion ");
                        }
                        else
                        {
                            liquidacion = liquidacionservice.Buscar(numeroliquidacion);
                            Console.WriteLine("Digite el nuevo valor del avaluo. ");
                            avaluo = decimal.Parse(Console.ReadLine());
                            liquidacion.Avaluo = avaluo;
                            liquidacion.CalcularPredio();
                            Console.WriteLine(liquidacionservice.ModificarLiquidacion(liquidacion));
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Eliminar. ");

                        Console.WriteLine("Digite el numero de liquidacion. ");
                        numeroliquidacion = Console.ReadLine();
                        if (liquidacionservice.Buscar(numeroliquidacion) == null)
                        {
                            Console.WriteLine("No existe la liquidacion ");
                        }
                        else
                        {
                            liquidacion = liquidacionservice.Buscar(numeroliquidacion);
                            Console.WriteLine(liquidacionservice.EliminarLiquidacion(liquidacion));
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        opcion = 'n';
                        break;
                }
            }


           
        }
    }
}
