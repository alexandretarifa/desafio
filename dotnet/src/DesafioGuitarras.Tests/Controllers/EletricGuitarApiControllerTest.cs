using DesafioGuitarras.Controllers;
using DesafioGuitarras.Domain.Services;
using DesafioGuitarras.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGuitarras.Tests.Controllers
{
    [TestClass]
    public class EletricGuitarApiControllerTest
    {
        [TestMethod]
        public void GetAll()
        {
            EletricGuitarApiController controller = new EletricGuitarApiController(new EletricGuitarService(new FakeUnitOfWork(), new FakeEletricGuitarRepository()));

            Assert.AreEqual(3, controller.GetAll().Count());
        }

        [TestMethod]
        public void Get()
        {
            EletricGuitarApiController controller = new EletricGuitarApiController(new EletricGuitarService(new FakeUnitOfWork(), new FakeEletricGuitarRepository()));

            Assert.IsNotNull(controller.Get(1));
            Assert.IsNull(controller.Get(5));
        }

    }
}
