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
    public partial class FrmTacGia : Form
    {
        public FrmTacGia()
        {
            InitializeComponent();
        }


        DTO_TacGia _TacGia = new DTO_TacGia();
        BLL_TacGia _TacGiaLib = new BLL_TacGia();
        bool Type_Add = false;

        private void FrmTacGia_Load(object sender, EventArgs e)
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
            txtMaTacGia.ReadOnly = false;
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
            DialogResult _dialogResult = MessageBox.Show("Bạn có muốn xóa thông tin Tác giả này ?", "Xóa Tác giả", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (_dialogResult == DialogResult.Yes)
            {
                _TacGiaLib.deleteTacGia(_TacGia.MaTacGia);
                MessageBox.Show("Xóa thành công Tác giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmTacGia_Load(null, null);
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkNullTacGia())
            {
                MessageBox.Show("Không được để trống Mã Tác giả và Tên Tác giả !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TacGia = GetInfoTacGia();
            if (Type_Add)
            {
                _TacGiaLib.insertTacGia(_TacGia);
                MessageBox.Show("Thêm thành công Tác giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                grcInfo_ReadOnly(true);
                grcInfo_Null();
                Type_Add = false;
            }
            else
            {
                _TacGiaLib.updateTacGia(_TacGia);
                MessageBox.Show("Cập nhật thành công thông tin Tác giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                BindInfoTacGia(_TacGia);
                grcInfo_ReadOnly(true);
            }

        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            btnCancle_View();
            if (dgvListTacGia.Rows.Count > 0)
            {
                BindInfoTacGia(_TacGia);
            }
            grcInfo_ReadOnly(true);

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _TacGia = dgvListTacGia.SelectedRows[0].DataBoundItem as DTO_TacGia;
            BindInfoTacGia(_TacGia);
            cellClick_View();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkMa.Checked)
                {
                    List<DTO_TacGia> _listTacGia = _TacGiaLib.searchTacGia(txtSearch.Text, 1);
                    dgvListTacGia.DataSource = _listTacGia;
                }
                if (chkTen.Checked)
                {
                    List<DTO_TacGia> _listTacGia = _TacGiaLib.searchTacGia(txtSearch.Text, 2);
                    dgvListTacGia.DataSource = _listTacGia;
                }

            }
        }

        #region LoadEventClickButton
        void BindInfoTacGia(DTO_TacGia _TacGia)
        {
            txtMaTacGia.Text = _TacGia.MaTacGia;
            txtTenTacGia.Text = _TacGia.TenTacGia;
            txtSDT.Text = _TacGia.Phone;
            txtDiaChi.Text = _TacGia.DiaChi;
            txtEmail.Text = _TacGia.Email;
        }

        DTO_TacGia GetInfoTacGia()
        {
            DTO_TacGia _TacGia = new DTO_TacGia();
            _TacGia.MaTacGia = txtMaTacGia.Text;
            _TacGia.TenTacGia = txtTenTacGia.Text;
            _TacGia.Phone = txtSDT.Text;
            _TacGia.DiaChi = txtDiaChi.Text;
            _TacGia.Email = txtEmail.Text;
            return _TacGia;
        }
        void LoadDgv()
        {
            List<DTO_TacGia> _listTacGia = _TacGiaLib.getAllTacGia();
            dgvListTacGia.DataSource = _listTacGia;
            btnLoad_View();
        }

        void grcInfo_ReadOnly(bool type)
        {
            txtMaTacGia.ReadOnly = true;
            txtTenTacGia.ReadOnly = type;
            txtDiaChi.ReadOnly = type;
            txtSDT.ReadOnly = type;
            txtEmail.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaTacGia.Text = "";
            txtTenTacGia.Text = "";
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
            dgvListTacGia.Enabled = false;
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
            dgvListTacGia.Enabled = true;
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
            dgvListTacGia.Enabled = true;
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
            dgvListTacGia.Enabled = false;
        }

        void cellClick_View()
        {
            btChange.Enabled = true;
            btDel.Enabled = true;
        }
        bool checkNullTacGia()
        {
            if (txtMaTacGia.Text == "" || txtTenTacGia.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
