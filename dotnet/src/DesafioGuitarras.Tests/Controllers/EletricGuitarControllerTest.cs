using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesafioGuitarras.Controllers;
using DesafioGuitarras.Domain.Services;
using DesafioGuitarras.Tests.Fakes;
using System.Web.Mvc;

namespace DesafioGuitarras.Tests.Controllers
{
    [TestClass]
    public class EletricGuitarControllerTest
    {

        [TestMethod]
        public void CreateActions()
        {
            var repository = new FakeEletricGuitarRepository();
            EletricGuitarController controller = new EletricGuitarController(new EletricGuitarService(new FakeUnitOfWork(), repository));

            var createView = controller.Create();
            var createAction = controller.Create(new Domain.Entities.EletricGuitar()
            {
                Id = 4,
                Name = "PRS",
                Description = "PRS",
                ImageUrl = "http://www.prsguitars.com/images/electrics/hollowbody12_straight1.png",
                Price = 9000,
                InsertDate = DateTime.Now
            });

            Assert.IsInstanceOfType(createView, typeof(ActionResult));
            Assert.IsInstanceOfType(createAction, typeof(ActionResult));
            Assert.AreEqual(4, repository.Guitars.Count);
        }

        [TestMethod]
        public void EditActions()
        {
            var repository = new FakeEletricGuitarRepository();
            EletricGuitarController controller = new EletricGuitarController(new EletricGuitarService(new FakeUnitOfWork(), repository));

            var editView = controller.Edit(1);
            var editAction = controller.Edit(new Domain.Entities.EletricGuitar()
            {
                Id = 1,
                Name = "PRS",
                Description = "PRS",
                ImageUrl = "http://www.prsguitars.com/images/electrics/hollowbody12_straight1.png",
                Price = 3000,
                InsertDate = DateTime.Now
            });

            Assert.IsInstanceOfType(editView, typeof(ActionResult));
            Assert.IsInstanceOfType(editAction, typeof(ActionResult));

            var model = repository.GetByPrimaryKey(1);
            Assert.AreEqual("PRS", model.Name);
            Assert.AreEqual("PRS", model.Description);
            Assert.AreEqual("http://www.prsguitars.com/images/electrics/hollowbody12_straight1.png", model.ImageUrl);
            Assert.AreEqual(3000, model.Price);
        }

        [TestMethod]
        public void DeleteActions()
        {
            var repository = new FakeEletricGuitarRepository();
            EletricGuitarController controller = new EletricGuitarController(new EletricGuitarService(new FakeUnitOfWork(), repository));

            var deleteAction = controller.Delete(1);

            Assert.IsInstanceOfType(deleteAction, typeof(ActionResult));
            Assert.AreEqual(2, repository.Guitars.Count);
        }
    }
}
