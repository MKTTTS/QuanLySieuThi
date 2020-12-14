namespace QuanLySieuThi
{
    partial class FormHetHan
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
            this.components = new System.ComponentModel.Container();
            this.XuLy_btn = new System.Windows.Forms.Button();
            this.DeSau_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.donViHangHoaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donViHangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donViHangHoaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViHangHoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // XuLy_btn
            // 
            this.XuLy_btn.Location = new System.Drawing.Point(262, 6);
            this.XuLy_btn.Name = "XuLy_btn";
            this.XuLy_btn.Size = new System.Drawing.Size(75, 23);
            this.XuLy_btn.TabIndex = 0;
            this.XuLy_btn.Text = "XỬ LÝ";
            this.XuLy_btn.UseVisualStyleBackColor = true;
            this.XuLy_btn.Click += new System.EventHandler(this.XuLy_btn_Click);
            // 
            // DeSau_btn
            // 
            this.DeSau_btn.Location = new System.Drawing.Point(472, 6);
            this.DeSau_btn.Name = "DeSau_btn";
            this.DeSau_btn.Size = new System.Drawing.Size(118, 23);
            this.DeSau_btn.TabIndex = 1;
            this.DeSau_btn.Text = "NHẮC TÔI SAU";
            this.DeSau_btn.UseVisualStyleBackColor = true;
            this.DeSau_btn.Click += new System.EventHandler(this.DeSau_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.XuLy_btn);
            this.panel1.Controls.Add(this.DeSau_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 35);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 74);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH HÀNG HẾT HẠN SỬ DỤNG";
            // 
            // donViHangHoaDataGridView
            // 
            this.donViHangHoaDataGridView.AutoGenerateColumns = false;
            this.donViHangHoaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.donViHangHoaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.donViHangHoaDataGridView.DataSource = this.donViHangHoaBindingSource;
            this.donViHangHoaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.donViHangHoaDataGridView.Location = new System.Drawing.Point(0, 74);
            this.donViHangHoaDataGridView.MultiSelect = false;
            this.donViHangHoaDataGridView.Name = "donViHangHoaDataGridView";
            this.donViHangHoaDataGridView.ReadOnly = true;
            this.donViHangHoaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.donViHangHoaDataGridView.Size = new System.Drawing.Size(844, 389);
            this.donViHangHoaDataGridView.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaMatHang";
            this.dataGridViewTextBoxColumn1.HeaderText = "MaMatHang";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenMatHang";
            this.dataGridViewTextBoxColumn2.HeaderText = "TenMatHang";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TenLoai";
            this.dataGridViewTextBoxColumn3.HeaderText = "TenLoai";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "XuatXu";
            this.dataGridViewTextBoxColumn4.HeaderText = "XuatXu";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GiaBan";
            this.dataGridViewTextBoxColumn5.HeaderText = "GiaBan";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NgaySanXuat";
            this.dataGridViewTextBoxColumn6.HeaderText = "NgaySanXuat";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "HanSuDung";
            this.dataGridViewTextBoxColumn7.HeaderText = "HanSuDung";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SoLuongHetHan";
            this.dataGridViewTextBoxColumn8.HeaderText = "SoLuongHetHan";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // donViHangHoaBindingSource
            // 
            this.donViHangHoaBindingSource.DataSource = typeof(QuanLySieuThi.DonViHangHoa);
            // 
            // FormHetHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 498);
            this.Controls.Add(this.donViHangHoaDataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormHetHan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormHetHan";
            this.Load += new System.EventHandler(this.FormHetHan_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donViHangHoaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViHangHoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button XuLy_btn;
        private System.Windows.Forms.Button DeSau_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource donViHangHoaBindingSource;
        private System.Windows.Forms.DataGridView donViHangHoaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}