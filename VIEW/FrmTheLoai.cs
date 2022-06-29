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
    public partial class FrmTheLoai : Form
    {
        public FrmTheLoai()
        {
            InitializeComponent();
        }

        private void FrmTheLoai_Load(object sender, EventArgs e)
        {
            LoadDgv();
            grcInfo_ReadOnly(true);
            grcInfo_Null();
        }

        DTO_TheLoai _TheLoai = new DTO_TheLoai();
        BLL_TheLoai _TheLoaiLib = new BLL_TheLoai();
        bool Type_Add = false;

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
            txtMaTheLoai.ReadOnly = false;
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
            DialogResult _dialogResult = MessageBox.Show("Bạn có muốn xóa thông tin Thể loại này ?", "Xóa Thể loại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (_dialogResult == DialogResult.Yes)
            {
                _TheLoaiLib.deleteTheLoai(_TheLoai.MaTheLoai);
                MessageBox.Show("Xóa thành công Thể loại !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmTheLoai_Load(null, null);
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkNullTheLoai())
            {
                MessageBox.Show("Không được để trống Mã Thể loại và Tên Thể loại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TheLoai = GetInfoTheLoai();
            if (Type_Add)
            {
                _TheLoaiLib.insertTheLoai(_TheLoai);
                MessageBox.Show("Thêm thành công Thể loại !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                grcInfo_ReadOnly(true);
                grcInfo_Null();
                Type_Add = false;
            }
            else
            {
                _TheLoaiLib.updateTheLoai(_TheLoai);
                MessageBox.Show("Cập nhật thành công thông tin Thể loại !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                BindInfoTheLoai(_TheLoai);
                grcInfo_ReadOnly(true);
            }

        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            btnCancle_View();
            if (dgvListTheLoai.Rows.Count > 0)
            {
                BindInfoTheLoai(_TheLoai);
            }
            grcInfo_ReadOnly(true);

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _TheLoai = dgvListTheLoai.SelectedRows[0].DataBoundItem as DTO_TheLoai;
            BindInfoTheLoai(_TheLoai);
            cellClick_View();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkMa.Checked)
                {
                    List<DTO_TheLoai> _listTheLoai = _TheLoaiLib.searchTheLoai(txtSearch.Text, 1);
                    dgvListTheLoai.DataSource = _listTheLoai;
                }
                if (chkTen.Checked)
                {
                    List<DTO_TheLoai> _listTheLoai = _TheLoaiLib.searchTheLoai(txtSearch.Text, 2);
                    dgvListTheLoai.DataSource = _listTheLoai;
                }

            }
        }

        #region LoadEventClickButton
        void BindInfoTheLoai(DTO_TheLoai _TheLoai)
        {
            txtMaTheLoai.Text = _TheLoai.MaTheLoai;
            txtTenTheLoai.Text = _TheLoai.TenTheLoai;
        }

        DTO_TheLoai GetInfoTheLoai()
        {
            DTO_TheLoai _TheLoai = new DTO_TheLoai();
            _TheLoai.MaTheLoai = txtMaTheLoai.Text;
            _TheLoai.TenTheLoai = txtTenTheLoai.Text;
            return _TheLoai;
        }
        void LoadDgv()
        {
            List<DTO_TheLoai> _listTheLoai = _TheLoaiLib.getAllTheLoai();
            dgvListTheLoai.DataSource = _listTheLoai;
            btnLoad_View();
        }

        void grcInfo_ReadOnly(bool type)
        {
            txtMaTheLoai.ReadOnly = true;
            txtTenTheLoai.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaTheLoai.Text = "";
            txtTenTheLoai.Text = "";
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
            dgvListTheLoai.Enabled = false;
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
            dgvListTheLoai.Enabled = true;
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
            dgvListTheLoai.Enabled = true;
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
            dgvListTheLoai.Enabled = false;
        }

        void cellClick_View()
        {
            btChange.Enabled = true;
            btDel.Enabled = true;
        }
        bool checkNullTheLoai()
        {
            if (txtMaTheLoai.Text == "" || txtTenTheLoai.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
