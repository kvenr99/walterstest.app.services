using app.entities;
using Company.Api.Controllers;
using Company.BL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiController.Tests
{
    [TestFixture]
    public class AccountControllerTest
    {

        private Mock<Lazy<IAccountRepository>> _mockRepository;

        #region setup
        /// <summary>
        /// Initial setup for tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<Lazy<IAccountRepository>>();
            Assert.NotNull(_mockRepository);
        }

        #endregion


        #region Unit Tests
        [Test]
        public void GetReturnsProductWithSameId()
        {
            // Arrange
            _mockRepository.Setup(x => x.Value.getByName("Copier"))
                .Returns(new List<Account>() { new Account { Id = 1, Number = 7760, Balance = 353.65, Name = "Copier" } });

            var controller = new AccountController(_mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.getByName("Copier");
            var contentResult = actionResult as OkNegotiatedContentResult<Account>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Copier", contentResult.Content.Name);
        }

        #endregion


        #region Tear Down
        [TearDown]
        public void DisposeTest()
        {
            if (_mockRepository != null)
                _mockRepository = null;
        }

        #endregion


    }
}
