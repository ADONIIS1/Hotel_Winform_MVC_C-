using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK
{
    public partial class Phong : UserControl
    {
        public string ItemTenPhong
        {
            get { return lbTenPhong.Text; }
            set { lbTenPhong.Text = value; }
        }
        public string ItemTinhTrangphong
        {
            get { return lbTinhTrangPhong.Text; }
            set { lbTinhTrangPhong.Text = value; }
        }
        public string ItemKhach
        {
            get { return lbTenKhach.Text; }
            set { lbTenKhach.Text = value; }
        }

        public string ItemThoiGian
        {
            get { return lbThoigian.Text; }
            set { lbThoigian.Text = value; }
        }
        public string ItemDonDep
        {
            get { return lbDonDep.Text; }
            set { lbDonDep.Text = value; }
        }
        public Phong()
        {
            InitializeComponent();
        }


        private void panel2_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
