using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrizzliesHelpingGrizzlies
{
    class Donor
    {
        public int DonorID { get; set; }
        public string DonorType { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Anonymous { get; set; }

        public Donor()
        {
            DonorID = 1;
            DonorType = "Company";
            CompanyName = "CN";
            FirstName = "First";
            LastName = "Last";
            Email = "name@email.com";
            StreetAddress = "1111 Street Address";
            City = "City";
            State = "State";
            ZipCode = 00000;
            PhoneNumber = "770-333-4444";
            Anonymous = "Yes";
        }
        public Donor(int DonorID, string DonorType, string CompanyName, string FirstName, string LastName, string Email, string StreetAddress, string City, string State, int ZipCode, string PhoneNumber, string Anonymous)
        {
            this.DonorID = DonorID;
            this.DonorType = DonorType;
            this.CompanyName = CompanyName;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PhoneNumber = PhoneNumber;
            this.Anonymous = Anonymous;
        }
        public override string ToString()
        {
            return "Donor ID: " + DonorID
                + "\nDonor Type: " + DonorType
                + "\nCompany Name: " + CompanyName
                + "\nFirst Name: " + FirstName
                + "\nLast Name: " + LastName
                + "\nEmail: " + Email
                + "\nStreetAddress: " + StreetAddress
                + "\nCity: " + City
                + "\nState: " + State
                + "\nZip Code: " + ZipCode
                + "\nPhone Number: " + PhoneNumber
                + "\nAnonymous Donor: " + Anonymous;
        }


    }
}

