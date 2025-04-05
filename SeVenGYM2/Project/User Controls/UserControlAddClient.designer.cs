
namespace SevenGym.Project.UserControls
{
    partial class UserControlAddClient
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cbCaptain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCard = new System.Windows.Forms.ComboBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.gbClientInfo = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbClientCode = new System.Windows.Forms.GroupBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.btnPrintCode = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txtId = new System.Windows.Forms.TextBox();
            this.gbClientInfo.SuspendLayout();
            this.gbClientCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Client:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(149, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(471, 27);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(149, 94);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(471, 27);
            this.txtPhone.TabIndex = 2;
            // 
            // cbCaptain
            // 
            this.cbCaptain.FormattingEnabled = true;
            this.cbCaptain.Location = new System.Drawing.Point(149, 151);
            this.cbCaptain.Name = "cbCaptain";
            this.cbCaptain.Size = new System.Drawing.Size(471, 29);
            this.cbCaptain.TabIndex = 3;
            this.cbCaptain.Click += new System.EventHandler(this.cbCaptain_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Captain:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Card:";
            // 
            // cbCard
            // 
            this.cbCard.FormattingEnabled = true;
            this.cbCard.Location = new System.Drawing.Point(390, 204);
            this.cbCard.Name = "cbCard";
            this.cbCard.Size = new System.Drawing.Size(230, 29);
            this.cbCard.TabIndex = 5;
            this.cbCard.Click += new System.EventHandler(this.cbCard_Click);
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(149, 259);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(377, 27);
            this.dtStart.TabIndex = 6;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(149, 317);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(377, 27);
            this.dtEnd.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Start at:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "End at:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Notes:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(149, 371);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(377, 157);
            this.txtNote.TabIndex = 8;
            // 
            // gbClientInfo
            // 
            this.gbClientInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbClientInfo.Controls.Add(this.btnReset);
            this.gbClientInfo.Controls.Add(this.txtName);
            this.gbClientInfo.Controls.Add(this.btnAddClient);
            this.gbClientInfo.Controls.Add(this.dtEnd);
            this.gbClientInfo.Controls.Add(this.label2);
            this.gbClientInfo.Controls.Add(this.dtStart);
            this.gbClientInfo.Controls.Add(this.label8);
            this.gbClientInfo.Controls.Add(this.cbCategory);
            this.gbClientInfo.Controls.Add(this.cbCard);
            this.gbClientInfo.Controls.Add(this.txtNote);
            this.gbClientInfo.Controls.Add(this.cbCaptain);
            this.gbClientInfo.Controls.Add(this.label3);
            this.gbClientInfo.Controls.Add(this.label7);
            this.gbClientInfo.Controls.Add(this.label4);
            this.gbClientInfo.Controls.Add(this.label6);
            this.gbClientInfo.Controls.Add(this.txtPhone);
            this.gbClientInfo.Controls.Add(this.label9);
            this.gbClientInfo.Controls.Add(this.label5);
            this.gbClientInfo.Location = new System.Drawing.Point(34, 40);
            this.gbClientInfo.Name = "gbClientInfo";
            this.gbClientInfo.Size = new System.Drawing.Size(638, 541);
            this.gbClientInfo.TabIndex = 0;
            this.gbClientInfo.TabStop = false;
            this.gbClientInfo.Text = "Client Information:";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(532, 485);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 29);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.White;
            this.btnAddClient.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddClient.Location = new System.Drawing.Point(532, 450);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(88, 29);
            this.btnAddClient.TabIndex = 9;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(149, 204);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(165, 29);
            this.cbCategory.TabIndex = 4;
            this.cbCategory.Click += new System.EventHandler(this.cbCategory_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Category:";
            // 
            // gbClientCode
            // 
            this.gbClientCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbClientCode.Controls.Add(this.picBarcode);
            this.gbClientCode.Controls.Add(this.btnPrintCode);
            this.gbClientCode.Location = new System.Drawing.Point(765, 126);
            this.gbClientCode.Name = "gbClientCode";
            this.gbClientCode.Size = new System.Drawing.Size(442, 300);
            this.gbClientCode.TabIndex = 0;
            this.gbClientCode.TabStop = false;
            this.gbClientCode.Text = "Client Barcode:";
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(48, 54);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(353, 134);
            this.picBarcode.TabIndex = 0;
            this.picBarcode.TabStop = false;
            // 
            // btnPrintCode
            // 
            this.btnPrintCode.BackColor = System.Drawing.Color.White;
            this.btnPrintCode.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPrintCode.Location = new System.Drawing.Point(148, 225);
            this.btnPrintCode.Name = "btnPrintCode";
            this.btnPrintCode.Size = new System.Drawing.Size(151, 29);
            this.btnPrintCode.TabIndex = 11;
            this.btnPrintCode.Text = "Print";
            this.btnPrintCode.UseVisualStyleBackColor = false;
            this.btnPrintCode.Click += new System.EventHandler(this.btnPrintCode_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(736, 64);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(471, 27);
            this.txtId.TabIndex = 0;
            // 
            // UserControlAddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbClientCode);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.gbClientInfo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlAddClient";
            this.Size = new System.Drawing.Size(1300, 594);
            this.Load += new System.EventHandler(this.UserControlAddClient_Load);
            this.Enter += new System.EventHandler(this.UserControlAddClient_Enter);
            this.gbClientInfo.ResumeLayout(false);
            this.gbClientInfo.PerformLayout();
            this.gbClientCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cbCaptain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCard;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.GroupBox gbClientInfo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.GroupBox gbClientCode;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Button btnPrintCode;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtId;
    }
}
