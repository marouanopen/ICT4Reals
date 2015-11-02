namespace UserInterface_Mockup_ICT4Reals
{
    partial class Login
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
            this.GBlogin = new System.Windows.Forms.GroupBox();
            this.btlogin = new System.Windows.Forms.Button();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.GBlogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBlogin
            // 
            this.GBlogin.Controls.Add(this.btlogin);
            this.GBlogin.Controls.Add(this.lblpassword);
            this.GBlogin.Controls.Add(this.lblusername);
            this.GBlogin.Controls.Add(this.tbpassword);
            this.GBlogin.Controls.Add(this.tbusername);
            this.GBlogin.Location = new System.Drawing.Point(12, 12);
            this.GBlogin.Name = "GBlogin";
            this.GBlogin.Size = new System.Drawing.Size(200, 100);
            this.GBlogin.TabIndex = 0;
            this.GBlogin.TabStop = false;
            this.GBlogin.Text = "Login";
            // 
            // btlogin
            // 
            this.btlogin.Location = new System.Drawing.Point(119, 73);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(75, 23);
            this.btlogin.TabIndex = 4;
            this.btlogin.Text = "Login";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(10, 50);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(55, 13);
            this.lblpassword.TabIndex = 3;
            this.lblpassword.Text = "password:";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(7, 20);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(58, 13);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "Username:";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(80, 47);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(114, 20);
            this.tbpassword.TabIndex = 1;
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(80, 20);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(114, 20);
            this.tbusername.TabIndex = 0;
            // 
            // Login
            // 
            this.AcceptButton = this.btlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 125);
            this.Controls.Add(this.GBlogin);
            this.Name = "Login";
            this.Text = "Login";
            this.GBlogin.ResumeLayout(false);
            this.GBlogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBlogin;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.TextBox tbusername;
    }
}