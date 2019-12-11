﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Business;

namespace GUI
{
    public partial class frm_suaDuAn : Form
    {
        List<ePhuongXa> ePhuongXa;
        List<eQuanHuyen> eQuanHuyen;
        List<eThanhPho> eThanhPho;
        BUSDiaChi busDiaChi;


        // Du An
        BUSDuAn busDuAn;
        eDuAn eDuAn;


        public frm_suaDuAn(string maDuAn, string tenDuAn, DateTime ngayBatDau, DateTime ngayKetThuc, string trangThai, int tienDoHoanThanh, string maDiaChi, string soNha, string phuongXa, string quanHuyen, string thanhPho)
        {

            InitializeComponent();

            ePhuongXa = new List<ePhuongXa>();
            eQuanHuyen = new List<eQuanHuyen>();
            eThanhPho = new List<eThanhPho>();
            busDiaChi = new BUSDiaChi();


            eDuAn = new eDuAn();
            busDuAn = new BUSDuAn();

            eDuAn.MaDuAn = maDuAn;
            eDuAn.NgayBatDau = ngayBatDau;
            eDuAn.NgayKetThuc = ngayKetThuc;
            eDuAn.TrangThai = trangThai;
            eDuAn.TienDo = tienDoHoanThanh;
            eDuAn.TenDuAn = tenDuAn;

            eDuAn.DiaChi = new eDiaChi(maDiaChi, soNha, phuongXa, quanHuyen, thanhPho);

        }
        public frm_suaDuAn(string maDuAn)
        {
            
            InitializeComponent();
            
        }
        public frm_suaDuAn()
        {
            InitializeComponent();
        }
        private void LoadSubForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ShowInTaskbar = false;
            form.TopLevel = false;
            form.Show();
            form.Dock = DockStyle.Fill;
            this.panelQuanLy.Controls.Clear();
            this.panelQuanLy.Controls.Add(form);
        }
        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void frm_suaDuAn_Load(object sender, EventArgs e)
        {
            this.Location = new Point(55, 42);

            cboTrangThai.DataSource = new string[] { "Ý Tưởng", "Kế Hoạch", "Đang triển khai", "Đang Hoàn Thành", "Hoàn Thành", "Đã Đóng", "Tạm Dừng", "Thất Bại", "Không Thực Hiện" };

            eThanhPho = busDiaChi.getAllThanhPho();

            cboThanhPho.DisplayMember = "thanhPho";
            cboThanhPho.ValueMember = "maThanhPho";
            cboThanhPho.DataSource = eThanhPho;


            txtMaDuAn.Text = eDuAn.MaDuAn;
            txtTenDuAn.Text = eDuAn.TenDuAn;
            dtmNgayBatDau.Value = eDuAn.NgayBatDau;
            dtmNgayKetThuc.Value = eDuAn.NgayKetThuc;
            cboTrangThai.Text = eDuAn.TrangThai;
            nudTienDoHoanThanh.Value = eDuAn.TienDo;

            txtSoNha.Text = eDuAn.DiaChi.soNha;
            cboThanhPho.Text = eDuAn.DiaChi.thanhPho;
            cboQuanHuyen.Text = eDuAn.DiaChi.quanHuyen;
            cboPhuongXa.Text = eDuAn.DiaChi.phuongXa;
        }

        private void cboThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            eQuanHuyen = busDiaChi.getAllQuanHuyen(cboThanhPho.SelectedValue.ToString());

            cboQuanHuyen.DisplayMember = "quanHuyen";
            cboQuanHuyen.ValueMember = "maQuanHuyen";
            cboQuanHuyen.DataSource = eQuanHuyen;
        }

        private void cboQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ePhuongXa = busDiaChi.getAllPhuongXa(cboQuanHuyen.SelectedValue.ToString());

            cboPhuongXa.DisplayMember = "phuongXa";
            cboPhuongXa.ValueMember = "maPhuongXa";
            cboPhuongXa.DataSource = ePhuongXa;
        }


        private void btnChon_Click(object sender, EventArgs e)
        {
            eDuAn.TenDuAn = txtTenDuAn.Text;
            eDuAn.NgayBatDau = dtmNgayBatDau.Value;
            eDuAn.NgayKetThuc = dtmNgayKetThuc.Value;
            eDuAn.TrangThai = cboTrangThai.Text;
            eDuAn.TienDo = (int)nudTienDoHoanThanh.Value;

            eDuAn.DiaChi.soNha = txtSoNha.Text;
            eDuAn.DiaChi.thanhPho = cboThanhPho.Text;
            eDuAn.DiaChi.quanHuyen = cboQuanHuyen.Text;
            eDuAn.DiaChi.phuongXa = cboPhuongXa.Text;

            busDuAn.UpdateItem(eDuAn);

            this.Close();
        }

        private void txtTenDuAn_Leave(object sender, EventArgs e)
        {
            if (txtTenDuAn.Text.Trim().Equals(""))
            {
                txtTenDuAn.Focus();
                errorProvider1.SetError(txtTenDuAn, "Khong de trong ten du an");
            }
            else
            {
                errorProvider1.SetError(txtTenDuAn, "");
            }
        }

        private void dtmNgayKetThuc_Leave(object sender, EventArgs e)
        {
            if (dtmNgayBatDau.Value > dtmNgayKetThuc.Value)
            {
                dtmNgayKetThuc.Focus();
                errorProvider1.SetError(dtmNgayKetThuc, "ngay ket thuc phai lon hon ngay bat dau");
            }
            else
            {
                errorProvider1.SetError(dtmNgayKetThuc, "");
            }
        }

        private void txtSoNha_Leave(object sender, EventArgs e)
        {
            if (txtSoNha.Text.Trim().Equals(""))
            {
                txtSoNha.Focus();
                errorProvider1.SetError(txtSoNha, "Khong de trong so nha");
            }
            else
            {
                errorProvider1.SetError(txtSoNha, "");
            }
        }

        private void nudTienDoHoanThanh_Leave(object sender, EventArgs e)
        {
            if (nudTienDoHoanThanh.Value < 0 || nudTienDoHoanThanh.Value > 100)
            {
                nudTienDoHoanThanh.Focus();
                errorProvider1.SetError(nudTienDoHoanThanh, "tu 0 den 100");
            }
            else
            {
                errorProvider1.SetError(nudTienDoHoanThanh, "");
            }
        }
    }
}
