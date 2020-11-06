using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookAdapter adapter = new AddressBookAdapter();
            AddressBookModel model = new AddressBookModel();
            model.firstName = "Kabir";
            model.lastName = "Sanyal";
            model.address = "HN 113";
            model.city = "Asansol";
            model.state = "WB";
            model.zip = 98723;
            model.phone = 917412;
            model.emailid = "ksan@gmail.com";
            string result = adapter.AddAddress(model);
            Console.WriteLine(result);
        }
    }
}
