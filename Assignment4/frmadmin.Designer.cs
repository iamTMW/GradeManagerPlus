namespace Assignment4
{
    partial class frmadmin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmadmin));
            this.txtBigBox = new System.Windows.Forms.TextBox();
            this.cmbNames = new System.Windows.Forms.ComboBox();
            this.btnClearChart = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.chartMarks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblClassMark = new System.Windows.Forms.Label();
            this.lstAverage = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClassA = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.txtClassAv = new System.Windows.Forms.TextBox();
            this.lblSavethechangesyoumadehere = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBigBox
            // 
            this.txtBigBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtBigBox.Location = new System.Drawing.Point(98, 330);
            this.txtBigBox.Multiline = true;
            this.txtBigBox.Name = "txtBigBox";
            this.txtBigBox.Size = new System.Drawing.Size(155, 284);
            this.txtBigBox.TabIndex = 34;
            // 
            // cmbNames
            // 
            this.cmbNames.FormattingEnabled = true;
            this.cmbNames.Location = new System.Drawing.Point(473, 64);
            this.cmbNames.Name = "cmbNames";
            this.cmbNames.Size = new System.Drawing.Size(121, 28);
            this.cmbNames.TabIndex = 33;
            this.cmbNames.SelectedIndexChanged += new System.EventHandler(this.cmbNames_SelectedIndexChanged_1);
            // 
            // btnClearChart
            // 
            this.btnClearChart.Location = new System.Drawing.Point(781, 237);
            this.btnClearChart.Name = "btnClearChart";
            this.btnClearChart.Size = new System.Drawing.Size(99, 33);
            this.btnClearChart.TabIndex = 32;
            this.btnClearChart.Text = "Clear Chart";
            this.btnClearChart.UseVisualStyleBackColor = true;
            this.btnClearChart.Click += new System.EventHandler(this.btnClearChart_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(781, 182);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(99, 37);
            this.btnChart.TabIndex = 31;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(784, 120);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 34);
            this.btnNew.TabIndex = 29;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1002, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 34);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(897, 61);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 33);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(784, 62);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 34);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(28, 147);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(52, 20);
            this.lblDOB.TabIndex = 25;
            this.lblDOB.Text = "D.O.B";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(28, 101);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 24;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(28, 62);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblFirstName.TabIndex = 23;
            this.lblFirstName.Text = "First Name";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(28, 21);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(87, 20);
            this.lblStudentID.TabIndex = 22;
            this.lblStudentID.Text = "Student ID";
            // 
            // txtDOB
            // 
            this.txtDOB.Location = new System.Drawing.Point(145, 141);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(157, 26);
            this.txtDOB.TabIndex = 21;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(145, 98);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(157, 26);
            this.txtLastName.TabIndex = 20;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(145, 56);
            this.txtFirstName.Multiline = true;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(157, 26);
            this.txtFirstName.TabIndex = 19;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(145, 15);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(157, 26);
            this.txtStudentID.TabIndex = 18;
            // 
            // chartMarks
            // 
            this.chartMarks.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartMarks";
            this.chartMarks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMarks.Legends.Add(legend1);
            this.chartMarks.Location = new System.Drawing.Point(346, 182);
            this.chartMarks.Name = "chartMarks";
            series1.ChartArea = "ChartMarks";
            series1.Legend = "Legend1";
            series1.Name = "Marks";
            this.chartMarks.Series.Add(series1);
            this.chartMarks.Size = new System.Drawing.Size(409, 338);
            this.chartMarks.TabIndex = 35;
            this.chartMarks.Text = "chart";
            // 
            // lblClassMark
            // 
            this.lblClassMark.AutoSize = true;
            this.lblClassMark.Location = new System.Drawing.Point(859, 305);
            this.lblClassMark.Name = "lblClassMark";
            this.lblClassMark.Size = new System.Drawing.Size(150, 20);
            this.lblClassMark.TabIndex = 46;
            this.lblClassMark.Text = "Class Average Mark";
            // 
            // lstAverage
            // 
            this.lstAverage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lstAverage.FormattingEnabled = true;
            this.lstAverage.ItemHeight = 20;
            this.lstAverage.Location = new System.Drawing.Point(849, 330);
            this.lstAverage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstAverage.Name = "lstAverage";
            this.lstAverage.Size = new System.Drawing.Size(160, 284);
            this.lstAverage.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Student Mark";
            // 
            // lblClassA
            // 
            this.lblClassA.AutoSize = true;
            this.lblClassA.Location = new System.Drawing.Point(28, 221);
            this.lblClassA.Name = "lblClassA";
            this.lblClassA.Size = new System.Drawing.Size(111, 20);
            this.lblClassA.TabIndex = 50;
            this.lblClassA.Text = "Class Average";
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(28, 182);
            this.lblAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(68, 20);
            this.lblAverage.TabIndex = 48;
            this.lblAverage.Text = "Average";
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(147, 182);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(157, 26);
            this.txtAverage.TabIndex = 51;
            // 
            // txtClassAv
            // 
            this.txtClassAv.Location = new System.Drawing.Point(147, 218);
            this.txtClassAv.Name = "txtClassAv";
            this.txtClassAv.Size = new System.Drawing.Size(157, 26);
            this.txtClassAv.TabIndex = 52;
            // 
            // lblSavethechangesyoumadehere
            // 
            this.lblSavethechangesyoumadehere.AutoSize = true;
            this.lblSavethechangesyoumadehere.Location = new System.Drawing.Point(831, 97);
            this.lblSavethechangesyoumadehere.Name = "lblSavethechangesyoumadehere";
            this.lblSavethechangesyoumadehere.Size = new System.Drawing.Size(235, 20);
            this.lblSavethechangesyoumadehere.TabIndex = 54;
            this.lblSavethechangesyoumadehere.Text = "Save the current page changes ";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(490, 576);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 38);
            this.btnExit.TabIndex = 55;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1131, 643);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblSavethechangesyoumadehere);
            this.Controls.Add(this.txtClassAv);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.lblClassA);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClassMark);
            this.Controls.Add(this.lstAverage);
            this.Controls.Add(this.chartMarks);
            this.Controls.Add(this.txtBigBox);
            this.Controls.Add(this.cmbNames);
            this.Controls.Add(this.btnClearChart);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.txtDOB);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtStudentID);
            this.Name = "frmadmin";
            this.Text = "frmadmin";
            this.Load += new System.EventHandler(this.frmadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBigBox;
        private System.Windows.Forms.ComboBox cmbNames;
        private System.Windows.Forms.Button btnClearChart;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarks;
        private System.Windows.Forms.Label lblClassMark;
        private System.Windows.Forms.ListBox lstAverage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClassA;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.TextBox txtClassAv;
        private System.Windows.Forms.Label lblSavethechangesyoumadehere;
        private System.Windows.Forms.Button btnExit;
    }
}