﻿using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_suaNhanVien : Form
    {
        // Dia Chi
        List<ePhuongXa> ePhuongXa;
        List<eQuanHuyen> eQuanHuyen;
        List<eThanhPho> eThanhPho;
        BUSDiaChi busDiaChi;

        // Nhan Vien
        eNhanVien eNhanVien;
        BUSNhanVien busNhanVien;
        public frm_suaNhanVien()
        {
            InitializeComponent();
        }
        public frm_suaNhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, string soDienThoai, string email, DateTime ngayVaoLam,  DateTime namSinh,  string soCMND, string soBHXH, string maDiaChi, string soNha, string phuongXa, string quanHuyen, string thanhPho, string viTriCongViec)
        {
            InitializeComponent();

            // Dia Chi
            ePhuongXa = new List<ePhuongXa>();
            eQuanHuyen = new List<eQuanHuyen>();
            eThanhPho = new List<eThanhPho>();
            busDiaChi = new BUSDiaChi();

            // Nhan Vien
            eNhanVien = new eNhanVien();
            busNhanVien = new BUSNhanVien();

            eNhanVien.manhanVien = maNhanVien;
            eNhanVien.hoTen = tenNhanVien;
            eNhanVien.gioiTinh = gioiTinh;
            eNhanVien.dienThoai = soDienThoai;
            eNhanVien.email = email;
            eNhanVien.ngayVaolam = ngayVaoLam;
            eNhanVien.namSinh = namSinh;
            eNhanVien.soCMND = soCMND;
            eNhanVien.soBaoHiemXH = soBHXH;
            eNhanVien.viTriCongViec = viTriCongViec;
            eNhanVien.diaChi = new eDiaChi(maDiaChi, soNha, phuongXa,quanHuyen, thanhPho);
           

        }
        private void pic_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_suaNhanVien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(55, 42);

            // Gan gioi tinh cho combobox
            cboGioiTinh.DataSource = new string[] { "Nữ", "Nam" };

            // Gan Vi Tri Cong Viec Cho Combobox

            cboViTriCongViec.DataSource = new string[] { "Quản Lý", "Khảo Sát", "Thiết Kế", "Giám Sát", "Thi Công" };

            // Gan danh sach thanh pho
            eThanhPho = busDiaChi.getAllThanhPho();

            cboThanhPho.DisplayMember = "thanhPho";
            cboThanhPho.ValueMember = "maThanhPho";
            cboThanhPho.DataSource = eThanhPho;

            // Load du lieu len control
            txtMaNhanVien.Text = eNhanVien.manhanVien;
            txtTenNhanVien.Text = eNhanVien.hoTen;
            cboGioiTinh.Text = eNhanVien.gioiTinh;
            txtSoDienThoai.Text = eNhanVien.dienThoai;
            dtmNamSinh.Value = eNhanVien.namSinh;
            txtEmail.Text = eNhanVien.email;
            dtmNgayVaoLam.Value = eNhanVien.ngayVaolam;
            txtCMND.Text = eNhanVien.soCMND;
            txtBHXH.Text = eNhanVien.soBaoHiemXH;
            cboViTriCongViec.Text = eNhanVien.viTriCongViec;


            txtSoNha.Text = eNhanVien.diaChi.soNha;
            cboPhuongXa.Text = eNhanVien.diaChi.phuongXa;
            cboQuanHuyen.Text = eNhanVien.diaChi.quanHuyen;
            cboThanhPho.Text = eNhanVien.diaChi.thanhPho;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int soLoi = 0;

            if (!checkTenNhanVien())
            {
                soLoi++;
            }

            if (!checkNamSinh())
            {
                soLoi++;
            }
            if (!checkCMND())
            {
                soLoi++;
            }

            if (!checkBHXH())
            {
                soLoi++;
            }
            if (!checkSDT())
            {
                soLoi++;
            }

            if (!checkSoNha())
            {
                soLoi++;
            }

            if (!checkNgayVaoLam())
            {
                soLoi++;
            }


            if (soLoi > 0)
            {
                MessageBox.Show("Sua tat ca loi");
                txtTenNhanVien.Focus();
                return;
            }
            // Cap nhat lai du lieu Nhan Vien
            eNhanVien.manhanVien = txtMaNhanVien.Text;
            eNhanVien.hoTen = txtTenNhanVien.Text;
            eNhanVien.gioiTinh = cboGioiTinh.Text;
            eNhanVien.dienThoai = txtSoDienThoai.Text;
            eNhanVien.namSinh = dtmNamSinh.Value;
            eNhanVien.email = txtEmail.Text;
            eNhanVien.ngayVaolam = dtmNgayVaoLam.Value;
            eNhanVien.soCMND = txtCMND.Text;
            eNhanVien.soBaoHiemXH = txtBHXH.Text;
            eNhanVien.viTriCongViec = cboViTriCongViec.Text;


            //Dia Chi
            eNhanVien.diaChi.soNha = txtSoNha.Text;
            eNhanVien.diaChi.phuongXa = cboPhuongXa.Text;
            eNhanVien.diaChi.quanHuyen = cboQuanHuyen.Text;
            eNhanVien.diaChi.thanhPho = cboThanhPho.Text;

            busNhanVien.UpdateItem(eNhanVien);

            this.Close();
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

        private void btnImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.png*)|*.jpg; *.png*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                picImage.Image = new Bitmap(open.FileName);
                // image fileName 

                picImage.Text = Path.GetFileName(open.FileName);


            }
        }



        private void txtTenNhanVien_Leave(object sender, EventArgs e)
        {
            if (checkTenNhanVien() == false)
            {
                txtEmail.Focus();

            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        bool checkTenNhanVien()
        {
            if (txtTenNhanVien.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtTenNhanVien, "Khong de trong ten nhan vien");
                return false;
            }
            return true;
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (!checkSDT())
            {

                txtSoDienThoai.Focus();

            }
            else
            {

                errorProvider1.SetError(txtSoDienThoai, "");
            }
        }

        bool checkSDT()
        {

            if (Regex.IsMatch(txtSoDienThoai.Text, @"\d{10,12}") == false)
            {


                errorProvider1.SetError(txtSoDienThoai, "nhap so tu 10 den 12 chu so");
                return false;
            }

            return true;
        }

        private void dtmNamSinh_Leave(object sender, EventArgs e)
        {


            if (checkNamSinh() == false)
            {
                dtmNamSinh.Focus();
            }
            else
            {
                errorProvider1.SetError(dtmNamSinh, "");
            }
        }

        bool checkNamSinh()
        {
            DateTime hientai = DateTime.Now;

            int tuoi = hientai.Year - dtmNamSinh.Value.Year;

            if (tuoi < 22 || tuoi > 65)
            {

                errorProvider1.SetError(dtmNamSinh, "Do tuoi khong hop le (tu 22 den 65)");
                return false;
            }
            return true;
        }

        private void dtmNgayVaoLam_Leave(object sender, EventArgs e)
        {


            if (checkNgayVaoLam() == false)
            {
                dtmNgayVaoLam.Focus();

            }
            else
            {
                errorProvider1.SetError(dtmNgayVaoLam, "");
            }

        }

        bool checkNgayVaoLam()
        {
            DateTime hientai = DateTime.Now;

            if (dtmNgayVaoLam.Value > hientai)
            {

                errorProvider1.SetError(dtmNgayVaoLam, "Ngay Vao Lam <= Ngay Hien Tai");
                return false;
            }
            return true;
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!checkEmail())
            {
                txtEmail.Focus();

            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        bool checkEmail()
        {
            if (!Regex.IsMatch(txtEmail.Text, @"\w@\w"))
            {

                errorProvider1.SetError(txtEmail, "email khong hop le. Mau: abc@gmail.com hoac abc@yahoo.com.vn");
                return false;
            }
            return true;
        }

        private void txtCMND_Leave(object sender, EventArgs e)
        {
            if (!checkCMND())
            {
                txtCMND.Focus();

            }
            else
            {
                errorProvider1.SetError(txtCMND, "");
            }
        }

        bool checkCMND()
        {
            if (!Regex.IsMatch(txtCMND.Text, @"\d"))
            {

                errorProvider1.SetError(txtCMND, "Khong de trong CMND");
                return false;
            }
            return true;
        }

        private void txtBHXH_Leave(object sender, EventArgs e)
        {
            if (!checkBHXH())
            {
                txtBHXH.Focus();

            }
            else
            {
                errorProvider1.SetError(txtBHXH, "");
            }
        }

        bool checkBHXH()
        {
            if (!Regex.IsMatch(txtBHXH.Text, @"^\d$"))
            {

                errorProvider1.SetError(txtBHXH, "Khong de trong BHXH");
                return false;
            }
            return true;
        }


        private void txtSoNha_Leave(object sender, EventArgs e)
        {
            if (!checkSoNha())
            {
                txtSoNha.Focus();

            }
            else
            {
                errorProvider1.SetError(txtSoNha, "");
            }
        }

        bool checkSoNha()
        {
            if (txtSoNha.Text.Trim().Equals(""))
            {

                errorProvider1.SetError(txtSoNha, "Khong de trong so nha");
                return false;
            }
            return true;
        }

    }
}
