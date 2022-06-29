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
    public partial class FrmDocGia : Form
    {
        public FrmDocGia()
        {
            InitializeComponent();
        }

        DTO_DocGia _DocGia = new DTO_DocGia();
        BLL_DocGia _DocGiaLib = new BLL_DocGia();
        bool Type_Add = false;

        private void FrmDocGia_Load(object sender, EventArgs e)
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
            txtMaDocGia.ReadOnly = false;
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
            DialogResult _dialogResult = MessageBox.Show("Bạn có muốn xóa thông tin Độc giả này ?", "Xóa Độc giả", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (_dialogResult == DialogResult.Yes)
            {
                _DocGiaLib.deleteDocGia(_DocGia.MaDocGia);
                MessageBox.Show("Xóa thành công Độc giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDocGia_Load(null, null);
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkNullDocGia())
            {
                MessageBox.Show("Không được để trống Mã Độc giả và Tên Độc giả !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DocGia = GetInfoDocGia();
            if (Type_Add)
            {
                _DocGiaLib.insertDocGia(_DocGia);
                MessageBox.Show("Thêm thành công Độc giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                grcInfo_ReadOnly(true);
                grcInfo_Null();
                Type_Add = false;
            }
            else
            {
                _DocGiaLib.updateDocGia(_DocGia);
                MessageBox.Show("Cập nhật thành công thông tin Độc giả !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();
                btnSaveView();
                BindInfoDocGia(_DocGia);
                grcInfo_ReadOnly(true);
            }

        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            btnCancle_View();
            if (dgvListDocGia.Rows.Count > 0)
            {
                BindInfoDocGia(_DocGia);
            }
            grcInfo_ReadOnly(true);

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _DocGia = dgvListDocGia.SelectedRows[0].DataBoundItem as DTO_DocGia;
            BindInfoDocGia(_DocGia);
            cellClick_View();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkMa.Checked)
                {
                    List<DTO_DocGia> _listDocGia = _DocGiaLib.searchDocGia(txtSearch.Text, 1);
                    dgvListDocGia.DataSource = _listDocGia;
                }
                if (chkTen.Checked)
                {
                    List<DTO_DocGia> _listDocGia = _DocGiaLib.searchDocGia(txtSearch.Text, 2);
                    dgvListDocGia.DataSource = _listDocGia;
                }

            }
        }

        #region LoadEventClickButton
        void BindInfoDocGia(DTO_DocGia _DocGia)
        {
            txtMaDocGia.Text = _DocGia.MaDocGia;
            txtTenDocGia.Text = _DocGia.TenDocGia;
            dtNgaySinh.Value = _DocGia.NgaySinh;
            if (_DocGia.GioiTinh == "Nam")
            {
                chkNam.Checked = true;
            }
            if (_DocGia.GioiTinh == "Nữ")
            {
                chkNu.Checked = true;
            }
            txtCCCD.Text = _DocGia.CCCD;
            txtSDT.Text = _DocGia.Phone;
            txtDiaChi.Text = _DocGia.DiaChi;
            txtEmail.Text = _DocGia.Email;
        }

        DTO_DocGia GetInfoDocGia()
        {
            DTO_DocGia _DocGia = new DTO_DocGia();
            _DocGia.MaDocGia = txtMaDocGia.Text;
            _DocGia.TenDocGia = txtTenDocGia.Text;
            _DocGia.NgaySinh = dtNgaySinh.Value;
            if (chkNam.Checked)
            {
                _DocGia.GioiTinh = "Nam";
            }
            if (chkNu.Checked)
            {
                _DocGia.GioiTinh = "Nữ";
            }
            _DocGia.CCCD = txtCCCD.Text;
            _DocGia.Phone = txtSDT.Text;
            _DocGia.DiaChi = txtDiaChi.Text;
            _DocGia.Email = txtEmail.Text;
            return _DocGia;
        }
        void LoadDgv()
        {
            List<DTO_DocGia> _listDocGia = _DocGiaLib.getAllDocGia();
            dgvListDocGia.DataSource = _listDocGia;
            btnLoad_View();
        }

        void grcInfo_ReadOnly(bool type)
        {
            txtMaDocGia.ReadOnly = true;
            txtTenDocGia.ReadOnly = type;
            if (type == true)
            {
                dtNgaySinh.Enabled = false;
                chkNam.Enabled = false;
                chkNu.Enabled = false;
            }
            else
            {
                dtNgaySinh.Enabled = true;
                chkNam.Enabled = true;
                chkNu.Enabled = true;
            }
            txtCCCD.ReadOnly = type;
            txtDiaChi.ReadOnly = type;
            txtSDT.ReadOnly = type;
            txtEmail.ReadOnly = type;
        }

        void grcInfo_Null()
        {
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            chkNam.Checked = false;
            chkNu.Checked = false;
            txtCCCD.Text = "";
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
            dgvListDocGia.Enabled = false;
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
            dgvListDocGia.Enabled = true;
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
            dgvListDocGia.Enabled = true;
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
            dgvListDocGia.Enabled = false;
        }

        void cellClick_View()
        {
            btChange.Enabled = true;
            btDel.Enabled = true;
        }
        bool checkNullDocGia()
        {
            if (txtMaDocGia.Text == "" || txtTenDocGia.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

        
    }
}
