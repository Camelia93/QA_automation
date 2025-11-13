using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace QA_Automation_Project.Core
{
    public static class TestDataReader
    {
        public static string GetData(string userType, string field)
        {
            // Obține calea completă a folderului bin\Debug\net8.0
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Urcă 3 nivele: net8.0 -> Debug -> bin -> QA_Automation_Project
            string projectPath = Directory.GetParent(basePath).Parent.Parent.Parent.FullName;

            // Creează calea corectă către fișierul JSON
            string filePath = Path.Combine(projectPath, "Test Data", "loginData.json");

            // Doar pentru debugging: vezi exact calea folosită
            Console.WriteLine($"[DEBUG] Calea completă JSON: {filePath}");

            // Citește fișierul
            var json = File.ReadAllText(filePath);
            var data = JObject.Parse(json);

            return data[userType][field].ToString();
        }
    }
}
