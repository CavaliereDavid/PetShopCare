using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PetShopCare.Library
{
    public class Context
    {
        // questo è il DbContext che viene usato per il caricamento ed il salvataggio delle entità tramite l'entity framework
        public required PetShopCareDbContext Database { get; init; }
        // questa è la connessione che viene usata per alcune query fatte con dapper (da fifare tramite l'entity framework)
        public required SqlConnection Connection { get; init; }

    }
}
