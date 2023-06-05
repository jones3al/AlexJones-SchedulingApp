namespace AlexJones_SchedulingApp.Screens
{
    partial class Dashboard
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
            this.DashboardTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DashboardTitle
            // 
            this.DashboardTitle.AutoSize = true;
            this.DashboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardTitle.Location = new System.Drawing.Point(392, 28);
            this.DashboardTitle.Name = "DashboardTitle";
            this.DashboardTitle.Size = new System.Drawing.Size(271, 58);
            this.DashboardTitle.TabIndex = 0;
            this.DashboardTitle.Text = "Dashboard";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 624);
            this.Controls.Add(this.DashboardTitle);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DashboardTitle;
    }
}