
namespace SevenGym.Project.UserControls
{
    partial class UserControlUpdateCard
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
            this.gpAddCard = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdateCard = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtCardPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvCard = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpAddCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).BeginInit();
            this.SuspendLayout();
            // 
            // gpAddCard
            // 
            this.gpAddCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gpAddCard.Controls.Add(this.btnReset);
            this.gpAddCard.Controls.Add(this.btnUpdateCard);
            this.gpAddCard.Controls.Add(this.cbCategory);
            this.gpAddCard.Controls.Add(this.txtCardPrice);
            this.gpAddCard.Controls.Add(this.txtName);
            this.gpAddCard.Controls.Add(this.label3);
            this.gpAddCard.Controls.Add(this.label4);
            this.gpAddCard.Controls.Add(this.label2);
            this.gpAddCard.Location = new System.Drawing.Point(31, 108);
            this.gpAddCard.Name = "gpAddCard";
            this.gpAddCard.Size = new System.Drawing.Size(419, 368);
            this.gpAddCard.TabIndex = 0;
            this.gpAddCard.TabStop = false;
            this.gpAddCard.Text = "Card Information:";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(217, 296);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 29);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdateCard
            // 
            this.btnUpdateCard.BackColor = System.Drawing.Color.White;
            this.btnUpdateCard.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUpdateCard.Location = new System.Drawing.Point(311, 296);
            this.btnUpdateCard.Name = "btnUpdateCard";
            this.btnUpdateCard.Size = new System.Drawing.Size(88, 29);
            this.btnUpdateCard.TabIndex = 5;
            this.btnUpdateCard.Text = "Edit";
            this.btnUpdateCard.UseVisualStyleBackColor = false;
            this.btnUpdateCard.Click += new System.EventHandler(this.btnUpdateCard_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(29, 157);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(370, 29);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.Click += new System.EventHandler(this.cbCategory_Click);
            // 
            // txtCardPrice
            // 
            this.txtCardPrice.Location = new System.Drawing.Point(29, 242);
            this.txtCardPrice.Name = "txtCardPrice";
            this.txtCardPrice.Size = new System.Drawing.Size(370, 27);
            this.txtCardPrice.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(29, 83);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(370, 27);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Card Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Card Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Card Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Gym Card:";
            // 
            // dgvCard
            // 
            this.dgvCard.AllowUserToAddRows = false;
            this.dgvCard.AllowUserToDeleteRows = false;
            this.dgvCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCard.BackgroundColor = System.Drawing.Color.White;
            this.dgvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvCard.Location = new System.Drawing.Point(469, 108);
            this.dgvCard.Name = "dgvCard";
            this.dgvCard.RowHeadersWidth = 51;
            this.dgvCard.RowTemplate.Height = 24;
            this.dgvCard.Size = new System.Drawing.Size(782, 368);
            this.dgvCard.TabIndex = 0;
            this.dgvCard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCard_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "Card_ID";
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 52;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Card_Name";
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.DataPropertyName = "Categories_Name";
            this.Column3.HeaderText = "Card Category";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 141;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.DataPropertyName = "Price";
            this.Column4.HeaderText = "Price";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // UserControlUpdateCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCard);
            this.Controls.Add(this.gpAddCard);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlUpdateCard";
            this.Size = new System.Drawing.Size(1300, 594);
            this.Load += new System.EventHandler(this.UserControlUpdateCard_Load);
            this.gpAddCard.ResumeLayout(false);
            this.gpAddCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpAddCard;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdateCard;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtCardPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
