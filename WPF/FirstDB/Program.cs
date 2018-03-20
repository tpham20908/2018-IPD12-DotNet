using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDB
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TP\11-DotNet\2018-IPD12-DotNet\WPF\FirstDB\FirstDB.mdf;Integrated Security=True;Connect Timeout=30");
            
            /*
            SqlConnection conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");
            */
            conn.Open();
            
            /*
            // insert a records
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Friends (Name) VALUES (@Name)", conn);
            insertCommand.Parameters.AddWithValue("@Name", "Leo");
            insertCommand.ExecuteNonQuery();
            */
            
            SqlCommand command = new SqlCommand("SELECT * FROM friends", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Id\tName");
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}\t{1}", reader[0], reader[1]));
                }
            }
            
            Console.ReadLine();
            conn.Close();
            
        }
    }
}
