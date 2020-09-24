using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.Abstract;
using Store.Entities;
using Store.WebUI.Controllers;
using Store.WebUI.HtmlHelpers;
using Store.WebUI.Models;

namespace Store.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<ICollectionRepository> mock = new Mock<ICollectionRepository>();
            mock.Setup(m => m.Collections).Returns(new List<Collection>
    {
        new Collection { CollectionId = 1, Name = "Игра1"},
        new Collection { CollectionId = 2, Name = "Игра2"},
        new Collection { CollectionId = 3, Name = "Игра3"},
        new Collection { CollectionId = 4, Name = "Игра4"},
        new Collection { CollectionId = 5, Name = "Игра5"}
    });
            CollectionController controller = new CollectionController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            CollectionsListViewModel result = (CollectionsListViewModel)controller.List(null, 2).Model;

            // Утверждение
            List<Collection> collections = result.Collections.ToList();
            Assert.IsTrue(collections.Count == 2);
            Assert.AreEqual(collections[0].Name, "Игра4");
            Assert.AreEqual(collections[1].Name, "Игра5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<ICollectionRepository> mock = new Mock<ICollectionRepository>();
            mock.Setup(m => m.Collections).Returns(new List<Collection>
    {
        new Collection { CollectionId = 1, Name = "Игра1"},
        new Collection { CollectionId = 2, Name = "Игра2"},
        new Collection { CollectionId = 3, Name = "Игра3"},
        new Collection { CollectionId = 4, Name = "Игра4"},
        new Collection { CollectionId = 5, Name = "Игра5"}
    });
            CollectionController controller = new CollectionController(mock.Object);
            controller.pageSize = 3;

            // Act
            CollectionsListViewModel result 
                = (CollectionsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}