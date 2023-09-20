using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.database;
class ConnectionDatabase
{
    protected static readonly string dbString = "Database=db_hr;Data Source=AFIFWORKS\\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;";

    protected SqlParameter setParameter(dynamic value, string nameParam)
    {
        var pName = new SqlParameter();
        pName.ParameterName = "@" + nameParam;
        pName.Value = value;
        pName.SqlDbType = SqlDbType.VarChar;
        return pName;
    }
}
