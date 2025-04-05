
namespace SevenGym.Project.UserControls
{
    partial class UserControlSession
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbSessionInfo = new System.Windows.Forms.GroupBox();
            this.cbSessionID = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtSessionDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddSession = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvAddSessions = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.gbSessionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Session:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Session Kind:";
            // 
            // gbSessionInfo
            // 
            this.gbSessionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbSessionInfo.Controls.Add(this.cbSessionID);
            this.gbSessionInfo.Controls.Add(this.btnReset);
            this.gbSessionInfo.Controls.Add(this.dtSessionDate);
            this.gbSessionInfo.Controls.Add(this.btnAddSession);
            this.gbSessionInfo.Controls.Add(this.txtPrice);
            this.gbSessionInfo.Controls.Add(this.label6);
            this.gbSessionInfo.Controls.Add(this.label2);
            this.gbSessionInfo.Controls.Add(this.label5);
            this.gbSessionInfo.Controls.Add(this.txtTel);
            this.gbSessionInfo.Controls.Add(this.txtName);
            this.gbSessionInfo.Controls.Add(this.label4);
            this.gbSessionInfo.Controls.Add(this.label3);
            this.gbSessionInfo.Location = new System.Drawing.Point(22, 93);
            this.gbSessionInfo.Name = "gbSessionInfo";
            this.gbSessionInfo.Size = new System.Drawing.Size(346, 473);
            this.gbSessionInfo.TabIndex = 0;
            this.gbSessionInfo.TabStop = false;
            this.gbSessionInfo.Text = "Enter Info";
            // 
            // cbSessionID
            // 
            this.cbSessionID.FormattingEnabled = true;
            this.cbSessionID.Items.AddRange(new object[] {
            "Gym",
            "Gym & Cardio",
            "Cardio",
            "Sauna",
            "Massage"});
            this.cbSessionID.Location = new System.Drawing.Point(35, 287);
            this.cbSessionID.Name = "cbSessionID";
            this.cbSessionID.Size = new System.Drawing.Size(288, 38);
            this.cbSessionID.TabIndex = 9;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(134, 431);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 29);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtSessionDate
            // 
            this.dtSessionDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSessionDate.Location = new System.Drawing.Point(35, 219);
            this.dtSessionDate.Name = "dtSessionDate";
            this.dtSessionDate.Size = new System.Drawing.Size(288, 33);
            this.dtSessionDate.TabIndex = 4;
            // 
            // btnAddSession
            // 
            this.btnAddSession.BackColor = System.Drawing.Color.White;
            this.btnAddSession.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSession.Location = new System.Drawing.Point(237, 431);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(88, 29);
            this.btnAddSession.TabIndex = 7;
            this.btnAddSession.Text = "Add";
            this.btnAddSession.UseVisualStyleBackColor = false;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(37, 379);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(288, 37);
            this.txtPrice.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Price:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(35, 137);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(288, 37);
            this.txtTel.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(35, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 37);
            this.txtName.TabIndex = 2;
            // 
            // dgvAddSessions
            // 
            this.dgvAddSessions.AllowUserToAddRows = false;
            this.dgvAddSessions.AllowUserToDeleteRows = false;
            this.dgvAddSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddSessions.BackgroundColor = System.Drawing.Color.White;
            this.dgvAddSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvAddSessions.Location = new System.Drawing.Point(388, 111);
            this.dgvAddSessions.Name = "dgvAddSessions";
            this.dgvAddSessions.ReadOnly = true;
            this.dgvAddSessions.RowHeadersWidth = 51;
            this.dgvAddSessions.RowTemplate.Height = 24;
            this.dgvAddSessions.Size = new System.Drawing.Size(888, 455);
            this.dgvAddSessions.TabIndex = 0;
            this.dgvAddSessions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddSessions_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "Session_ID";
            this.Column1.HeaderText = "Session";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 134;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Client_Name";
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Phone";
            this.Column3.HeaderText = "Phone";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "S_Date";
            this.Column4.HeaderText = "Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SessionKind";
            this.Column5.HeaderText = "Session Kind";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.DataPropertyName = "Price";
            this.Column6.HeaderText = "Price";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 108;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(607, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(690, 76);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(371, 37);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // UserControlSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvAddSessions);
            this.Controls.Add(this.gbSessionInfo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlSession";
            this.Size = new System.Drawing.Size(1300, 594);
            this.Load += new System.EventHandler(this.UserControlSession_Load);
            this.Enter += new System.EventHandler(this.UserControlSession_Enter);
            this.gbSessionInfo.ResumeLayout(false);
            this.gbSessionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbSessionInfo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtSessionDate;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvAddSessions;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox cbSessionID;
    }
}
