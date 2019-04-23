﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Controllers;

namespace TrainingProject.Service
{
    class StatusService
    {
        public List<Type> TypeList { get; set; }

        public void QueryStatus()
        {
            string queryString = "select * from plan_status";

            using (var con = new DbProvider().Connection)
            {
                TypeList = con.Query<Type>(queryString).ToList();
            }
        }

        public void PrintStatus()
        {
            if (TypeList != null)
            {
                foreach (var type in TypeList)
                {
                    Console.WriteLine(type);
                }
            }
        }

        public int InserStatus(DynamicParameters InsertValues)
        {
            string sql = @"
                   insert into plan_status 
                        ( name )
                    values
                       (@name)
            ";
            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sql, InsertValues);
                return count;
            }

        }

        public int DeleteStatus(int delId)
        {
            string sqlDel = @"
                    delete from plan_types
                    where
                      id = @delId
            ";

            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sqlDel, new { delId });
                return count;
            }

        }

        public int UpdateStatus(DynamicParameters UpdateValues)
        {
            string sql = @"
                UPDATE plan_types
                SET name = @name
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
