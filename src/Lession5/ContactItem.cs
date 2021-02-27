using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lession5
{
    public class ContactItem
    {
        public long Id { get; set; }

        // Are you a current SMART Modular customer?
        public int customer { get; set; }
        // Country
        public string Country { get; set; }
        // Business Type
        public string BusinessType { get; set; }
        // Main Products Services Offered by Your Company
        public string MainProducts { get; set; }
    }
}
