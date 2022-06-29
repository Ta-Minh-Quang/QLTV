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
    public class BLL_KeSach
    {
        private Connection _conn;

        public BLL_KeSach()
        {
            _conn = new Connection();
        }

        public List<DTO_KeSach> getAllKeSach()
        {
            string _strSQL = "select * from tbl_KeSach ";
            DataTable _dt = _conn.excuteSelectQuery(_strSQL, null);
            List<DTO_KeSach> _ListKeSach = new List<DTO_KeSach>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_KeSach _KeSach = new DTO_KeSach();
                    _KeSach.MaKeSach = _dt.Rows[i]["MaKeSach"]?.ToString();
                    _KeSach.TenKeSach = _dt.Rows[i]["TenKeSach"]?.ToString();
                    _ListKeSach.Add(_KeSach);
                }
                return _ListKeSach;
            }
            return null;
        }

        public bool insertKeSach(DTO_KeSach _KeSach)
        {
            string _strSQL = "insert into tbl_KeSach values(@MaKeSach, @TenKeSach)";
            SqlParameter[] _sqlParameters = new SqlParameter[2];
            _sqlParameters[0] = new SqlParameter("@MaKeSach", SqlDbType.VarChar);
            _sqlParameters[0].Value = _KeSach.MaKeSach;
            _sqlParameters[1] = new SqlParameter("@TenKeSach", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _KeSach.TenKeSach;

            return _conn.excuteInsertQuery(_strSQL, _sqlParameters);
        }

        public bool updateKeSach(DTO_KeSach _KeSach)
        {
            string _strSQL = "update tbl_KeSach set TenKeSach = @TenKeSach where MaKeSach = @MaKeSach";
            SqlParameter[] _sqlParameters = new SqlParameter[2];
            _sqlParameters[0] = new SqlParameter("@MaKeSach", SqlDbType.VarChar);
            _sqlParameters[0].Value = _KeSach.MaKeSach;
            _sqlParameters[1] = new SqlParameter("@TenKeSach", SqlDbType.NVarChar);
            _sqlParameters[1].Value = _KeSach.TenKeSach;

            return _conn.excuteUpdateQuery(_strSQL, _sqlParameters);
        }

        public bool deleteKeSach(string MaKeSach)
        {
            string _query = "delete from tbl_KeSach where MaKeSach = @MaKeSach";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaKeSach", SqlDbType.VarChar);
            sqlParameters[0].Value = MaKeSach;

            return _conn.excuteDeleteQuery(_query, sqlParameters);
        }

        public List<DTO_KeSach> searchKeSach(string input, int type)
        {
            string _strSQL = "select * from tbl_KeSach ";
            DataTable _dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            switch (type)
            {
                case 1:
                    _strSQL += "where MaKeSach like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.VarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
                case 2:
                    _strSQL += "where TenKeSach like @Input";
                    sqlParameters[0] = new SqlParameter("@Input", SqlDbType.NVarChar);
                    sqlParameters[0].Value = "%" + input + "%";
                    break;
            }
            _dt = _conn.excuteSelectQuery(_strSQL, sqlParameters);
            List<DTO_KeSach> _ListKeSach = new List<DTO_KeSach>();
            if (_dt != null)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DTO_KeSach _KeSach = new DTO_KeSach();
                    _KeSach.MaKeSach = _dt.Rows[i]["MaKeSach"]?.ToString();
                    _KeSach.TenKeSach = _dt.Rows[i]["TenKeSach"]?.ToString();
                    _ListKeSach.Add(_KeSach);
                }
                return _ListKeSach;
            }
            return null;
        }
    }
}
