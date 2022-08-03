using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public Employer? Employer { get; set; }

        public Partner()
        {

        }

        public Partner(string name, string address, string contactPerson, string contactNumber, Employer? employer)
        {
            Name = name;
            Address = address;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            Employer = employer;
        }
    }
}
