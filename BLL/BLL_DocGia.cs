using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_DocGia
    {
        private Connection _conn;

        public BLL_DocGia()
        {
            _conn = new Connection();
        }

        public List<DTO_DocGia> getAllDocGia()
        {
            string _strSQL = "select * from tbl_DocGia ";
            DataTable _dt = _conn.excuteSelectQuery(_strSQL, null);
            List<DTO_DocGia> _ListDocGia = new List<DTO_DocGia>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_DocGia _DocGia = new DTO_DocGia();
                    _DocGia.MaDocGia = _dt.Rows[i]["MaDocGia"]?.ToString();
                    _DocGia.TenDocGia = _dt.Rows[i]["TenDocGia"]?.ToString();
                    _DocGia.NgaySinh = Convert.ToDateTime(Convert.ToDateTime(_dt.Rows[i]["NgaySinh"]?.ToString()).ToString("dd/MM/yyyy"));
                    _DocGia.GioiTinh = _dt.Rows[i]["GioiTinh"]?.ToString();
                    _DocGia.CCCD = _dt.Rows[i]["CCCD"]?.ToString();
                    _DocGia.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _DocGia.Email = _dt.Rows[i]["Email"]?.ToString();
                    _DocGia.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _ListDocGia.Add(_DocGia);
                }
                return _ListDocGia;
            }
            return null;
        }

        public bool insertDocGia(DTO_DocGia _DocGia)
        {
            string _strSQL = "insert into tbl_DocGia values(@MaDocGia, @TenDocGia, @NgaySinh, @GioiTinh, @CCCD, @Phone, @Email, @DiaChi)";
            SqlParameter[] _sqlParameters = new SqlParameter[8];
            _sqlParameters[0] = new SqlParameter("@MaDocGia", SqlDbType.VarChar);
            _sqlParameters[0].Value = _DocGia.MaDocGia;
            _sqlParameters[1] = new SqlParameter("@TenDocGia", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _DocGia.TenDocGia;
            _sqlParameters[2] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            _sqlParameters[2].Value = _DocGia.NgaySinh;
            _sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.VarChar);
            _sqlParameters[3].Value = _DocGia.GioiTinh;
            _sqlParameters[4] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            _sqlParameters[4].Value = _DocGia.CCCD;
            _sqlParameters[5] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[5].Value = _DocGia.Phone;
            _sqlParameters[6] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[6].Value = _DocGia.Email;
            _sqlParameters[7] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[7].Value = _DocGia.DiaChi;

            return _conn.excuteInsertQuery(_strSQL, _sqlParameters);
        }

        public bool updateDocGia(DTO_DocGia _DocGia)
        {
            string _strSQL = @"update tbl_DocGia set TenDocGia = @TenDocGia, NgaySinh = @NgaySinh, 
                                                    GioiTinh = @GioiTinh, CCCD = @CCCD, 
                                                    Phone = @Phone, Email = @Email, 
                                                    DiaChi = @DiaChi 
                                where MaDocGia = @MaDocGia";
            SqlParameter[] _sqlParameters = new SqlParameter[8];
            _sqlParameters[0] = new SqlParameter("@MaDocGia", SqlDbType.VarChar);
            _sqlParameters[0].Value = _DocGia.MaDocGia;
            _sqlParameters[1] = new SqlParameter("@TenDocGia", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _DocGia.TenDocGia;
            _sqlParameters[2] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            _sqlParameters[2].Value = _DocGia.NgaySinh;
            _sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.VarChar);
            _sqlParameters[3].Value = _DocGia.GioiTinh;
            _sqlParameters[4] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            _sqlParameters[4].Value = _DocGia.CCCD;
            _sqlParameters[5] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[5].Value = _DocGia.Phone;
            _sqlParameters[6] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[6].Value = _DocGia.Email;
            _sqlParameters[7] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[7].Value = _DocGia.DiaChi;

            return _conn.excuteUpdateQuery(_strSQL, _sqlParameters);
        }

        public bool deleteDocGia(string MaDocGia)
        {
            string _query = "delete from tbl_DocGia where MaDocGia = @MaDocGia";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaDocGia", SqlDbType.VarChar);
            sqlParameters[0].Value = MaDocGia;

            return _conn.excuteDeleteQuery(_query, sqlParameters);
        }

        public List<DTO_DocGia> searchDocGia(string input, int type)
        {
            string _strSQL = "select * from tbl_DocGia ";
            DataTable _dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            switch (type)
            {
                case 1:
                    _strSQL += "where MaDocGia like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.VarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
                case 2:
                    _strSQL += "where TenDocGia like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.NVarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
            }
            _dt = _conn.excuteSelectQuery(_strSQL, sqlParameters);
            List<DTO_DocGia> _ListDocGia = new List<DTO_DocGia>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_DocGia _DocGia = new DTO_DocGia();
                    _DocGia.MaDocGia = _dt.Rows[i]["MaDocGia"]?.ToString();
                    _DocGia.TenDocGia = _dt.Rows[i]["TenDocGia"]?.ToString();
                    _DocGia.NgaySinh = Convert.ToDateTime(_dt.Rows[i]["NgaySinh"]?.ToString());
                    _DocGia.GioiTinh = _dt.Rows[i]["GioiTinh"]?.ToString();
                    _DocGia.CCCD = _dt.Rows[i]["CCCD"]?.ToString();
                    _DocGia.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _DocGia.Email = _dt.Rows[i]["Email"]?.ToString();
                    _DocGia.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _ListDocGia.Add(_DocGia);
                }
                return _ListDocGia;
            }
            return null;
        }
    }
}
