using Books_Api.dbAccess.conection;
using Books_Api.dbAccess.dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.daoEditorials
{
    public class Dao : IDao
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        public Dao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<editorialsDto> Get()
        {
            List<editorialsDto> editorials = new List<editorialsDto>();
            string storeProcedure = "GetEditorials";

            DataTable table = ExecuteProcedureGet(storeProcedure);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                editorials.Add(new editorialsDto
                {
                    id = int.Parse(table.Rows[i]["id"].ToString()),
                    name = table.Rows[i]["nombre"].ToString(),
                    campus = table.Rows[i]["sede"].ToString()
                });
            }

            return editorials;
        }

        public DataTable ExecuteProcedureGet(string storeProcedure)
        {
            try
            {
                _connection = new conectionDb(_configuration);
                DataTable dt = new DataTable();
                using (var con = _connection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error execute Get editorial", ex);
            }

        }

        public bool Create(editorialsDto editorial)
        {
            return ExecuteInsert(editorial);
        }

        public bool ExecuteInsert(editorialsDto editorial)
        {
            try
            {
                string storeProcedure = "CreateEditorials";
                _connection = new conectionDb(_configuration);
                using (var con = _connection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = editorial.name;
                        cmd.Parameters.Add("@campus", SqlDbType.VarChar).Value = editorial.campus;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error execute insert editorial", ex);
            }
        }
    }
}
