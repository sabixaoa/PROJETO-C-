using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto
{
    [Serializable()]
    class Basico:Contentor
    {
        private string _descricao;
        private bool _refrigerado;

        public Basico()
        {

        }

        public Basico(string descricao, bool refrigerado)
        {
            Descricao = descricao;
            Refrigerado = refrigerado;
        }

        public string Descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public bool Refrigerado
        {
            get => _refrigerado;
            set => _refrigerado = value;
        }

        public override string ToString()
        {
            string s = "Descricao: " + _descricao;
            s += "\nRefrigerado: " + _refrigerado;
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Basico b = obj as Basico;
            return b._descricao == _descricao &&
                   b._refrigerado == _refrigerado && base.Equals(obj);
        }
    }
}
