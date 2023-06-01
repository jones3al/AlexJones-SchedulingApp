namespace AlexJones_SchedulingApp
{
    partial class LoginForm
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
            this.Usernametextbox = new System.Windows.Forms.TextBox();
            this.Passwordtextbox = new System.Windows.Forms.TextBox();
            this.Loginbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Usernametextbox
            // 
            this.Usernametextbox.Location = new System.Drawing.Point(208, 147);
            this.Usernametextbox.Name = "Usernametextbox";
            this.Usernametextbox.Size = new System.Drawing.Size(347, 22);
            this.Usernametextbox.TabIndex = 0;
            this.Usernametextbox.Text = "username";
            // 
            // Passwordtextbox
            // 
            this.Passwordtextbox.Location = new System.Drawing.Point(208, 209);
            this.Passwordtextbox.Name = "Passwordtextbox";
            this.Passwordtextbox.Size = new System.Drawing.Size(347, 22);
            this.Passwordtextbox.TabIndex = 1;
            this.Passwordtextbox.Text = "Password";
            // 
            // Loginbutton
            // 
            this.Loginbutton.Location = new System.Drawing.Point(272, 281);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(208, 47);
            this.Loginbutton.TabIndex = 2;
            this.Loginbutton.Text = "Login";
            this.Loginbutton.UseVisualStyleBackColor = true;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.Passwordtextbox);
            this.Controls.Add(this.Usernametextbox);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Usernametextbox;
        private System.Windows.Forms.TextBox Passwordtextbox;
        private System.Windows.Forms.Button Loginbutton;
    }
}

