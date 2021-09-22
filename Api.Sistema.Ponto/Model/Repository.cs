using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Sistema.Ponto.Model
{
    public class Repository
    {
        private string conStr;
        public Repository()
        {
            conStr = @"Server = DESKTOP - KCV0913; Database = RH; Trusted_Connection = True;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }
        }

        //INSERT
        public void add(LoginModel loginModel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO INFO (Loguin, senha, Id, CPF)

                             VALUES(@Loguin, @senha, @Id, @CPF)";
                dbConnection.Open();
                dbConnection.Execute(sql, loginModel);
            }
        }

        internal LoginModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<LoginModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoginModel GetByLoguin(string Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM INFO WHERE Id= @Id";
                dbConnection.Open();
                return dbConnection.Query<LoginModel>(sql, new { Id = Id }).FirstOrDefault();
            }
        }

        public void Update(LoginModel loginModel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"UPDATE INFO SET Loguin= @Loguin, senha = @senha, CPF = @CPF WHERE Id= @Id";
                dbConnection.Open();
                dbConnection.Query<LoginModel>(sql, loginModel);
            }

        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"DELETE FROM INFO WHERE Id= @Id";
                dbConnection.Open();
                dbConnection.Query<LoginModel>(sql, new { Id = Id });
            }
        }
    }
}
