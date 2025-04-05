
namespace SevenGym.Project.UserControls
{
    partial class UserControlSumByDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSumByDay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtSumSessionsDay = new System.Windows.Forms.DateTimePicker();
            this.dgvSumMoneyDay = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumMoneyDay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Money OF Sessions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date:";
            // 
            // dtSumSessionsDay
            // 
            this.dtSumSessionsDay.Location = new System.Drawing.Point(527, 77);
            this.dtSumSessionsDay.Name = "dtSumSessionsDay";
            this.dtSumSessionsDay.Size = new System.Drawing.Size(376, 27);
            this.dtSumSessionsDay.TabIndex = 1;
            this.dtSumSessionsDay.ValueChanged += new System.EventHandler(this.dtSumSessionsDay_ValueChanged);
            // 
            // dgvSumMoneyDay
            // 
            this.dgvSumMoneyDay.AllowUserToAddRows = false;
            this.dgvSumMoneyDay.AllowUserToDeleteRows = false;
            this.dgvSumMoneyDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSumMoneyDay.BackgroundColor = System.Drawing.Color.White;
            this.dgvSumMoneyDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSumMoneyDay.Location = new System.Drawing.Point(66, 126);
            this.dgvSumMoneyDay.Name = "dgvSumMoneyDay";
            this.dgvSumMoneyDay.ReadOnly = true;
            this.dgvSumMoneyDay.RowHeadersWidth = 51;
            this.dgvSumMoneyDay.RowTemplate.Height = 24;
            this.dgvSumMoneyDay.Size = new System.Drawing.Size(1172, 441);
            this.dgvSumMoneyDay.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExport.BackgroundImage")));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(1193, 70);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(45, 45);
            this.btnExport.TabIndex = 2;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UserControlSumByDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvSumMoneyDay);
            this.Controls.Add(this.dtSumSessionsDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlSumByDay";
            this.Size = new System.Drawing.Size(1300, 594);
            this.Load += new System.EventHandler(this.UserControlSumByDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumMoneyDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtSumSessionsDay;
        private System.Windows.Forms.DataGridView dgvSumMoneyDay;
        private System.Windows.Forms.Button btnExport;
    }
}
