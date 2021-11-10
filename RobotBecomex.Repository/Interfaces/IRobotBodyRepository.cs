﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotBecomex.Domain;
using RobotBecomex.Domain.Enums;

namespace RobotBecomex.Repository.Interfaces
{
    public interface IRobotBodyRepository
    {
        Task<Robot> Increase<T>(ArmEnum arm);
        Task<Robot> Decrease<T>(ArmEnum arm);
    }
}
