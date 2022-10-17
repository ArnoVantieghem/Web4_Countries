using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Model;
using Xunit;
namespace CountryServiceUT
{
    public class UnitTestCountryController
    {
        private CountryController CC;
        private Mock<ICountryRepository> mockRepo;
        [Fact]
        public void TestGet_UnknownID_NotFound()
        {
            mockRepo = new Mock<ICountryRepository>();
            CC = new CountryController(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetCountry(2)).Throws(new CountryException("country doesn't exist"));
            var res = CC.Get(2);
            Assert.IsType<NotFoundObjectResult>(res.Result);
        }
        [Fact]
        public void TestGet_ValidID_Country()
        {
            mockRepo = new Mock<ICountryRepository>();
            CC = new CountryController(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetCountry(2)).Returns(new Country(2,"Duitsland","Berlijn","Europa"));
            var res = CC.Get(2);
            Assert.IsType<Country>(res.Value);
        }
    }
}