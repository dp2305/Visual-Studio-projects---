﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace OrderHub__SAT_Task_.Staff
{
    public partial class StaffSummerTime : Form
    {
        public StaffSummerTime()
        {
            InitializeComponent();
        }

        public static int selected_ID = 0;

        private const string ORDER = "orders.txt";

        public const string ORDERS = "orders.xml";

        private string ID = "ID.txt";

        public string numbervalue = "";


        private void SaveOrdersToXml()
        {
            // Ensure the ListView has items
            if (lsvOutput.Items.Count == 0)
            {
                MessageBox.Show("No orders to save.");
                return;
            }

            // Validate file path (optional)
            if (string.IsNullOrWhiteSpace(ORDERS))
            {
                MessageBox.Show("Invalid file path.");
                return;
            }

            XElement ordersXml;

            // Check if the XML file already exists
            if (File.Exists(ORDERS))
            {
                // Load existing XML file
                ordersXml = XElement.Load(ORDERS);
            }
            else
            {
                // Create a new root element if the file does not exist
                ordersXml = new XElement("Orders");
            }

            // Generate a new ID
            int newId = IDgeneration();

            // Create a new FullOrder element with the generated ID
            XElement fullOrderElement = new XElement("FullOrder",
                new XElement("ID", newId.ToString()) // Use the generated ID for the full order
            );

            // Iterate through each item in the ListView and add to the FullOrder element
            foreach (ListViewItem item in lsvOutput.Items)
            {
                XElement orderElement = new XElement("Order",
                    new XElement("Details", item.Text),
                    new XElement("Price", item.SubItems[1].Text),
                    new XElement("Quantity", item.SubItems[2].Text)
                );
                fullOrderElement.Add(orderElement);
            }

            // Add the FullOrder element to the root
            ordersXml.Add(fullOrderElement);

            // Save the updated XML structure to the specified file
            ordersXml.Save(ORDERS);

            MessageBox.Show("Orders saved to XML file.");
        }
        private int IDgeneration()
        {
            // Generate the ID
            int newId = 1;
            if (File.Exists(ID))
            {
                string[] lines = File.ReadAllLines(ID);

                // If there are existing records, calculate the new ID based on the last record
                if (lines.Length > 0)
                {
                    string[] item = lines[lines.Length - 1].Split(",");
                    newId = int.Parse(item[0]) + 1;
                }
            }

            // Construct the record
            string id = newId.ToString();
            string record = $"{id}";

            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(ID, true))
            {
                tw.WriteLine(record);
            }

            return newId;
        }
        private double CalculateTotalCost()
        {
            double totalCost = 0.0;

            foreach (ListViewItem item in lsvOutput.Items)
            {
                // Assuming the price is stored in the third column (index 2)
                string priceText = item.SubItems[2].Text.Replace("$", "");
                if (double.TryParse(priceText, out double price))
                {
                    totalCost += price;
                }
            }

            return totalCost;
        }

        private void ProcessPayment(double amountPaid)
        {
            double totalCost = CalculateTotalCost();
            double change = amountPaid - totalCost;

            MessageBox.Show($"Payment: ${amountPaid}\nTotal Cost: ${totalCost}\nChange: ${change}");

            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }



        private class XmlHelper
        {
            public static void DisplayItemDetails(string xmlFilePath, string itemName, ListView lsvOutput)
            {
                // Check if the file path exists
                if (System.IO.File.Exists(xmlFilePath))
                {
                    // Create a new XmlDocument object and load the XML file
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    // Build the XPath query dynamically based on the item name
                    string xpathQuery = $"/FoodItems/Item/{itemName}/Price";
                    XmlNode priceNode = xmlDoc.SelectSingleNode(xpathQuery);

                    // Check if the price node was found
                    if (priceNode != null)
                    {
                        string price = priceNode.InnerText;

                        // Get the Quantity node
                        string quantityXpathQuery = $"/FoodItems/Item/{itemName}/Quantity";
                        XmlNode quantityNode = xmlDoc.SelectSingleNode(quantityXpathQuery);

                        // Check if the quantity node was found
                        string quantity = quantityNode != null ? quantityNode.InnerText : "N/A";
                        ListViewItem listItem = new ListViewItem();

                        listItem.Text = (itemName);
                        listItem.SubItems.Add(price);
                        listItem.SubItems.Add(quantity);
                        lsvOutput.Items.Insert(0, listItem);
                    }
                    else
                    {
                        // Handle the case where the price node was not found
                        MessageBox.Show($"The item '{itemName}' could not be found.");
                    }
                }
            }
        }
        private void btnRaspberrySlush_Click(object sender, EventArgs e)
        {

        }

        private void btnCookiesanCreamMilkShake_Click(object sender, EventArgs e)
        {

        }

        private void btnZooperdooper_Click(object sender, EventArgs e)
        {

        }

        private void btn5DollarNote_Click(object sender, EventArgs e)
        {

        }

        private void btn10DollarNote_Click(object sender, EventArgs e)
        {

        }

        private void btn20DollarNote_Click(object sender, EventArgs e)
        {

        }

        private void btn50DollarNote_Click(object sender, EventArgs e)
        {

        }

        private void btn1Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn2Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn3Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn4Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn5Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn6Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn7Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn8Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn9Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn0Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btn00Numberpad_Click(object sender, EventArgs e)
        {

        }

        private void btnDecimalpointNumberpad_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteNumerpad_Click(object sender, EventArgs e)
        {

        }

        private void btnCreditPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnSalePayment_Click(object sender, EventArgs e)
        {

        }

        private void btnMain_Click(object sender, EventArgs e)
        {

        }

        private void btnDessert_Click(object sender, EventArgs e)
        {

        }

        private void btnSides_Click(object sender, EventArgs e)
        {

        }

        private void btnCold_Click(object sender, EventArgs e)
        {

        }

        private void btnHot_Click(object sender, EventArgs e)
        {

        }

        private void Special_Click(object sender, EventArgs e)
        {

        }

        private void btnEaster_Click(object sender, EventArgs e)
        {

        }
    }
}
