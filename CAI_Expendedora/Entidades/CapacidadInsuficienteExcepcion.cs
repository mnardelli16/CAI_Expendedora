﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class CapacidadInsuficienteExcepcion:Exception
    { 
        public CapacidadInsuficienteExcepcion(): base("No hay lugar en la expendedora para agregar una lata")
        {

        }
    }
}
