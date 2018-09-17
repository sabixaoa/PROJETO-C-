using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Projecto
{
    [Serializable()]
    internal class Navio
    {
        public static int ultimo = 0;
        private string _nome;
        private int _numero;
        private int _MaxContentores;
        private int _MaxExplosivos;
        private int _MaxQuimicos;
        private ArrayList _contentores;
        private bool _estado;

        public bool Estado
        {
            get => _estado;
            set => _estado = value;
        }


        public Navio(string nome,bool estado,int MaxContentore, int MaxExplosivos, int MaxQuimicos)
        {
            
            _nome = nome;
            ultimo++;
            _numero = ultimo;
            _MaxContentores = MaxContentores;
            _MaxExplosivos = MaxExplosivos;
            _MaxQuimicos = MaxQuimicos;
            _estado = estado;          

            _contentores = new ArrayList();
        }

        public Navio()
        {
        }

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }


        public int MaxContentores
        {
            get => _MaxContentores;
            set => _MaxContentores = value;
        }

        public int MaxExplosivos
        {
            get => _MaxExplosivos;
            set => _MaxExplosivos = value;
        }
        public int MaxQuimicos
        {
            get => _MaxQuimicos;
            set => _MaxQuimicos = value;
        }

        public int Numero
        {
            get => _numero;
            set => _numero = value;
        }

        public ArrayList Contentores
        {
            get => _contentores;
            set => _contentores = value;
        }

        public override string ToString()
        {
            string s = "Nome: " + _nome;
            s += "\nNumero: " + _numero;
            s += "\nMaximo de Contentores: " + _MaxContentores;
            s += "\nMaximo de Contentores Explosivos: " + _MaxExplosivos;
            s += "\n Maximo de Contentores Quimicos: " + _MaxQuimicos;
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Navio n = obj as Navio;
            return n._nome == _nome &&
                   n._numero == _numero;
        }

        public void adicionarcontentornavio(Contentor c)
        {
           

            if (MaxContentores >= _contentores.Count)
                    throw new MaxContentorException("Maximo de contentores antigido");
            
            if (_contentores.GetType()==typeof(Quimicos))
            {
                if (MaxQuimicos >= MaxQuimicos)
                    throw new MaxQuimicoException("Maximo de contentores Quimicos antigido");
            }

            if (_contentores.GetType() == typeof(Explosivo))
            {
                if (MaxExplosivos >= MaxExplosivos)
                    throw new MaxExplosivoException("Maximo de contentores Explosivo antigido");
            }

        }        
    }
}
