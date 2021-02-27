using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lession6
{
    public class ContactItem
    {
        public long Id { get; set; }

        // Are you a current SMART Modular customer?
        public int Customer { get; set; }
        
        // Country
        public string Country { get; set; }
        
        // Business Type
        public string BusinessType { get; set; }
        public string BusinessOthers { get; set; }

        // Main Products Services Offered by Your Company
        public string MainProducts { get; set; }
        
        // Company
        public string Company { get; set; }

        // Name First Name
        public string FirstName { get; set; }

        // Name Last Name
        public string LastName { get; set; }

        // Business Title
        public string BusinessTitle { get; set; }

        // Business Email
        public string Email { get; set; }

        // Business Telephone
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }

        // Please enter your questions or comments below
        public string Comments { get; set; }

        // private columns
        public DateTime CreateDate { get; set; }

        public string AdminNotes { get; set; }
    }

    public class ContactItemDTO
    {
        public long Id { get; set; }

        // Are you a current SMART Modular customer?
        public int Customer { get; set; }

        // Country
        public string Country { get; set; }

        // Business Type
        public string BusinessType { get; set; }
        public string BusinessOthers { get; set; }

        // Main Products Services Offered by Your Company
        public string MainProducts { get; set; }

        // Company
        public string Company { get; set; }

        // Name First Name
        public string FirstName { get; set; }

        // Name Last Name
        public string LastName { get; set; }

        // Business Title
        public string BusinessTitle { get; set; }

        // Business Email
        public string Email { get; set; }

        // Business Telephone
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }

        // Please enter your questions or comments below
        public string Comments { get; set; }

    }

}
