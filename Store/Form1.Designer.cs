namespace Store
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbnEmployee = new System.Windows.Forms.RadioButton();
            this.rbnCustomer = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbnEmployee);
            this.panel1.Controls.Add(this.rbnCustomer);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 102);
            this.panel1.TabIndex = 0;
            // 
            // rbnEmployee
            // 
            this.rbnEmployee.AutoSize = true;
            this.rbnEmployee.Location = new System.Drawing.Point(14, 64);
            this.rbnEmployee.Name = "rbnEmployee";
            this.rbnEmployee.Size = new System.Drawing.Size(78, 17);
            this.rbnEmployee.TabIndex = 1;
            this.rbnEmployee.TabStop = true;
            this.rbnEmployee.Text = "Сотрудник";
            this.rbnEmployee.UseVisualStyleBackColor = true;
            // 
            // rbnCustomer
            // 
            this.rbnCustomer.AutoSize = true;
            this.rbnCustomer.Checked = true;
            this.rbnCustomer.Location = new System.Drawing.Point(14, 20);
            this.rbnCustomer.Name = "rbnCustomer";
            this.rbnCustomer.Size = new System.Drawing.Size(85, 17);
            this.rbnCustomer.TabIndex = 0;
            this.rbnCustomer.TabStop = true;
            this.rbnCustomer.Text = "Покупатель";
            this.rbnCustomer.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(25, 127);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 52);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 191);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Идентификация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbnEmployee;
        private System.Windows.Forms.RadioButton rbnCustomer;
        private System.Windows.Forms.Button btnOk;
    }
}

