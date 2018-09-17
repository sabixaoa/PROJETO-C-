using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto
{
    [Serializable()]
    class MaxContentorException :System.Exception
    {
        public MaxContentorException() : base() { }
        public MaxContentorException(string mensagem) : base(mensagem) { }
    }
}
