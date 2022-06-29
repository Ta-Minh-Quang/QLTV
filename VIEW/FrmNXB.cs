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

        DTO_NXB _NXB = new DTO_NXB();
        BLL_NXB _NXBLib = new BLL_NXB();
        bool Type_Add = false;

        private void FrmNXB_Load(object sender, EventArgs e)
        {
            LoadDgv();
            grcInfo_ReadOnly(true);
            grcInfo_Null();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadDgv();
            grcInfo_ReadOnly(true);
            grcInfo_Null();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            grcInfo_Null();
            grcInfo_ReadOnly(false);
            txtMaNXB.ReadOnly = false;
            btnAddView();
            Type_Add = true;
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            btnChange_View();
            grcInfo_ReadOnly(false);
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Bạn có muốn xóa thông tin Nhà xuất bản này ?", "Xóa Nhà xuất bản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (_dialogResult == DialogResult.Yes)
            {
                _NXBLib.deleteNXB(_NXB.MaNXB);
                MessageBox.Show("Xóa thành công Nhà xuất bản !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmNXB_Load(null, null);
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkNullNXB())
            {
                MessageBox.Show("Không được để trống Mã NXB và Tên NXB !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NXB = GetInfoNXB();
            if (Type_Add)
            {
                _NXBLib.insertNXB(_NXB);
                MessageBox.Show("Thêm thành công Nhà xuất bản !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                grcInfo_ReadOnly(true);
                grcInfo_Null();
                Type_Add = false;
            }
            else
            {
                _NXBLib.updateNXB(_NXB);
                MessageBox.Show("Cập nhật thành công thông tin Nhà xuất bản !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                BindInfoNXB(_NXB);
                grcInfo_ReadOnly(true);
            }
            
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            btnCancle_View();
            if (dgvListNXB.Rows.Count > 0)
            {
                BindInfoNXB(_NXB);
            }
            grcInfo_ReadOnly(true);

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _NXB = dgvListNXB.SelectedRows[0].DataBoundItem as DTO_NXB;
            BindInfoNXB(_NXB);
            cellClick_View();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkMa.Checked)
                {
                    List<DTO_NXB> _listNXB = _NXBLib.searchNXB(txtSearch.Text, 1);
                    dgvListNXB.DataSource = _listNXB;
                }
                if (chkTen.Checked)
                {
                    List<DTO_NXB> _listNXB = _NXBLib.searchNXB(txtSearch.Text, 2);
                    dgvListNXB.DataSource = _listNXB;
                }
                
            }
        }

        #region LoadEventClickButton
        void BindInfoNXB(DTO_NXB _NXB)
        {
            txtMaNXB.Text = _NXB.MaNXB;
            txtTenNXB.Text = _NXB.TenNXB;
            txtNguoiDaiDien.Text = _NXB.NguoiDaiDien;
            txtSDT.Text = _NXB.Phone;
            txtDiaChi.Text = _NXB.DiaChi;
            txtEmail.Text = _NXB.Email;
        }

        DTO_NXB GetInfoNXB()
        {
            DTO_NXB _NXB = new DTO_NXB();
            _NXB.MaNXB = txtMaNXB.Text;
            _NXB.TenNXB = txtTenNXB.Text;
            _NXB.NguoiDaiDien = txtNguoiDaiDien.Text;
            _NXB.Phone = txtSDT.Text;
            _NXB.DiaChi = txtDiaChi.Text;
            _NXB.Email = txtEmail.Text;
            return _NXB;
        }
        void LoadDgv()
        {
            List<DTO_NXB> _listNXB = _NXBLib.getAllNXB();
            dgvListNXB.DataSource = _listNXB;
            btnLoad_View();
        }

        void grcInfo_ReadOnly(bool type)
        {
            txtMaNXB.ReadOnly = true;
            txtTenNXB.ReadOnly = type;
            txtNguoiDaiDien.ReadOnly = type;
            txtDiaChi.ReadOnly = type;
            txtSDT.ReadOnly = type;
            txtEmail.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtNguoiDaiDien.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtSearch.Text = "";
            txtEmail.Text = "";
        }

        void btnLoad_View()
        {
            btAdd.Enabled = true;
            btChange.Enabled = false;
            btDel.Enabled = false;
            btSave.Enabled = false;
            btCancle.Enabled = false;
        }

        void btnChange_View()
        {
            grcSearch.Enabled = false;
            btRefresh.Enabled = false;
            btAdd.Enabled = false;
            btChange.Enabled = false;
            btDel.Enabled = false;
            btSave.Enabled = true;
            btCancle.Enabled = true;
            dgvListNXB.Enabled = false;
        }

        void btnCancle_View()
        {
            grcSearch.Enabled = true;
            btRefresh.Enabled = true;
            btAdd.Enabled = true;
            btChange.Enabled = true;
            btDel.Enabled = true;
            btSave.Enabled = false;
            btCancle.Enabled = false;
            dgvListNXB.Enabled = true;
        }

        void btnSaveView()
        {
            grcSearch.Enabled = true;
            btRefresh.Enabled = true;
            btAdd.Enabled = true;
            btChange.Enabled = false;
            btDel.Enabled = false;
            btSave.Enabled = false;
            btCancle.Enabled = false;
            dgvListNXB.Enabled = true;
        }
        void btnAddView()
        {
            grcSearch.Enabled = false;
            btRefresh.Enabled = false;
            btAdd.Enabled = false;
            btChange.Enabled = false;
            btDel.Enabled = false;
            btSave.Enabled = true;
            btCancle.Enabled = true;
            dgvListNXB.Enabled = false;
        }

        void cellClick_View()
        {
            btChange.Enabled = true;
            btDel.Enabled = true;
        }
        bool checkNullNXB()
        {
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
