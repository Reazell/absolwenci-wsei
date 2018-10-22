using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services;
using Moq;
using Xunit;

namespace CareerMonitoring.Tests.Services
{
    public class UnregisteredUserServiceTest
    {
        [Fact]
        public async Task Create_async_should_invoke_add_async_on_user_repository()
        {
            //Arrange
            var unregisteredUserRepositoryMock = new Mock<IUnregisteredUserRepository>();
            var unregisteredUserService = new UnregisteredUserService(unregisteredUserRepositoryMock.Object);
            //Act
            await unregisteredUserService.CreateAsync("john", "johnson", "Informatyka i ekonometria", "2018-01-01 00:00:00", "dzienne",
                "john@gmail.com");
            //Assert
            unregisteredUserRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<UnregisteredUser>()),Times.Once());
        }
    }
}





















