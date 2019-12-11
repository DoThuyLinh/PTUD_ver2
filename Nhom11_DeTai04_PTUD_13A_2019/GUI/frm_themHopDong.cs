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
    public partial class frm_themHopDong : Form
    {
        eHopDong eHopDong;
        BUSHopDong busHopDong;
        BUSDuAn busDuAn;
        public frm_themHopDong()
        {
            InitializeComponent();
            eHopDong = new eHopDong();
            busDuAn = new BUSDuAn();
            busHopDong = new BUSHopDong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_themHopDong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(55, 42);
            nudGiaTriHopDong.Maximum = Decimal.MaxValue;

            // Xet toa do cho frm Hop Dong
            this.Location = new Point(55, 42);

            // Lay danh sach Du An, dong thoi xu ly TenDuAn thanh ma + ten
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
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            eHopDong.duAn.MaDuAn = cboDuAn.SelectedValue.ToString();
            eHopDong.tenHopDong = txtTenHopDong.Text;
            eHopDong.ngayKyKet = dtmNgayKyKet.Value;
            eHopDong.ngayHetHan = dtmNgayHetHan.Value;
            eHopDong.giaTriHopDong = (double)nudGiaTriHopDong.Value;
            eHopDong.thongTin = txtThongTin.Text;

            busHopDong.AddItem(eHopDong);

            this.Close();
        }

        private void txtTenHopDong_Leave(object sender, EventArgs e)
        {
            if (txtTenHopDong.Text.Trim().Equals(""))
            {
                txtTenHopDong.Focus();
                errorProvider1.SetError(txtTenHopDong, "Khong de trong ten hop dong");
            }
            else
            {
                errorProvider1.SetError(txtTenHopDong, "");
            }
        }

        private void dtmNgayKyKet_Leave(object sender, EventArgs e)
        {
            eDuAn duAn = busDuAn.GetItemByCondition(t=>t.MaDuAn.Equals(cboDuAn.SelectedValue.ToString()));

            if (dtmNgayKyKet.Value < duAn.NgayBatDau || dtmNgayKyKet.Value > DateTime.Now)
            {
                dtmNgayKyKet.Focus();
                errorProvider1.SetError(dtmNgayKyKet, "ngay Ky Ket > ngay Du An bat dau. Ngay Du An:" + duAn.NgayBatDau.ToShortDateString() + "\n" + "Ngay ky ket <= ngay hien tai");
            }
            else
            {
                errorProvider1.SetError(dtmNgayKyKet, "");
            }
        }

        private void dtmNgayHetHan_Leave(object sender, EventArgs e)
        {
            if (dtmNgayHetHan.Value < dtmNgayKyKet.Value)
            {
                dtmNgayKyKet.Focus();
                errorProvider1.SetError(dtmNgayHetHan, "ngay Het Han > ngay Ky Ket");
            }
            else
            {
                errorProvider1.SetError(dtmNgayHetHan, "");
            }
        }

        private void nudGiaTriHopDong_Leave(object sender, EventArgs e)
        {
            if (nudGiaTriHopDong.Value <= 0)
            {
                nudGiaTriHopDong.Focus();
                errorProvider1.SetError(nudGiaTriHopDong, "Gia Tri phai > 0");
            }
            else
            {
                errorProvider1.SetError(nudGiaTriHopDong, "");
            }
        }
    }
}
