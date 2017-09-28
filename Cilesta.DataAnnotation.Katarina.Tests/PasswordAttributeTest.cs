namespace Cilesta.DataAnnotation.Katarina.Tests
{
    using Cilesta.DataAnnotation.Katarina.Tests.Models;
    using Cilesta.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PasswordAttributeTest : BaseTest
    {
        [TestMethod]
        public void Test()
        {
            var model = new PasswordTestModel();

            model.Password = "qwe132asd";
            var trueResult = model.Validate();

            Assert.IsTrue(trueResult.IsValid);

            model.Password = "123";
            var falseResult = model.Validate();

            Assert.IsFalse(trueResult.IsValid);
        }

        protected override void AfterInit()
        {
            //throw new System.NotImplementedException();
        }
    }
}
