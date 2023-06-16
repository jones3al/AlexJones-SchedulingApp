
namespace AlexJones_SchedulingApp
{
    partial class NewCustomerForm
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
            this.checkCustomerActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpCustomerDetails = new System.Windows.Forms.GroupBox();
            this.lblCustomerNameWarning = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerPhoneValue = new System.Windows.Forms.Label();
            this.btnNewAddress = new System.Windows.Forms.Button();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.lblCustomerAddressValue = new System.Windows.Forms.Label();
            this.cmbAddressId = new System.Windows.Forms.ComboBox();
            this.lblAddressId = new System.Windows.Forms.Label();
            this.tboxCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tboxCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.grpCustomerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkCustomerActive
            // 
            this.checkCustomerActive.AutoSize = true;
            this.checkCustomerActive.Location = new System.Drawing.Point(289, 27);
            this.checkCustomerActive.Margin = new System.Windows.Forms.Padding(4);
            this.checkCustomerActive.Name = "checkCustomerActive";
            this.checkCustomerActive.Size = new System.Drawing.Size(117, 20);
            this.checkCustomerActive.TabIndex = 7;
            this.checkCustomerActive.Text = "Active Account";
            this.checkCustomerActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 277);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 277);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpCustomerDetails
            // 
            this.grpCustomerDetails.Controls.Add(this.lblCustomerNameWarning);
            this.grpCustomerDetails.Controls.Add(this.lblCustomerPhone);
            this.grpCustomerDetails.Controls.Add(this.lblCustomerPhoneValue);
            this.grpCustomerDetails.Controls.Add(this.btnNewAddress);
            this.grpCustomerDetails.Controls.Add(this.lblCustomerAddress);
            this.grpCustomerDetails.Controls.Add(this.lblCustomerAddressValue);
            this.grpCustomerDetails.Controls.Add(this.cmbAddressId);
            this.grpCustomerDetails.Controls.Add(this.lblAddressId);
            this.grpCustomerDetails.Controls.Add(this.tboxCustomerName);
            this.grpCustomerDetails.Controls.Add(this.lblCustomerName);
            this.grpCustomerDetails.Location = new System.Drawing.Point(20, 59);
            this.grpCustomerDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpCustomerDetails.Name = "grpCustomerDetails";
            this.grpCustomerDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpCustomerDetails.Size = new System.Drawing.Size(401, 210);
            this.grpCustomerDetails.TabIndex = 2;
            this.grpCustomerDetails.TabStop = false;
            this.grpCustomerDetails.Text = "Details";
            // 
            // lblCustomerNameWarning
            // 
            this.lblCustomerNameWarning.AutoSize = true;
            this.lblCustomerNameWarning.ForeColor = System.Drawing.Color.Red;
            this.lblCustomerNameWarning.Location = new System.Drawing.Point(32, 20);
            this.lblCustomerNameWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerNameWarning.Name = "lblCustomerNameWarning";
            this.lblCustomerNameWarning.Size = new System.Drawing.Size(306, 16);
            this.lblCustomerNameWarning.TabIndex = 9;
            this.lblCustomerNameWarning.Text = "Customer Name cannot contain special characters";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(28, 174);
            this.lblCustomerPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(49, 16);
            this.lblCustomerPhone.TabIndex = 8;
            this.lblCustomerPhone.Text = "Phone:";
            // 
            // lblCustomerPhoneValue
            // 
            this.lblCustomerPhoneValue.AutoSize = true;
            this.lblCustomerPhoneValue.Location = new System.Drawing.Point(115, 174);
            this.lblCustomerPhoneValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPhoneValue.Name = "lblCustomerPhoneValue";
            this.lblCustomerPhoneValue.Size = new System.Drawing.Size(85, 16);
            this.lblCustomerPhoneValue.TabIndex = 7;
            this.lblCustomerPhoneValue.Text = "111-222-3333";
            // 
            // btnNewAddress
            // 
            this.btnNewAddress.Location = new System.Drawing.Point(253, 76);
            this.btnNewAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewAddress.Name = "btnNewAddress";
            this.btnNewAddress.Size = new System.Drawing.Size(105, 28);
            this.btnNewAddress.TabIndex = 6;
            this.btnNewAddress.Text = "New Address";
            this.btnNewAddress.UseVisualStyleBackColor = true;
            this.btnNewAddress.Click += new System.EventHandler(this.btnNewAddress_Click);
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(28, 116);
            this.lblCustomerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(61, 16);
            this.lblCustomerAddress.TabIndex = 5;
            this.lblCustomerAddress.Text = "Address:";
            // 
            // lblCustomerAddressValue
            // 
            this.lblCustomerAddressValue.AutoSize = true;
            this.lblCustomerAddressValue.Location = new System.Drawing.Point(115, 116);
            this.lblCustomerAddressValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerAddressValue.Name = "lblCustomerAddressValue";
            this.lblCustomerAddressValue.Size = new System.Drawing.Size(124, 48);
            this.lblCustomerAddressValue.TabIndex = 4;
            this.lblCustomerAddressValue.Text = "XXX Main St, Suite 1\r\nNew York, 11111\r\nUnited States";
            // 
            // cmbAddressId
            // 
            this.cmbAddressId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddressId.FormattingEnabled = true;
            this.cmbAddressId.Location = new System.Drawing.Point(119, 76);
            this.cmbAddressId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAddressId.Name = "cmbAddressId";
            this.cmbAddressId.Size = new System.Drawing.Size(80, 24);
            this.cmbAddressId.TabIndex = 3;
            // 
            // lblAddressId
            // 
            this.lblAddressId.AutoSize = true;
            this.lblAddressId.Location = new System.Drawing.Point(28, 80);
            this.lblAddressId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddressId.Name = "lblAddressId";
            this.lblAddressId.Size = new System.Drawing.Size(77, 16);
            this.lblAddressId.TabIndex = 2;
            this.lblAddressId.Text = "Address ID:";
            // 
            // tboxCustomerName
            // 
            this.tboxCustomerName.Location = new System.Drawing.Point(87, 44);
            this.tboxCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.tboxCustomerName.Name = "tboxCustomerName";
            this.tboxCustomerName.Size = new System.Drawing.Size(271, 22);
            this.tboxCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(28, 48);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(47, 16);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Name:";
            // 
            // tboxCustomerId
            // 
            this.tboxCustomerId.Location = new System.Drawing.Point(52, 25);
            this.tboxCustomerId.Margin = new System.Windows.Forms.Padding(4);
            this.tboxCustomerId.Name = "tboxCustomerId";
            this.tboxCustomerId.ReadOnly = true;
            this.tboxCustomerId.Size = new System.Drawing.Size(55, 22);
            this.tboxCustomerId.TabIndex = 1;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(16, 28);
            this.lblCustomerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(23, 16);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "ID:";
            // 
            // NewCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 318);
            this.Controls.Add(this.checkCustomerActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpCustomerDetails);
            this.Controls.Add(this.tboxCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewCustomerForm";
            this.Text = "New Customer";
            this.Load += new System.EventHandler(this.NewCustomerForm_Load);
            this.grpCustomerDetails.ResumeLayout(false);
            this.grpCustomerDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox tboxCustomerId;
        private System.Windows.Forms.GroupBox grpCustomerDetails;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Label lblCustomerAddressValue;
        private System.Windows.Forms.ComboBox cmbAddressId;
        private System.Windows.Forms.Label lblAddressId;
        private System.Windows.Forms.TextBox tboxCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.CheckBox checkCustomerActive;
        private System.Windows.Forms.Button btnNewAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCustomerPhoneValue;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerNameWarning;
    }
}