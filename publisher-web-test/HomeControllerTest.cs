using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bus.Abstract;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcContrib.TestHelper;
using Publisher_web.Controllers;

namespace publisher_web_test
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly TestableHomeController _controller;
        private readonly HomeController _homeController;

        public HomeControllerTest()
        {
            _controller = TestableHomeController.Create();
            _homeController = new HomeController(_controller._journalManagerMock.Object);
        }

        [TestMethod]
        public void can_render_indexpage()
        {
            HomeController controller = new HomeController(_controller._journalManagerMock.Object);
            var result = controller.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void can_get_any_publishes()
        {
            JournalModel model = new JournalModel()
            {
                Id = 4,
                Publishes = new List<PublishModel>(),
                PublishCount = 10,
                Name = "testjournal"
            };

            _controller._journalManagerMock.Setup(x => x.Get(It.IsAny<int>())).Returns(model);

            var result = _homeController.Publishes(It.IsAny<int>());

            Assert.IsNotNull(result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void can_save_not_publish_file()
        {
            JournalModel model = new JournalModel()
            {
                Id = 4,
                Publishes = new List<PublishModel>(),
                PublishCount = 10,
                Name = "testjournal"
            };

            _controller._journalManagerMock.Setup(x => x.InsertPublish(It.IsAny<PublishModel>())).Returns(true);
            _controller._journalManagerMock.Setup(x => x.Get(It.IsAny<int>())).Returns(model);

            new TestControllerBuilder().InitializeController(_homeController);

            var httpContextMock = new Mock<HttpContextBase>();
            var serverMock = new Mock<HttpServerUtilityBase>();
            serverMock.Setup(x => x.MapPath("~/App_Data/uploads")).Returns(@"C:\Users\baran\Desktop\medical\MedicalJournal\Publisher-web\App_Data\uploads");
            httpContextMock.Setup(x => x.Server).Returns(serverMock.Object);

            var file1Mock = new Mock<HttpPostedFileBase>();
            file1Mock.Setup(f => f.ContentLength).Returns(1);
            file1Mock.Setup(x => x.FileName).Returns("file1.pdf");

            var result = _homeController.Publishes(file1Mock.Object);
            file1Mock.Verify(x => x.SaveAs(@"C:\Users\baran\Desktop\medical\MedicalJournal\Publisher-web\App_Data\uploads\file1.pdf"));

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void can_delete_selected_data()
        {
            _controller._journalManagerMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            _controller._journalManagerMock.Setup(x => x.GetAll());

            _homeController.Delete(It.IsAny<int>());

            _controller._journalManagerMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }

    public class TestableHomeController
    {
        public Mock<IJournalManager> _journalManagerMock;

        public TestableHomeController(Mock<IJournalManager> journalManagerMock)
        {
            _journalManagerMock = journalManagerMock;
        }

        public static TestableHomeController Create()
        {
            return new TestableHomeController(new Mock<IJournalManager>());
        }
    }
}