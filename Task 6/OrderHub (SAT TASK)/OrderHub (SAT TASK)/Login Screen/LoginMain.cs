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

            // Get the matched regular user
            var matchedRegularUser = regularUserQuery.FirstOrDefault();

            // Get the matched chef user
            var matchedChefUser = chefUserQuery.FirstOrDefault();

            string user = txtUsername.Text;
            string password = txtPassword.Text;

            // Check regular user credentials
            if (matchedRegularUser != null && user == matchedRegularUser.Username && password == matchedRegularUser.Password)
            {
                // Hide the current form
                this.Hide();

                // Create a new instance of StaffMainScreen form
                StaffMainScreen form2 = new StaffMainScreen();

                // Subscribe to the Closed event of form2 to close the current form when form2 is closed
                form2.Closed += (s, args) => this.Close();

                // Display form2
                form2.Show();
            }
            // Check chef user credentials
            else if (matchedChefUser != null && user == matchedChefUser.Username && password == matchedChefUser.Password)
            {
                // Hide the current form
                this.Hide();

                // Create a new instance of StaffMainScreen form
                StaffMainScreen form2 = new StaffMainScreen();

                // Subscribe to the Closed event of form2 to close the current form when form2 is closed
                form2.Closed += (s, args) => this.Close();

                // Display form2
                form2.Show();
            }
            // If neither credentials match, show an error message
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }




    }
}
