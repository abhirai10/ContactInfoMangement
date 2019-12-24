using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using ContactInfoManagement.Models;
using ContactInfoManagement.BusinessLayer;
using ContactInfoManagement.Controllers;
using Moq;
using System.Net;

namespace ContactManagement.Tests
{
    [TestClass]
    public class ContactControllerTest
    {
        //Return type is OkNegotiatedContentResult and the returned product has the right ID
        [TestMethod]
        public void TestMethod_GetContactByIdBLL()
        {
            // Arrange
            var mockRepository = new Mock<IContactBusinessLayer>();
            mockRepository.Setup(x => x.GetContactByIdBLL(1))
                .Returns(new ContactViewModel { Id = 1 });

            var controller = new ContactsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetContactById(1);
            var contentResult = actionResult as OkNegotiatedContentResult<ContactViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        //GetContactById returns NotFound() if id not found this Unit Test checks if the return type is NotFoundResult
        [TestMethod]
        public void TestMethod_GetContactByIdNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IContactBusinessLayer>();
            var controller = new ContactsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetContactById(100);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        //The Delete method calls Ok() if successfully deleted
        [TestMethod]
        public void TestMethod_DeleteContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactBusinessLayer>();
            var controller = new ContactsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.DeleteContact(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        //Unit test to verify that the action sets the correct routing values
        [TestMethod]
        public void TestMethod_AddNewContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactBusinessLayer>();
            var controller = new ContactsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.AddNewContact(new ContactViewModel {Id=10, FirstName = "ABHI", LastName = "RAI", Email = "ABC@gmail.com", PhoneNumber = 9123467896, Status = "Active" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<ContactViewModel>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }

        //Unit test to check the status code when Contact is updated
        [TestMethod]
        public void TestMethod_UpdateContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactBusinessLayer>();
            var controller = new ContactsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.UpdateContact(new ContactViewModel { Id=10, FirstName = "ABHI", LastName = "RAI", Email = "ABC@gmail.com", PhoneNumber = 9123467896, Status = "Active" });
            var contentResult = actionResult as NegotiatedContentResult<ContactViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.NotFound, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(10, contentResult.Content.Id);
        }
    }
}
