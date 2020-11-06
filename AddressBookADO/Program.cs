using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookAdapter adapter = new AddressBookAdapter();
            AddressBookModel model = new AddressBookModel();
            model.firstName = "Nikhil";
            model.lastName = "Prasad";
            model.address = "HN 32";
            model.city = "Agra";
            model.state = "UP";
            model.zip = 13413;
            model.phone = 658366;
            model.emailid = "np@gmail.com";
            string result = adapter.AddAddress(model);
            Console.WriteLine(result);
        }
    }
}
