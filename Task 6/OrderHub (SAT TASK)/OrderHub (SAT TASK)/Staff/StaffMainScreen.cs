using OrderHub__SAT_Task_.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace OrderHub__SAT_Task_
{
    public partial class StaffMainScreen : Form
    {
        private string ID = "ID.txt";

        public string numbervalue = "";

        public static int selected_ID = 0;

        private List<string> orders = new List<string>();

        private const string ORDER = "orders.txt";

        public const string ORDERS = "orders.xml";

        public const string FOODITEMLIST = "FoodItemList.xml";

        public StaffMainScreen()
        {
            InitializeComponent();
        }

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



        private void btnSignOut_Click(object sender, EventArgs e)
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


        private void lsvOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Quantity = clhQuantity.Text;
            string Details = clhOrderDetail.Text;
            string price = clhPrice.Text;
            if (lsvOutput.SelectedItems.Count > 0)
            {
                // Populate text boxes and combo box with data from the selected item in lvwStudents.
                Quantity = lsvOutput.SelectedItems[0].Text; // Second column (LastName).
                Details = lsvOutput.SelectedItems[0].SubItems[1].Text;    // Third column (Email).
                price = lsvOutput.SelectedItems[0].SubItems[2].Text; // Fourth column (PhoneNumber).
            }
        }

        // Updates the number value and the TextBox with the selected number.
        private void UpdateNumberValue(string value)
        {
            numbervalue += value;
            lsvOutput.Items[0].SubItems[2].Text = numbervalue;
        }

        private void btn1Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("1");
        }

        private void btn2Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("2");
        }

        private void btn3Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("3");
        }

        private void btn4Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("4");
        }

        private void btn5Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("5");
        }

        private void btn6Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("6");
        }

        private void btn7Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("7");
        }

        private void btn8Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("8");
        }

        private void btn9Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("9");
        }

        private void btn0Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("0");
        }

        private void btn00Numberpad_Click(object sender, EventArgs e)
        {
            UpdateNumberValue("00");
        }

        private void btnDecimalpointNumberpad_Click(object sender, EventArgs e)
        {
            // Add a decimal point only if there isn't one already
            if (!numbervalue.Contains("."))
            {
                UpdateNumberValue(".");
            }
        }

        private void btnDeleteNumerpad_Click(object sender, EventArgs e)
        {
            // Remove the last character from the numbervalue string
            if (numbervalue.Length > 0)
            {
                numbervalue = numbervalue.Substring(0, numbervalue.Length - 1);
                lsvOutput.Items[0].SubItems[3].Text = numbervalue;
            }
        }


        private void btnCreditPayment_Click(object sender, EventArgs e)
        {
            // Save orders from ListView to XML file
            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }

        private void btnReciept_Click(object sender, EventArgs e)
        {
            MessageBox.Show("printing recipt");
        }

        private void btnCheeseBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "CheeseBurger", lsvOutput);
        }

        private void btnDoubleCheeseBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "DoubleCheeseBurger", lsvOutput);
        }

        private void btnThreeCheeseBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "TripleCheeseBurger", lsvOutput);
        }

        private void EightCheeseBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "EightCheeseBurger",
                        lsvOutput);
        }

        private void btnAngusBeefBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "AngusBeefBurger",
                        lsvOutput);
        }

        private void btnHamBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "HamBurger",
                        lsvOutput);
        }

        private void btnMushroomBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "MushroomBurger",
                        lsvOutput);
        }

        private void btnBaconCheeseBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "BaconCheeseBurger",
                        lsvOutput);
        }

        private void btnTurkeyBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "TurkeyBurger",
                        lsvOutput);
        }

        private void btnChickenBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "ChickenBurger",
                        lsvOutput);
        }

        private void btnChiliBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "ChiliBurger",
                        lsvOutput);
        }

        private void btnLambBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "LambBurger",
                 lsvOutput);
        }

        private void btnBBQBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "BBQBurger",
                        lsvOutput);
        }

        private void btnElkBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "ElkBurger",
                        lsvOutput);
        }

        private void btnOnionBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "OnionBurger",
                        lsvOutput);
        }

        private void btnSalmonBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "SalmonBurger",
                        lsvOutput);
        }

        private void btnPizzaBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "PizzaBurger",
                        lsvOutput);
        }

        private void btnTeriyakiBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "TeriyakiBurger",
                        lsvOutput);
        }

        private void btnBlackbeanBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "BlackBeanBurger",
                        lsvOutput);
        }

        private void btn5DollarNote_Click(object sender, EventArgs e)
        {
            // Calculate the total cost
            double totalCost = CalculateTotalCost();
            double amountPaid = 5;
            double change = amountPaid - totalCost;

            if (amountPaid < totalCost)
            {
                MessageBox.Show("not enough");
                return;
            }

            else
            {
                txtChange.Text = $"Payment: ${amountPaid}\nTotal Cost: ${totalCost}\nChange: ${change}";
            }

            // Save orders from ListView to XML file
            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }

        private void btn10DollarNote_Click(object sender, EventArgs e)
        {
            // Calculate the total cost
            double totalCost = CalculateTotalCost();
            double amountPaid = 10;
            double change = amountPaid - totalCost;


            if (amountPaid < totalCost)
            {
                MessageBox.Show("not enough");
                return;
            }

            else
            {
                txtChange.Text = $"Payment: ${amountPaid}\nTotal Cost: ${totalCost}\nChange: ${change}";
            }

            // Save orders from ListView to XML file
            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }

        private void btn20DollarNote_Click(object sender, EventArgs e)
        {
            // Calculate the total cost
            double totalCost = CalculateTotalCost();
            double amountPaid = 20;
            double change = amountPaid - totalCost;

            if (amountPaid < totalCost)
            {
                MessageBox.Show("not enough");
                return;
            }
            else
            {
                txtChange.Text = $"Payment: ${amountPaid}\nTotal Cost: ${totalCost}\nChange: ${change}";
            }

            // Save orders from ListView to XML file
            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }

        private void btn50DollarNote_Click(object sender, EventArgs e)
        {
            // Calculate the total cost
            double totalCost = CalculateTotalCost();
            double amountPaid = 50;
            double change = amountPaid - totalCost;

            if (amountPaid < totalCost)
            {
                MessageBox.Show("not enough");
                return;
            }

            else
            {
                txtChange.Text = $"Payment: ${amountPaid}\nTotal Cost: ${totalCost}\nChange: ${change}";
            }


            // Save orders from ListView to XML file
            SaveOrdersToXml();
            lsvOutput.Items.Clear();
        }

        private void btnWaguBurger_Click(object sender, EventArgs e)
        {
            XmlHelper.DisplayItemDetails("FoodItemList.xml", "WaguBurger",
                        lsvOutput);
        }

        private void btnSalePayment_Click(object sender, EventArgs e)
        {
            SaveOrdersToXml();
            lsvOutput.Items.Clear();

        }

        private void btnMemberLogin_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of MemberLogin form.
            MemberLogin memberlogin = new MemberLogin();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            memberlogin.Closed += (s, args) => this.Close();

            // Display MemberLogin.
            memberlogin.Show();
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of StaffDessertScreen form.
            StaffDessertScreen StaffDessertScreen = new StaffDessertScreen();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            StaffDessertScreen.Closed += (s, args) => this.Close();

            // Display MemberLogin.
            StaffDessertScreen.Show();
        }

        private void btnSides_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of StaffDessertScreen form.
            StaffSidesScreen StaffSidesScreen = new StaffSidesScreen();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            StaffSidesScreen.Closed += (s, args) => this.Close();

            // Display MemberLogin.
            StaffSidesScreen.Show();
        }

        private void btnCold_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of StaffDessertScreen form.
            StaffColdScreen StaffColdScreen = new StaffColdScreen();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            StaffColdScreen.Closed += (s, args) => this.Close();

            // Display MemberLogin.
            StaffColdScreen.Show();
        }
    }
}
