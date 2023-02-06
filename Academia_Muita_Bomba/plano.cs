using System;

class Plano{
  public int Id {get;set;}
  public string Nome{get;set;}
  public string Descricao{get;set;}
  public int Preco{get;set;}
  public override string ToString(){
    return $"{Id} {Nome} {Descricao} {Preco}";
  }
}