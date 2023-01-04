using System;

class Program{
  public static void Main(){
    Console.WriteLine("Bem-vindo a Academia Mega Bomba");
    Registro r1 = new Registro(1, "Matricula");
    Registro r2 = new Registro(2, "Pessoa");
    Matricula m1 = new Matricula(1, "Bruno", 20, DateTime.Parse("04/02/2023"), "mensal", 2);
    Matricula m2 = new Matricula(2, "Rio", 20, DateTime.Parse("04/01/2024"), "anual", 2);
    Console.WriteLine(m1);
    Console.WriteLine(m2);
  }
}