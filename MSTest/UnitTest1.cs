using AddressBookADO;
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
        /// The test checks whether the Add method is
        /// retruning the success message or not
        [TestMethod]
        public void GivenDataAddsDataReturnSuccessMessage()
        {
            AddressBookModel model = new AddressBookModel();
            model.firstName = "Akhil";
            model.lastName = "Roy";
            model.address = "HN 202";
            model.city = "Kolkata";
            model.state = "WB";
            model.zip = 102943;
            model.phone = 9082741;
            model.emailid = "ak@gmail.com";
            string result = adapter.AddAddress(model);
            Assert.AreEqual(result, "Added succesfully");
        }
        /// The UpdateTable method has been called and an update query is passed
        /// The test checks whether any row is affected or not
        [TestMethod]
        public void GivenQueryUpdatesTable() {
            bool result = adapter.UpdateTable(@"update Address_Model set city='Silchar' where first_name ='Jatin'");
            Assert.IsTrue(result);
        }
        /// The UpdateTable method has been called and an delete query is passed
        /// The test checks whether any row is affected or not
        [TestMethod]
        public void GivenQueryDeletesRowFromTable() {
            bool result = adapter.UpdateTable(@"delete from Address_Model where first_name ='Nikhil'");
            Assert.IsTrue(result);
        }
    }
}
