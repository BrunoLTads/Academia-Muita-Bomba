using System;

class Program{
  public static void Main(){
    Console.WriteLine("Bem-vindo a Academia Mega Bomba");
    int op = 0;
    do{
      try{
      // O comando try junto com o catch mais abaixo, está sendo utilizado na criação de um bloco de erro. Caso o usuário erre o input, o menu enviará o usuário ao início.
      op = Menu();
      switch(op){
      case 1 : LoginCreate(); break;
      case 2 : LoginRead(); break;
      case 3 : LoginUpdate(); break;
      case 4 : LoginDelete(); break;
      case 5 : MatriculaCreate(); break;
      case 6 : MatriculaRead(); break;
      case 7 : MatriculaUpdate(); break;
      case 8 : MatriculaDelete(); break;
      case 9 : EventoCreate(); break;
      case 10 : EventoRead(); break;
      case 11 : EventoUpdate(); break;
      case 12 : EventoDelete(); break;
      }
      }
      catch(Exception erro){
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
        Console.WriteLine("Tente novamente.");
      }
  } while (op != 0);
    }
  public static int Menu(){
    Console.WriteLine();
    Console.WriteLine("---- Escolha uma opção. ----");
    Console.WriteLine("01 - Inserir novo login");
    Console.WriteLine("02 - Listar logins cadastrados");
    Console.WriteLine("03 - Atualizar logins cadastrados");
    Console.WriteLine("04 - Excluir login cadastrado");
    Console.WriteLine("05 - Inserir nova matrícula");
    Console.WriteLine("06 - Listar matrículas cadastradas");
    Console.WriteLine("07 - Atualizar matrículas cadastradas");
    Console.WriteLine("08 - Excluir matrícula cadastrada");
    Console.WriteLine("09 - Inserir evento");
    Console.WriteLine("10 - Listar eventos cadastrados");
    Console.WriteLine("11 - Atualizar evento");
    Console.WriteLine("12 - Excluir um evento");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("-----------------------");
    Console.WriteLine("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("");
    return op;
  }
  public static void LoginCreate(){
    Console.WriteLine("----- Inserir um novo login -----");
    // Ler dados
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    // Instanciar a classe Login
    Console.Write("Informe a senha: ");
    string senha = Console.ReadLine();
    Console.Write("Informe o cargo: ");
    string cargo = Console.ReadLine();
    Login obj = new Login(id, nome, senha, cargo);
    // Inserir o login no sistema
    Sistema.LoginCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LoginRead(){
    Console.WriteLine("----- Listar os registros cadastrados -----");
    foreach(Login obj in Sistema.LoginRead())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void LoginUpdate(){
    Console.WriteLine("----- Atualize um login -----");
    // Ler dados
    Console.Write("Informe o id do login: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string nome = Console.ReadLine();
    // Instanciar a classe Registro
    string senha = Console.ReadLine();
    string plano = Console.ReadLine();
    Login obj = new Login(id, nome, senha, plano);
    // Atualizar o registro no sistema
    Sistema.LoginUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LoginDelete(){
    Console.WriteLine("----- Exclua um registro -----");
    // Ler dados
    Console.Write("Informe o id do login: ");
    int id = int.Parse(Console.ReadLine());
    string nome = "";
    string senha = "";
    string cargo = "";
    // Instanciar a classe Registro
    Login obj = new Login(id, nome, senha, cargo);
    // Excluir o registro no sistema
    Sistema.LoginDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaCreate(){
    Console.WriteLine("----- Inserir uma nova matrícula -----");
    // Ler dados
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a idade: ");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Informe a data de pagamento: ");
    // Se atentar para essa data de pagamento. Acho melhor fazer algo para deixar ela automática.
    DateTime pagamento = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe o plano: ");
    string plano = (Console.ReadLine());

    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, plano, idLogin);
    // Inserir a matrícula no sistema
    Sistema.MatriculaCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaRead(){
    Console.WriteLine("----- Listar as matrículas cadastradas -----");
    foreach(Matricula obj in Sistema.MatriculaRead())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void MatriculaUpdate(){
    Console.WriteLine("----- Atualize uma matrícula -----");
    // Ler dados
    Console.Write("Informe o id da matrícula: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a idade: ");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Informe a data de pagamento: ");
    DateTime pagamento = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe o plano: ");
    string plano = (Console.ReadLine());
    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, plano, idLogin);
    // Atualizar o registro no sistema
    Sistema.MatriculaUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaDelete(){
    Console.WriteLine("----- Exclua uma matrícula -----");
    // Ler dados
    Console.Write("Informe o id da matrícula: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id);
    // Excluir a matrícula no sistema
    Sistema.MatriculaDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EventoCreate(){
    Console.WriteLine("----- Inserir um novo evento -----");
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Evento obj = new Evento{Descricao = desc};
    Sistema.EventoCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void EventoRead(){
    Console.WriteLine("----- Listar os eventos cadastradas -----");
    foreach(Evento obj in Sistema.EventoRead())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void EventoUpdate(){
    Console.WriteLine("----- Atualizar um evento -----");
    Console.Write("Informe o id do evento a ser utilizado");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Evento obj = new Evento{Id = id, Descricao = desc};
    //Adicionar o de datetime tbm
    Sistema.EventoUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EventoDelete(){
    Console.WriteLine("----- Informe o evento a ser excluido -----");
    int id = int.Parse(Console.ReadLine());
    Evento obj = new Evento{Id = id};
    Sistema.EventoDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
}