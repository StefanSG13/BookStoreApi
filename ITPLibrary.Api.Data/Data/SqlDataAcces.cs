using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Data
{
    public class SqlDataAcces<T> : ISqlDataAcces<T> where T : class
    {
        private readonly IDbConnection _connection;

        public SqlDataAcces()
        {
            _connection = new SqlConnection(SD.SqlDeffaultConnection);
        }

        public T Get(string queryString)
        {
            _connection.Open();
            var obj = _connection.QueryFirstOrDefault<T>(queryString);
            _connection.Close();
            return obj;
        }

        public IEnumerable<T> GetAll(string queryString)
        {
            IEnumerable<T> listOfEntities;
            _connection.Open();
            listOfEntities = _connection.Query<T>(queryString);
            _connection.Close();
            return listOfEntities;
        }

        public void Update(string sqlCommand, T entity)
        {
            _connection.Open();
            _connection.Execute(sqlCommand, entity);
            _connection.Close();
        }

        public void Add(string sqlCommand, T entity)
        {
            _connection.Open();
            _connection.Execute(sqlCommand, entity);
            _connection.Close();
        }
        public void Delete(string sqlCommand, int id)
        {
            _connection.Open();
            _connection.Execute(sqlCommand, new {Id=id});
            _connection.Close();
        }

    }
}
