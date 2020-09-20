using CAI_Expendedora.Entidades;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CAI_Expendedora
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuConsola M = new MenuConsola();
            Expendedora Exp = new Expendedora();
            
            
            M.PantallaInicio(); // inicio de menu
            
            string seguir;

            do
            {
                int _opcion = M.EleccionMenu(); // elijo una opcion del menu
                try
                {
                    switch (_opcion)
                    {
                        case 0:
                            {
                                Exp.EncenderMaquina();
                                break;
                            }
                        case 1:
                            {
                                Exp.Listado();
                                break;
                            }
                        case 2:
                            {
                                IngresarLata(Exp);
                                break;
                            }
                        case 3:
                            {
                                ExtraerLata(Exp);
                                break;
                            }
                        case 4:
                            {
                                ObtenerBalance(Exp);
                                break;
                            }
                        case 5:
                            {
                                MostrarStock(Exp);
                                break;
                            }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                bool ok;

                do
                {
                    Console.WriteLine("Desea elegir otra opcion S/N : ");
                    seguir = Console.ReadLine();
                    ok = new Validaciones().ValidarSalida(seguir);
                } while (ok == false);


            } while (seguir == "S");

            Console.WriteLine("HASTA LUEGO");
        
            //System.Console.Clear();

            Console.ReadKey();

        }

        static void IngresarLata(Expendedora exp)
        {
            try 
            {
                if (!exp.Encendida)
                {
                    Console.WriteLine("Primero debe encender la maquina para continuar.");
                }
                else
                {
                    exp.ListaLatas();
                    string codigo;

                    Console.WriteLine("Ingrese un codigo de lata: ");
                    codigo = Console.ReadLine();
                    Lata L1 = exp.BuscarLata(codigo);

                    if (L1 == null)
                    {
                        throw new CodigoInvalidoExepcion();
                    }
                    else
                    {
                        try
                        {
                            double _precio = 0;
                            string _strprecio;
                            bool esPrecio;
                            // INGRESO PRECIO
                            do
                            {
                                Console.Write("Ingrese precio: ");
                                _strprecio = Console.ReadLine();
                                esPrecio = new Validaciones().ValidarPrecio(_strprecio, ref _precio);
                            } while (esPrecio == false);

                            // INGRESO VOLUMEN
                            double _volumen = 0;
                            string _strvolumen;
                            bool esVolumen;
                            do
                            {
                                Console.Write("Ingrese volumen: ");
                                _strvolumen = Console.ReadLine();
                                esVolumen = new Validaciones().ValidarPrecio(_strvolumen, ref _volumen);
                            } while (esVolumen == false);

                            Lata Lata = new Lata(L1.Codigo, L1.Nombre, L1.Sabor, _precio, _volumen);

                            exp.AgregarLata(Lata);

                            Console.WriteLine("Lata agregada con exito");

                        } catch(CapacidadInsuficienteExcepcion ee)
                        {
                            Console.WriteLine(ee.Message);
                        }
                    }
                }
            }
            catch(CodigoInvalidoExepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ExtraerLata(Expendedora exp)
        {
            try
            {
                if (!exp.Encendida)
                {
                    Console.WriteLine("Primero debe encender la maquina para continuar.");
                }
                try
                {
                    //SELECCIONA EL CODIGO DE LATA
                    exp.ListaLatas();
                    Console.Write("Por favor selccione el codigo de lata a extraer: ");

                    string codigo = Console.ReadLine();
                    Lata L1 = exp.BuscarLata(codigo);

                    if (L1 == null)
                    {
                        throw new CodigoInvalidoExepcion();
                    }
                    else if (exp.EstaVacia())
                    {
                        throw new SinStockExcepcion();
                    }
                    else
                    {
                        //INGRESO DEL DINERO, UNA VEZ SELECCIONADA LA LATA
                        try
                        {
                            double _dinero = 0;
                            string _strdinero;
                            bool esDinero;
                            // INGRESO PRECIO
                            do
                            {
                                Console.Write("Ingrese dinero: ");
                                _strdinero = Console.ReadLine();
                                esDinero = new Validaciones().ValidarPrecio(_strdinero, ref _dinero);
                            } while (esDinero == false);

                            if(_dinero < L1.Precio)
                            {
                                throw new DineroInsuficienteExcepcion();
                            }
                            else
                            {
                                Console.WriteLine("Lata extraida con EXITO");

                                exp.ExtraerLata(L1.Codigo, L1.Precio);
                            }
                        }
                        catch(DineroInsuficienteExcepcion e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                }
                catch (CodigoInvalidoExepcion ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (SinStockExcepcion ez)
                {
                    Console.WriteLine(ez.Message);
                }

            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

        }

        static void ObtenerBalance(Expendedora exp)
        {
            try
            {
                if (!exp.Encendida)
                {
                    Console.WriteLine("Primero debe encender la maquina para continuar.");
                }
                else
                {
                    Console.WriteLine(exp.GetBalance());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void MostrarStock(Expendedora exp)
        {
            try
            {
                if (!exp.Encendida)
                {
                    Console.WriteLine("Primero debe encender la maquina para continuar.");
                }
                else if (exp.EstaVacia())
                {
                    throw new SinStockExcepcion();
                } 
                else
                {
                    exp.StockBalance();
                }
            }
            catch (SinStockExcepcion se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}
