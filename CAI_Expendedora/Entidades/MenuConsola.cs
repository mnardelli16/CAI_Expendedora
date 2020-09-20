using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class MenuConsola
    {
        public void PantallaInicio()
        {
            string _msj;

            _msj =
                "-----------------------------------------------------------------------------\n" +
                "---------------------BIENVENIDO A LA MAQUINA EXPENDEDORA---------------------\n" +
                "-----------------------------------------------------------------------------\n\n" +
                "MENU:                              \n" +
                "0 - Encender la maquina            \n" +
                "1 - Listado de latas disponibles   \n" +
                "2 - Insertar Lata                  \n" +
                "3 - Extraer Lata                   \n" +
                "4 - Emitir Balance                 \n" +
                "5 - Control Stock                  \n";



            Console.WriteLine(_msj);
        }

        public int EleccionMenu()
        {
            string _opcion;
            bool _flag;

            do
            {
                Console.WriteLine("Elija una opcion del menu:");
                _opcion = Console.ReadLine();
                _flag = new Validaciones().ValidarIngresoCaso(_opcion);

            } while (_flag == false);

           
            return Convert.ToInt32(_opcion);
        }

    }
}
