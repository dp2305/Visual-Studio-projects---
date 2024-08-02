using OrderHub__SAT_Task_.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public StaffMainScreen()
        {
            InitializeComponent();
        }

        public static int selected_ID = 0;

        private List<string> orders = new List<string>();

        private const string ORDER = "orders.txt";

        public const string ORDERS = "orders.xml";

        public const string FOODITEMLIST = "FoodItemList.xml";


        private void DeleteLatestInputFromLogFile()
        {
            // Read all lines from the log file
            string[] lines = File.ReadAllLines(ID);

            // Check if there are any entries in the log
            if (lines.Length > 0)
            {
                // Remove the last entry
                Array.Resize(ref lines, lines.Length - 1);

                // Write the updated entries back to the log file
                File.WriteAllLines(ID, lines);
            }
        }

        private void LoadOrdersFromFile()
        {
            if (File.Exists(ORDERS))
            {
                XElement ordersXml = XElement.Load(ORDERS);

                // Iterate through each FullOrder element
                foreach (XElement fullOrder in ordersXml.Elements("FullOrder"))
                {
                    // Iterate through each Order element within the FullOrder
                    foreach (XElement orderElement in fullOrder.Elements("Order"))
                    {
                        ListViewItem listItem = new ListViewItem(fullOrder.Element("ID").Value);
                        listItem.SubItems.Add(orderElement.Element("Details").Value);
                        listItem.SubItems.Add(orderElement.Element("Price").Value);
                        listItem.SubItems.Add(orderElement.Element("Quantity").Value);

                        lsvOutput.Items.Add(listItem);
                    }
                }
            }
        }


        private void LoadFoodItemFromFile() 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("FoodItemList.xml");
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


        private void AddItemToListViewAndLogFile(string itemName, string price, string quantity)
        {
            

            ListViewItem listItem = new ListViewItem();

            listItem.Text = (itemName);
            listItem.SubItems.Add(price);
            listItem.SubItems.Add(quantity);

            lsvOutput.Items.Insert(0, listItem);
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

        private void btn1Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "1";
        }

        private void btn2Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "2";
        }

        private void btn3Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "3";
        }

        private void btn4Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "4";
        }

        private void btn5Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "5";
        }

        private void btn6Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "6";
        }

        private void btn7Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "7";
        }

        private void btn8Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "8";
        }

        private void btn9Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "9";
        }

        private void btn0Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            numbervalue = "";
        }

        private void StaffMainScreen_Load(object sender, EventArgs e)
        {
            LoadOrdersFromFile();
        }

        private void btn00Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue + "00";
        }

        private void btnDecimalpointNumberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[3].Text = numbervalue + ".";
        }

        private void btnDeleteNumerpad_Click(object sender, EventArgs e)
        {
            DeleteLatestInputFromLogFile();
            lsvOutput.Items.RemoveAt(0);
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
            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\duttp\\source\\repos\\Visual-Studio-projects-\\Task 6\\OrderHub (SAT TASK)\\OrderHub (SAT TASK)\\bin\\Debug\\net8.0-windows\\FoodItemList.xml");

            // Navigate to the Price element under CheeseBurger
            XmlNode priceNode = xmlDoc.SelectSingleNode("/FoodItems/Item/CheeseBurger/Price");

            // Check if the node was found
            if (priceNode != null)
            {
                // Display the price in a message box
                MessageBox.Show("The price of the Cheese Burger is " + priceNode.InnerText);
            }


            //AddItemToListViewAndLogFile("Cheese Burger", "$5", "1");
        }

        private void btnDoubleCheeseBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Double Cheese Burger", "$15", "1");
        }

        private void btnThreeCheeseBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Three Cheese Burger", "$18", "1");
        }

        private void EightCheeseBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Eight Cheese Burger", "$20", "1");
        }

        private void btnAngusBeefBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Angus Beef Burger", "$10", "1");
        }

        private void btnHamBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Ham Burger", "$8", "1");
        }

        private void btnMushroomBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Mushroom Burger", "$7", "1");
        }

        private void btnBaconCheeseBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Bacon Cheese Burger", "$10", "1");
        }

        private void btnTurkeyBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Turkey Burger", "$12", "1");
        }

        private void btnChickenBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Chicken Burger", "$13", "1");
        }

        private void btnChiliBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Chili Burger", "$5", "1");
        }

        private void btnLambBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Lamb Burger", "$7", "1");
        }

        private void btnBBQBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("BBQ Burger", "$5", "1");
        }

        private void btnElkBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Elk Burger", "$13", "1");
        }

        private void btnOnionBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Onion Burger", "$9", "1");
        }

        private void btnSalmonBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Salmon Burger", "$10", "1");
        }

        private void btnPizzaBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Pizza Burger", "$12", "1");
        }

        private void btnTeriyakiBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Teriyaki Burger", "$18", "1");
        }

        private void btnBlackbeanBurger_Click(object sender, EventArgs e)
        {
            AddItemToListViewAndLogFile("Black Bean Burger", "$5", "1");
        }

        private void btn5DollarNote_Click(object sender, EventArgs e)
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
            AddItemToListViewAndLogFile("Wagu Burger", "$50", "1");
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

            // Create a new instance of EditDelete form.
            MemberLogin memberlogin = new MemberLogin();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            memberlogin.Closed += (s, args) => this.Close();

            // Display MemberLogin.
            memberlogin.Show();
        }
    }
}
