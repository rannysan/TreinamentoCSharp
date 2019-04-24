using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Controllers;

namespace TrainingProject.Service
{
    class PlanService
    {
        public List<Plan> PlansList { get; set; }

        public void QueryPlans()
        {
            string queryString = @"
            select
	            p.id as Id,
	            p.name as Name,
	            p.start_date as StartDate,
	            p.end_date as EndDate,
	            t.id as Id,
	            t.name as Name,
	            s.id as Id,
	            s.name as Name,
	            u.id as Id,
	            u.name as Name,
	            u.register_date as RegisterDate
            from plans p
            inner join plan_types t on (t.id = p.id_type)
            inner join plan_status s on (s.id = p.id_status)
            inner join users u on (u.id = p.id_user)
            ";

            using (var con = new DbProvider().Connection)
            {
                PlansList = con.Query<Plan, Type, Status, User, Plan>(queryString, (p, t, s, u) =>
                {
                    p.PlanType = t;
                    p.Status = s;
                    p.Responsible = u;
                    return p;
                }).ToList();
            }

            if (PlansList != null)
            {
                foreach (var plan in PlansList)
                {
                    Console.WriteLine(plan);
                }
            }
        }

        public int InsertPlan(DynamicParameters InsertValues)
        {
            string sql = @"
                   insert into plans 
                        ( name, id_type, id_user, id_status, start_date, end_date)
                    values
                       (@name, @type, @idUser, @status, @startDate, @endDate)
            ";
            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sql, InsertValues);
                return count;
            }

        }

        public int DeletePlan(int delId)
        {
            string sqlDel = @"
                    delete from plans
                    where
                      id = @delId
            ";

            using (var con = new DbProvider().Connection)
            {
                var count = con.Execute(sqlDel, new { delId });
                return count;
            }

        }

        public int UpdatePlan(DynamicParameters UpdateValues)
        {
            string sql = @"
                UPDATE plans
                SET name = @name, id_type = @type, id_user = @idUser, id_status = @status, start_date = @startDate, end_date = @endDate
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
