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
    public class BLL_TacGia
    {
        private Connection _conn;

        public BLL_TacGia()
        {
            _conn = new Connection();
        }

        public List<DTO_TacGia> getAllTacGia()
        {
            string _strSQL = "select * from tbl_TacGia ";
            DataTable _dt = _conn.excuteSelectQuery(_strSQL, null);
            List<DTO_TacGia> _ListTacGia = new List<DTO_TacGia>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_TacGia _TacGia = new DTO_TacGia();
                    _TacGia.MaTacGia = _dt.Rows[i]["MaTacGia"]?.ToString();
                    _TacGia.TenTacGia = _dt.Rows[i]["TenTacGia"]?.ToString();
                    _TacGia.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _TacGia.Email = _dt.Rows[i]["Email"]?.ToString();
                    _TacGia.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _ListTacGia.Add(_TacGia);
                }
                return _ListTacGia;
            }
            return null;
        }

        public bool insertTacGia(DTO_TacGia _TacGia)
        {
            string _strSQL = "insert into tbl_TacGia values(@MaTacGia, @TenTacGia, @Phone, @Email, @DiaChi)";
            SqlParameter[] _sqlParameters = new SqlParameter[5];
            _sqlParameters[0] = new SqlParameter("@MaTacGia", SqlDbType.VarChar);
            _sqlParameters[0].Value = _TacGia.MaTacGia;
            _sqlParameters[1] = new SqlParameter("@TenTacGia", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _TacGia.TenTacGia;
            _sqlParameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[2].Value = _TacGia.Phone;
            _sqlParameters[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[3].Value = _TacGia.Email;
            _sqlParameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[4].Value = _TacGia.DiaChi;

            return _conn.excuteInsertQuery(_strSQL, _sqlParameters);
        }

        public bool updateTacGia(DTO_TacGia _TacGia)
        {
            string _strSQL = "update tbl_TacGia set TenTacGia = @TenTacGia, Phone = @Phone, Email = @Email, DiaChi = @DiaChi where MaTacGia = @MaTacGia";
            SqlParameter[] _sqlParameters = new SqlParameter[5];
            _sqlParameters[0] = new SqlParameter("@MaTacGia", SqlDbType.VarChar);
            _sqlParameters[0].Value = _TacGia.MaTacGia;
            _sqlParameters[1] = new SqlParameter("@TenTacGia", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _TacGia.TenTacGia;
            _sqlParameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            _sqlParameters[2].Value = _TacGia.Phone;
            _sqlParameters[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            _sqlParameters[3].Value = _TacGia.Email;
            _sqlParameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            _sqlParameters[4].Value = _TacGia.DiaChi;

            return _conn.excuteUpdateQuery(_strSQL, _sqlParameters);
        }

        public bool deleteTacGia(string MaTacGia)
        {
            string _query = "delete from tbl_TacGia where MaTacGia = @MaTacGia";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTacGia", SqlDbType.VarChar);
            sqlParameters[0].Value = MaTacGia;

            return _conn.excuteDeleteQuery(_query, sqlParameters);
        }

        public List<DTO_TacGia> searchTacGia(string input, int type)
        {
            string _strSQL = "select * from tbl_TacGia ";
            DataTable _dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            switch (type)
            {
                case 1:
                    _strSQL += "where MaTacGia like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.VarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
                case 2:
                    _strSQL += "where TenTacGia like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.NVarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
            }
            _dt = _conn.excuteSelectQuery(_strSQL, sqlParameters);
            List<DTO_TacGia> _ListTacGia = new List<DTO_TacGia>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_TacGia _TacGia = new DTO_TacGia();
                    _TacGia.MaTacGia = _dt.Rows[i]["MaTacGia"]?.ToString();
                    _TacGia.TenTacGia = _dt.Rows[i]["TenTacGia"]?.ToString();
                    _TacGia.Phone = _dt.Rows[i]["Phone"]?.ToString();
                    _TacGia.Email = _dt.Rows[i]["Email"]?.ToString();
                    _TacGia.DiaChi = _dt.Rows[i]["DiaChi"]?.ToString();
                    _ListTacGia.Add(_TacGia);
                }
                return _ListTacGia;
            }
            return null;
        }
        
    }

}
