using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GrizzliesHelpingGrizzlies
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            toolTip1.SetToolTip(numericUpDownDonorID, "Type Donor ID");
            toolTip1.SetToolTip(comboBoxDonorType, "Select Donor Type");
            toolTip1.SetToolTip(textBoxCompany, "Type company nam or leave blank For individual.");
            toolTip1.SetToolTip(textBoxFirst, "Type Frist Name");
            toolTip1.SetToolTip(textBoxLast, "Type Last Name");
            toolTip1.SetToolTip(textBoxEmail, "Type Email Address");
            toolTip1.SetToolTip(comboBoxAnonymous, "Select if you would like to be anonymous.");
            toolTip1.SetToolTip(textBoxStreet, "Type Street Address");
            toolTip1.SetToolTip(textBoxCity, "Type City");
            toolTip1.SetToolTip(textBoxState, "Type State");
            toolTip1.SetToolTip(textBoxZip, "Type Zip Code");
            toolTip1.SetToolTip(textBoxPhone, "Type Phone Number \ne.g. 999-999-9999");
            toolTip1.SetToolTip(checkBoxMail, "Please check if you would like to be added to the mailing list.");
            toolTip1.SetToolTip(buttonAddDonor, "Click To Add Donor");
            toolTip1.SetToolTip(textBoxEmailMilingList, "Type email to be added to the mailing list.");


            Donor don1 = new Donor(1, "Company", "GGC", "John", "Griffin", "jgriffin@ggc.edu", "1000 University Lane", "Lawrenceville", "Georgia", 30043, "678-123-1234", "Yes");
            Donor don2 = new Donor(2, "Company", "Trader Joe's", "Joe", "Trader", "traderjoes@gmail.com", "5185 Peachtree Pkwy", "Norcross", "Georgia", 30092, "678-966-9236", "Yes");
            Donor don3 = new Donor(3, "Company", "Whole Foods", "John", "Mackey", "jmackey@gmail.com", "5001 Peachtree Blvd", "Atlanta", "Georgia", 30341, "470-552-0750", "Yes");
            Donor don4 = new Donor(4, "Company", "Target", "Brian", "Cornell", "brainc@gmail.com", "3205 Woodward Crossing Blvd", "Buford", "Georgia", 30519, "678-482-2367", "Yes");
            Donor don5 = new Donor(5, "Company", "Free People", "Richard", "Hayne", "reechard@gmail.com", "3160 1st St", "Alpharetta", "Georgia", 30009, "678-248-5536", "Yes");
            Donor don6 = new Donor(6, "Company", "Soleil Lune", "Meyoung", "Jones", "mjones@gmail.com", "2389 Mineral Springs Rd", "Winder", "Georgia", 30011, "678-123-1234", "Yes");
            Donor don7 = new Donor(7, "Individual", "", "Nick", "Jones", "njjones@gmail.com", "6793 Blue Bird Lane", "Lawrenceville", "Georgia", 30044, "678-900-4444", "No");
            Donor don8 = new Donor(8, "Individual", "", "Nicole", "Smith", "nicsmith@gmail.com", "1089 Roswell Rd", "Roswell", "Georgia", 30233, "770-316-9234", "No");
            Donor don9 = new Donor(9, "Individual", "", "Bretman", "Rock", "bretmanrock@gmail.com", "2854 Cheatu Elan", "Atlanta", "Georgia", 30090, "678-458-1984", "No");
            Donor don10 = new Donor(10, "Individual", "", "Nacey", "Jade", "njade@gmail.com", "4563 Jim Moore Rd", "Dacula", "Georgia", 30019, "678-678-1256", "No");

            donorBindingSource.Add(don1);
            donorBindingSource.Add(don2);
            donorBindingSource.Add(don3);
            donorBindingSource.Add(don4);
            donorBindingSource.Add(don5);
            donorBindingSource.Add(don6);
            donorBindingSource.Add(don7);
            donorBindingSource.Add(don8);
            donorBindingSource.Add(don9);
            donorBindingSource.Add(don10);

            updateLabelsDonor();
        }

        private void updateLabelsDonor()
        {
            double totalDonors = 0;
            int numCompany = 0, numIndividual = 0;
            foreach (Donor don in donorBindingSource)
            {
                totalDonors += don.DonorID;
                if (don.DonorType == "Company")
                    numCompany++;
                else numIndividual++;
            }
            labelTotalDonor.Text = "The total number of donors is: " + totalDonors;
            labelNumCompany.Text = "The number of company donors is: " + numCompany;
            labelNumIndividual.Text = "The number of individual donors is: " + numIndividual;
        }

        private void numericUpDownDonorID_Validating(object sender, CancelEventArgs e)
        {
            foreach (Donor don in donorBindingSource)
            {
                if (numericUpDownDonorID.Value == don.DonorID)
                {
                    MessageBox.Show("Please enter unique Donor ID");
                    numericUpDownDonorID.Focus();
                    break;
                }

            }
        }

        private void textBoxFirst_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxFirst.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid first name.");
                textBoxFirst.Focus();
                textBoxFirst.SelectAll();
            }
        }

        private void textBoxLast_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxLast.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid last name.");
                textBoxLast.Focus();
                textBoxLast.SelectAll();
            }
        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEmail.Text.Contains("@") == false)
            {
                MessageBox.Show("Please enter a valid email.");

                textBoxEmail.Focus();
                textBoxEmail.SelectAll();
            }
        }

        private void textBoxStreet_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxStreet.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid street address.");
                textBoxStreet.Focus();
                textBoxStreet.SelectAll();
            }
        }

        private void textBoxCity_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid city.");
                textBoxCity.Focus();
                textBoxCity.SelectAll();
            }
        }

        private void textBoxState_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxState.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid state.");
                textBoxState.Focus();
                textBoxState.SelectAll();
            }
        }

        private void textBoxZip_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxZip.Text.Trim().Length != 5)
            {
                MessageBox.Show("Please enter a valid zip code.");
                textBoxZip.Focus();
                textBoxZip.SelectAll();
            }
        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPhone.Text.Trim().Length != 12)
            {
                MessageBox.Show("Please enter a valid phone number");
                textBoxPhone.Focus();
                textBoxPhone.SelectAll();
            }
        }

        private void buttonAddDonor_Click(object sender, EventArgs e)
        {
            Donor donorObject = new Donor();

            donorObject.DonorID = Int32.Parse(numericUpDownDonorID.Text);
            donorObject.DonorType = comboBoxDonorType.Text;
            donorObject.CompanyName = textBoxCompany.Text;
            donorObject.FirstName = textBoxFirst.Text;
            donorObject.LastName = textBoxLast.Text;
            donorObject.Email = textBoxEmail.Text;
            donorObject.Anonymous = comboBoxAnonymous.Text;
            donorObject.StreetAddress = textBoxStreet.Text;
            donorObject.City = textBoxCity.Text;
            donorObject.State = textBoxState.Text;
            donorObject.ZipCode = Int32.Parse(textBoxZip.Text);
            donorObject.PhoneNumber = textBoxPhone.Text;

            donorBindingSource.Add(donorObject);


            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=GHGDatabase.mdb
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=GHGDatabase.mdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Insert into Donor(DonorID,DonorType,CompanyName, FirstName, LastName, Email, StreetAddress, City, State, ZipCode, PhoneNumber, Anonymous)Values('" + 
                numericUpDownDonorID.Value + "','" + comboBoxDonorType.Text
                + "','" + textBoxCompany.Text + "','" + textBoxFirst.Text + "','" + 
                textBoxLast.Text + "','" + textBoxEmail.Text + "','" + textBoxStreet.Text + "','" + 
                textBoxCity.Text + "','" + textBoxState.Text + "','" + textBoxZip.Text
                + "','"+  textBoxPhone.Text + "','" + comboBoxAnonymous.Text + "')";

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Submitted", "Congrats");
            con.Close();

            numericUpDownDonorID.ResetText();
            comboBoxDonorType.ResetText();
            textBoxCompany.ResetText();
            textBoxFirst.ResetText();
            textBoxLast.ResetText();
            textBoxEmail.ResetText();
            comboBoxAnonymous.ResetText();
            textBoxStreet.ResetText();
            textBoxCity.ResetText();
            textBoxState.ResetText();
            textBoxZip.ResetText();
            textBoxPhone.ResetText();
            checkBoxMail.Checked = false;


            //MessageBox.Show("The donor has been added.");

            updateLabelsDonor();

        }

        private void checkBoxMail_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxMailingList.Items.Contains(textBoxEmail.Text))
            {
              MessageBox.Show("Email is already in mailing list");
                checkBoxMail.Checked = false;
            }
            else
            {
                listBoxMailingList.Items.Add(textBoxEmail.Text);
            }
        }

        private void buttonMailingListAdd_Click(object sender, EventArgs e)
        {
            if (listBoxMailingList.Items.Contains(textBoxEmailMilingList.Text))
            {
               MessageBox.Show("Email is already in mailing list");
            }
            else
            {
                listBoxMailingList.Items.Add(textBoxEmailMilingList.Text);
                MessageBox.Show("Email has been added.");
                textBoxEmailMilingList.Focus();
                textBoxEmailMilingList.SelectAll();
                //textBoxEmailMilingList.ResetText();
            }

        }

        private void textBoxEmailMilingList_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEmailMilingList.Text.Contains("@") == false)
            {
                MessageBox.Show("Please enter a valid email.");

                textBoxEmailMilingList.Focus();
                textBoxEmailMilingList.SelectAll();
            }
        }

       
    }
}
