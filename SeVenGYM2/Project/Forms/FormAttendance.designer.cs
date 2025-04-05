
namespace SevenGym.Project.Forms
{
    partial class FormAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAttendance));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.dgvMarkAttendance = new System.Windows.Forms.DataGridView();
            this.dtAttendance = new System.Windows.Forms.DateTimePicker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Attendance Form:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(145, 132);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(671, 27);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // dgvMarkAttendance
            // 
            this.dgvMarkAttendance.AllowUserToAddRows = false;
            this.dgvMarkAttendance.AllowUserToDeleteRows = false;
            this.dgvMarkAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarkAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvMarkAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Mark});
            this.dgvMarkAttendance.Location = new System.Drawing.Point(33, 181);
            this.dgvMarkAttendance.Name = "dgvMarkAttendance";
            this.dgvMarkAttendance.RowHeadersWidth = 51;
            this.dgvMarkAttendance.RowTemplate.Height = 24;
            this.dgvMarkAttendance.Size = new System.Drawing.Size(879, 124);
            this.dgvMarkAttendance.TabIndex = 2;
            this.dgvMarkAttendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarkAttendance_CellContentClick);
            // 
            // dtAttendance
            // 
            this.dtAttendance.Location = new System.Drawing.Point(198, 70);
            this.dtAttendance.Name = "dtAttendance";
            this.dtAttendance.Size = new System.Drawing.Size(573, 27);
            this.dtAttendance.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "C_Name";
            this.Column1.HeaderText = "Client Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EndDate";
            this.Column2.HeaderText = "End Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.DataPropertyName = "Count_Attend";
            this.Column3.HeaderText = "Attend";
            this.Column3.Name = "Column3";
            this.Column3.Width = 93;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Notes";
            this.Column4.HeaderText = "Notes";
            this.Column4.Name = "Column4";
            // 
            // Mark
            // 
            this.Mark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Mark.HeaderText = "Mark";
            this.Mark.MinimumWidth = 6;
            this.Mark.Name = "Mark";
            this.Mark.Width = 55;
            // 
            // FormAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 334);
            this.Controls.Add(this.dtAttendance);
            this.Controls.Add(this.dgvMarkAttendance);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark Attendance";
            this.Load += new System.EventHandler(this.FormAttendance_Load);
            this.Shown += new System.EventHandler(this.FormAttendance_Shown);
            this.Enter += new System.EventHandler(this.FormAttendance_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView dgvMarkAttendance;
        private System.Windows.Forms.DateTimePicker dtAttendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mark;
    }
}