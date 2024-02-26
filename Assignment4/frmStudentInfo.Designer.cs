namespace Assignment4
{
    partial class frmStudentInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentInfo));
            this.chartMarks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtBigBox = new System.Windows.Forms.TextBox();
            this.btnChart = new System.Windows.Forms.Button();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblStudentMarkInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // chartMarks
            // 
            chartArea2.Name = "ChartMarks";
            this.chartMarks.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMarks.Legends.Add(legend2);
            this.chartMarks.Location = new System.Drawing.Point(333, 175);
            this.chartMarks.Name = "chartMarks";
            series2.ChartArea = "ChartMarks";
            series2.Legend = "Legend1";
            series2.Name = "Marks";
            this.chartMarks.Series.Add(series2);
            this.chartMarks.Size = new System.Drawing.Size(395, 302);
            this.chartMarks.TabIndex = 32;
            this.chartMarks.Text = "chart";
            // 
            // txtBigBox
            // 
            this.txtBigBox.Location = new System.Drawing.Point(12, 220);
            this.txtBigBox.Multiline = true;
            this.txtBigBox.Name = "txtBigBox";
            this.txtBigBox.Size = new System.Drawing.Size(150, 279);
            this.txtBigBox.TabIndex = 31;
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(228, 175);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(99, 37);
            this.btnChart.TabIndex = 30;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(14, 143);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(52, 20);
            this.lblDOB.TabIndex = 28;
            this.lblDOB.Text = "D.O.B";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(14, 97);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 27;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(14, 58);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblFirstName.TabIndex = 26;
            this.lblFirstName.Text = "First Name";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(14, 17);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(87, 20);
            this.lblStudentID.TabIndex = 25;
            this.lblStudentID.Text = "Student ID";
            // 
            // txtDOB
            // 
            this.txtDOB.Location = new System.Drawing.Point(116, 137);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(157, 26);
            this.txtDOB.TabIndex = 24;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(116, 94);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(157, 26);
            this.txtLastName.TabIndex = 23;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(116, 52);
            this.txtFirstName.Multiline = true;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(157, 26);
            this.txtFirstName.TabIndex = 22;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(116, 11);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(157, 26);
            this.txtStudentID.TabIndex = 21;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(235, 443);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 34);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblStudentMarkInfo
            // 
            this.lblStudentMarkInfo.AutoSize = true;
            this.lblStudentMarkInfo.Location = new System.Drawing.Point(15, 197);
            this.lblStudentMarkInfo.Name = "lblStudentMarkInfo";
            this.lblStudentMarkInfo.Size = new System.Drawing.Size(105, 20);
            this.lblStudentMarkInfo.TabIndex = 34;
            this.lblStudentMarkInfo.Text = "Student Mark";
            // 
            // frmStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.lblStudentMarkInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chartMarks);
            this.Controls.Add(this.txtBigBox);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.txtDOB);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtStudentID);
            this.Name = "frmStudentInfo";
            this.Text = "Student Info";
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarks;
        private System.Windows.Forms.TextBox txtBigBox;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblStudentMarkInfo;
    }
}