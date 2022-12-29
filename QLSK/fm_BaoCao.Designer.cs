
namespace QLSK
{
    partial class fm_BaoCao
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportHoaDon_CustomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbThang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyKhachSan1DataSet = new QLSK.QuanLyKhachSan1DataSet();
            this.HOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HOADONTableAdapter = new QLSK.QuanLyKhachSan1DataSetTableAdapters.HOADONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHoaDon_CustomBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKhachSan1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbNam);
            this.panel1.Controls.Add(this.cbbThang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1246, 72);
            this.panel1.TabIndex = 2;
            // 
            // cbbNam
            // 
            this.cbbNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNam.BackColor = System.Drawing.Color.Transparent;
            this.cbbNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNam.FocusedState.Parent = this.cbbNam;
            this.cbbNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNam.HoverState.Parent = this.cbbNam;
            this.cbbNam.ItemHeight = 30;
            this.cbbNam.ItemsAppearance.Parent = this.cbbNam;
            this.cbbNam.Location = new System.Drawing.Point(774, 23);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.ShadowDecoration.Parent = this.cbbNam;
            this.cbbNam.Size = new System.Drawing.Size(443, 36);
            this.cbbNam.TabIndex = 1;
            this.cbbNam.SelectedIndexChanged += new System.EventHandler(this.cbbNam_SelectedIndexChanged);
            // 
            // cbbThang
            // 
            this.cbbThang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbThang.BackColor = System.Drawing.Color.Transparent;
            this.cbbThang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbThang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbThang.FocusedState.Parent = this.cbbThang;
            this.cbbThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbThang.HoverState.Parent = this.cbbThang;
            this.cbbThang.ItemHeight = 30;
            this.cbbThang.ItemsAppearance.Parent = this.cbbThang;
            this.cbbThang.Location = new System.Drawing.Point(33, 23);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.ShadowDecoration.Parent = this.cbbThang;
            this.cbbThang.Size = new System.Drawing.Size(735, 36);
            this.cbbThang.TabIndex = 0;
            this.cbbThang.SelectedIndexChanged += new System.EventHandler(this.cbbThang_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1246, 564);
            this.panel2.TabIndex = 3;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "HoaDonData";
            reportDataSource1.Value = this.HOADONBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSK.ReportHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1184, 513);
            this.reportViewer1.TabIndex = 1;
            // 
            // QuanLyKhachSan1DataSet
            // 
            this.QuanLyKhachSan1DataSet.DataSetName = "QuanLyKhachSan1DataSet";
            this.QuanLyKhachSan1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HOADONBindingSource
            // 
            this.HOADONBindingSource.DataMember = "HOADON";
            this.HOADONBindingSource.DataSource = this.QuanLyKhachSan1DataSet;
            // 
            // HOADONTableAdapter
            // 
            this.HOADONTableAdapter.ClearBeforeFill = true;
            // 
            // fm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 636);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fm_BaoCao";
            this.Text = "fm_BaoCao";
            this.Load += new System.EventHandler(this.fm_BaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportHoaDon_CustomBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKhachSan1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNam;
        private Guna.UI2.WinForms.Guna2ComboBox cbbThang;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportHoaDon_CustomBindingSource;
        private System.Windows.Forms.BindingSource HOADONBindingSource;
        private QuanLyKhachSan1DataSet QuanLyKhachSan1DataSet;
        private QuanLyKhachSan1DataSetTableAdapters.HOADONTableAdapter HOADONTableAdapter;
    }
}