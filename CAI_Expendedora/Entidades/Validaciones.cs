using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class Validaciones
    {
        public bool ValidarIngresoCaso(string opcion)
        {
            bool _flag = false;
            int _caso;

            if (!Int32.TryParse(opcion, out _caso))
            {
                Console.WriteLine("Debe ingresar una opcion valida");
            }
            else if (_caso < 0 && _caso > 5)
            {
                Console.WriteLine("Debe ingresar una opcion valida");
            }
            else
                _flag = true;
            
            return _flag;
        }

        public bool ValidarSalida(string a)
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(a))
            {
                Console.WriteLine("No debe dejar espacios en blanco");
            }
            else if (a == "S")
            {
                flag = true;
            }
            else if (a == "N")
            {
                flag = true;
            }
            else
            {
                Console.WriteLine("No son opciones validas");
            }
            return flag;
        }

        public bool ValidarPrecio(string precio, ref double salida)
        {
            bool _flag = false;

            if (!double.TryParse(precio, out salida))
            {
                Console.WriteLine("Debe ingresar un numero valido");
            }
            else if (salida <= 0)
            {
                Console.WriteLine("El precio debe ser positivo");
            }
            else
                _flag = true;

            return _flag;
        }
    }
}
