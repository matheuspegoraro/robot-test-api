using System;
using System.Threading.Tasks;
using System.Text.Json;

using RobotBecomex.Repository.Interfaces;
using RobotBecomex.Domain;
using RobotBecomex.DB;
using RobotBecomex.Domain.Enums;
using RobotBecomex.Helper.Exceptions;

namespace RobotBecomex.Repository
{
    public class RobotHeadRepository : IRobotHeadRepository
    {
        public async Task<Robot> Increase<T>()
        {
            return await Alter<T>(1);
        }

        public async Task<Robot> Decrease<T>()
        {
            return await Alter<T>(-1);
        }

        public async Task<Robot> Alter<T>(int operation)
        {
            var robot = JsonSerializer.Deserialize<Robot>(await JsonDB.Read());

            if (typeof(T) == typeof(HeadInclinationEnum))
            {
                robot.RobotHead.HeadInclination += operation;

                if (!Enum.IsDefined(typeof(T), robot.RobotHead.HeadInclination))
                    throw new InvalidInclinationException();
            }
            else if (typeof(T) == typeof(HeadRotationEnum))
            {
                bool canRotate = robot.RobotHead.HeadInclination != HeadInclinationEnum.Down;

                robot.RobotHead.HeadRotation += operation;

                if (!Enum.IsDefined(typeof(T), robot.RobotHead.HeadRotation) || !canRotate)
                    throw new InvalidRotationException();
            }

            JsonDB.Save(robot);

            return robot;
        }
    }
}
