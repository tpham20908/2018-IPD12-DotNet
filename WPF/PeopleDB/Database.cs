using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    class Database
    {
        private SqlConnection conn;
        /*SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TP\11-DotNet\2018-IPD12-DotNet\WPF\FirstDB\FirstDB.mdf;Integrated Security=True;Connect Timeout=30");*/

        public Database()
        {
            conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");
            conn.Open();
        }
        public void AddPerson(Person p)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age, Height) " +
                "VALUES (@name, @age, @height)", conn);
            insertCommand.Parameters.AddWithValue("@name", p.Name);
            insertCommand.Parameters.AddWithValue("@age", p.Age);
            insertCommand.Parameters.AddWithValue("@height", p.Height);
            insertCommand.ExecuteNonQuery();
        }      

        public List<Person> GetAllPeople()
        {
            List<Person> list = new List<Person>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM People", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader[0] + "");
                    String name = reader[1] + "";
                    int age = int.Parse(reader[2] + "");
                    double height = double.Parse(reader[3] + "");
                    Person p = new Person(id, name, age, height);
                    list.Add(p);
                }
            }
            return list;
        }

        public void DeletePerson(int id)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE FROM People WHERE ID = @id", conn);
            deleteCommand.Parameters.AddWithValue("@id", id);
            deleteCommand.ExecuteNonQuery();
        }

        public void UpdatePerson(Person p)
        {
            SqlCommand updateCommand = new SqlCommand("UPDATE People SET " +
                "name = @name, age = @age, height = @height where id = @id", conn);
            updateCommand.Parameters.AddWithValue("@name", p.Name);
            updateCommand.Parameters.AddWithValue("@age", p.Age);
            updateCommand.Parameters.AddWithValue("@height", p.Height);
            updateCommand.Parameters.AddWithValue("@id", p.Id);
            updateCommand.ExecuteNonQuery();
        }
    }
}
