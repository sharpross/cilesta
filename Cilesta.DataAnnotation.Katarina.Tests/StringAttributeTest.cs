namespace Cilesta.DataAnnotation.Katarina.Tests
{
    using Cilesta.DataAnnotation.Katarina.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringAttributeTest
    {
        [TestMethod]
        public void Test()
        {
            var model = new StringTestModel();

            model.Name = "123456";
            var trueResult = model.Validate();

            Assert.Equals(trueResult.IsValid, true);

            model.Name = "123";
            var falseResult = model.Validate();

            Assert.Equals(trueResult.IsValid, false);
        }
    }
}
