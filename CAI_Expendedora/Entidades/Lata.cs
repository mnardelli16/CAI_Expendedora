using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class Lata
    {
        //ATRIBUTOS
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;


        //PROPIEDADES
        public string Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
        public string Sabor
        {
            get
            {
                return this._sabor;
            }
            set
            {
                this._sabor = value;
            }
        }

        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }

        public double Volumen
        {
            get
            {
                return this._volumen;
            }
            set
            {
                this._volumen = value;
            }
        }

        //CONSTRUCTORES
        public Lata()
        {

        }

        public Lata(string codigo, string nombre, string sabor)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
        }

        public Lata(string codigo, string nombre, string sabor, double precio, double volumen):this(codigo,nombre,sabor)
        {
            this._precio = precio;
            this._volumen = volumen;
        }


        //METODOS

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}",this._codigo, this._nombre, this._sabor);
        }

        public string ListaLatas()
        {
            return string.Format("{0}", this._codigo);
        }

        public double GetPrecioPorLitro(double precio, double volumen)
        { 
            return (1000 * precio) / volumen;
        }

        public string StockLatas()
        {
            return string.Format("{0} - {1} $ {2} / $/L {3}",this._nombre,this._sabor,this._precio, this.GetPrecioPorLitro(this._precio,this._volumen));
        }
    }
}
