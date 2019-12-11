using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_themCongViec : Form
    {
        eCongViec congViec;
        BUSCongViec busCongViec;
        BUSDuAn busDuAn;
        public frm_themCongViec()
        {
            InitializeComponent();
            congViec = new eCongViec();
            busCongViec = new BUSCongViec();
            busDuAn = new BUSDuAn();
        }

        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_themCongViec_Load(object sender, EventArgs e)
        {
            this.Location = new Point(55, 42);
            List<eDuAn> listDuAn = new List<eDuAn>();
            foreach (eDuAn i in busDuAn.GetAllList())
            {
                i.TenDuAn = "[" + i.MaDuAn + "] " + i.TenDuAn;
                listDuAn.Add(i);
            }

            // Gan danh sach Du An cho combobox
            cboDuAn.DisplayMember = "TenDuAn";
            cboDuAn.ValueMember = "MaDuAn";
            cboDuAn.DataSource = listDuAn;

            // Gan trang thai
            cboTrangThai.DataSource = new string[] { "Chưa thực hiện", "Đang thực hiện", "Hoàn thành" };
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            congViec.DuAn.MaDuAn = cboDuAn.SelectedValue.ToString();
            congViec.TenCongViec = txtTenCongViec.Text;
            congViec.Tiendo = (int)nudTienDoCongViec.TextAlign;
            congViec.TrangThai = cboTrangThai.Text;
            congViec.NgayBatDau = dtmNgayBatDau.Value;
            congViec.NgayKetThuc = dtmNgayKetThuc.Value;
            congViec.ViTriCongViec = cboViTriCongViec.Text;
            busCongViec.AddItem(congViec);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboDuAn_Leave(object sender, EventArgs e)
        {

        }

        private void txtTenCongViec_Leave(object sender, EventArgs e)
        {
            if (txtTenCongViec.Text.Trim().Equals(""))
            {
                txtTenCongViec.Focus();
                errorProvider1.SetError(txtTenCongViec, "Khong de trong ten cong viec");
            }
            else
            {
                errorProvider1.SetError(txtTenCongViec, "");
            }
        }

        private void dtmNgayKetThuc_Leave(object sender, EventArgs e)
        {
            if (dtmNgayBatDau.Value < dtmNgayKetThuc.Value)
            {
                dtmNgayKetThuc.Focus();
                errorProvider1.SetError(dtmNgayKetThuc, "ngay ket thuc phai lon hon ngay bat dau");
            }
            else
            {
                errorProvider1.SetError(dtmNgayKetThuc, "");
            }
        }

        private void nudTienDoCongViec_Leave(object sender, EventArgs e)
        {
            if (nudTienDoCongViec.Value < 0 || nudTienDoCongViec.Value > 100)
            {
                nudTienDoCongViec.Focus();
                errorProvider1.SetError(nudTienDoCongViec, "tu 0 den 100");
            }
            else
            {
                errorProvider1.SetError(nudTienDoCongViec, "");
            }
        }
    }
}
