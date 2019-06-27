using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace megacoolnew
{
    class DBAccess
    {

        SqlConnection conn;

        public DBAccess()
        {
            conn = ConnectionManager.GetConnection();
        }

    }
}
