namespace Assignment4
{
    partial class frmForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForgetPassword));
            this.txtNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConirm = new System.Windows.Forms.Button();
            this.txtReEnterPass = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnterPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(238, 99);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(121, 26);
            this.txtNewPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter New Password:";
            // 
            // btnConirm
            // 
            this.btnConirm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConirm.Location = new System.Drawing.Point(151, 205);
            this.btnConirm.Name = "btnConirm";
            this.btnConirm.Size = new System.Drawing.Size(140, 40);
            this.btnConirm.TabIndex = 4;
            this.btnConirm.Text = "Confirm";
            this.btnConirm.UseVisualStyleBackColor = false;
            this.btnConirm.Click += new System.EventHandler(this.btnConirm_Click);
            // 
            // txtReEnterPass
            // 
            this.txtReEnterPass.Location = new System.Drawing.Point(238, 136);
            this.txtReEnterPass.Name = "txtReEnterPass";
            this.txtReEnterPass.Size = new System.Drawing.Size(121, 26);
            this.txtReEnterPass.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Re Enter New Password:";
            // 
            // lblEnterPassword
            // 
            this.lblEnterPassword.AutoSize = true;
            this.lblEnterPassword.Location = new System.Drawing.Point(113, 27);
            this.lblEnterPassword.Name = "lblEnterPassword";
            this.lblEnterPassword.Size = new System.Drawing.Size(195, 20);
            this.lblEnterPassword.TabIndex = 7;
            this.lblEnterPassword.Text = "Enter the Password Below";
            // 
            // frmForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 299);
            this.Controls.Add(this.lblEnterPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReEnterPass);
            this.Controls.Add(this.btnConirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPassword);
            this.Name = "frmForgetPassword";
            this.Text = "Reset Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox txtNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConirm;
        private System.Windows.Forms.MaskedTextBox txtReEnterPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnterPassword;
    }
}