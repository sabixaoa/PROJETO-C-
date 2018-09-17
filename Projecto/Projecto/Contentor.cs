using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Projecto
{
    [Serializable()]
    class Contentor 
    {
        public static int ultimo=0;
        private int _numero_navio;
        private int _numero;
        private string _destino;
        private int _peso;
        private string _tipo;
        


        public Contentor(string destino, string tipo, int peso)
        {
            _tipo = tipo;
            _destino = destino;
            _peso = peso;
            ultimo++;
            _numero = ultimo;
        }

        public Contentor()
        {

        }

        public string Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }

        public int Numero
        {
            get => _numero;
            set => _numero=value;
        }


              
        public string Destino
        {
            get => _destino;
            set => _destino=value;
        }

        public int Numero_Navio
        {
            get => _numero_navio;
            set => _numero_navio = value;
        }

        public int Peso
        {
            get => _peso;
            set => _peso = value;
        }

        public override string ToString()
        {
            string s = "Numero Navio: " + _numero_navio;
            s += "\nNumero Contentor: " + _numero;
            s += "\nDestino: " + _destino;
            s += "\nTipo: " + _tipo;
            s += "\nPeso: " + _peso;

            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Contentor c = obj as Contentor;
            return c._numero_navio == _numero_navio &&
                   c._numero == _numero &&
                   c._destino == _destino &&
                   c._tipo==_tipo &&
                   c._peso == _peso;
        }
        

    }
}

           