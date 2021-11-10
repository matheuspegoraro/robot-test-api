using Moq;
using RobotBecomex.Domain.Enums;
using RobotBecomex.Helper.Exceptions;
using RobotBecomex.Repository;
using RobotBecomex.Repository.Interfaces;
using RobotBecomex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RobotBecomex.Tests.Services
{
    public class RobotBodyTests
    {
        private RobotBodyRepository robotBodyRepository;
        private RobotRepository robotRepository;

        public RobotBodyTests()
        {
            robotRepository = new RobotRepository();
            robotBodyRepository = new RobotBodyRepository();
        }

        // Contraindo cotovelo do braço esquerdo
        [Fact]
        public async void IncreaseElbow_ValidLeftElbowMovimentation()
        {
            await robotRepository.Reset();

            await robotBodyRepository.Increase<ElbowMovimentationEnum>(ArmEnum.Left);
            await robotBodyRepository.Increase<ElbowMovimentationEnum>(ArmEnum.Left);

            var robot = await robotRepository.Get();

            Assert.Equal(ElbowMovimentationEnum.Contracted, robot.RobotBody.RobotLeftArm.Elbow);
        }

        // Movimento do cotovelo do braço direito inválido
        [Fact]
        public async Task IncreaseElbow_InvalidRightElbowMovimentation()
        {
            await robotRepository.Reset();

            await Assert.ThrowsAsync<InvalidElbowMovimentationException>(() => robotBodyRepository.Decrease<ElbowMovimentationEnum>(ArmEnum.Right));
        }

        // Tentando rotacionar o pulso do braço esquedo com o cotovelo em repouso
        [Fact]
        public async void IncreaseWrist_InvalidLeftWristMovimentation()
        {
            await robotRepository.Reset();

            await Assert.ThrowsAsync<InvalidWristMovimentationException>(() => robotBodyRepository.Increase<WristMovimentationEnum>(ArmEnum.Left));
        }

        // Rotacionando pulso do braço direito com o cotovelo fortemente contraído
        [Fact]
        public async Task IncreaseWrist_ValidRightWristMovimentation()
        {
            await robotRepository.Reset();

            await robotBodyRepository.Increase<ElbowMovimentationEnum>(ArmEnum.Right);
            await robotBodyRepository.Increase<ElbowMovimentationEnum>(ArmEnum.Right);
            await robotBodyRepository.Increase<ElbowMovimentationEnum>(ArmEnum.Right);


            await robotBodyRepository.Decrease<WristMovimentationEnum>(ArmEnum.Right);
            await robotBodyRepository.Increase<WristMovimentationEnum>(ArmEnum.Right);
            await robotBodyRepository.Increase<WristMovimentationEnum>(ArmEnum.Right);
            await robotBodyRepository.Increase<WristMovimentationEnum>(ArmEnum.Right);

            var robot = await robotRepository.Get();

            Assert.Equal(WristMovimentationEnum.Rotation90, robot.RobotBody.RobotRightArm.Wrist);
        }
    }
}
