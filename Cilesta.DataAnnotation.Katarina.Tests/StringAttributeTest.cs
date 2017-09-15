namespace Cilesta.DataAnnotation.Katarina.Tests
{
    using Cilesta.DataAnnotation.Katarina.Tests.Models;
    using Cilesta.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringAttributeTest : BaseTest
    {
        [TestMethod]
        public void Test()
        {
            var model = new StringTestModel();

            model.Name = "123456";
            var trueResult = model.Validate();

            Assert.IsTrue(trueResult.IsValid);

            model.Name = "123";
            var falseResult = model.Validate();

            Assert.IsFalse(trueResult.IsValid);
        }
    }
}
