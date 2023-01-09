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
      case 1 : RegistroInserir(); break;
      case 2 : RegistroListar(); break;
      case 3 : RegistroAtualizar(); break;
      case 4 : RegistroExcluir(); break;
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
    Console.WriteLine("01 - Inserir novo registro");
    Console.WriteLine("02 - Listar registros cadastrados");
    Console.WriteLine("03 - Atualizar registros cadastrados");
    Console.WriteLine("04 - Excluir registro cadastrado");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("-----------------------");
    Console.WriteLine("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("");
    return op; //Por algum motivo no console ta mostrando tudo direitinho, mas depois mostra ;1;1R e apaga o restante. Testei no online gdb e funcionou tranquilo. Deve ser algum problema do replit.
  }
  public static void RegistroInserir(){
    Console.WriteLine("----- Inserir um novo registro -----");
    // Ler dados
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Registro
    Registro obj = new Registro(id, descricao);
    // Inserir o registro no sistema
    Sistema.RegistroInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void RegistroListar(){
    Console.WriteLine("----- Listar os registros cadastrados -----");
    foreach(Registro obj in Sistema.RegistroListar())
     Console.WriteLine(obj);
    Console.WriteLine("-------------------------------");
  }
  public static void RegistroAtualizar(){
    Console.WriteLine("----- Atualize um registro -----");
    // Ler dados
    Console.Write("Informe o id do registro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Registro
    Registro obj = new Registro(id, descricao);
    // Atualizar o registro no sistema
    Sistema.RegistroAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void RegistroExcluir(){
    Console.WriteLine("----- Exclua um registro -----");
    // Ler dados
    Console.Write("Informe o id do registro: ");
    int id = int.Parse(Console.ReadLine());
    string descricao = "";
    // Instanciar a classe Registro
    Registro obj = new Registro(id, descricao);
    // Excluir o registro no sistema
    Sistema.RegistroExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
}