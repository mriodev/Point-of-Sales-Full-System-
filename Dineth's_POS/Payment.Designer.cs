namespace Dineth_s_POS
{
    partial class Payment
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbPay = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.txtCheck);
            this.Panel2.Controls.Add(this.label19);
            this.Panel2.Controls.Add(this.cmbPay);
            this.Panel2.Controls.Add(this.label18);
            this.Panel2.Controls.Add(this.label16);
            this.Panel2.Controls.Add(this.txtSubTotal);
            this.Panel2.Controls.Add(this.Label14);
            this.Panel2.Location = new System.Drawing.Point(12, 74);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(358, 364);
            this.Panel2.TabIndex = 147;
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(165, 109);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.ReadOnly = true;
            this.txtCheck.Size = new System.Drawing.Size(145, 20);
            this.txtCheck.TabIndex = 162;
            this.txtCheck.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.Info;
            this.label19.Location = new System.Drawing.Point(1, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 21);
            this.label19.TabIndex = 161;
            this.label19.Text = "Check No";
            this.label19.Visible = false;
            // 
            // cmbPay
            // 
            this.cmbPay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPay.FormattingEnabled = true;
            this.cmbPay.Items.AddRange(new object[] {
            "Cash",
            "Check",
            "Bank Transfer"});
            this.cmbPay.Location = new System.Drawing.Point(165, 74);
            this.cmbPay.Name = "cmbPay";
            this.cmbPay.Size = new System.Drawing.Size(144, 21);
            this.cmbPay.TabIndex = 160;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Info;
            this.label18.Location = new System.Drawing.Point(5, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 21);
            this.label18.TabIndex = 159;
            this.label18.Text = "Pay by";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Iskoola Pota", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 24);
            this.label16.TabIndex = 158;
            this.label16.Text = "Payment Receive";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(165, 45);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(146, 20);
            this.txtSubTotal.TabIndex = 147;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.SystemColors.Info;
            this.Label14.Location = new System.Drawing.Point(2, 44);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(78, 21);
            this.Label14.TabIndex = 77;
            this.Label14.Text = "Sub Total";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 450);
            this.Controls.Add(this.Panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox txtCheck;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbPay;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtSubTotal;
        internal System.Windows.Forms.Label Label14;
    }
}