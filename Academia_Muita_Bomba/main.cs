using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

/*
  O sistema de login do IFPet é feito usando 
*/

class Program{

  private static Login clienteLogin = null;

  public static void Main(){
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    
    try{
      Sistema.ArquivosAbrir();
    }
    catch (Exception erro){
      Console.WriteLine(erro.Message);
    }


    Console.WriteLine("Bem-vindo à Academia Muita Bomba!\n");

    // define a operação a ser feita pelo usuário
    int op = 0;
    // define o tipo de usuário (admin ou cliente/aluno)
    int perfil = 0;

    do{
      try{
        // OLÁ AMIGO!
        /* O if abaixo é a estrutura principal do login, que vai levar aos
           respectivos menus.
        */

        // Não selecionou o perfil ainda, vai mostrar o menu de user
        if (perfil == 0) {
          //op = 0;
          perfil = MenuUsuario();

        // Selecionou o perfil de admin
        }
        if (perfil == 1) {
          op = MenuAdmin();
          /* O comando try junto com o catch mais abaixo está sendo utilizado na criação de um bloco de erro.
           Caso o usuário erre o input, o menu enviará o usuário ao início. */
          switch(op){
          case 1 : LoginCreate(); break;
          case 2 : LoginRead(); break;
          case 3 : LoginUpdate(); break;
          case 4 : LoginDelete(); break;
          case 5 : MatriculaCreate(); break;
          case 6 : MatriculaRead(); break;
          case 7 : MatriculaUpdate(); break;
          case 8 : MatriculaDelete(); break;
          case 9 : AulaCreate(); break;
          case 10 : AulaRead(); break;
          case 11 : AulaUpdate(); break;
          case 12 : AulaDelete(); break;
          case 13 : PlanoCreate(); break;
          case 14 : PlanoRead(); break;
          case 15 : PlanoUpdate(); break;
          case 16 : PlanoDelete(); break;
          case 17: InscricaoCreate(); break;
          case 18: InscricaoRead(); break;
          case 19: InscricaoUpdate(); break;
          case 20: InscricaoDelete(); break;
          case 99: perfil = 0; break;
          }

        // Selecionou o perfil de cliente, mas não está logado
        }
        if(perfil == 2 && clienteLogin == null){
          op = Login();
          clienteLogin = Sistema.LoginRead(op);
          if(op == 666) {
            Console.WriteLine();
            Console.WriteLine("Dados incorretos!!!");
          }

        // Selecionou o perfil de cliente e está logado
        }
        if(perfil == 2 && clienteLogin != null){
          /* Nota: nos vídeos do IFPet, Gilbert trata ClienteLogin como a função
             que maneja o login do cliente, e ClienteLogout como a que lida com as
             operações que o cliente pode fazer.
             Aqui, é Login e MenuAluno, na respectiva ordem.
          */
          op = MenuAluno();
          switch(op) {
            case 1: VizAulas(); break;
          case 2: InscreAula(); break;
            case 3: VizInscri(); break;
            case 4: VizInfo(); break;
            case 0: perfil = 0; clienteLogin = null; MenuAluno();  break;
          }
        }
        if (perfil == 99) {
          break;
        }
        if (perfil == 24) {
          Console.WriteLine("AHAHAHAHAA EU VOU VIARAR O CORIGGRNAAA");
        }


        
      }
      catch(Exception erro){
          op = -1;
          Console.WriteLine("Erro: " + erro.Message);
          Console.WriteLine("Tente novamente.");
        }
    }while (op != 0);


    try{
      Sistema.ArquivosSalvar();
    }
    catch (Exception erro){
      Console.WriteLine(erro.Message);
    }
  }

  public static int MenuUsuario(){
    Console.WriteLine("---- Olá! Quem é você? ----");
    Console.WriteLine("01 - Administrador");
    Console.WriteLine("02 - Cliente");
    Console.WriteLine("99 - Sair do sistema");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int Login(){
    Console.WriteLine();
    Console.WriteLine("---- Olá! Bem vindo à academia MuitaBomba! ----");
    Console.WriteLine("---- Por favor, insira seu id de login. ----");
    string tlogin = Console.ReadLine();
    Console.WriteLine("---- Agora, sua senha. ----");
    string tsenha = Console.ReadLine();
    // se senha do login cujo id foi digitado
    if ( Sistema.LoginRead(int.Parse(tlogin)).GetSenha() == tsenha ){
      return int.Parse(tlogin);
    }else{
      return 666;
    }
    
    }

  public static int MenuAluno() {
    /*
      Operações a serem adicionadas:
        - ver aulas disponiveis
        - inscrever-se em aula
        - ver inscrições feitas
        - ver o plano
        - ver a matricula
        - logout
    */
    Console.WriteLine();
    Console.WriteLine("---- Olá, " + clienteLogin.GetNome() + " ----");
    Console.WriteLine("01 - Visualizar aulas disponíveis");
    Console.WriteLine("02 - Inscrever-se em aula");
    Console.WriteLine("03 - Visualizar aulas inscritas");
    // Visualizar plano e matrícula
    Console.WriteLine("04 - Visualizar informações da conta");

    Console.WriteLine("00 - Logout");
    return int.Parse(Console.ReadLine());
  }

  public static void VizAulas(){
    // para cada aula na lista de aula
    Console.WriteLine("As aulas disponíveis são:");
    foreach (Aula aula in Sistema.AulaRead() ){
      Console.Write(aula);
    }
    
  }

  public static void InscreAula(){
    //A única diferença aqui é que o cliente/aluno só vai conseguir ver o login dele. No InscricaoCreate o usuário observa todos os logins e, consequentemente, as senhas KKKKKKKKKKKKK
    Console.Write("Informe o id da inscrição: ");
    int id = int.Parse(Console.ReadLine());
    
    IEnumerable<Login> loginesp = from Login in Sistema.logins
                                    where Login.Nome == clienteLogin.GetNome()
                                    select Login;
    
    foreach(var login in loginesp){
    Console.WriteLine("Selecione o id do seu login: \n" +  login);
      }
    
      
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    AulaRead();
    Console.Write("Informe o id da aula: ");
    int idAula = int.Parse(Console.ReadLine());

    Inscricao obj = new Inscricao(id, idLogin, idAula);
    Sistema.InscricaoCreate(obj);
    }

  public static void VizInscri() {
    // 
    IEnumerable<Inscricao> inscricaoesp = from Inscricao in Sistema.inscricoes
                                    where Inscricao.IdLogin == clienteLogin.GetId()
                                    select Inscricao;
    
    foreach(var obj in inscricaoesp){
    var aulainscrita = obj.IdAula;

    IEnumerable<Aula> aulaesp = from Aula in Sistema.aulas
                                  where Aula.Id == aulainscrita
                                  select Aula;
    
    foreach(var aulas in aulaesp){
      Console.WriteLine("Você está inscrito na(s) seguinte(s) aulas:\n" + aulas);
  }
      }
    } 
  
  public static void VizInfo() {
    IEnumerable<Matricula> matriculaesp = from Matricula in Sistema.matriculas
                                    where Matricula.Nome == clienteLogin.GetNome()
                                    select Matricula;
    
    foreach(var obj in matriculaesp){
    var id = obj.IdPlano;
    Console.WriteLine("Sua matrícula é: \n" +  obj);

    IEnumerable<Plano> planoesp = from Plano in Sistema.planos
                                  where Plano.Id == id
                                  select Plano;
    
    foreach(var planos in planoesp){
      Console.WriteLine("Seu plano é: \n" + planos);
    }
      }

    
  }

  public static int MenuAdmin(){
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

    Console.WriteLine("09 - Inserir aula");
    Console.WriteLine("10 - Listar aulas cadastradas");
    Console.WriteLine("11 - Atualizar aula");
    Console.WriteLine("12 - Excluir um aula");

    Console.WriteLine("13 - Inserir plano");
    Console.WriteLine("14 - Listar planos cadastrados");
    Console.WriteLine("15 - Atualizar plano");
    Console.WriteLine("16 - Excluir um plano");

    Console.WriteLine("17 - Inserir inscrição");
    Console.WriteLine("18 - Listar inscrições");
    Console.WriteLine("19 - Atualizar uma inscrição");
    Console.WriteLine("20 - Excluir uma inscrição");
    
    Console.WriteLine("99 - Voltar ao menu anterior");
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
    Console.WriteLine("----- Listar os Logins cadastrados -----");
    // Ordenando os logins pelo Id utilizando o metodo OrderBy do Linq
    IEnumerable<Login> loginord = from Login in Sistema.logins
                                  where Login.Id >= 1
                                  select Login;

    loginord = loginord.OrderBy(Login => Login.Id);
    foreach(var obj in loginord){
      Console.WriteLine(obj);
    }
    
  }
  public static void LoginUpdate(){
    Console.WriteLine("----- Atualize um login -----");
    // Ler dados
    Console.Write("Informe o id do login: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string nome = Console.ReadLine();
    // Instanciar a classe Login
    string senha = Console.ReadLine();
    string cargo = Console.ReadLine();
    Login obj = new Login(id, nome, senha, cargo);
    // Atualizar o Login no sistema
    Sistema.LoginUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LoginDelete(){
    Console.WriteLine("----- Exclua um Login -----");
    // Ler dados
    Console.Write("Informe o id do login: ");
    int id = int.Parse(Console.ReadLine());
    string nome = "";
    string senha = "";
    string cargo = "";
    // Instanciar a classe Login
    Login obj = new Login(id, nome, senha, cargo);
    // Excluir o Login no sistema
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

    PlanoRead();
    Console.Write("Informe o id do plano: ");
    int idPlano = int.Parse(Console.ReadLine());

    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, idPlano, idLogin);
    // Inserir a matrícula no sistema
    Sistema.MatriculaCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void MatriculaRead(){
    Console.WriteLine("----- Listar as matrículas cadastradas -----");
    IEnumerable<Matricula> matriculaord = from Matricula in Sistema.matriculas
                                  where Matricula.Id >= 1
                                  select Matricula;

    matriculaord = matriculaord.OrderBy(Matricula => Matricula.Id);
    foreach(var obj in matriculaord){
      Console.WriteLine(obj);
  }
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
    
    PlanoRead();
    Console.Write("Informe o id do plano: ");
    int idPlano = int.Parse(Console.ReadLine());
    
    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());
    // Instanciar a classe Matricula
    Matricula obj = new Matricula(id, nome, idade, pagamento, idPlano, idLogin);
    // Atualizar o Login no sistema
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
  public static void AulaCreate(){
    Console.WriteLine("----- Inserir uma nova aula -----");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Console.Write("Informe a data e hora: ");
    DateTime datahora = DateTime.Parse(Console.ReadLine());
    int vagaspreenchidas = int.Parse(Console.ReadLine());
    Console.Write("Informe o número de vagas totais: ");
    int vagastotais = int.Parse(Console.ReadLine());
    Aula obj = new Aula{Id = id, Nome = nome, Descricao = desc, Datahora = datahora, Vagaspreenchidas = vagaspreenchidas, Vagastotais = vagastotais};
    Sistema.AulaCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void AulaRead(){
    Console.WriteLine("----- Listar as aulas cadastradas -----");
    IEnumerable<Aula> aulaord = from Aula in Sistema.aulas
                                  where Aula.Id >= 1
                                  select Aula;

    aulaord = aulaord.OrderBy(Aula => Aula.Datahora);
    foreach(var obj in aulaord){
      Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
    }
  public static void AulaUpdate(){
    Console.WriteLine("----- Atualizar uma aula -----");
    Console.Write("Informe o id da aula a ser utilizada");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Console.Write("Informe a data e hora: ");
    DateTime datahora = DateTime.Parse(Console.ReadLine());
    int vagaspreenchidas = int.Parse(Console.ReadLine());
    Console.Write("Informe o número de vagas totais: ");
    int vagastotais = int.Parse(Console.ReadLine());
    Aula obj = new Aula{Id = id, Nome = nome, Descricao = desc, Datahora = datahora, Vagaspreenchidas = vagaspreenchidas, Vagastotais = vagastotais};
    //Adicionar o de datetime tbm
    Sistema.AulaUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void AulaDelete(){
    Console.WriteLine("----- Informe a aula a ser excluida -----");
    int id = int.Parse(Console.ReadLine());
    Aula obj = new Aula{Id = id};
    Sistema.AulaDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void PlanoCreate(){
    Console.WriteLine("----- Inserir um novo plano -----");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    int preco = int.Parse(Console.ReadLine());
    Plano obj = new Plano{Id = id, Nome = nome, Descricao = desc, Preco = preco};
    Sistema.PlanoCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void PlanoRead(){
    Console.WriteLine("----- Listar os planos cadastrados -----");
    IEnumerable<Plano> planoord = from Plano in Sistema.planos
                                  where Plano.Id >= 1
                                  select Plano;

    planoord = planoord.OrderBy(Plano => Plano.Id);
    foreach(var obj in planoord){
      Console.WriteLine(obj);
  }
    }
  public static void PlanoUpdate(){
    Console.WriteLine("----- Atualizar um plano -----");
    Console.Write("Informe o id do plano a ser utilizado");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a descricao: ");
    string desc = Console.ReadLine();
    Console.Write("Informe o preço: ");
    int preco = int.Parse(Console.ReadLine());
    Plano obj = new Plano{Id = id, Nome = nome, Descricao = desc, Preco = preco};
    Sistema.PlanoUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void PlanoDelete(){
    Console.WriteLine("----- Informe o plano a ser excluido -----");
    int id = int.Parse(Console.ReadLine());
    Plano obj = new Plano{Id = id};
    Sistema.PlanoDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void InscricaoCreate(){
    Console.WriteLine("----- Inserir uma nova inscrição -----");
    // Ler dados
    Console.Write("Informe o id da inscrição: ");
    int id = int.Parse(Console.ReadLine());

    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    AulaRead();
    Console.Write("Informe o id da aula: ");
    int idAula = int.Parse(Console.ReadLine());

    
    // Instanciar a classe Inscricao
    Inscricao obj = new Inscricao(id, idLogin, idAula);
    // Inserir a matrícula no sistema
    Sistema.InscricaoCreate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void InscricaoRead(){
    Console.WriteLine("----- Listar inscrições cadastradas -----");
    foreach(Inscricao obj in Sistema.InscricaoRead())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void InscricaoUpdate(){
    Console.WriteLine("----- Atualize uma inscrição -----");
    // Ler dados
    Console.Write("Informe o id da inscrição: ");
    int id = int.Parse(Console.ReadLine());
    LoginRead();
    Console.Write("Informe o id do login: ");
    int idLogin = int.Parse(Console.ReadLine());

    AulaRead();
    Console.Write("Informe o id da aula: ");
    int idAula = int.Parse(Console.ReadLine());
    
    // Instanciar a classe Inscricao
    Inscricao obj = new Inscricao(id, idLogin, idAula);
    // Atualizar o Login no sistema
    Sistema.InscricaoUpdate(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void InscricaoDelete(){
    Console.WriteLine("----- Exclua uma inscrição -----");
    // Ler dados
    Console.Write("Informe o id da inscrição: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Inscricao
    Inscricao obj = new Inscricao(id);
    // Excluir a inscrição no sistema
    Sistema.InscricaoDelete(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
}