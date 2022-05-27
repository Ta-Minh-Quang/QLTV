using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btn_TrangChu_ItemClick(null, null);
        }

        private bool CheckExitForm(string name)
        {
            foreach (Form form in this.MdiChildren)
                if (form.Name == name)
                    return true;
            return false;
        }

        private void ActiveChildForm(string name)
        {
            foreach (Form form in this.MdiChildren)
                if (form.Name == name)
                {
                    form.Activate();
                    return;
                }
        }

        private void btn_TrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmTrangChu"))
            {
                
                FrmTrangChu form = new FrmTrangChu();
                form.MdiParent = this;
                form.Name = "FrmTrangChu";
                form.Show();
            }
            else
                ActiveChildForm("FrmTrangChu");
        }

        private void btn_Thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_DangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmDangNhap"))
            {

                FrmDangNhap form = new FrmDangNhap();
                form.MdiParent = this;
                form.Name = "FrmDangNhap";
                form.Show();
            }
            else
                ActiveChildForm("FrmDangNhap");
        }

        private void btn_TaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmTaoTK"))
            {

                FrmTaoTK form = new FrmTaoTK();
                form.MdiParent = this;
                form.Name = "FrmTaoTK";
                form.Show();
            }
            else
                ActiveChildForm("FrmTaoTK");
        }

        private void btn_DoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmDoiMK"))
            {

                FrmDoiMK form = new FrmDoiMK();
                form.MdiParent = this;
                form.Name = "FrmDoiMK";  
                form.Show();
            }
            else
                ActiveChildForm("FrmDoiMK");
        }

        private void btn_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_ThongTinTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmThongTinTK"))
            {

                FrmThongTinTK form = new FrmThongTinTK();
                form.MdiParent = this;
                form.Name = "FrmThongTinTK";
                form.Show();
            }
            else
                ActiveChildForm("FrmThongTinTK");
        }

        private void btn_TimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmTimKiem"))
            {

                FrmTimKiem form = new FrmTimKiem();
                form.MdiParent = this;
                form.Name = "FrmTimKiem";
                form.Show();
            }
            else
                ActiveChildForm("FrmTimKiem");
        }

        private void btn_NXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmNXB"))
            {

                FrmNXB form = new FrmNXB();
                form.MdiParent = this;
                form.Name = "FrmNXB";
                form.Show();
            }
            else
                ActiveChildForm("FrmNXB");
        }

        private void btn_TacGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmTacGia"))
            {

                FrmTacGia form = new FrmTacGia();
                form.MdiParent = this;
                form.Name = "FrmTacGia";
                form.Show();
            }
            else
                ActiveChildForm("FrmTacGia");
        }

        private void btn_DocGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmDocGia"))
            {

                FrmDocGia form = new FrmDocGia();
                form.MdiParent = this;
                form.Name = "FrmDocGia";
                form.Show();
            }
            else
                ActiveChildForm("FrmDocGia");
        }

        private void btn_DauSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmDauSach"))
            {

                FrmTheLoai form = new FrmTheLoai();
                form.MdiParent = this;
                form.Name = "FrmDauSach";
                form.Show();
            }
            else
                ActiveChildForm("FrmDauSach");
        }

        private void btn_Sach_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmSach"))
            {

                FrmSach form = new FrmSach();
                form.MdiParent = this;
                form.Name = "FrmSach";
                form.Show();
            }
            else
                ActiveChildForm("FrmSach");
        }

        private void btn_Muon_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmMuon"))
            {

                FrmMuon form = new FrmMuon();
                form.MdiParent = this;
                form.Name = "FrmMuon";
                form.Show();
            }
            else
                ActiveChildForm("FrmMuon");
        }

        private void btn_Tra_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExitForm("FrmTra"))
            {

                FrmTra form = new FrmTra();
                form.MdiParent = this;
                form.Name = "FrmTra";
                form.Show();
            }
            else
                ActiveChildForm("FrmTra");
        }
    }
}