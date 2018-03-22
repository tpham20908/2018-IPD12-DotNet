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
            //conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Minh\Documents\TUNG\JAC\JAC Docs\11 - DotNet\2018 - IPD12 - DotNet\Practices\TodoList\Todos.mdf;Integrated Security=True;Connect Timeout=30");
            conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; password = tp%ipd12");
            conn.Open();
        }

        public List<Todo> GetAllTodos()
        {
            List<Todo> todoList = new List<Todo>();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Todos;", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string task = (string)reader["Task"];
                    DateTime dueDate = (DateTime)reader["DueDate"];
                    bool isDone = (byte)reader["IsDone"] == 1;
                    Todo todo = new Todo() { Id = id, Task = task, DueDate = dueDate, IsDone = isDone };
                    todoList.Add(todo);
                }
            }
            return todoList.ToList();
        }

        public void AddTodo(Todo todo)
        {
            string sql = "INSERT INTO Todos (Task, DueDate, IsDone) VALUES (@Task, @DueDate, @IsDone);";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("Task", todo.Task);
                cmd.Parameters.AddWithValue("DueDate", todo.DueDate);
                cmd.Parameters.AddWithValue("IsDone", todo.IsDone);
                cmd.ExecuteNonQuery();
            }
        }

        internal void UpdateTodo(Todo todo)
        {
            string sql = "UPDATE Todos SET Task = @Task, DueDate = @DueDate, IsDone = @IsDone WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("Task", todo.Task);
                cmd.Parameters.AddWithValue("DueDate", todo.DueDate);
                cmd.Parameters.AddWithValue("IsDone", todo.IsDone);
                cmd.Parameters.AddWithValue("Id", todo.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
