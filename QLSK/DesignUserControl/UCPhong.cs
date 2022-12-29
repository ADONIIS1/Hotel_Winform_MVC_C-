using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK.DesignUserControl
{
    public partial class UCPhong : UserControl
    {
        public UCPhong()
        {
            InitializeComponent();
        }
       
        public string ItemTenKhach
        {
            get { return lbTenKhach.Text; }
            set { lbTenKhach.Text = value; }
        }
        public string ItemLoaiP
        {
            get { return lbLoaiP.Text; }
            set { lbLoaiP.Text = value; }
        }
        public string ItemSoPhong
        {
            get { return lbSoPhong.Text; }
            set { lbSoPhong.Text = value; }
        }
        public string ItemTinhTrang
        {
            get { return lbtinhtrang.Text; }
            set { lbtinhtrang.Text = value; }
        }
        public string ItemThoiGian
        {
            get { return lbThoiGian.Text; }
            set { lbThoiGian.Text = value; }
        }
        public Image ItemPbKhachHang
        {
            get { return pbKhachHang.Image; }
            set { pbKhachHang.Image = value; }
        }
        public Image ItemPbThoigian
        {
            get { return pbThoiGian.Image; }
            set { pbThoiGian.Image = value; }
        }
        private int soPhieu;
     
        public int SoPhieu { get => soPhieu; set => soPhieu = value; }

        int hover = 0 ;
        Color temp;
        private void UCPhong_MouseLeave(object sender, EventArgs e)
        {
            this.hover--;
            if(this.hover <= 0)
            {
                this.BackColor = temp;
            }
        }

        private void UCPhong_MouseEnter(object sender, EventArgs e)
        {
            this.hover++;
            if (this.hover > 0)
            {
                temp = this.BackColor;
                this.BackColor = Color.Aquamarine;
            }
        }


    }
}
