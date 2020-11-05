using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO
{
   public class AddressBookModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public double phone { get; set; }
        public string emailid { get; set; }
    }
}
