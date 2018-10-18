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
        
//        [Fact]
//        public async Task Get_all_async_should_invoke_get_all_async_on_user_repository()
//        {
//            //Arrange
//            DateTime date = Convert.ToDateTime("2018-01-01 00:00:00");
//            var unregisteredUser = new UnregisteredUser("john", "johnson", "Informatyka i ekonometria", date, "dzienne",
//                "john@gmail.com");
//            var unregisteredUser2 = new UnregisteredUser("john", "johnson", "Informatyka i ekonometria", date, "dzienne",
//                "john@gmail.com");
//            List<UnregisteredUser> unregisteredUsersList = new List<UnregisteredUser>();
//            unregisteredUsersList.Add(unregisteredUser);
//            unregisteredUsersList.Add((unregisteredUser2));
//            var unregisteredUserRepositoryMock = new Mock<IUnregisteredUserRepository>().Setup(x=>x.GetAllAsync().Result(unregisteredUsersList));
//            var unregisteredUserService = new UnregisteredUserService(unregisteredUserRepositoryMock);
//            
//            //Act
//            var unregisteredUsers = await unregisteredUserService.GetAllAsync();
//            
//            //Assert
//            unregisteredUserRepositoryMock.Verify(x=>x.GetAllAsync(It.IsInRange(),Times.Once());
//
//        }
    }
}





















