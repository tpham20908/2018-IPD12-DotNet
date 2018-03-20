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
        SqlConnection conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");

        public void insertToPeople(String name, int age, double height)
        {
            conn.Open();
            SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age, Height) " +
                "VALUES (@name, @age, @height)", conn);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@age", age);
            insertCommand.Parameters.AddWithValue("@height", height);
            insertCommand.ExecuteNonQuery();
        }      

        public List<Person> selectPeople()
        {
            List<Person> list = new List<Person>();
            conn.Open();
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
                }
            }
            return list;
        }
    }
}
