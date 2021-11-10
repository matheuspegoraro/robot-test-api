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
    public class RobotBodyRepository : IRobotBodyRepository
    {
        public async Task<Robot> Increase<T>(ArmEnum arm)
        {
            return await Alter<T>(1, arm);
        }

        public async Task<Robot> Decrease<T>(ArmEnum arm)
        {
            return await Alter<T>(-1, arm);
        }

        public async Task<Robot> Alter<T>(int operation, ArmEnum arm)
        {
            var robot = JsonSerializer.Deserialize<Robot>(await JsonDB.Read());

            dynamic attr;

            if (typeof(T) == typeof(ElbowMovimentationEnum))
            {
                attr = arm == ArmEnum.Left ? (robot.RobotBody.RobotLeftArm.Elbow += operation) : (robot.RobotBody.RobotRightArm.Elbow += operation);

                if (!Enum.IsDefined(typeof(T), attr))
                    throw new InvalidElbowMovimentationException();
            }
            else if (typeof(T) == typeof(WristMovimentationEnum))
            {
                bool canMove = arm == ArmEnum.Left ? (robot.RobotBody.RobotLeftArm.Elbow == ElbowMovimentationEnum.StronglyContracted) : 
                    (robot.RobotBody.RobotRightArm.Elbow == ElbowMovimentationEnum.StronglyContracted);

                attr = arm == ArmEnum.Left ? (robot.RobotBody.RobotLeftArm.Wrist += operation) : (robot.RobotBody.RobotRightArm.Wrist += operation);

                if (!Enum.IsDefined(typeof(T), attr) || !canMove)
                    throw new InvalidWristMovimentationException();
            }

            JsonDB.Save(robot);

            return robot;
        }
    }
}
