using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora.Entidades
{
    class Expendedora
    {
        //ATRIBUTOS
        private string _proveedor;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;
        private List<Lata> _latas;

        //PROPIEDADES

        public string Proveedor
        {
            get 
            { 
                return this._proveedor; 
            }
            set
            {
                this._proveedor = value;
            }
        }

        public int Capacidad
        {
            get
            {
                return this._capacidad;
            }
            set
            {
                this._capacidad = value;
            }
        }

        public double Dinero
        {
            get
            {
                return this._dinero;
            }
            set
            {
                this._dinero = value;
            }
        }

        public bool Encendida
        {
            get
            {
                return this._encendida;
            }
        }


        //CONSTRUCTORES

        public Expendedora()
        {
            this._latas = new List<Lata>();
            this.InicializarBebida();
            this._capacidad = 50;
            this._dinero = 0;
        }

        

        //METODOS

        public void EncenderMaquina()
        {
            this._encendida = true;
            Console.WriteLine("Buen dia! Expendedora Encendida");
        }

        public void InicializarBebida()
        {
            this._latas.Add(new Lata("CO1", "Coca Cola", "Regular",40,600));
            this._latas.Add(new Lata("CO2", "Coca Cola", "Zero",45,600));
            this._latas.Add(new Lata("SP1", "Sprite", "Regular",41,600));
            this._latas.Add(new Lata("SP2", "Sprite", "Zero",46,600));
            this._latas.Add(new Lata("FA1", "Fanta", "Regular",42,600));
            this._latas.Add(new Lata("FA2", "Fanta", "Zero",47,600));
        }

        public void Listado()
        {
            foreach(Lata L in this._latas)
            {
                Console.WriteLine(L.ToString());
            }
        }

        public void AgregarLata(Lata la)
        {
            if (this._latas.Count >= this._capacidad)
            {
                throw new CapacidadInsuficienteExcepcion();

            }
            else
            {
                this._latas.Add(la);

            }
        }

        public Lata ExtraerLata(string lata, double dinero)
        {
            Lata L1 = BuscarLata(lata);
            this._latas.Remove(L1);
            this._dinero += dinero;
            return L1;
        }

        public int GetCapacidadRestante()
        {
            return _capacidad - _latas.Count;
        }

        public void ListaLatas()
        {
            foreach (Lata L in this._latas)
            {
                Console.WriteLine(L.ListaLatas());
            }
        }

        public Lata BuscarLata(string L)
        {
            return _latas.Find(LA => LA.Codigo == L);
        }

        public string GetBalance()
        {
            string msj = "DINERO DE LA MAQUINA: $ " + this._dinero.ToString() + "\n" +
                         "CANTIDAD DE LATAS: " + this._latas.Count + "\n" ;

            return msj;
        }

        public bool EstaVacia()
        {
            if(_latas.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StockBalance()
        {
            foreach (Lata L in this._latas)
            {
                Console.WriteLine(L.StockLatas());
            }
        }
    }
}
