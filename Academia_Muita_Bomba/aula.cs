using System;

class Aula{
  public int Id {get;set;}
  public string Nome{get;set;}
  public string Descricao{get;set;}
  public DateTime Datahora{get;set;}
  public int Vagaspreenchidas{get;set;}
  public int Vagastotais{get;set;}
  public override string ToString(){
    return $"{Id} {Nome} {Descricao} {Datahora: dd/MM/yyyy HH:mm} {Vagaspreenchidas}/{Vagastotais}";
  }
}