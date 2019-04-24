using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Service;

namespace TrainingProject.View
{
    public class MenuView
    {
        private UserService UService { get; set; }
        private PlanService PService { get; set; }
        private TypeService TService { get; set; }
        private StatusService SService { get; set; }

        public MenuView()
        {
            UService = new UserService();
            PService = new PlanService();
            TService = new TypeService();
            SService = new StatusService();
        }

        public  void PrincipalMenu()
        {
            
            Console.WriteLine(@"
         Menu 

  1 - Usuários
  2 - Planos
  3 - Status
  4 - Tipos 
  5 - Sair
            ");
            Console.Write("Selecione uma opção: ");
           int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Clear();
                    UserMenu();
                    break;
                case 2:
                    Console.Clear();
                    PlanMenu();
                    break;
                case 3:
                    Console.Clear();
                    StatusMenu();
                    break;
                case 4:
                    Console.Clear();
                    TypeMenu();
                    break;
                case 5:
                    System.Diagnostics.Process.GetCurrentProcess().Close();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção valida");
                    PrincipalMenu();                    
                    break;
            }
        }

        public void UserMenu()
        {
            Console.WriteLine(@"
         Menu - Usuários

  1 - Listar Usuários
  2 - Inserir Usuário
  3 - Atualizar Usuário
  4 - Deletar Usuário
  5 - Buscar Usuário  
  6 - Voltar
            ");

            Console.Write("Selecione uma opção: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Clear();
                    UService.QueryUser();
                    //UService.PrintUsers();
                    Console.WriteLine("\r\nPrecione ENTER para voltar...");
                    Console.ReadLine();
                    Console.Clear();
                    UserMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira os dados do Usuário \r\n");
                    var InsertValues = new DynamicParameters();
                    Console.Write("Digite o Nome: ");
                    InsertValues.Add("name", Console.ReadLine());
                    Console.Write("\r\n" + InsertValues.Get<string>("name"));
                    InsertValues.Add("registerDate", DateTime.Now);
                    InsertValues.Add("lastChangeDate", DateTime.Now);
                    if (UService.InsertUser(InsertValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário cadastrado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao cadastrar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    UService.QueryUser();
                    //UService.PrintUsers();
                    Console.Write("\r\nDigite o ID do usuário q deseja atualizar: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Insira os novos dados do Usuário \r\n");
                    var UpdateValues = new DynamicParameters();

                    Console.Write("Digite o Nome: ");
                    UpdateValues.Add("name", Console.ReadLine());

                    Console.Write("\r\n" + UpdateValues.Get<string>("name"));

                    User test = UService.UserList.Find(user => user.Id == id);

                    UpdateValues.Add("registerDate", test.RegisterDate);
                    UpdateValues.Add("lastChangeDate", DateTime.Now);
                    UpdateValues.Add("id", id);

                    if (UService.UpdateUser(UpdateValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário Atualizado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao atualizar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    break;
                case 4:
                    Console.Clear();
                    UService.QueryUser();
                   //UService.PrintUsers();
                    Console.Write("\r\nDigite o ID do usuário q deseja deletar: ");
                    
                    if (UService.DeleteUser(Convert.ToInt32(Console.ReadLine())) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário deletado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao deletar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        UserMenu();
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Digite o nome do usuário que você busca: ");
                    string name = Console.ReadLine();
                    User result = UService.UserList.Find(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    PrincipalMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção valida");
                    UserMenu();
                    break;
            }
        }

        public void PlanMenu()
        {
            Console.WriteLine(@"
         Menu - Planos

  1 - Listar Planos
  2 - Inserir Plano
  3 - Atualizar Plano
  4 - Deletar Plano
  5 - Buscar Plano  
  6 - Voltar
            ");

            Console.Write("Selecione uma opção: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Clear();
                    PService.QueryPlans();
                    //PService.PrintPlans();
                    Console.WriteLine("\r\nPrecione ENTER para voltar...");
                    Console.ReadLine();
                    Console.Clear();
                    PlanMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira os dados do Plano \r\n");
                    var InsertValues = new DynamicParameters();

                    //@name, @type, @idUser, @status, @startDate, @endDate
                    Console.Write("Digite o Nome: ");
                    InsertValues.Add("name", Console.ReadLine());

                    Console.Write("Digite o Tipo: ");
                    InsertValues.Add("type", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite o Status: ");
                    InsertValues.Add("status", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite o ID do responsavel: ");
                    InsertValues.Add("idUser", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite a Data Inicial (Sem traços): ");
                    InsertValues.Add("startDate", Console.ReadLine());

                    Console.Write("Digite a Data Final (Sem traços nem espaços): ");
                    InsertValues.Add("endDate", Console.ReadLine());
                    
                    if (PService.InsertPlan(InsertValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário cadastrado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao cadastrar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    PService.QueryPlans();
                    //PService.PrintPlans();
                    Console.Write("\r\nDigite o ID do Plano q deseja atualizar: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Insira os novos dados do Plano \r\n");
                    var UpdateValues = new DynamicParameters();

                    Plan resultUp = PService.PlansList.Find(user => user.Id == id);
                    UpdateValues.Add("id", id);

                    //@name, @type, @idUser, @status, @startDate, @endDate
                    Console.Write("Digite o Nome: ");
                    UpdateValues.Add("name", Console.ReadLine());

                    Console.Write("Digite o Tipo: ");
                    UpdateValues.Add("type", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite o Status: ");
                    UpdateValues.Add("status", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite o ID do responsavel: ");
                    UpdateValues.Add("idUser", Convert.ToInt32(Console.ReadLine()));

                    Console.Write("Digite a Data Inicial (Sem traços): ");
                    UpdateValues.Add("startDate", Console.ReadLine());

                    Console.Write("Digite a Data Final (Sem traços nem espaços): ");
                    UpdateValues.Add("endDate", Console.ReadLine());


                    if (PService.UpdatePlan(UpdateValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário Atualizado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao atualizar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    break;
                case 4:
                    Console.Clear();
                    PService.QueryPlans();
                    //PService.PrintPlans();
                    Console.Write("\r\nDigite o ID do usuário q deseja deletar: ");

                    if (PService.DeletePlan(Convert.ToInt32(Console.ReadLine())) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuário deletado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao deletar Usuário!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        PlanMenu();
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Digite o nome do plano que você busca: ");
                    string name = Console.ReadLine();
                    Plan result = PService.PlansList.Find(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    PrincipalMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção valida");
                    PlanMenu();
                    break;
            }
        }

        public void TypeMenu()
        {
            Console.WriteLine(@"
         Menu - Tipo

  1 - Listar Tipo
  2 - Inserir Tipo
  3 - Atualizar Tipo
  4 - Deletar Tipo
  5 - Voltar
            ");

            Console.Write("Selecione uma opção: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Clear();
                    TService.QueryType();
                    //TService.PrintTypes();
                    Console.WriteLine("\r\nPrecione ENTER para voltar...");
                    Console.ReadLine();
                    Console.Clear();
                    TypeMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira os dados do Tipo \r\n");
                    var InsertValues = new DynamicParameters();
                    Console.Write("Digite o Nome: ");
                    InsertValues.Add("name", Console.ReadLine());
                    
                    
                    if (TService.InserType(InsertValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Tipo cadastrado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao cadastrar Tipo!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    TService.QueryType();
                    //TService.PrintTypes();
                    Console.Write("\r\nDigite o ID do tipo q deseja atualizar: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Insira os novos dados do Tipo \r\n");
                    var UpdateValues = new DynamicParameters();

                    Console.Write("Digite o Nome: ");
                    UpdateValues.Add("name", Console.ReadLine());
                    
                    UpdateValues.Add("id", id);

                    if (TService.UpdateType(UpdateValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Tipo Atualizado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao atualizar Tipo!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    break;
                case 4:
                    Console.Clear();
                    TService.QueryType();
                    //TService.PrintTypes();
                    Console.Write("\r\nDigite o ID do Tipo q deseja deletar: ");

                    if (TService.DeleteType(Convert.ToInt32(Console.ReadLine())) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Tipo deletado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao deletar Tipo!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        TypeMenu();
                    }
                    break;
                case 5:
                    Console.Clear();
                    PrincipalMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção valida");
                    TypeMenu();
                    break;
            }
        }

        public void StatusMenu()
        {
            Console.WriteLine(@"
         Menu - Status

  1 - Listar Status
  2 - Inserir Statu
  3 - Atualizar Statu
  4 - Deletar Statu
  5 - Voltar
            ");

            Console.Write("Selecione uma opção: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Clear();
                    SService.QueryStatus();
                    //SService.PrintStatus();
                    Console.WriteLine("\r\nPrecione ENTER para voltar...");
                    Console.ReadLine();
                    Console.Clear();
                    StatusMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira os dados do Status \r\n");
                    var InsertValues = new DynamicParameters();
                    Console.Write("Digite o Nome: ");
                    InsertValues.Add("name", Console.ReadLine());
                    
                    
                    if (SService.InserStatus(InsertValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Status cadastrado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao cadastrar Status!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    SService.QueryStatus();
                    //SService.PrintStatus();
                    Console.Write("\r\nDigite o ID do tipo q deseja atualizar: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Insira os novos dados do Status \r\n");
                    var UpdateValues = new DynamicParameters();

                    Console.Write("Digite o Nome: ");
                    UpdateValues.Add("name", Console.ReadLine());

                    UpdateValues.Add("id", id);

                    if (SService.UpdateStatus(UpdateValues) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Status Atualizado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao atualizar Status!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    break;
                case 4:
                    Console.Clear();
                    SService.QueryStatus();
                    //SService.PrintStatus();
                    Console.Write("\r\nDigite o ID do Tipo q deseja deletar: ");

                    if (SService.DeleteStatus(Convert.ToInt32(Console.ReadLine())) != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Status deletado com sucesso!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro ao deletar Status!!");
                        Console.WriteLine("Precione ENTER para voltar...");
                        Console.ReadLine();
                        Console.Clear();
                        StatusMenu();
                    }
                    break;
                case 5:
                    Console.Clear();
                    PrincipalMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção valida");
                    StatusMenu();
                    break;
            }
        }
    }
}
