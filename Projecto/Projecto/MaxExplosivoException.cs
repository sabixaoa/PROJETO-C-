using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto
{
    [Serializable()]
    class MaxExplosivoException:System.Exception
    {
        public MaxExplosivoException() : base() { }
        public MaxExplosivoException(string mensagem) : base(mensagem) { }
    }
}
