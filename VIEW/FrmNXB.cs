using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;


namespace VIEW
{
    public partial class FrmNXB : Form
    {
        
        public FrmNXB()
        {
            InitializeComponent();
        }

        private void FrmNXB_Load(object sender, EventArgs e)
        {
            LoadDgv();
            grcInfo_EnabledFalse(true);
            grcInfo_Null();
        }

        void LoadDgv()
        {
            BLL_NXB _NXBLib = new BLL_NXB();
            List<DTO_NXB> _listNXB = _NXBLib.getAllNXB();
            dgvListNXB.DataSource = _listNXB;
        }

        void grcInfo_EnabledFalse(bool type)
        {
            txtTenNXB.ReadOnly = type;
            txtNguoiDaiDien.ReadOnly = type;
            txtDiaChi.ReadOnly = type;
            txtSDT.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtNguoiDaiDien.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        void btnLoad()
        {

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadDgv();
            grcInfo_EnabledFalse(true);
            grcInfo_Null();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

        }

        private void btChange_Click(object sender, EventArgs e)
        {

        }

        private void btDel_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void btCancle_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void BindInfoNXB(DTO_NXB _NXB)
        {
            txtMaNXB.Text = _NXB.MaNXB;
            txtTenNXB.Text = _NXB.TenNXB;
            txtNguoiDaiDien.Text = _NXB.NguoiDaiDien;
            txtSDT.Text = _NXB.Phone;
            txtDiaChi.Text = _NXB.DiaChi;
        }

        private void dgvListNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTO_NXB _NXBLib = dgvListNXB.SelectedRows[0].DataBoundItem as DTO_NXB;
            BindInfoNXB(_NXBLib);
        }
    }
}
