namespace Cilesta.DataAnnotation.Katarina.Tests
{
    using Cilesta.DataAnnotation.Katarina.Tests.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PasswordAttributeTest
    {
        [TestMethod]
        public void Test()
        {
            var model = new PasswordTestModel();

            model.Password = "qwe132asd";
            var trueResult = model.Validate();

            Assert.Equals(trueResult.IsValid, true);

            model.Password = "123";
            var falseResult = model.Validate();

            Assert.Equals(trueResult.IsValid, false);
        }
    }
}
