using OrderHub__SAT_Task_.Manager;
using OrderHub__SAT_Task_.Staff;
using System.Xml.Linq;

namespace OrderHub__SAT_Task_
{
    public partial class LoginMain : Form
    {
        private string logFilePath = "Login.txt";
        public LoginMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\users.xml");

            // Query for regular user
            var regularUserQuery = from x in doc.Descendants("users")
                                   where (string)x.Element("username") == txtUsername.Text
                                   select new
                                   {
                                       Username = (string)x.Element("username"),
                                       Password = (string)x.Element("pwd")
                                   };

            // Query for chef user
            var chefUserQuery = from x in doc.Descendants("users")
                                where (string)x.Element("Chefuser") == txtUsername.Text
                                select new
                                {
                                    Username = (string)x.Element("Chefuser"),
                                    Password = (string)x.Element("ChefPwd")
                                };

            var AdminUserQuery = from x in doc.Descendants("users")
                                where (string)x.Element("adminuser") == txtUsername.Text
                                select new
                                {
                                    Username = (string)x.Element("adminuser"),
                                    Password = (string)x.Element("adminpwd")
                                };

            // Get the matched regular user
            var matchedRegularUser = regularUserQuery.FirstOrDefault();

            // Get the matched chef user
            var matchedChefUser = chefUserQuery.FirstOrDefault();

            // Get the matched chef user
            var matchedAdminUser = AdminUserQuery.FirstOrDefault();


            string user = txtUsername.Text;
            string password = txtPassword.Text;

            // Check regular user credentials
            if (matchedRegularUser != null && user == matchedRegularUser.Username && password == matchedRegularUser.Password)
            {
                // Hide the current form
                this.Hide();

                // Create a new instance of StaffMainScreen form
                StaffMainScreen StaffMainScreen = new StaffMainScreen();

                // Subscribe to the Closed event of form2 to close the current form when form2 is closed
                StaffMainScreen.Closed += (s, args) => this.Close();

                // Display form2
                StaffMainScreen.Show();
            }

            // Check chef user credentials
            else if (matchedChefUser != null && user == matchedChefUser.Username && password == matchedChefUser.Password)
            {
                // Hide the current form
                this.Hide();

                // Create a new instance of ChefMainScreen form
                ChefMainScreen ChefMainScreen = new ChefMainScreen();

                // Subscribe to the Closed event of form2 to close the current form when form2 is closed
                ChefMainScreen.Closed += (s, args) => this.Close();

                // Display form2
                ChefMainScreen.Show(); 
            }

            else if (matchedAdminUser != null && user == matchedAdminUser.Username && password == matchedAdminUser.Password)
            {
                // Hide the current form
                this.Hide();

                // Create a new instance of ChefMainScreen form
                ChangepricingMain ChangepricingMain = new ChangepricingMain();

                // Subscribe to the Closed event of form2 to close the current form when form2 is closed
                ChangepricingMain.Closed += (s, args) => this.Close();

                // Display form2
                ChangepricingMain.Show();

            }
            // If neither credentials match, show an error message
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
    }
}
