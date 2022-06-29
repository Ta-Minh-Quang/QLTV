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
    public class BLL_TheLoai
    {
        private Connection _conn;

        public BLL_TheLoai()
        {
            _conn = new Connection();
        }

        public List<DTO_TheLoai> getAllTheLoai()
        {
            string _strSQL = "select * from tbl_TheLoai ";
            DataTable _dt = _conn.excuteSelectQuery(_strSQL, null);
            List<DTO_TheLoai> _ListTheLoai = new List<DTO_TheLoai>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_TheLoai _TheLoai = new DTO_TheLoai();
                    _TheLoai.MaTheLoai = _dt.Rows[i]["MaTheLoai"]?.ToString();
                    _TheLoai.TenTheLoai = _dt.Rows[i]["TenTheLoai"]?.ToString();
                    _ListTheLoai.Add(_TheLoai);
                }
                return _ListTheLoai;
            }
            return null;
        }

        public bool insertTheLoai(DTO_TheLoai _TheLoai)
        {
            string _strSQL = "insert into tbl_TheLoai values(@MaTheLoai, @TenTheLoai)";
            SqlParameter[] _sqlParameters = new SqlParameter[2];
            _sqlParameters[0] = new SqlParameter("@MaTheLoai", SqlDbType.VarChar);
            _sqlParameters[0].Value = _TheLoai.MaTheLoai;
            _sqlParameters[1] = new SqlParameter("@TenTheLoai", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _TheLoai.TenTheLoai;

            return _conn.excuteInsertQuery(_strSQL, _sqlParameters);
        }

        public bool updateTheLoai(DTO_TheLoai _TheLoai)
        {
            string _strSQL = "update tbl_TheLoai set TenTheLoai = @TenTheLoai where MaTheLoai = @MaTheLoai";
            SqlParameter[] _sqlParameters = new SqlParameter[2];
            _sqlParameters[0] = new SqlParameter("@MaTheLoai", SqlDbType.VarChar);
            _sqlParameters[0].Value = _TheLoai.MaTheLoai;
            _sqlParameters[1] = new SqlParameter("@TenTheLoai", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _TheLoai.TenTheLoai;

            return _conn.excuteUpdateQuery(_strSQL, _sqlParameters);
        }

        public bool deleteTheLoai(string MaTheLoai)
        {
            string _query = "delete from tbl_TheLoai where MaTheLoai = @MaTheLoai";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTheLoai", SqlDbType.VarChar);
            sqlParameters[0].Value = MaTheLoai;

            return _conn.excuteDeleteQuery(_query, sqlParameters);
        }

        public List<DTO_TheLoai> searchTheLoai(string input, int type)
        {
            string _strSQL = "select * from tbl_TheLoai ";
            DataTable _dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            switch (type)
            {
                case 1:
                    _strSQL += "where MaTheLoai like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.VarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
                case 2:
                    _strSQL += "where TenTheLoai like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.NVarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
            }
            _dt = _conn.excuteSelectQuery(_strSQL, sqlParameters);
            List<DTO_TheLoai> _ListTheLoai = new List<DTO_TheLoai>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_TheLoai _TheLoai = new DTO_TheLoai();
                    _TheLoai.MaTheLoai = _dt.Rows[i]["MaTheLoai"]?.ToString();
                    _TheLoai.TenTheLoai = _dt.Rows[i]["TenTheLoai"]?.ToString();
                    _ListTheLoai.Add(_TheLoai);
                }
                return _ListTheLoai;
            }
            return null;
        }
    }
}
