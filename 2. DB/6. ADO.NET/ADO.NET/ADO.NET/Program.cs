using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET
{
    public class Program
    {
        private static readonly string ConnectionString =
            @"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=AdoDb;Integrated Security=True";
        
        private static readonly List<(string Name, int Age)> _users = new List<(string Name, int Age)>
        {
            (Name: "Anghelenici Cristian", Age: 22),
            (Name: "Andrei Profir", Age: 18),
            (Name: "Ion Tutu", Age: 15),
            (Name: "Vitalie Malachi", Age: 33),
            (Name: "Alexandru Fiodor", Age: 20),
            (Name: "Valeria Moraru", Age: 19)
        };


        private static void Main(string[] args)
        {
            CreateTable();
            InsertInDB();
            DisplayMenu();

            Console.ReadKey();
        }

        private static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1: Display all data");
                Console.WriteLine("2: Insert new row");
                Console.WriteLine("3: Update row");
                Console.WriteLine("4: Delete row");
                Console.WriteLine("0: Exit");
                Console.WriteLine("\nEnter the option:");
                ConsoleKeyInfo option = Console.ReadKey();

                Console.Clear();
                switch (option.KeyChar)
                {
                    case '1':
                        DisplayAllData();
                        Console.WriteLine("Press key for back....");
                        break;
                    case '2':
                        InsertNewRow();
                        Console.WriteLine("The row was saved!");
                        break;
                    case '3':
                        DisplayAllData();
                        Console.WriteLine();
                        UpdateRow();
                        Console.WriteLine("The row was updated!");
                        break;
                    case '4':
                        DisplayAllData();
                        Console.WriteLine();
                        DeleteRow();
                        Console.WriteLine("The row was deleted!");
                        break;
                    case '0':
                        return;
                }
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        private static void DisplayAllData()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = CreateCustomerAdapter(connection);

                adapter.Fill(dataTable);

                DisplayAllRows(dataTable);
            }
        }

        private static void InsertNewRow()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
                age = 25;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = CreateCustomerAdapter(connection);

                adapter.Fill(dataTable);

                DataRow newRow = dataTable.NewRow();
                newRow["Name"] = name;
                newRow["Age"] = age;

                dataTable.Rows.Add(newRow);

                adapter.Update(dataTable);
            }
        }

        private static void UpdateRow()
        {
            Console.Write("Enter the Id of the row: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter new name for user: ");
            string newName = Console.ReadLine();            

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                DataTable table = new DataTable();
                SqlDataAdapter adapter = CreateCustomerAdapter(connection);

                adapter.Fill(table);

                DataRow row = table.Rows[0];

                foreach (DataRow dataRow in table.Rows)
                {
                    if ((int) dataRow["Id"] == id)
                    {
                        row = dataRow;
                        break;
                    }
                }

                row["Name"] = newName;

                adapter.Update(table);
            }
        }

        private static void DeleteRow()
        {
            Console.Write("Enter the Id of the row: ");
            int id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = CreateCustomerAdapter(connection);

                adapter.Fill(table);

                int row = -1;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Console.WriteLine(table.Rows[i]["Id"]);
                    if ((int) table.Rows[i]["Id"] == id)
                    {
                        row = i;
                        break;
                    }
                }

                if (row == -1) return;

                table.Rows[row].Delete();

                adapter.Update(table);
            }
        }


        private static void InsertInDB()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var dataSet = new DataSet();
                SqlDataAdapter adapter = CreateCustomerAdapter(connection);

                adapter.Fill(dataSet);

                DataTable table = dataSet.Tables[0];
                DisplayAllRows(table);

                InsertRowsInDataTable(table);
                adapter.Update(dataSet);

                dataSet.Clear();
                adapter.Fill(dataSet);
                 
                DisplayAllRows(dataSet.Tables[0]);
            }
        }

        public static SqlDataAdapter CreateCustomerAdapter(SqlConnection connection)
        {
            var selectCommand = new SqlCommand("SELECT * FROM Users", connection);

            var insertCommand = new SqlCommand("INSERT INTO Users(Name, Age) VALUES (@Name, @Age)", connection);
            insertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            SqlParameter parameter = insertCommand.Parameters.Add("@Age", SqlDbType.Int);
            parameter.SourceColumn = "Age";


            var updateCommand = new SqlCommand("UPDATE Users SET Name = @Name WHERE Id = @Id", connection);
            updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            parameter = updateCommand.Parameters.Add("@Id", SqlDbType.Int);
            parameter.SourceColumn = "Id";

            var deleteCommand = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
            parameter = deleteCommand.Parameters.Add("@Id", SqlDbType.Int);
            parameter.SourceColumn = "Id";


            var adapter = new SqlDataAdapter(selectCommand.CommandText, connection)
            {
                SelectCommand = selectCommand,
                InsertCommand = insertCommand,
                DeleteCommand = deleteCommand,
                UpdateCommand = updateCommand
            };

            return adapter;
        }

        private static void InsertRowsInDataTable(DataTable dataTable)
        {
            foreach (var user in _users)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Name"] = user.Name;
                newRow["Age"] = user.Age;

                dataTable.Rows.Add(newRow);
            }
        }

        public static void DisplayAllRows(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["Id"]}: {row["Name"]}, {row["Age"]} years");
            }
            Console.WriteLine();
        }

        private static void CreateTable()
        {
            string userTableString = "CREATE TABLE Users (" +
                                     "Id int IDENTITY(1, 1) PRIMARY KEY, " +
                                     "Name nvarchar(50) NOT NULL, " +
                                     "Age int )";

            string productTableText = "CREATE TABLE Products (" +
                                      "Id int IDENTITY(1, 1) PRIMARY KEY, " +
                                      "Name nvarchar(100) NOT NULL, " +
                                      "Price money NOT NULL)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(userTableString, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(productTableText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }


}
