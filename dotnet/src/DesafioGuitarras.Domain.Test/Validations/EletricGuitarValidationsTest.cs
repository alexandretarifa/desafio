using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Validations.EletricGuitars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesafioGuitarras.Domain.Test.Validations
{
    [TestClass]
    public class EletricGuitarValidationsTest
    {
        [TestMethod]
        public void FitForRegistering()
        {
            EletricGuitar obj = new EletricGuitar
            {
                Id = 0,
                Name = "Fender Guitar",
                Description = "my fender guitar",
                InsertDate = DateTime.Now,
                Price = 2000,
                ImageUrl = null,
                Sku = "still no sku"
            };

            var validation = new FitForRegistering().Validate(obj);

            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void SkuFormatValidation()
        {
            EletricGuitar obj = new EletricGuitar
            {
                Id = 100,
                Name = "Fender Guitar",
                Description = "my fender guitar",
                InsertDate = DateTime.Now,
                Price = 2000,
                ImageUrl = null,
                Sku = "100_fender_guitar"
            };

            var validation = new SkuFormatValidation().Validate(obj);

            Assert.IsTrue(validation.IsValid);
        }
    }
}
