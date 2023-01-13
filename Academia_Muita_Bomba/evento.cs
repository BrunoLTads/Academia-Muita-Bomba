using System;

class Evento{
  public int Id {get;set;}
  public string Descricao{get;set;}
  public DateTime Datahora{get;set;}
  public override string ToString(){
    return $"{Id} {Descricao} {Datahora}";
  }
}