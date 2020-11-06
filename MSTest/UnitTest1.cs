using AddressBookADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        /// The GetPersons method is called and a query is passed to get the people from 
        /// a particular city
        /// The test checks whether it is returning the expected list
        [TestMethod]
        public void GivenQueryGivesPeopleFromACity() {
            List<string> expected = new List<string>();
            List<string> actual = adapter.GetPersons(@"select first_name from Address_Model where city ='Kolkata'");
            expected.Add("Akhil");
            expected.Add("Pooja");
            expected.Equals(actual);
        }
        /// The GetPersons method is called and a query is passed to get the people from 
        /// a particular city
        /// The test checks whether it is returning the expected list
        [TestMethod]
        public void GivenQueryGivesPeopleFromAState()
        {
            List<string> expected = new List<string>();
            List<string> actual = adapter.GetPersons(@"select first_name from Address_Model where state ='WB'");
            expected.Add("Akhil");
            expected.Add("Pooja");
            expected.Add("Kabir");
            expected.Equals(actual);
        }
        /// In this test, the GetCount method is called and
        /// query is passed to get count of the people from a city
        /// It is checked whether it is returning the corect count or not
        [TestMethod]
        public void GivenQueryGivesCountOfPeopleFromACity() {
            int expected = adapter.GetCount(@"select count(first_name) from Address_Model where city ='Kolkata'");
            int actual = 2;
            Assert.AreEqual(expected, actual);
        }
        /// In this test, the GetCount method is called and
        /// query is passed to get count of the people from a state
        /// It is checked whether it is returning the corect count or not
        [TestMethod]
        public void GivenQueryGivesCountOfPeopleFromAState()
        {
            int expected = adapter.GetCount(@"select count(first_name) from Address_Model where state ='WB'");
            int actual = 3;
            Assert.AreEqual(expected, actual);
        }
    }
}
