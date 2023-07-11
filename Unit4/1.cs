using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_ConsoleApp
{
    class Program
    {
        static SqlConnection connection;
        static SqlDataAdapter dataAdapter;
        static DataSet dataSet;
        static DataTable dataTable;
        static string connectionString = "Data Source=Microsoft SQL Server Database File (SqlClient);Initial Catalog=NFSU;Integrated Security=True";

        static void Main(string[] args)
        {
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            while (true)
            {
                Console.WriteLine("1. Add record");
                Console.WriteLine("2. Search record");
                Console.WriteLine("3. Edit record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddRecord();
                            break;
                        case 2:
                            SearchRecord();
                            break;
                        case 3:
                            EditRecord();
                            break;
                        case 4:
                            DeleteRecord();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                }

                Console.WriteLine();
            }
        }

        static void AddRecord()
        {
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the email:");
            string email = Console.ReadLine();

            // Create INSERT query
            string query = "INSERT INTO Your_Table (Name, Email) VALUES (@Name, @Email)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Record added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        static void SearchRecord()
        {
            Console.WriteLine("Enter the name to search:");
            string searchName = Console.ReadLine();

            // Create SELECT query
            string query = "SELECT * FROM Your_Table WHERE Name = @SearchName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SearchName", searchName);

                dataAdapter.SelectCommand = command;

                try
                {
                    connection.Open();
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            dataTable = dataSet.Tables[0];

            if (dataTable.Rows.Count > 0)
            {
                Console.WriteLine("Search Results:");

                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Email: {row["Email"]}");
                }
            }
            else
            {
                Console.WriteLine("No records found!");
            }
        }

        static void EditRecord()
        {
            Console.WriteLine("Enter the ID of the record to edit:");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Enter the updated name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the updated email:");
                string email = Console.ReadLine();

                // Create UPDATE query
                string query = "UPDATE Your_Table SET Name = @Name, Email = @Email WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Console.WriteLine("Record updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Please try again.");
            }
        }

        static void DeleteRecord()
        {
            Console.WriteLine("Enter the ID of the record to delete:");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                // Create DELETE query
                string query = "DELETE FROM Your_Table WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Console.WriteLine("Record deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Please try again.");
            }
        }
    }
}
