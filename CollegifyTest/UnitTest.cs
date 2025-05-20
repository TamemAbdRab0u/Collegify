using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Collegify.Repository;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Collegify.Controllers;
using Collegify.Models;
using System.Linq.Expressions;


namespace CollegifyTest
{
    public class DepartmentControllerTests
    {
        [Fact]
        public void ReturnsDepartmentList()
        {
            var mockRepo = new Mock<IDepartmentRepo>();
            var sampleData = new List<Department>
            {
                new Department { Id = 1, DepartmentName = "Test A" },
                new Department { Id = 2, DepartmentName = "Test B" }
            };

            mockRepo.Setup(repo => repo.GetAll()).Returns(sampleData.AsQueryable());

            var controller = new DepartmentController(mockRepo.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Department>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }


        [Fact]
        public void GetCreate()
        {
            var mockRepo = new Mock<IDepartmentRepo>();
            var controller = new DepartmentController(mockRepo.Object);

            var result = controller.Add();

            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void PostCreate()
        {
            var mockRepo = new Mock<IDepartmentRepo>();
            var controller = new DepartmentController(mockRepo.Object);
            ITempDataDictionary tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            controller.TempData = tempData;

            var category = new Department { Id = 1, DepartmentName = "Test Category" };

            var result = controller.SaveAdd(category) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            mockRepo.Verify(r => r.Add(category), Times.Once);
            mockRepo.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void PostEdit()
        {

            var mockRepo = new Mock<IDepartmentRepo>();
            var controller = new DepartmentController(mockRepo.Object);
            ITempDataDictionary tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            controller.TempData = tempData;

            var category = new Department { Id = 1, DepartmentName = "Updated Category" };

            var result = controller.SaveEdit(category) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            mockRepo.Verify(r => r.Update(category), Times.Once);
            mockRepo.Verify(r => r.Save(), Times.Once);
        }  
    }
}