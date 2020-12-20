using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface OpstiDomenskiObjekat
    {
        string NazivTabele { get; }
        string ID { get; }
        string UslovID { get; }
        string UslovOpsti { get; }
        string UslovSort { get; }
        string Insert { get;  }
        string Update { get; }
        string Update2 { get; }
        OpstiDomenskiObjekat procitajRed(DataRow red);



    }
}
