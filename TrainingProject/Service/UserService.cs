using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using TrainingProject.Controllers;

namespace TrainingProject.Service
{
    class UserService
    {
        public  List<User> UserList { get; set; }

        //Trazer todos usuarios do BD
        public  void QueryUser()
        {
            string queryString = "select id, name, register_date as RegisterDate from users";

            using (var con = new DbProvider().Connection)
            {
                UserList = con.Query<User>(queryString).ToList();
            }
            if (UserList != null)
            {
                foreach (var user in UserList)
                {
                    Console.WriteLine(user);
                }
            }
        }

       

        //Adicionar usuario via comando sql
        public int InsertUser(DynamicParameters InsertValues)
        {
            string sql = @"
                   insert into users 
                        ( name, register_date, last_changed_date)
                    values
                       (@name, @registerDate, @lastChangeDate)
            ";
            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sql, InsertValues);
                return count;
            }
                
        }

        //Deletando usuario via comando sql

        public int DeleteUser(int delId)
        {
            string sqlDel = @"
                    delete from users
                    where
                      id = @delId
            ";

            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sqlDel, new { delId });
                return count;
            }
                
        }

        public int UpdateUser(DynamicParameters UpdateValues)
        {
            UpdateValues.Add("lastChangeDate", DateTime.Now);

            string sql = @"
                UPDATE users
                SET name = @name, last_changed_date = @lastChangeDate
                WHERE id = @id;
            ";

            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sql, UpdateValues);
                return count;
            }

        }

    }
}
