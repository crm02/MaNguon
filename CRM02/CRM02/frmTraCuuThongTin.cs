﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM02
{
    public partial class frmTraCuuThongTin : Form
    {
        public frmTraCuuThongTin()
        {
            InitializeComponent();
        }
        private void LoadDataDonHang(string MaKH)
        {
            List<ClassDonHang> list = ClassQuanLyDonHang.Intance.LoadDanhSachDonHangTheoKH(MaKH);

            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].HeaderText = "Mã đơn Hàng";
            dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
            dataGridView1.Columns[2].HeaderText = "Thành tiền";
            dataGridView1.Columns[3].HeaderText = "Người Tạo";
            dataGridView1.Columns[4].HeaderText = "Ngày tạo";
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void buttonTraCuu_Click(object sender, EventArgs e)
        {
            if (textBoxSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!","Thông báo");
            }
            else
            {
                ClassKhachHang khachhang = ClassQuanLyKhachHang.Intance.TraCuuKhachHang(textBoxSDT.Text);
                if(khachhang == null)
                {
                    MessageBox.Show("Không tìm thấy!", "Thông báo");
                    tabControlMain.Visible = false;
                }
                else
                {
                    tabControlMain.Visible = true;
                    labelHoTen.Text = khachhang.HoTen.ToUpper();
                    labelHang.Text = "Hạng thành viên: "+ khachhang.HangThanhVien;
                    labelDiemThuong.Text = "Điểm thưởng: " + khachhang.DiemThuong.ToString();

                    LoadDataDonHang(khachhang.MaKH.ToString());
                }

            }
        }
    }
}