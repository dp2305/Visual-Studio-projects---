using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OrderHub__SAT_Task_.Staff
{
    public partial class MemberLogin : Form
    {
        public MemberLogin()
        {
            InitializeComponent();
        }
        private const string MembersFileName = "Members.xml";

        private void LoadOrdersFromFile()
        {
            string mID = "", mNA = "", mA = "";
            using (XmlReader reader = XmlReader.Create("Members.xml"))
            {
                // Loop through each XML node.
                while (reader.Read())
                {
                    // Check if the current node is a start element.
                    if (reader.IsStartElement())
                    {
                        // Switch based on the element name.
                        switch (reader.Name.ToString())
                        {
                            case "MemberID":
                                // Read and store the FirstName element value.
                                mID = reader.ReadString();
                                break;
                            case "MemberName":
                                // Read and store the LastName element value.
                                mNA = reader.ReadString();
                                break;
                            case "MemberAge":
                                // Read and store the Email element value.
                                mA = reader.ReadString();


                                // Once all fields are read, create a ListViewItem and add it to lvwStudents.
                                ListViewItem listItem = new ListViewItem();   // Represents a row in the ListView.
                                listItem.Text = mID;                            // Set the first column (FirstName).
                                listItem.SubItems.Add(mNA);                     // Add subsequent columns (LastName, Email, PhoneNumber, Payment).
                                listItem.SubItems.Add(mA);
                                lsvOutput1.Items.Add(listItem);
                                break;
                        }
                    }
                }
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of EditDelete form.
            LoginMain login = new LoginMain();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            login.Closed += (s, args) => this.Close();

            // Display form2.
            login.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of EditDelete form.
            StaffMainScreen staffMainScreen = new StaffMainScreen();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            staffMainScreen.Closed += (s, args) => this.Close();

            // Display form2.
            staffMainScreen.Show();
        }

        private void lsvOutput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOutput1.SelectedItems.Count > 0)
            {
                // Populate text boxes and combo box with data from the selected item in lvwStudents.
                lsvOutput1.Text = lsvOutput1.SelectedItems[0].Text;          // First column (Member Name).
                lsvOutput1.Text = lsvOutput1.SelectedItems[0].SubItems[1].Text; // Second column (Member Number).
            }
        }

        private void MemberLogin_Load(object sender, EventArgs e) 
        {
            LoadOrdersFromFile(); 
        }

        private void btnLoginMember_Click(object sender, EventArgs e)
        {
            if (lsvOutput1.SelectedItems.Count > 0)
            {
                // Get the selected member's ID
                string memberID = lsvOutput1.SelectedItems[0].Text;

                // Display the member ID in the text box
                txtMemberSigninOutput.Text = "Signing in: " + memberID;
            }
            else
            {
                MessageBox.Show("Please select a member from the list.");
            }
        }

        private void btnMemberLogOut_Click(object sender, EventArgs e)
        {
            if (lsvOutput1.SelectedItems.Count > 0)
            {
                // Get the selected member's ID
                string memberID = lsvOutput1.SelectedItems[0].Text;

                // Display the member ID in the text box
                txtMemberSigninOutput.Text = "Signing out: " + memberID;
            }
            else
            {
                MessageBox.Show("Please select a member from the list.");
            }
        }
    }
}
