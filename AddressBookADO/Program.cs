using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookAdapter addressBook = new AddressBookAdapter();
            addressBook.CreateTable();
        }
    }
}
