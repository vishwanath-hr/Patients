using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientRegistration.Models;
using PatientRegistration.DataAccessLayer;
using PatientRegistration.Controllers;
using System.Web.Http.Results;
using System.Web.Http;

namespace PatientRegistrationUnitTestProject
{
    [TestClass]
    public class PatientRegistrationUnitTest
    {
        [TestMethod]
        public void GetPatientsTest()
        {
            // Arrange
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(x => x.GetByID(1))
                .Returns(new Patient { Id = 1 });

            var controller = new PatientsAPIController(mockRepository.Object);

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<Patient>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetPatientsNotFound()
        {
            // Set up Prerequisites   
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(x => x.GetByID(1))
                .Returns(new Patient { Id = 1 });
            var controller = new PatientsAPIController(mockRepository.Object);
            // Act  
            IHttpActionResult actionResult = controller.Get(100);
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddPatientTest()
        {
            // Arrange  
            var mockRepository = new Mock<IPatientRepository>();
        
            var controller = new PatientsAPIController(mockRepository.Object);

            Patient patient = new Patient
            {
                 Forename="fore name", Surname="sur name", Gender="male" 
            };
            // Act  
            IHttpActionResult actionResult = controller.Post(patient);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Patient>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
    }
}
