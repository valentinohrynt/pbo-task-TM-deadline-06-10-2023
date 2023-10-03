using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop // Implementasi namespace
{
    // Abstract Class UnexpectedStop yang memiliki metode Stop
    public abstract class UnexpectedStop
    {
        public abstract void Stop();
    }
    // Interface IKlakson yang memiliki metode SuaraKlakson.
    public interface IBelok
    {
        void Belok();
    }
}
