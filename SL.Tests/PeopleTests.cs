using Moq;
using SL.Ado.Controllers;
using SL.Domain.Entities;
using SL.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SL.Tests
{
    public class PeopleTests
    {
        //subject under test
        PeopleController _sut;
                
        [Fact]
        public async Task Post_WithEmptyGuid_ReturnsPersonWithGeneratedGuidAsync()
        {
            //Arrange
            var mockedRepo = new Mock<IGenericRepository<Person>>();
            var person = new Person { Name = "Urim" };

            mockedRepo.Setup(x => x.Insert(It.IsAny<Person>())).Returns<Person>(x => {
                x.Id = Guid.NewGuid();
                return Task.FromResult(x);
            });

            _sut = new PeopleController(mockedRepo.Object);
            //Act

            Person response = await _sut.PostAsync(person);

            //Assert

            Assert.False(response.Id == Guid.Empty);
            Assert.Equal(person.Name, response.Name);
        }
    }
}
