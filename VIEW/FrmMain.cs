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
    }
}