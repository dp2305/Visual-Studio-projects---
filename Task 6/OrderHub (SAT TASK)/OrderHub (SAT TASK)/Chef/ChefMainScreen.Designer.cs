namespace OrderHub__SAT_Task_.Staff
{
    partial class ChefMainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lsvOutput = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnLoad = new Button();
            btnConfirm = new Button();
            btnReject = new Button();
            btnLogout = new Button();
            txtOrderNumber = new TextBox();
            lsvOrderList = new ListView();
            columnHeader3 = new ColumnHeader();
            SuspendLayout();
            // 
            // lsvOutput
            // 
            lsvOutput.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader1, columnHeader4 });
            lsvOutput.Location = new Point(-1, 1);
            lsvOutput.Margin = new Padding(2, 2, 2, 2);
            lsvOutput.Name = "lsvOutput";
            lsvOutput.Size = new Size(621, 367);
            lsvOutput.TabIndex = 0;
            lsvOutput.UseCompatibleStateImageBehavior = false;
            lsvOutput.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Order ID";
            columnHeader2.Width = 350;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Item";
            columnHeader1.Width = 350;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Quantity";
            columnHeader4.Width = 180;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(-1, 364);
            btnLoad.Margin = new Padding(2, 2, 2, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(214, 89);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(209, 364);
            btnConfirm.Margin = new Padding(2, 2, 2, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(210, 89);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(417, 364);
            btnReject.Margin = new Padding(2, 2, 2, 2);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(201, 89);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(615, 407);
            btnLogout.Margin = new Padding(2, 2, 2, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(188, 46);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new Point(615, 1);
            txtOrderNumber.Margin = new Padding(2, 2, 2, 2);
            txtOrderNumber.Multiline = true;
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new Size(189, 52);
            txtOrderNumber.TabIndex = 5;
            txtOrderNumber.Text = "Nunber of Orders:";
            // 
            // lsvOrderList
            // 
            lsvOrderList.Columns.AddRange(new ColumnHeader[] { columnHeader3 });
            lsvOrderList.Font = new Font("Segoe UI", 30F);
            lsvOrderList.Location = new Point(615, 44);
            lsvOrderList.Margin = new Padding(2, 2, 2, 2);
            lsvOrderList.Name = "lsvOrderList";
            lsvOrderList.Size = new Size(189, 366);
            lsvOrderList.TabIndex = 6;
            lsvOrderList.UseCompatibleStateImageBehavior = false;
            lsvOrderList.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "ID";
            columnHeader3.Width = 250;
            // 
            // ChefMainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(190, 138, 98);
            ClientSize = new Size(800, 450);
            Controls.Add(lsvOrderList);
            Controls.Add(txtOrderNumber);
            Controls.Add(btnLogout);
            Controls.Add(btnReject);
            Controls.Add(btnConfirm);
            Controls.Add(btnLoad);
            Controls.Add(lsvOutput);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ChefMainScreen";
            Text = "Form1";
            Load += ChefMainScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lsvOutput;
        private Button btnLoad;
        private Button btnConfirm;
        private Button btnReject;
        private Button btnLogout;
        private TextBox txtOrderNumber;
        private ListView lsvOrderList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}