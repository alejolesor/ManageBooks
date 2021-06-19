using Books_Api.dbAccess.conection;
using Books_Api.dbAccess.dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.dao
{
    public class Dao : IDao
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        public Dao(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<booksDto> Get()
        {
            List<booksDto> books = new List<booksDto>();
            string storeProcedure = "getBooks";

            DataTable table = ExecuteProcedureGet(storeProcedure);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                books.Add(new booksDto
                {
                    isbn = int.Parse(table.Rows[i]["ISBN"].ToString()),
                    editorials = int.Parse(table.Rows[i]["editoriales_id"].ToString()),
                    tittle = table.Rows[i]["titulo"].ToString(),
                    synopsis = table.Rows[i]["sinopsis"].ToString(),
                    n_pages = table.Rows[i]["n_paginas"].ToString(),

                });
            }

            return books;
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
                throw new InvalidOperationException("Error execute Get books", ex);
            }

        }

        public bool Create(booksDto book) {
            return ExecuteInsert(book);
        }

        public bool ExecuteInsert(booksDto book)
        {
            try
            {
                string storeProcedure = "CreateBook";
                _connection = new conectionDb(_configuration);
                using (var con = _connection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@editorial", SqlDbType.VarChar).Value = book.editorials;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = book.tittle;
                        cmd.Parameters.Add("@sinopsis", SqlDbType.VarChar).Value = book.synopsis;
                        cmd.Parameters.Add("@n_paginas", SqlDbType.VarChar).Value = book.n_pages;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error execute insert book", ex);
            }
        }
    }
}
