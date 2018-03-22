using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Database
    {
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Minh\Documents\TUNG\JAC\JAC Docs\11 - DotNet\2018 - IPD12 - DotNet\Practices\TodoList\Todos.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }
    }
}
