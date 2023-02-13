using System;

public class Plano{
  public int Id {get;set;}
  public string Nome{get;set;}
  public string Descricao{get;set;}
  public double Preco{get;set;}
  public override string ToString(){
    return $"Id: {Id}\nPlano: {Nome}\nDescrição: {Descricao}\nPreço: {Preco:0.00}";
  }
}