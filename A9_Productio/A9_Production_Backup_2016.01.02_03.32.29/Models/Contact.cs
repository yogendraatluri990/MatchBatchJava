using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A9_Production.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public Nullable<int> UserId { get; set; }
        public bool ISActive { get; set; }
        public virtual User User { get; set; }

           
    }
}