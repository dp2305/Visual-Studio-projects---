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
    public partial class ChefMainScreen : Form
    {
        public ChefMainScreen()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of EditDelete form.
            LoginMain form1 = new LoginMain();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            form1.Closed += (s, args) => this.Close();

            // Display form2.
            form1.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void ChefMainScreen_Load(object sender, EventArgs e)
        {
            string ID = "";
            using (XmlReader reader = XmlReader.Create("orders.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        // Return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "ID":       // Store the data element FirstName 
                                ID = reader.ReadString();


                                // When all fields have been read
                                // Add the row object to the listview table.
                                ListViewItem listItem = new ListViewItem();   

                                listItem.Text = ID;
                                    lsvOrderList.Items.Add(listItem);      // Display entire
                                break;
                        }
                    }
                }
            }
        }
    }
}
