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
    public class BLL_NXB
    {
        private Connection _conn;

        public BLL_NXB()
        {
            _conn = new Connection();
        }

        public List<DTO_NXB> getAllNXB()
        {
            string _strSQL = "select * from tbl_NhaXuatBan ";
            DataTable _dt = _conn.excuteSelectQuery(_strSQL, null);
            List<DTO_NXB> _ListNXB = new List<DTO_NXB>();
            if (_dt != null)
            {
                for (int i=0; i<_dt.Rows.Count; i++)
                {
                    DTO_NXB _NXB = new DTO_NXB();
                    _NXB.MaNXB = _dt.Rows[i]["MaNXB"]?.ToString();
                    _NXB.TenNXB = _dt.Rows[i]["TenNXB"]?.ToString(); 
                    _NXB.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _NXB.Email = _dt.Rows[i]["Email"]?.ToString();
                    _NXB.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _NXB.NguoiDaiDien = _dt.Rows[i]["NguoiDaiDien"]?.ToString();
                    _ListNXB.Add(_NXB);
                }
                return _ListNXB;
            }
            return null;
        }

        public bool insertNXB(DTO_NXB _NXB)
        {
            string _strSQL = "insert into tbl_NhaXuatBan values(@MaNXB, @TenNXB, @Phone, @Email, @DiaChi, @NguoiDaiDien)";
            SqlParameter[] _sqlParameters = new SqlParameter[5];
            _sqlParameters[0] = new SqlParameter("@MaNXB", SqlDbType.VarChar);
            _sqlParameters[0].Value = _NXB.MaNXB;
            _sqlParameters[1] = new SqlParameter("@TenNXB", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _NXB.TenNXB;
            _sqlParameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[2].Value = _NXB.Phone;
            _sqlParameters[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[3].Value = _NXB.Email;
            _sqlParameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[4].Value = _NXB.DiaChi;
            _sqlParameters[5] = new SqlParameter("@NguoiDaiDien", SqlDbType.NVarChar);
            _sqlParameters[5].Value = _NXB.NguoiDaiDien;

            return _conn.excuteInsertQuery(_strSQL, _sqlParameters);
        }

        public bool updateNXB(DTO_NXB _NXB)
        {
            string _strSQL = "update tbl_NhaXuatBan set TenNXB = @TenNXB, Phone = @Phone, Email = @Email, DiaChi = @DiaChi, NguoiDaiDien = @NguoiDaiDien where MaNXB = @MaNXB";
            SqlParameter[] _sqlParameters = new SqlParameter[5];
            _sqlParameters[0] = new SqlParameter("@MaNXB", SqlDbType.VarChar);
            _sqlParameters[0].Value = _NXB.MaNXB;
            _sqlParameters[1] = new SqlParameter("@TenNXB", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _NXB.TenNXB;
            _sqlParameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[2].Value = _NXB.Phone;
            _sqlParameters[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[3].Value = _NXB.Email;
            _sqlParameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[4].Value = _NXB.DiaChi;
            _sqlParameters[5] = new SqlParameter("@NguoiDaiDien", SqlDbType.NVarChar);
            _sqlParameters[5].Value = _NXB.NguoiDaiDien;

            return _conn.excuteUpdateQuery(_strSQL, _sqlParameters);
        }

        public bool deleteNXB(string MaNXB)
        {
            string _query = "delete from tbl_NhaXuatBan where MaNXB = @MaNXB";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaNXB", SqlDbType.VarChar);
            sqlParameters[0].Value = MaNXB;

            return _conn.excuteDeleteQuery(_query, sqlParameters);
        }

        public List<DTO_NXB> searchNXB(string input, int type)
        {
            string _strSQL = "select * from tbl_NhaXuatBan ";
            DataTable _dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            switch (type)
            {
                case 1:
                    _strSQL += "where MaNXB like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.VarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
                case 2:
                    _strSQL += "where TenNXB like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.NVarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
            }
            _dt = _conn.excuteSelectQuery(_strSQL, sqlParameters);
            List<DTO_NXB> _ListNXB = new List<DTO_NXB>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_NXB _NXB = new DTO_NXB();
                    _NXB.MaNXB = _dt.Rows[i]["MaNXB"]?.ToString();
                    _NXB.TenNXB = _dt.Rows[i]["TenNXB"]?.ToString();
                    _NXB.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _NXB.Email = _dt.Rows[i]["Email"]?.ToString();
                    _NXB.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _NXB.NguoiDaiDien = _dt.Rows[i]["NguoiDaiDien"]?.ToString();
                    _ListNXB.Add(_NXB);
                }
                return _ListNXB;
            }
            return null;
        }
    }
}
