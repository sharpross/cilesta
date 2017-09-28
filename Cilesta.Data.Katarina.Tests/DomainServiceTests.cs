namespace Cilesta.Data.Katarina.Tests
{
    using System;
    using Cilesta.Data.Katarina.Tests.Entities;
    using Cilesta.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DomainServiceTests : BaseTest
    {
        [TestMethod]
        public void TestCreate()
        {
        }

        [TestMethod]
        public void TestUpdate()
        {
        }

        [TestMethod]
        public void TestDelete()
        {
        }

        protected override void AfterInit()
        {
            Container.RegisterDataSource<UserMessage>();
        }
    }
}
