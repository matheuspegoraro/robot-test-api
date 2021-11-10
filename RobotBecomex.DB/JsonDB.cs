using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RobotBecomex.DB
{
    public static class JsonDB
    {
        public static string GetConnection()
        {
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            return solutionDir + "\\currentRobot.json";
        }

        public static async void Save(object file)
        {
            IfFileNotExists();

            await File.WriteAllTextAsync(GetConnection(), JsonSerializer.Serialize(file));
        }

        public static async Task<string> Read()
        {
            IfFileNotExists();

            return await File.ReadAllTextAsync(GetConnection());
        }

        public async static void IfFileNotExists()
        {
            if (!File.Exists(GetConnection()))
            {
                File.Create(GetConnection()).Dispose();
                await File.WriteAllTextAsync(GetConnection(), "{}");
            }
        }
    }
}
