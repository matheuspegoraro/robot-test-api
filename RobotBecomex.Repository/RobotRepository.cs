using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotBecomex.Repository.Interfaces;
using RobotBecomex.Domain;
using RobotBecomex.DB;

using System.IO;
using System.Text.Json;

namespace RobotBecomex.Repository
{
    public class RobotRepository : IRobotRepository
    {
        public async Task<Robot> Reset()
        {
            var robot = new Robot();

            JsonDB.Save(robot);

            return await Task.FromResult(robot);
        }

        public async Task<Robot> Get()
        {
            var jsonRobot = await JsonDB.Read();

            return JsonSerializer.Deserialize<Robot>(jsonRobot);
        }
    }
}
