﻿using Business;
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
    public partial class frm_suaCongViec : Form
    {
        eCongViec congViec;
        BUSCongViec busCongViec;
        public frm_suaCongViec()
        {
            InitializeComponent();
        }
        public frm_suaCongViec(string maCongViec, eDuAn duAn, string tenCongViec, DateTime ngayBatDau, DateTime ngayKetThuc, string trangThai, int tienDoCongViec, string viTriCongViec)
        {
            InitializeComponent();

            congViec = new eCongViec();
            busCongViec = new BUSCongViec();

            congViec.MaCongViec = maCongViec;
            congViec.DuAn = duAn;
            congViec.TrangThai = trangThai;
            congViec.Tiendo = tienDoCongViec;
            congViec.NgayBatDau = ngayBatDau;
            congViec.NgayKetThuc = ngayKetThuc;
            congViec.TenCongViec = tenCongViec;
            congViec.ViTriCongViec = viTriCongViec;

            // Gan gia tri Trang Thai cho combobox
            cboTrangThai.DataSource = new string[] { "Chưa thực hiện", "Đang thực hiện", "Hoàn thành" };

            // Gan gia tri Vi Tri Cong Viec cho combobox
            cboViTriCongViec.DataSource = new string[] { "Quản Lý", "Khảo Sát", "Thiết Kế", "Giám Sát", "Thi Công" };

        }
        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_suaCongViec_Load(object sender, EventArgs e)
        {
            this.Location = new Point(55, 42);

            txtMaCongViec.Text = congViec.MaCongViec;
            txtMaCongViec.ReadOnly = true;
            txtTenCongViec.Text = congViec.TenCongViec;
            dtmNgayBatDau.Value = congViec.NgayBatDau;
            dtmNgayKetThuc.Value = congViec.NgayKetThuc;
            cboTrangThai.Text = congViec.TrangThai;
            nudTienDoCongViec.Value = congViec.Tiendo;
            cboViTriCongViec.Text = congViec.ViTriCongViec;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            congViec.TenCongViec = txtTenCongViec.Text;
            congViec.NgayBatDau = dtmNgayBatDau.Value;
            congViec.NgayKetThuc = dtmNgayKetThuc.Value;
            congViec.TrangThai = cboTrangThai.Text;
            congViec.Tiendo = (int)nudTienDoCongViec.Value;
            congViec.ViTriCongViec = cboViTriCongViec.Text;

            busCongViec.UpdateItem(congViec);
            this.Close();
        }

        private void txtTenCongviec_Leave(object sender, EventArgs e)
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

        private void dtmNgayBatDau_Leave(object sender, EventArgs e)
        {

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
