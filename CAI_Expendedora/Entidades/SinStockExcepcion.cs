﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class SinStockExcepcion:Exception
    {
        public SinStockExcepcion(): base("No hay stock para mostrar")
        {

        } 
    }
}
