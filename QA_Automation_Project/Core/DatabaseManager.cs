
using MySql.Data.MySqlClient;
using NUnit.Framework.Internal;
using OpenQA.Selenium.BiDi.Input;
using System;

namespace QA_Automation_Project.Core
{
    public class DatabaseManager
    {
        private string connectionString = "server=localhost;user=root;password=root;database=qa_automation;";

        public void TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("✅ Conexiunea la baza de date a reușit!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Eroare la conexiune: " + ex.Message);
            }
        }

        public (string username, string password) GetUserData(string tableName, int id)

        {
            string username = "";
            string password = "";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 🧩 Interpolare pentru a alege tabelul dorit (users / invalid_logins)
                string query = $"SELECT username, password FROM {tableName} WHERE id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            username = reader.GetString("username");
                            password = reader.GetString("password");
                        }
                    }
                }
            }

            return (username, password);
        }
      

        public void SaveTestResult(string testName, string status, string errorMessage)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO test_results (test_name, status, error_message) VALUES (@test_name, @status, @error_message)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@test_name", testName);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@error_message", errorMessage);
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine($"✅ Rezultatul testului '{testName}' a fost salvat în baza de date.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"❌ Eroare la salvarea rezultatului în DB: {ex.Message}");
            }
        }
        public List<(string username, string password)> GetAllUsers(string tableName)
        {
            var users = new List<(string username, string password)>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT username, password FROM {tableName}";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add((reader.GetString("username"), reader.GetString("password")));
                    }
                }
            }

            return users;
        }

    }
}
