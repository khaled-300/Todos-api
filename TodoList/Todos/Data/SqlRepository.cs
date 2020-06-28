using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Todos.Model;

namespace Todos.Data
{
    public class SqlRepository : IRepository
    {
        private static readonly ILog _Log = LogManager.GetLogger(typeof(SqlRepository));


        public IConfiguration Configuration { get; }

        public IDbConnection db { get; set; }


        public SqlRepository(IDbConnection db)
        {
            this.db = db;
        }


        public Todo Create(Todo todos)
        {
            try
            {
                todos.Id = Guid.NewGuid();
                string query = @"INSERT INTO TodoList ([id], [message]) VALUES ( @Id , @Message)";
                db.Execute(query,new { todos.Id, todos.Message });

                return todos;
            }
            catch (Exception ex)
            {
                _Log.ErrorFormat("Error connecting to sql server \n {0}", ex);
                throw ex;
            }
        }

        public void DeleteById(string id)
        {
            try
            {
                string query = @"DELETE TodoList WHERE id = @id";
                db.Execute(query, new { id});
            }
            catch (Exception ex)
            {
                _Log.ErrorFormat("Error connecting to sql server \n {0}", ex);
                throw ex;
            }
        }

        public IList<Todo> FindAll()
        {
            try
            {
                string query = @"SELECT * from TodoList";
                var todos = db.Query<Todo>(query).ToList();

                return todos;
            }
            catch (Exception ex)
            {
                _Log.ErrorFormat("Error connecting to sql server \n {0}", ex);
                throw ex;
            }
        }

        public Todo FindById(string id)
        {
            try
            {
                string query = @"SELECT * from TodoList where id = @id";

                Todo todo = db.Query<Todo>(query, new { id }).FirstOrDefault();

                return todo;
            }
            catch (Exception ex)
            {
                _Log.ErrorFormat("Error connecting to sql server \n {0}", ex);
                throw ex;
            }
        }

        public void UpdateById(string id, Todo newTodo)
        {
            try
            {
                string query = @"UPDATE TodoList SET Message = @Message where id = @id";
                db.Execute(query, new { id, newTodo.Message });
            }
            catch (Exception ex)
            {
                _Log.ErrorFormat("Error connecting to sql server \n {0}", ex);
                throw ex;
            }
        }
    }
}
