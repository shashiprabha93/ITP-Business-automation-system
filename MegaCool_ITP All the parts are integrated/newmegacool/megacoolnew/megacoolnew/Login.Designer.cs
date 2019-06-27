namespace megacoolnew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(13, 159);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(91, 20);
            this.username.TabIndex = 5;
            this.username.Text = "Username :";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(13, 221);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(86, 20);
            this.password.TabIndex = 6;
            this.password.Text = "Password :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 190);
            this.textBox1.MaximumSize = new System.Drawing.Size(245, 30);
            this.textBox1.MinimumSize = new System.Drawing.Size(245, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 254);
            this.textBox2.MaximumSize = new System.Drawing.Size(245, 30);
            this.textBox2.MinimumSize = new System.Drawing.Size(245, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(245, 20);
            this.textBox2.TabIndex = 8;
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(89, 291);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(75, 23);
            this.loginbtn.TabIndex = 9;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // minimize
            // 
            this.minimize.Image = ((System.Drawing.Image)(resources.GetObject("minimize.Image")));
            this.minimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.minimize.Location = new System.Drawing.Point(239, 0);
            this.minimize.MaximumSize = new System.Drawing.Size(28, 28);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(28, 28);
            this.minimize.TabIndex = 14;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            this.minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseDown);
            this.minimize.MouseLeave += new System.EventHandler(this.minimize_MouseLeave);
            this.minimize.MouseHover += new System.EventHandler(this.minimize_MouseHover);
            this.minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseUp);
            // 
            // close
            // 
            this.close.Image = global::megacoolnew.Properties.Resources.cl_nor;
            this.close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.close.Location = new System.Drawing.Point(267, 0);
            this.close.MaximumSize = new System.Drawing.Size(28, 28);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(28, 28);
            this.close.TabIndex = 15;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.close_MouseDown);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            this.close.MouseHover += new System.EventHandler(this.close_MouseHover);
            this.close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.close_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 28);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 397);
            this.ControlBox = false;
            this.Controls.Add(this.close);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 397);
            this.MinimumSize = new System.Drawing.Size(300, 397);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Panel panel1;

    }
}