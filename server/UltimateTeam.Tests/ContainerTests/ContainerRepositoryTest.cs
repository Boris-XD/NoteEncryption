using Xunit;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using System;

namespace UltimateTeam.Tests.ContainerTests
{
    public class ContainerRepositoryTest
    {
        private readonly Mock<IContainerRepository> containerRepositoryMock;

        public ContainerRepositoryTest()
        {
            containerRepositoryMock = new Mock<IContainerRepository>();
        }

        [Fact]
        public void GetShouldReturnContainer()
        {
            var container = new Container();

            containerRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Container> { container });

            var result = containerRepositoryMock.Object.GetAllAsync().Result.First();

            Assert.Equal(container, result);
        }

        [Fact]
        public void GetShouldReturnNull()
        {
            containerRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Container>());

            var result = containerRepositoryMock.Object.GetAllAsync().Result.FirstOrDefault();

            Assert.Null(result);
        }

        [Fact]
        public void GetShouldThrowException()
        {
            containerRepositoryMock.Setup(x => x.GetAllAsync()).ThrowsAsync(new Exception());

            var result = Assert.ThrowsAsync<Exception>(() => containerRepositoryMock.Object.GetAllAsync());

            Assert.NotNull(result);
        }

        [Fact]
        public void GetShouldThrowExceptionWhenContainerIsNullTest()
        {
            containerRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Container> { null });

            var result = Assert.ThrowsAsync<ArgumentNullException>(() => containerRepositoryMock.Object.GetAllAsync());

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllContainersWithUserIdTest()
        {
            var container = new Container();
            container.UserId = Guid.NewGuid();

            var userId = container.UserId;

            containerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(container);

            var result = containerRepositoryMock.Object.GetByIdAsync(userId).Result;

            Assert.Equal(container, result);
            Assert.Equal(userId, result.UserId);
        }

        [Fact]
        public void GetAllContainersWithUserIdShouldThrowException()
        {
            containerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ThrowsAsync(new Exception());

            var result = Assert.ThrowsAsync<Exception>(() => containerRepositoryMock.Object.GetByIdAsync(Guid.NewGuid()));

            Assert.NotNull(result);
        }
    }
}