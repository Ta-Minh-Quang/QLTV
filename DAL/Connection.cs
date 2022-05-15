using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Connection
    {
        private string stringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        private SqlDataAdapter _myAdapter;

        public SqlConnection getConnection()
        {
            SqlConnection _conn = new SqlConnection(stringConnection);
            return openConnect(_conn);
        }

        private SqlConnection openConnect(SqlConnection _conn)
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(stringConnection);
            }
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            return _conn;
        }

        public DataTable excuteSelectQuery(String _query, SqlParameter[] _sqlParameter)
        {
            SqlCommand _myCommand = new SqlCommand();
            DataTable _dt = new DataTable();
            DataSet _ds = new DataSet();
            _myAdapter = new SqlDataAdapter();
            using (var _conn = getConnection())
            {
                try
                {
                    _myCommand.Connection = _conn;
                    _myCommand.CommandText = _query;
                    if (_sqlParameter != null)
                    {
                        _myCommand.Parameters.AddRange(_sqlParameter);
                    }
                    _myCommand.ExecuteNonQuery();
                    _myAdapter.SelectCommand = _myCommand;
                    _myAdapter.Fill(_ds);
                    _dt = _ds.Tables[0];
                }
                catch (Exception e)
                {
                    Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                    return null;
                }
            }
            return _dt;
        }

        public bool excuteInsertQuery(String _query, SqlParameter[] _sqlParameter)
        {
            SqlCommand _myCommand = new SqlCommand();
            _myAdapter = new SqlDataAdapter();
            using (var _conn = getConnection())
            {
                try
                {
                    _myCommand.Connection = _conn;
                    _myCommand.CommandText = _query;
                    _myCommand.Parameters.AddRange(_sqlParameter);
                    _myAdapter.InsertCommand = _myCommand;
                    _myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                    return false;
                }
            }
            return true;
        }

        public bool excuteUpdateQuery(String _query, SqlParameter[] _sqlParameter)
        {
            SqlCommand _myCommand = new SqlCommand();
            _myAdapter = new SqlDataAdapter();

            using (var _conn = getConnection())
            {
                try
                {
                    _myCommand.Connection = _conn;
                    _myCommand.CommandText = _query;
                    _myCommand.Parameters.AddRange(_sqlParameter);
                    _myAdapter.UpdateCommand = _myCommand;
                    _myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                    return false;
                }
            }
            return true;
        }

        public bool excuteDeleteQuery(String _query, SqlParameter[] _sqlParameter)
        {
            SqlCommand _myCommand = new SqlCommand();
            _myAdapter = new SqlDataAdapter();

            using (var _conn = getConnection())
            {
                try
                {
                    _myCommand.Connection = _conn;
                    _myCommand.CommandText = _query;
                    _myCommand.Parameters.AddRange(_sqlParameter);
                    _myAdapter.DeleteCommand = _myCommand;
                    _myCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                    return false;
                }
            }
            return true;

        }


    }
}
