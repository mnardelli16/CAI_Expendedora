using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class DineroInsuficienteExcepcion:Exception
    {
        public DineroInsuficienteExcepcion() : base("NO hay dinero suficiente")
        {

        }
    }
}
