using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderHub__SAT_Task_.Manager
{
    public partial class ManagerMainscreen : Form
    {
        public ManagerMainscreen()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create a new instance of EditDelete form.
            ChangePriceMains ChangePriceMains = new ChangePriceMains();

            // Subscribe to the Closed event of form2 to close the current form when form2 is closed.
            ChangePriceMains.Closed += (s, args) => this.Close();

            // Display form2.
            ChangePriceMains.Show();
        }
    }
}
