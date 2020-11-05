using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookADO.AddressBookAdapter adapter = null;
        [TestInitialize]
        public void SetUp() {
            adapter = new AddressBookADO.AddressBookAdapter();
        }
        /// The method checks whether any number of rows is affected 
        /// from the CreateTable method
        [TestMethod]
        public void GivenQueryCreatesTable()
        {
            bool result = adapter.CreateTable();
            Assert.IsTrue(result);
        }
    }
}
