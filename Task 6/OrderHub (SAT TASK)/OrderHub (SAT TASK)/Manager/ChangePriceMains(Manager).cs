using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Hide();
            LoginMain form1 = new LoginMain();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private class XmlHelper
        {
            public static void DisplayItemPrice(string xmlFilePath, string itemName, ListView lsvOutput)
            {
                if (System.IO.File.Exists(xmlFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    string xpathQuery = $"/FoodItems/Item/{itemName}/Price";
                    XmlNode priceNode = xmlDoc.SelectSingleNode(xpathQuery);

                    if (priceNode != null)
                    {
                        string price = priceNode.InnerText;

                        if (lsvOutput.Columns.Count == 0)
                        {
                            lsvOutput.Columns.Add("Item Name");
                            lsvOutput.Columns.Add("Price");
                            lsvOutput.View = View.Details;
                        }

                        lsvOutput.Items.Clear();

                        ListViewItem listItem = new ListViewItem(itemName);
                        listItem.SubItems.Add(price);
                        lsvOutput.Items.Add(listItem);
                    }
                    else
                    {
                        MessageBox.Show($"The price for item '{itemName}' could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("The XML file path is incorrect or the file does not exist.");
                }
            }

            public static void UpdateItemPrice(string xmlFilePath, string itemName, string newPrice)
            {
                if (System.IO.File.Exists(xmlFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    string xpathQuery = $"/FoodItems/Item/{itemName}/Price";
                    XmlNode priceNode = xmlDoc.SelectSingleNode(xpathQuery);

                    if (priceNode != null)
                    {
                        priceNode.InnerText = newPrice;

                        xmlDoc.Save(xmlFilePath);
                        MessageBox.Show($"{itemName} price updated to {newPrice}");
                    }
                    else
                    {
                        MessageBox.Show($"The price for item '{itemName}' could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("The XML file path is incorrect or the file does not exist.");
                }
            }
        }
        private void UpdateItem(string itemName)
        {
            // Display the item price in the ListView
            XmlHelper.DisplayItemPrice("DessertFoodItems.xml", itemName, lsvOutput);
        }

        private void btn7Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("$7");
        }

        private void btnBrownie_Click(object sender, EventArgs e)
        {
            UpdateItem("Brownie");
        }

        private void btnBananaBread_Click(object sender, EventArgs e)
        {
            UpdateItem("BannaBread");
        }

        private void btnChocoMousse_Click(object sender, EventArgs e)
        {
            UpdateItem("ChocoMousse");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lsvOutput.Items.Count > 0)
            {
                var itemName = lsvOutput.Items[0].Text;
                var newPrice = lsvOutput.Items[0].SubItems[1].Text;



                // Update the item price in the XML file
                XmlHelper.UpdateItemPrice("DessertFoodItems.xml", itemName, newPrice);
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }
    }
}
