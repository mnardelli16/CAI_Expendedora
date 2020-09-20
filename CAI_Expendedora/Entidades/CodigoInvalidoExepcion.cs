using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class CodigoInvalidoExepcion:Exception
    {
        public CodigoInvalidoExepcion() : base("El codigo ingresado es incorrecto")
        {

        }
    }
}
