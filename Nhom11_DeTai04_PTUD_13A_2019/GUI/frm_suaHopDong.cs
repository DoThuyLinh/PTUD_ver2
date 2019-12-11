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
    public partial class frm_suaHopDong : Form
    {
        eHopDong eHopDong;
        BUSHopDong busHopDong;
        BUSDuAn busDuAn;
        public frm_suaHopDong()
        {
            InitializeComponent();
            busHopDong = new BUSHopDong();
            eHopDong = new eHopDong();
            busDuAn = new BUSDuAn();
        }
        public frm_suaHopDong(string maHopDong, string maDuAn, string tenHopDong, DateTime ngayKyKet, DateTime ngayHetHan, double giaTriHopDong, string thongTin)
        {
            InitializeComponent();

            eHopDong = new eHopDong();
            busHopDong = new BUSHopDong();

            eHopDong.maHopDong = maHopDong;
            eHopDong.duAn.MaDuAn = maDuAn;
            eHopDong.tenHopDong = tenHopDong;
            eHopDong.ngayKyKet = ngayKyKet;
            eHopDong.ngayHetHan = ngayHetHan;
            eHopDong.giaTriHopDong = giaTriHopDong;
            eHopDong.thongTin = thongTin;

        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_suaHopDong_Load(object sender, EventArgs e)
        {
            nudGiaTriHopDong.Maximum = Decimal.MaxValue;
            this.Location = new Point(55, 42);

            txtMaHopDong.Text = eHopDong.maHopDong;
            txtTenHopDong.Text = eHopDong.tenHopDong;
            dtmNgayKyKet.Value = eHopDong.ngayKyKet;
            dtmNgayHetHan.Value = eHopDong.ngayHetHan;
            nudGiaTriHopDong.Value = (decimal)eHopDong.giaTriHopDong;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            eHopDong.tenHopDong = txtTenHopDong.Text;
            eHopDong.ngayKyKet = dtmNgayKyKet.Value;
            eHopDong.ngayHetHan = dtmNgayHetHan.Value;
            eHopDong.giaTriHopDong = (double)nudGiaTriHopDong.Value;

            busHopDong.UpdateItem(eHopDong);

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
            eDuAn duAn = busDuAn.GetItemByCondition(t => t.MaDuAn.Equals(eHopDong.duAn.MaDuAn));
            


            if ((dtmNgayKyKet.Value < duAn.NgayBatDau) ||  (dtmNgayKyKet.Value > DateTime.Now))
            {
                dtmNgayKyKet.Focus();
                errorProvider1.SetError(dtmNgayKyKet, "ngay Ky Ket > ngay Du An bat dau. Ngay Du An:" + duAn.NgayBatDau.ToShortDateString() +"\n" + "Ngay ky ket <= ngay hien tai");
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
