using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDBCustDlg
{
    class Database
    {
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TP\11-DotNet\2018-IPD12-DotNet\WPF\TodoDBCustDlg\TodoDBCustDlg.mdf;Integrated Security=True;Connect Timeout=30");
            /*
            conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; todoassword = ttodo%itodod12");
            */
            conn.Open();
        }

        public void AddTodo(Todo todo)
        {
            string sql = "INSERT INTO Todos (Task, DueDate, IsDone) VALUES (@Task, @DueDate, @IsDone);";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", todo.Task);
                cmd.Parameters.AddWithValue("@Age", todo.DueDate);
                cmd.Parameters.AddWithValue("@IsDone", todo.IsDone);
                //int id = (int)cmd.ExecuteScalar();
                //return id;
            }
        }

        public List<Todo> GetAllTodos()
        {
            List<Todo> result = new List<Todo>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Todos", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string task = (string)reader["Task"];
                    DateTime dueDate = (DateTime)reader["DueDate"];
                    bool isDone = (byte)reader["IsDone"] != 0;
                    Todo todo = new Todo() { Id = id, Task = task, DueDate = dueDate, IsDone = isDone };
                    result.Add(todo);
                }
            }
            return result;
        }

        internal void UpdateTodo(Todo todo)
        {
            string sql = "UPDATE Todos SET Task = @Task, DueDate = @DueDate, IsDone = @IsDone WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", todo.Id);
            cmd.Parameters.AddWithValue("@Task", todo.Task);
            cmd.Parameters.AddWithValue("@DueDate", todo.DueDate);
            cmd.Parameters.AddWithValue("@IsDone", todo.IsDone ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        internal void DeleteTodoById(int id)
        {
            string sql = "DELETE FROM Todos WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
