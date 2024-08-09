using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OrderHub__SAT_Task_.Manager
{
    public partial class ChangePriceMains : Form
    {
        public ChangePriceMains()
        {
            InitializeComponent();
        }
        public string numbervalue = "";
        private void UpdateNumberValue(string value)
        {
            numbervalue += value;
            lsvOutput.Items[0].SubItems[1].Text = numbervalue;
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

        private class XmlHelper
        {
            public static void DisplayItemPrice(string xmlFilePath, string itemName, ListView lsvOutput)
            {
                // Check if the file path exists
                if (System.IO.File.Exists(xmlFilePath))
                {
                    // Create a new XmlDocument object and load the XML file
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    // Build the XPath query to find the item by its specific element name
                    string xpathQuery = $"/FoodItems/Item/{itemName}/Price";
                    XmlNode priceNode = xmlDoc.SelectSingleNode(xpathQuery);

                    // Check if the price node was found
                    if (priceNode != null)
                    {
                        string price = priceNode.InnerText;

                        // Configure ListView if not already configured
                        if (lsvOutput.Columns.Count == 0)
                        {
                            lsvOutput.Columns.Add("Item Name");
                            lsvOutput.Columns.Add("Price");
                            lsvOutput.View = View.Details; // Ensure the view is set to details
                        }

                        // Clear previous items
                        lsvOutput.Items.Clear();

                        // Create a new list view item with the item name and price
                        ListViewItem listItem = new ListViewItem(price);
                        listItem.SubItems.Add(price); // Add price as the second column
                        lsvOutput.Items.Add(listItem);
                    }
                    else
                    {
                        // Handle the case where the price node was not found
                        MessageBox.Show($"The price for item '{itemName}' could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("The XML file path is incorrect or the file does not exist.");
                }
            }

        }


        private void btn7Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("$7");
        }

        private void btnBrownie_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemPrice("DessertFoodItems.xml", "Brownie", lsvOutput);
        }
    }
}
