using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2Passengers
{
    class Database
    {
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TP\11-DotNet\2018-IPD12-DotNet\Quiz2Passengers\Quiz2PassengersDB.mdf;Integrated Security=True;Connect Timeout=30");
            /*
            conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; password = tp%ipd12");
            */
            conn.Open();
        }

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> pList = new List<Passenger>();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Passengers;", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    string passport = (string)reader["Passport"];
                    string destination = (string)reader["Destination"];
                    DateTime departureDateTime = (DateTime)reader["DepartureDateTime"];

                    Passenger p = new Passenger() { Id = id, Name = name, Passport = passport,
                        Destination = destination, DepartureDateTime = departureDateTime };
                    pList.Add(p);
                }
            }
            return pList.ToList();
        }
        
        public void AddPassenger(Passenger p)
        {
            string sql = "INSERT INTO Passengers (Name, Passport, Destination, DepartureDateTime)" +
                " VALUES (@Name, @Passport, @Destination, @DepartureDateTime);";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("Name", p.Name);
                cmd.Parameters.AddWithValue("Passport", p.Passport);
                cmd.Parameters.AddWithValue("Destination", p.Destination);
                cmd.Parameters.AddWithValue("DepartureDateTime", p.DepartureDateTime);
                cmd.ExecuteNonQuery();
            }
        }

        internal void UpdatePassenger(Passenger p)
        {
            string sql = "UPDATE Passengers SET " +
                "Name = @Name, Passport = @Passport, Destination = @Destination, DepartureDateTime = @DepartureDateTime" +
                " WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", p.Id);
            cmd.Parameters.AddWithValue("Name", p.Name);
            cmd.Parameters.AddWithValue("Passport", p.Passport);
            cmd.Parameters.AddWithValue("Destination", p.Destination);
            cmd.Parameters.AddWithValue("DepartureDateTime", p.DepartureDateTime);
            cmd.ExecuteNonQuery();
        }

        internal void DeletePassenger(int id)
        {
            string sql = "DELETE FROM Passengers WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
