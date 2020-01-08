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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            toolTip1.SetToolTip(numericUpDownDonation, "Type Donation ID");
            toolTip1.SetToolTip(numericUpDownDonor, "Type Donation ID");
            toolTip1.SetToolTip(dateTimePickerDate, "Select Date");
            toolTip1.SetToolTip(comboBoxType, "Pick Type of Donation");
            toolTip1.SetToolTip(textBoxValue, "Type in Donation Value");
            toolTip1.SetToolTip(buttonAdd, "Click To Add New Donation");

            Donation d1 = new Donation(1, 1, DateTime.Now, "Money", 100);
            Donation d2 = new Donation(2, 2, new DateTime(2019, 11, 12), "Toys", 50);
            Donation d3 = new Donation(3, 3, new DateTime(2019, 11, 14), "Money", 70);
            Donation d4 = new Donation(4, 3, new DateTime(2019, 11, 18), "Food", 30);
            Donation d5 = new Donation(5, 3, DateTime.Now, "Toys", 10);
            Donation d6 = new Donation(6, 4, DateTime.Now, "Money", 15);
            Donation d7 = new Donation(7, 5, DateTime.Now, "Food", 25);
            Donation d8 = new Donation(8, 6, DateTime.Now, "Money", 75);
            Donation d9 = new Donation(9, 6, DateTime.Now, "Food", 150);
            Donation d10 = new Donation(10, 1, DateTime.Now, "Money", 50);

            donationBindingSource.Add(d1);
            donationBindingSource.Add(d2);
            donationBindingSource.Add(d3);
            donationBindingSource.Add(d4);
            donationBindingSource.Add(d5);
            donationBindingSource.Add(d6);
            donationBindingSource.Add(d7);
            donationBindingSource.Add(d8);
            donationBindingSource.Add(d9);
            donationBindingSource.Add(d10);

            updateLabels();

            tabControl1.TabPages.Remove(tabPage2);
        }

        private void updateLabels()
        {
            double totalValue = 0;
            int numToys = 0, numMoney = 0, numFood = 0, numClothes = 0;
            foreach (Donation d in donationBindingSource)
            {
                totalValue += d.DonationValue;
                if (d.DonationType == "Toys")
                    numToys++;
                else if (d.DonationType == "Money")
                    numMoney++;
                else if (d.DonationType == "Clothing")
                    numClothes++;
                else numFood++;
            }
            labelTotalValue.Text = "The total value of donations is: $" + totalValue;
            labelNumToys.Text = "The total number of toy donations is: " + numToys;
            labelNumMoney.Text = "The total number of money donations is: " + numMoney;
            labelNumClothes.Text = "The total number of clothing donations is: " + numClothes;
            labelNumFood.Text = "The total number of food donations is: " + numFood;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBoxPassword.Text.Trim().Length != 0 && textBoxUserName.Text.Trim().Length != 0)
            {
                //tabControl1.TabPages.Add(tabPage2);
                //tabControl1.TabPages.Remove(tabPage1);

                if (textBoxUserName.Text == "Admin")
                {
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.TabPages.Remove(tabPage1);
                }
                else
                {
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage4);
                }
            }
            else
            {
                MessageBox.Show("Enter valid username and password.");
            }

        }

        private void numericUpDownDonation_Validating(object sender, CancelEventArgs e)
        {
            foreach (Donation d in donationBindingSource)
            {
                if (numericUpDownDonation.Value == d.DonationID)
                {
                    MessageBox.Show("Please enter unique Donation ID");
                    numericUpDownDonation.Focus();
                    break;
                }

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Donation donationObject = new Donation();

            donationObject.DonationID = Int32.Parse(numericUpDownDonation.Text);
            donationObject.DonorID = Int32.Parse(numericUpDownDonor.Text);
            donationObject.DonationDate = dateTimePickerDate.Value;
            donationObject.DonationType = comboBoxType.Text;
            donationObject.DonationValue = Double.Parse(textBoxValue.Text);

            donationBindingSource.Add(donationObject);

            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=GHGDatabase.mdb
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=GHGDatabase.mdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Insert into Donation(ID,DonorID,DonationDate,DonationType,DonationValue)Values('" + numericUpDownDonation.Value + "','" + numericUpDownDonor.Value
                + "','" + dateTimePickerDate.Value.Date + "','" + comboBoxType.Text + "','" + textBoxValue.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Submitted", "Congrats");
            con.Close();

            numericUpDownDonation.ResetText();
            numericUpDownDonor.ResetText();
            dateTimePickerDate.ResetText();
            comboBoxType.SelectedIndex = -1;
            textBoxValue.ResetText();
            


            updateLabels();

            

        }

        private void textBoxValue_Validating(object sender, CancelEventArgs e)
        {
            double donVal = 0;
            if (Double.TryParse(textBoxValue.Text, out donVal) == false)
            {
                MessageBox.Show("Please enter a valid donation value.");
                textBoxValue.Focus();
                textBoxValue.SelectAll();

            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void textBoxUserName_Validating(object sender, CancelEventArgs e)
        {
            // Valid username is any string above length 0

            if (textBoxUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid username");
                textBoxUserName.Focus();
                textBoxUserName.SelectAll();
            }
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            // Valid password is any string above length 0
            if (textBoxPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid password");
                textBoxPassword.Focus();
                textBoxPassword.SelectAll();
            }
        }

        private void buttonSerach_Click(object sender, EventArgs e)
        {
            foreach (Donation d in donationBindingSource)
            {
                if (d.DonationType == comboBoxSearchType.Text)
                {
                    listBoxSearch.Items.Add(d.DonorID + ": " + d.DonationValue);
                }
            }
        }
    }
}
