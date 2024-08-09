using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OrderHub__SAT_Task_.Staff
{
    public partial class ChefMainScreen : Form
    {
        public ChefMainScreen()
        {
            InitializeComponent();
        }
        public const string ORDERS = "PastOrders.xml";
        private string ID = "ID.txt";

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
            lsvOutput.Items.Clear();
            // Check if any item in lsvOrderlist ListView is selected.
            if (lsvOrderList.SelectedItems.Count > 0)
            {
                string ID = "", Details = "", Quantity = "";  // Initialize variables to store data.

                // Read data from "Students.xml" using XmlReader.
                using (XmlReader reader = XmlReader.Create("orders.xml"))
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
                                case "ID":
                                    // Read and store the FirstName element value.
                                    ID = reader.ReadString();
                                    break;
                                case "Details":
                                    // Read and store the LastName element value.
                                    Details = reader.ReadString();
                                    break;
                                case "Quantity":
                                    // Read and store the Email element value.
                                    Quantity = reader.ReadString();



                                    // Once all fields are read, create a ListViewItem and add it to lvwStudents.
                                    ListViewItem listItem = new ListViewItem();   // Represents a row in the ListView.
                                    listItem.Text = ID;                            // Set the first column (FirstName).
                                    listItem.SubItems.Add(Details);                     // Add subsequent columns (LastName, Email, PhoneNumber, Payment).
                                    listItem.SubItems.Add(Quantity);


                                    // Check if all fields have values before adding to the ListView.
                                    if (ID != "" && Details != "" && Quantity != "" & ID == lsvOrderList.SelectedItems[0].Text)
                                    {
                                        lsvOutput.Items.Add(listItem);          // Add the ListViewItem to the ListView.
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ChefMainScreen_Load(object sender, EventArgs e)
        {
            LoadOrderList();
            
        }

        private void LoadOrderList()
        {
            lsvOrderList.Items.Clear();
            string ID = "";
            using (XmlReader reader = XmlReader.Create("orders.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "ID":
                                ID = reader.ReadString();
                                ListViewItem listItem = new ListViewItem
                                {
                                    Text = ID
                                };
                                lsvOrderList.Items.Add(listItem);
                                break;
                        }
                    }
                }
            }
        }

        private void lsvOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOrderList.SelectedItems.Count > 0)
            {
                string selectedID = lsvOrderList.SelectedItems[0].Text;
                LoadOrderDetails(selectedID);
            }
        }

        private void LoadOrderDetails(string orderID)
        {
            // Clear the second ListView before loading new data
            lsvOutput.Items.Clear();

            // Load order details based on the selected ID
            if (File.Exists(StaffMainScreen.ORDERS))
            {
                XElement ordersXml = XElement.Load(StaffMainScreen.ORDERS);

                // Iterate through each FullOrder element
                foreach (XElement fullOrder in ordersXml.Elements("FullOrder"))
                {
                    // Iterate through each Order element within the FullOrder
                    foreach (XElement orderElement in fullOrder.Elements("Order"))
                    {
                        ListViewItem listItem = new ListViewItem(fullOrder.Element("ID").Value);
                        listItem.SubItems.Add(orderElement.Element("Details").Value);
                        listItem.SubItems.Add(orderElement.Element("Item").Value);
                        listItem.SubItems.Add(orderElement.Element("Quantity").Value);

                        lsvOutput.Items.Add(listItem);

                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveOrdersToXml();

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lsvOrderList.SelectedItems.Count > 0)
            {
                //Selects value to be deleted 
                string del = lsvOrderList.SelectedItems[0].Text;
                if (del == "")
                {
                    MessageBox.Show("Please select a Order first");
                }
                var xml = File.ReadAllText("orders.xml");
                XDocument doc = XDocument.Parse(xml);

                //Remove xml element that matches the selected firstName field
                doc.Descendants().Elements("FullOrder").Where(x => x.Element("ID")?.Value == del).Remove();

                var result = doc.ToString();
                MessageBox.Show("Order Rejected");
                doc.Save("orders.xml");

                LoadOrderList();
            }
        }
    }
}
