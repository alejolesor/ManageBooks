using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.conection
{
    public interface IConnection
    {
        SqlConnection GetConnection();
    }
}
