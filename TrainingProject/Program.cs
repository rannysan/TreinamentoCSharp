using System;
using System.Configuration;
using TrainingProject.Controllers;
using TrainingProject.Service;
using TrainingProject.View;

namespace TrainingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DbProvider.SetConnectionString(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

            Console.WriteLine(@"---Treinamento C#---");
            //UService.QueryUser();
            //User test = UService.UserList.Find(user => user.Id == 106);
            //Console.WriteLine(test);
            var Menu = new MenuView();

            Menu.PrincipalMenu();
            
            


            // Specify the parameter value.
            //List<Plan> planList = new List<Plan>();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
                //planList = connection.Query<Plan, Type, Status, User, Plan>(queryString3, (p, t, s, u) =>
                //{
                //    p.PlanType = t;
                //    p.Status = s;
                //    p.Responsible = u;
                //    return p;
                //}).ToList();

            //    //// Create the Command and Parameter objects.
            //    //SqlCommand command = new SqlCommand(queryString, connection);
            //    //command.Parameters.AddWithValue("@pricePoint", paramValue);
            //    //try
            //    //{
            //    //    connection.Open();
            //    //    SqlDataReader reader = command.ExecuteReader();
            //    //    while (reader.Read())
            //    //    {
            //    //        var user = new User((int)reader[0], (string)reader[1]);
            //    //        userList.Add(user);
            //    //    }
            //    //    reader.Close();


            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    Console.WriteLine(ex.Message);
            //    //}
            //    Console.ReadLine();
            //}
        }
    }
}
