
namespace QLSK
{
    partial class Phong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTinhTrangPhong = new System.Windows.Forms.Label();
            this.lbTenPhong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDonDep = new System.Windows.Forms.Label();
            this.lbThoigian = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTenKhach = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTinhTrangPhong);
            this.panel1.Controls.Add(this.lbTenPhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 60);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbTinhTrangPhong
            // 
            this.lbTinhTrangPhong.AutoSize = true;
            this.lbTinhTrangPhong.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTinhTrangPhong.Location = new System.Drawing.Point(234, 18);
            this.lbTinhTrangPhong.Name = "lbTinhTrangPhong";
            this.lbTinhTrangPhong.Size = new System.Drawing.Size(87, 19);
            this.lbTinhTrangPhong.TabIndex = 2;
            this.lbTinhTrangPhong.Text = "Tình Trạng";
            this.lbTinhTrangPhong.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbTenPhong
            // 
            this.lbTenPhong.AutoSize = true;
            this.lbTenPhong.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenPhong.Location = new System.Drawing.Point(17, 18);
            this.lbTenPhong.Name = "lbTenPhong";
            this.lbTenPhong.Size = new System.Drawing.Size(94, 19);
            this.lbTenPhong.TabIndex = 0;
            this.lbTenPhong.Text = "Tên Phòng";
            this.lbTenPhong.Click += new System.EventHandler(this.panel2_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbDonDep);
            this.panel2.Controls.Add(this.lbThoigian);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 59);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbDonDep
            // 
            this.lbDonDep.AutoSize = true;
            this.lbDonDep.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonDep.Location = new System.Drawing.Point(234, 16);
            this.lbDonDep.Name = "lbDonDep";
            this.lbDonDep.Size = new System.Drawing.Size(78, 19);
            this.lbDonDep.TabIndex = 3;
            this.lbDonDep.Text = "Dọn Dẹp";
            this.lbDonDep.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbThoigian
            // 
            this.lbThoigian.AutoSize = true;
            this.lbThoigian.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoigian.Location = new System.Drawing.Point(51, 28);
            this.lbThoigian.Name = "lbThoigian";
            this.lbThoigian.Size = new System.Drawing.Size(84, 19);
            this.lbThoigian.TabIndex = 3;
            this.lbThoigian.Text = "Thời Gian";
            this.lbThoigian.Click += new System.EventHandler(this.panel2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QLSK.Properties.Resources.icons8_time_64px;
            this.pictureBox2.Location = new System.Drawing.Point(13, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbTenKhach);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 56);
            this.panel3.TabIndex = 3;
            this.panel3.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbTenKhach
            // 
            this.lbTenKhach.AutoSize = true;
            this.lbTenKhach.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKhach.Location = new System.Drawing.Point(73, 12);
            this.lbTenKhach.Name = "lbTenKhach";
            this.lbTenKhach.Size = new System.Drawing.Size(211, 28);
            this.lbTenKhach.TabIndex = 1;
            this.lbTenKhach.Text = "Tên Khách Phòng";
            this.lbTenKhach.Click += new System.EventHandler(this.panel2_Click);
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Phong";
            this.Size = new System.Drawing.Size(346, 175);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTenPhong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbTinhTrangPhong;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTenKhach;
        private System.Windows.Forms.Label lbThoigian;
        private System.Windows.Forms.Label lbDonDep;
    }
}
