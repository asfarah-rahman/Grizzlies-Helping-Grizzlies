using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrizzliesHelpingGrizzlies
{
    class Donation
    {
        public int DonationID { get; set; }
        public int DonorID { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationType { get; set; }
        public double DonationValue { get; set; }

        public Donation()
        {
            DonationID = 1;
            DonorID = 1;
            DonationDate = DateTime.Now;
            DonationType = "Money";
            DonationValue = 1;
        }
        public Donation(int DonationID, int DonorID, DateTime DonationDate, string DonationType, double DonationValue)
        {
            this.DonationID = DonationID;
            this.DonorID = DonorID;
            this.DonationDate = DonationDate;
            this.DonationType = DonationType;
            this.DonationValue = DonationValue;
        }
        public override string ToString()
        {
            return "Donation ID: " + DonationID
                + "\nDonor ID: " + DonorID
                + "\nDonation Date: " + DonationDate
                + "\nDonation Type: " + DonationType
                + "\nDonation Value: " + DonationValue;
        }

    }
}
