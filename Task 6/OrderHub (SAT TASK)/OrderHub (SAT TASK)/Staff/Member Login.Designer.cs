﻿namespace OrderHub__SAT_Task_.Staff
{
    partial class MemberLogin
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
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            btnMemberLogOut = new Button();
            btnLoginMember = new Button();
            lsvOutput1 = new ListView();
            columnHeader3 = new ColumnHeader();
            btnSignOut = new Button();
            btnMemberLogin = new Button();
            btnBlank = new Button();
            btnChristmas = new Button();
            btnSummerTime = new Button();
            btnEaster = new Button();
            button5 = new Button();
            btnHot = new Button();
            btnCold = new Button();
            btnSides = new Button();
            btnDessert = new Button();
            btnMain = new Button();
            txtMemberSigninOutput = new TextBox();
            SuspendLayout();
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Member Number";
            columnHeader2.Width = 300;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Member Name";
            columnHeader1.Width = 300;
            // 
            // btnMemberLogOut
            // 
            btnMemberLogOut.Location = new Point(440, 395);
            btnMemberLogOut.Margin = new Padding(2, 2, 2, 2);
            btnMemberLogOut.Name = "btnMemberLogOut";
            btnMemberLogOut.Size = new Size(360, 58);
            btnMemberLogOut.TabIndex = 93;
            btnMemberLogOut.Text = "Signout member ";
            btnMemberLogOut.UseVisualStyleBackColor = true;
            btnMemberLogOut.Click += btnMemberLogOut_Click;
            // 
            // btnLoginMember
            // 
            btnLoginMember.Location = new Point(96, 395);
            btnLoginMember.Margin = new Padding(2, 2, 2, 2);
            btnLoginMember.Name = "btnLoginMember";
            btnLoginMember.Size = new Size(346, 58);
            btnLoginMember.TabIndex = 92;
            btnLoginMember.Text = "Sign in Member";
            btnLoginMember.UseVisualStyleBackColor = true;
            btnLoginMember.Click += btnLoginMember_Click;
            // 
            // lsvOutput1
            // 
            lsvOutput1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader1, columnHeader3 });
            lsvOutput1.Location = new Point(96, 50);
            lsvOutput1.Margin = new Padding(2, 2, 2, 2);
            lsvOutput1.Name = "lsvOutput1";
            lsvOutput1.Size = new Size(706, 350);
            lsvOutput1.TabIndex = 91;
            lsvOutput1.UseCompatibleStateImageBehavior = false;
            lsvOutput1.View = View.Details;
            lsvOutput1.SelectedIndexChanged += lsvOutput1_SelectedIndexChanged;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Member Age";
            columnHeader3.Width = 90;
            // 
            // btnSignOut
            // 
            btnSignOut.Font = new Font("Segoe UI", 12F);
            btnSignOut.Location = new Point(217, -2);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(124, 55);
            btnSignOut.TabIndex = 109;
            btnSignOut.Text = " Sign Out";
            btnSignOut.UseVisualStyleBackColor = true;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnMemberLogin
            // 
            btnMemberLogin.BackColor = Color.SkyBlue;
            btnMemberLogin.Font = new Font("Segoe UI", 12F);
            btnMemberLogin.ForeColor = Color.White;
            btnMemberLogin.Location = new Point(96, -2);
            btnMemberLogin.Name = "btnMemberLogin";
            btnMemberLogin.Size = new Size(124, 55);
            btnMemberLogin.TabIndex = 108;
            btnMemberLogin.Text = "Member Login";
            btnMemberLogin.UseVisualStyleBackColor = false;
            // 
            // btnBlank
            // 
            btnBlank.ForeColor = Color.FromArgb(190, 138, 98);
            btnBlank.Location = new Point(0, -2);
            btnBlank.Name = "btnBlank";
            btnBlank.Size = new Size(99, 74);
            btnBlank.TabIndex = 107;
            btnBlank.UseVisualStyleBackColor = true;
            // 
            // btnChristmas
            // 
            btnChristmas.Font = new Font("Segoe UI", 12F);
            btnChristmas.Location = new Point(-3, 406);
            btnChristmas.Name = "btnChristmas";
            btnChristmas.Size = new Size(103, 49);
            btnChristmas.TabIndex = 118;
            btnChristmas.Text = "Christmas";
            btnChristmas.UseVisualStyleBackColor = true;
            // 
            // btnSummerTime
            // 
            btnSummerTime.Font = new Font("Segoe UI", 12F);
            btnSummerTime.Location = new Point(-1, 364);
            btnSummerTime.Name = "btnSummerTime";
            btnSummerTime.Size = new Size(100, 46);
            btnSummerTime.TabIndex = 117;
            btnSummerTime.Text = "Summer Time";
            btnSummerTime.UseVisualStyleBackColor = true;
            // 
            // btnEaster
            // 
            btnEaster.Font = new Font("Segoe UI", 12F);
            btnEaster.Location = new Point(0, 320);
            btnEaster.Name = "btnEaster";
            btnEaster.Size = new Size(98, 46);
            btnEaster.TabIndex = 116;
            btnEaster.Text = "Easter";
            btnEaster.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(-3, 277);
            button5.Name = "button5";
            button5.Size = new Size(101, 46);
            button5.TabIndex = 115;
            button5.Text = "Special";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnHot
            // 
            btnHot.Font = new Font("Segoe UI", 12F);
            btnHot.Location = new Point(-2, 235);
            btnHot.Name = "btnHot";
            btnHot.Size = new Size(100, 46);
            btnHot.TabIndex = 114;
            btnHot.Text = "Hot";
            btnHot.UseVisualStyleBackColor = true;
            // 
            // btnCold
            // 
            btnCold.Font = new Font("Segoe UI", 12F);
            btnCold.Location = new Point(-2, 193);
            btnCold.Name = "btnCold";
            btnCold.Size = new Size(101, 46);
            btnCold.TabIndex = 113;
            btnCold.Text = "Cold";
            btnCold.UseVisualStyleBackColor = true;
            // 
            // btnSides
            // 
            btnSides.Font = new Font("Segoe UI", 12F);
            btnSides.Location = new Point(-1, 151);
            btnSides.Name = "btnSides";
            btnSides.Size = new Size(100, 46);
            btnSides.TabIndex = 112;
            btnSides.Text = "Sides";
            btnSides.UseVisualStyleBackColor = true;
            // 
            // btnDessert
            // 
            btnDessert.Font = new Font("Segoe UI", 12F);
            btnDessert.Location = new Point(0, 109);
            btnDessert.Name = "btnDessert";
            btnDessert.Size = new Size(100, 44);
            btnDessert.TabIndex = 111;
            btnDessert.Text = "Dessert";
            btnDessert.UseVisualStyleBackColor = true;
            // 
            // btnMain
            // 
            btnMain.BackColor = Color.White;
            btnMain.Font = new Font("Segoe UI", 12F);
            btnMain.ForeColor = Color.Black;
            btnMain.Location = new Point(0, 68);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(99, 44);
            btnMain.TabIndex = 110;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = false;
            btnMain.Click += btnMain_Click;
            // 
            // txtMemberSigninOutput
            // 
            txtMemberSigninOutput.Font = new Font("Microsoft Sans Serif", 24F);
            txtMemberSigninOutput.Location = new Point(354, -2);
            txtMemberSigninOutput.Margin = new Padding(2, 2, 2, 2);
            txtMemberSigninOutput.Multiline = true;
            txtMemberSigninOutput.Name = "txtMemberSigninOutput";
            txtMemberSigninOutput.Size = new Size(330, 50);
            txtMemberSigninOutput.TabIndex = 119;
            // 
            // MemberLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(190, 138, 98);
            ClientSize = new Size(800, 450);
            Controls.Add(txtMemberSigninOutput);
            Controls.Add(lsvOutput1);
            Controls.Add(btnChristmas);
            Controls.Add(btnSummerTime);
            Controls.Add(btnEaster);
            Controls.Add(button5);
            Controls.Add(btnHot);
            Controls.Add(btnCold);
            Controls.Add(btnSides);
            Controls.Add(btnDessert);
            Controls.Add(btnMain);
            Controls.Add(btnSignOut);
            Controls.Add(btnMemberLogin);
            Controls.Add(btnBlank);
            Controls.Add(btnMemberLogOut);
            Controls.Add(btnLoginMember);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MemberLogin";
            Text = "Member Login";
            Load += MemberLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private Button btnMemberLogOut;
        private Button btnLoginMember;
        private ListView lsvOutput1;
        private Button btnSignOut;
        private Button btnMemberLogin;
        private Button btnBlank;
        private Button btnChristmas;
        private Button btnSummerTime;
        private Button btnEaster;
        private Button button5;
        private Button btnHot;
        private Button btnCold;
        private Button btnSides;
        private Button btnDessert;
        private Button btnMain;
        private ColumnHeader columnHeader3;
        private TextBox txtMemberSigninOutput;
    }
}