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
      case 1 : LoginInserir(); break;
      case 2 : LoginListar(); break;
      case 3 : LoginAtualizar(); break;
      case 4 : LoginExcluir(); break;
      case 5 : MatriculaInserir(); break;
      case 6 : MatriculaListar(); break;
      case 7 : MatriculaAtualizar(); break;
      case 8 : MatriculaExcluir(); break;
      case 9 : EventoInserir(); break;
      case 10 : EventoListar(); break;
      case 11 : EventoAtualizar(); break;
      case 12 : EventoExcluir(); break;
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
  public static void LoginInserir(){
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
    Sistema.LoginInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LoginListar(){
    Console.WriteLine("----- Listar os registros cadastrados -----");
    foreach(Login obj in Sistema.LoginListar())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void LoginAtualizar(){
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
    Sistema.LoginAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LoginExcluir(){
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
    Sistema.LoginExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaInserir(){
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

    LoginListar();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, plano, idLogin);
    // Inserir a matrícula no sistema
    Sistema.MatriculaInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaListar(){
    Console.WriteLine("----- Listar as matrículas cadastradas -----");
    foreach(Matricula obj in Sistema.MatriculaListar())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void MatriculaAtualizar(){
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
    LoginListar();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, plano, idLogin);
    // Atualizar o registro no sistema
    Sistema.MatriculaAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaExcluir(){
    Console.WriteLine("----- Exclua uma matrícula -----");
    // Ler dados
    Console.Write("Informe o id da matrícula: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id);
    // Excluir a matrícula no sistema
    Sistema.MatriculaExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EventoInserir(){
    Console.WriteLine("----- Inserir um novo evento -----");
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Evento obj = new Evento{Descricao = desc};
    Sistema.EventoInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void EventoListar(){
    Console.WriteLine("----- Listar os eventos cadastradas -----");
    foreach(Evento obj in Sistema.EventoListar())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void EventoAtualizar(){
    Console.WriteLine("----- Atualizar um evento -----");
    Console.Write("Informe o id do evento a ser utilizado");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Evento obj = new Evento{Id = id, Descricao = desc};
    //Adicionar o de datetime tbm
    Sistema.EventoAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void EventoExcluir(){
    Console.WriteLine("----- Informe o evento a ser excluido -----");
    int id = int.Parse(Console.ReadLine());
    Evento obj = new Evento{Id = id};
    Sistema.EventoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
}