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
    public class RobotHeadTests
    {
        private RobotHeadRepository robotHeadRepository;
        private RobotRepository robotRepository;

        public RobotHeadTests()
        {
            robotRepository = new RobotRepository();
            robotHeadRepository = new RobotHeadRepository();
        }

        // Diminuindo rotação de Em Repouso para -45o
        [Fact]
        public async void DecreaseRotation_ValidRotateRobotHead()
        {
            await robotRepository.Reset();

            var robot = await robotHeadRepository.Decrease<HeadRotationEnum>();

            Assert.Equal(HeadRotationEnum.RotationM45, robot.RobotHead.HeadRotation);
        }

        // Não possui mais rotações para incrementar, somente para diminuir
        [Fact]
        public async Task IncreaseRotation_IncreaseForInvalidRotateRobotHead()
        {
            await robotRepository.Reset();

            await Assert.ThrowsAsync<InvalidRotationException>(() => robotHeadRepository.Increase<HeadRotationEnum>());
        }

        // Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo.
        [Fact]
        public async Task IncreaseRotation_RotateRobotHeadWithDownInclination()
        {
            await robotRepository.Reset();

            await robotHeadRepository.Decrease<HeadInclinationEnum>();

            await Assert.ThrowsAsync<InvalidRotationException>(() => robotHeadRepository.Increase<HeadRotationEnum>());
        }

        // Diminuindo inclinação de Em Repouso para Baixo
        [Fact]
        public async void DecreaseRotation_ValidInclinationRobotHead()
        {
            await robotRepository.Reset();

            var robot = await robotHeadRepository.Decrease<HeadInclinationEnum>();

            Assert.Equal(HeadInclinationEnum.Down, robot.RobotHead.HeadInclination);
        }

        // Diminuindo inclinação para opção inexistente
        [Fact]
        public async void DecreaseRotation_InvalidInclinationRobotHead()
        {
            await robotRepository.Reset();

            await robotHeadRepository.Decrease<HeadInclinationEnum>();

            await Assert.ThrowsAsync<InvalidInclinationException>(() => robotHeadRepository.Decrease<HeadInclinationEnum>());
        }
    }
}
