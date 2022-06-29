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
    public partial class FrmKeSach : Form
    {
        public FrmKeSach()
        {
            InitializeComponent();
        }

        DTO_KeSach _KeSach = new DTO_KeSach();
        BLL_KeSach _KeSachLib = new BLL_KeSach();
        bool Type_Add = false;

        private void FrmKeSach_Load(object sender, EventArgs e)
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
            txtMaKeSach.ReadOnly = false;
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
            DialogResult _dialogResult = MessageBox.Show("Bạn có muốn xóa thông tin Kệ sách này ?", "Xóa Kệ sách", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (_dialogResult == DialogResult.Yes)
            {
                _KeSachLib.deleteKeSach(_KeSach.MaKeSach);
                MessageBox.Show("Xóa thành công Kệ sách !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmKeSach_Load(null, null);
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkNullKeSach())
            {
                MessageBox.Show("Không được để trống Mã Kệ sách và Tên Kệ sách !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _KeSach = GetInfoKeSach();
            if (Type_Add)
            {
                _KeSachLib.insertKeSach(_KeSach);
                MessageBox.Show("Thêm thành công Kệ sách !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                grcInfo_ReadOnly(true);
                grcInfo_Null();
                Type_Add = false;
            }
            else
            {
                _KeSachLib.updateKeSach(_KeSach);
                MessageBox.Show("Cập nhật thành công thông tin Kệ sách !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                BindInfoKeSach(_KeSach);
                grcInfo_ReadOnly(true);
            }

        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            btnCancle_View();
            if (dgvListKeSach.Rows.Count > 0)
            {
                BindInfoKeSach(_KeSach);
            }
            grcInfo_ReadOnly(true);

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListKeSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _KeSach = dgvListKeSach.SelectedRows[0].DataBoundItem as DTO_KeSach;
            BindInfoKeSach(_KeSach);
            cellClick_View();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkMa.Checked)
                {
                    List<DTO_KeSach> _listKeSach = _KeSachLib.searchKeSach(txtSearch.Text, 1);
                    dgvListKeSach.DataSource = _listKeSach;
                }
                if (chkTen.Checked)
                {
                    List<DTO_KeSach> _listKeSach = _KeSachLib.searchKeSach(txtSearch.Text, 2);
                    dgvListKeSach.DataSource = _listKeSach;
                }

            }
        }

        #region LoadEventClickButton
        void BindInfoKeSach(DTO_KeSach _KeSach)
        {
            txtMaKeSach.Text = _KeSach.MaKeSach;
            txtTenKeSach.Text = _KeSach.TenKeSach;
        }

        DTO_KeSach GetInfoKeSach()
        {
            DTO_KeSach _KeSach = new DTO_KeSach();
            _KeSach.MaKeSach = txtMaKeSach.Text;
            _KeSach.TenKeSach = txtTenKeSach.Text;
            return _KeSach;
        }
        void LoadDgv()
        {
            List<DTO_KeSach> _listKeSach = _KeSachLib.getAllKeSach();
            dgvListKeSach.DataSource = _listKeSach;
            btnLoad_View();
        }

        void grcInfo_ReadOnly(bool type)
        {
            txtMaKeSach.ReadOnly = true;
            txtTenKeSach.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaKeSach.Text = "";
            txtTenKeSach.Text = "";
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
            dgvListKeSach.Enabled = false;
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
            dgvListKeSach.Enabled = true;
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
            dgvListKeSach.Enabled = true;
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
            dgvListKeSach.Enabled = false;
        }

        void cellClick_View()
        {
            btChange.Enabled = true;
            btDel.Enabled = true;
        }
        bool checkNullKeSach()
        {
            if (txtMaKeSach.Text == "" || txtTenKeSach.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
