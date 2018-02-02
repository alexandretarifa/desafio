using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Specifications.EletricGuitars;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioGuitarras.Domain.Test.Validations
{
    [TestClass]
    public class EletricGuitarSpecificationsTest
    {
        [TestMethod]
        public void DescriptionMaxLength()
        {
            EletricGuitar obj = new EletricGuitar { Description = string.Empty.PadLeft(801, '0') };
            var falseValidation = new DescriptionMaxLength().IsSatisfiedBy(obj);

            obj.Description = string.Empty.PadLeft(8, '0');
            var trueValidation = new DescriptionMaxLength().IsSatisfiedBy(obj);

            Assert.IsFalse(falseValidation);
            Assert.IsTrue(trueValidation);
        }

        [TestMethod]
        public void ImageUrlMaxLength()
        {
            EletricGuitar obj = new EletricGuitar { ImageUrl = string.Empty.PadLeft(8001, '0') };
            var falseValidation = new ImageUrlLength().IsSatisfiedBy(obj);

            obj.ImageUrl = string.Empty.PadLeft(8, '0');
            var stringTrueValidation = new ImageUrlLength().IsSatisfiedBy(obj);

            obj.ImageUrl = null;
            var nullTrueValidation = new ImageUrlLength().IsSatisfiedBy(obj);

            Assert.IsFalse(falseValidation);
            Assert.IsTrue(stringTrueValidation);
            Assert.IsTrue(nullTrueValidation);
        }

        [TestMethod]
        public void NameMaxLength()
        {
            EletricGuitar obj = new EletricGuitar { Name = string.Empty.PadLeft(401, '0') };
            var falseValidation = new NameMaxLength().IsSatisfiedBy(obj);

            obj.Name = string.Empty.PadLeft(8, '0');
            var trueValidation = new NameMaxLength().IsSatisfiedBy(obj);

            Assert.IsFalse(falseValidation);
            Assert.IsTrue(trueValidation);
        }

        [TestMethod]
        public void SkuFormat()
        {
            EletricGuitar obj = new EletricGuitar
            {
                Id = 123,
                Name = "test ok",
                Sku = ""
            };

            var trueValidation = new SkuFormat().IsSatisfiedBy(obj);

            Assert.IsTrue(trueValidation);
        }

        [TestMethod]
        public void SkuMaxLength()
        {
            EletricGuitar obj = new EletricGuitar
            {
                Id = 123,
                Name = "test ok from length size",
                Sku = ""
            };

            var trueValidation = new SkuMaxLength().IsSatisfiedBy(obj);

            Assert.IsTrue(trueValidation);
        }
    }
}
