using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto
{
    [Serializable()]
    class Quimicos:Contentor
    {
        private string _tipoquimico;

        public Quimicos()
        {

        }

        public Quimicos(string tipoquimico)
        {
            Tipoquimico = tipoquimico;
        }

        public string Tipoquimico
        {
            get => _tipoquimico;
            set => _tipoquimico = value;
        }


        public override string ToString()
        {
            string s = "Tipo: " + _tipoquimico;
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Quimicos q = obj as Quimicos;
            return q._tipoquimico == _tipoquimico && base.Equals(obj);
        }
    }
}
