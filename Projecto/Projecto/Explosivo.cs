using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projecto
{
    [Serializable()]
    class Explosivo:Contentor
    {
        private string _tipoexplosivo;
        private bool _plastico;

        public Explosivo()
        {

        }

        public Explosivo(string tipoexplosivo, bool plastico)
        {
            Tipoexplosivo = tipoexplosivo;
            Plastico = plastico;
        }

        public string Tipoexplosivo
        {
            get => _tipoexplosivo;
            set => _tipoexplosivo = value;
        }
        public bool Plastico
        {
            get => _plastico;
            set => _plastico = value;
        }

        public override string ToString()
        {
            string s = "Tipo: " + _tipoexplosivo;
            s += "Plastico: " + _plastico;
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Explosivo e = obj as Explosivo;
            return e._tipoexplosivo == _tipoexplosivo &&
                e._plastico == _plastico && base.Equals(obj);
        }
    }
}
