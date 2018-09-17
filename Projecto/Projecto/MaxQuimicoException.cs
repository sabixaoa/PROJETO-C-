using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto
{
    [Serializable()]
    class MaxQuimicoException:System.Exception
    {
        public MaxQuimicoException() : base() { }
        public MaxQuimicoException(string mensagem) : base(mensagem) { }
    }
}
