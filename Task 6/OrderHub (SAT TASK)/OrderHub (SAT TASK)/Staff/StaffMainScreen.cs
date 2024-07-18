using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace OrderHub__SAT_Task_
{
    public partial class StaffMainScreen : Form
    {
        private string logFilePath = "ID.txt";
        public string numbervalue = "";

        public StaffMainScreen()
        {
            InitializeComponent();
        }

        public static int selected_ID = 0;

        private List<string> orders = new List<string>();

        private const string ordersFileName = "orders.txt";

        private const string xmlFileName = "orders.xml";


        private void DeleteLatestInputFromLogFile()
        {
            // Read all lines from the log file
            string[] lines = File.ReadAllLines(logFilePath);

            // Check if there are any entries in the log
            if (lines.Length > 0)
            {
                // Remove the last entry
                Array.Resize(ref lines, lines.Length - 1);

                // Write the updated entries back to the log file
                File.WriteAllLines(logFilePath, lines);
            }
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
            if (string.IsNullOrWhiteSpace(xmlFileName))
            {
                MessageBox.Show("Invalid file path.");
                return;
            }

            // Create the root XML element named "Orders"
            XElement ordersXml = new XElement("Orders");

            // Iterate through each item in the ListView
            foreach (ListViewItem item in lsvOutput.Items)
            {
                XElement orderElement = new XElement("Order",
                    new XElement("ID", item.Text),
                    new XElement("Details", item.SubItems[1].Text),
                    new XElement("Price", item.SubItems[2].Text),
                    new XElement("Quantity", item.SubItems[3].Text)
                );
                ordersXml.Add(orderElement);
            }

            // Save the XML structure to the specified file
            ordersXml.Save(xmlFileName);

            MessageBox.Show("Orders saved to XML file.");
        }


        private void LoadOrdersFromFile()
        {
            if (File.Exists(ordersFileName))
            {
                // Read orders from text file
                string[] lines = File.ReadAllLines(ordersFileName);
                orders.AddRange(lines);

                // Populate ListView with orders
                foreach (string order in orders)
                {
                    lsvOutput.Items.Add(order);
                }
            }
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

        private void lsvOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = clhID.Text;
            string Quantity = clhQuantity.Text;
            string Details = clhOrderDetail.Text;
            string price = clhPrice.Text;
            if (lsvOutput.SelectedItems.Count > 0)
            {
                // Populate text boxes and combo box with data from the selected item in lvwStudents.
                id = lsvOutput.SelectedItems[0].Text;          // First column (FirstName).
                Quantity = lsvOutput.SelectedItems[0].SubItems[1].Text; // Second column (LastName).
                Details = lsvOutput.SelectedItems[0].SubItems[2].Text;    // Third column (Email).
                price = lsvOutput.SelectedItems[0].SubItems[3].Text; // Fourth column (PhoneNumber).
            }
        }

        private void btn1Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "1";
        }

        private void btn2Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "2";
        }

        private void btn3Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "3";
        }

        private void btn4Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "4";
        }

        private void btn5Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "5";
        }

        private void btn6Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "6";
        }

        private void btn7Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "7";
        }

        private void btn8Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "8";
        }

        private void btn9Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue = "9";
        }

        private void btn0Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue + "0";
        }

        private void btn00Numberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue + "00";
        }

        private void btnDecimalpointNumberpad_Click(object sender, EventArgs e)
        {
            lsvOutput.Items[0].SubItems[1].Text = numbervalue + ".";
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
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Cheese Burger");
            Item.SubItems.Add("$5");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnDoubleCheeseBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }

            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";

            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }

            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Double Cheese Burger");
            Item.SubItems.Add("$12");
            Item.SubItems.Add("1");
            lsvOutput.Items.Insert(0, Item);
        }

        private void btnThreeCheeseBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Three Cheese Burger");
            Item.SubItems.Add("$16");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void EightCheeseBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Eight Cheese Burger");
            Item.SubItems.Add("$18");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnAngusBeefBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Angus Beef Burger");
            Item.SubItems.Add("$15");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnHamBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Ham Burger");
            Item.SubItems.Add("$7");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnMushroomBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Mushroom Burger");
            Item.SubItems.Add("$5");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnBaconCheeseBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Bacon Cheese Burger");
            Item.SubItems.Add("$10");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnWaguBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Wagu Burger");
            Item.SubItems.Add("$50");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnTurkeyBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Turkey Burger");
            Item.SubItems.Add("$10");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnChickenBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Chicken Burger");
            Item.SubItems.Add("$8");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnChiliBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Chili Burger");
            Item.SubItems.Add("$5");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnLambBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Lamb Burger");
            Item.SubItems.Add("$7");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnBBQBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("BBQ Burger");
            Item.SubItems.Add("$5");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnElkBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Elk Burger");
            Item.SubItems.Add("$20");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnOnionBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Onion Burger");
            Item.SubItems.Add("$7");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnSalmonBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Salmon Burger");
            Item.SubItems.Add("$15");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnPizzaBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Pizza Burger");
            Item.SubItems.Add("$12");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnTeriyakiBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Teriyaki Burger");
            Item.SubItems.Add("$18");
            Item.SubItems.Add("1");

            lsvOutput.Items.Insert(0, Item);
        }

        private void btnBlackbeanBurger_Click(object sender, EventArgs e)
        {
            // Generate the ID
            int NewId = 1;
            if (File.Exists(logFilePath))
            {
                String[] Lines = File.ReadAllLines(logFilePath);

                // If there are existing records, calculate the new ID based on the last record
                if (Lines.Length > 0)
                {
                    string[] item = Lines[Lines.Length - 1].Split(",");
                    NewId = int.Parse(item[0]) + 1;
                }
            }


            // Construct the record
            string ID = NewId.ToString();
            string Record = $"{ID}";


            // Write the record to the log file
            using (TextWriter tw = new StreamWriter(logFilePath, true))
            {
                tw.WriteLine(Record);
            }


            ListViewItem Item = new ListViewItem();
            Item.Text = NewId.ToString();
            Item.SubItems.Add("Black Bean Burger");
            Item.SubItems.Add("$5");
            Item.SubItems.Add("1");


            lsvOutput.Items.Insert(0, Item);
        }

        private void btn5DollarNote_Click(object sender, EventArgs e)
        {
            if (lsvOutput.Items.Count > 0)
            {
                decimal totalCost = 0m;

                // Sum up the prices from all items
                foreach (ListViewItem item in lsvOutput.Items)
                {
                    string priceText = item.SubItems[2].Text; // Adjusted to correct the price column index if it's 2
                    if (decimal.TryParse(priceText.TrimStart('$'), out decimal price))
                    {
                        totalCost += price;
                    }
                    else
                    {
                        MessageBox.Show("Invalid price format in one or more items");
                        return;
                    }
                }

                decimal payment = 5.00m;
                if (totalCost <= payment)
                {
                    // Calculate change
                    decimal change = payment - totalCost;
                    txtChange.Text = $"Change: ${change:F2}";

                    // Show message if change is zero
                    if (change == 0)
                    {
                        MessageBox.Show("That is enough");
                    }

                    // Save orders from ListView to XML file
                    SaveOrdersToXml();
                    lsvOutput.Items.Clear();
                    txtChange.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("No items in the list");
            }
        }

        private void btn10DollarNote_Click(object sender, EventArgs e)
        {
            if (lsvOutput.Items.Count > 0)
            {
                decimal totalCost = 0m;

                // Sum up the prices from all items
                foreach (ListViewItem item in lsvOutput.Items)
                {
                    string priceText = item.SubItems[2].Text; // Adjusted to correct the price column index if it's 2
                    if (decimal.TryParse(priceText.TrimStart('$'), out decimal price))
                    {
                        totalCost += price;
                    }
                    else
                    {
                        MessageBox.Show("Invalid price format in one or more items");
                        return;
                    }
                }

                decimal payment = 10.00m;
                if (totalCost <= payment)
                {
                    // Calculate change
                    decimal change = payment - totalCost;
                    txtChange.Text = $"Change: ${change:F2}";

                    // Show message if change is zero
                    if (change == 0)
                    {
                        MessageBox.Show("That is enough");
                    }

                    // Save orders from ListView to XML file
                    SaveOrdersToXml();
                    lsvOutput.Items.Clear();
                    txtChange.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("No items in the list");
            }
        }

        private void btn20DollarNote_Click(object sender, EventArgs e)
        {
            if (lsvOutput.Items.Count > 0)
            {
                decimal totalCost = 0m;

                // Sum up the prices from all items
                foreach (ListViewItem item in lsvOutput.Items)
                {
                    string priceText = item.SubItems[2].Text; // Adjusted to correct the price column index if it's 2
                    if (decimal.TryParse(priceText.TrimStart('$'), out decimal price))
                    {
                        totalCost += price;
                    }
                    else
                    {
                        MessageBox.Show("Invalid price format in one or more items");
                        return;
                    }
                }

                decimal payment = 20.00m;
                if (totalCost <= payment)
                {
                    // Calculate change
                    decimal change = payment - totalCost;
                    txtChange.Text = $"Change: ${change:F2}";

                    // Show message if change is zero
                    if (change == 0)
                    {
                        MessageBox.Show("That is enough");
                    }

                    // Save orders from ListView to XML file
                    SaveOrdersToXml();
                    lsvOutput.Items.Clear();
                    txtChange.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("No items in the list");
            }
        }

        private void btn50DollarNote_Click(object sender, EventArgs e)
        {
            if (lsvOutput.Items.Count > 0)
            {
                decimal totalCost = 0m;

                // Sum up the prices from all items
                foreach (ListViewItem item in lsvOutput.Items)
                {
                    string priceText = item.SubItems[2].Text; // Adjusted to correct the price column index if it's 2
                    if (decimal.TryParse(priceText.TrimStart('$'), out decimal price))
                    {
                        totalCost += price;
                    }
                    else
                    {
                        MessageBox.Show("Invalid price format in one or more items");
                        return;
                    }
                }

                decimal payment = 50.00m;
                if (totalCost <= payment)
                {
                    // Calculate change
                    decimal change = payment - totalCost;
                    txtChange.Text = $"Change: ${change:F2}";

                    // Show message if change is zero
                    if (change == 0)
                    {
                        MessageBox.Show("That is enough");
                    }

                    // Save orders from ListView to XML file
                    SaveOrdersToXml();
                    lsvOutput.Items.Clear();
                    txtChange.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("No items in the list");
            }
        }
    }
}
