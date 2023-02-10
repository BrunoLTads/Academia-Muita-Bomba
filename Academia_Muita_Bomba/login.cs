using System;

public class Login{
  private int id {get; set;}
  private string nome {get; set;}
  private string senha {get;set;}
  private string cargo {get;set;}


  
  public Login(int id, string nome, string senha, string cargo){
    this.id = id;
    this.nome = nome;
    this.senha = senha;
    this.cargo = cargo;
  }
  public void SetId(int id){
    this.id = id;
  }
  public void SetNome(string nome){
    this.nome = nome;
  }
  public void SetSenha(string senha){
    this.senha = senha;
  }
  public void SetCargo(string cargo){
    this.cargo = cargo;
  }
  public int GetId(){
    return id;
  }
  public string GetNome(){
    return nome;
  }
  public string GetSenha(){
    return senha;
  }
  public string GetCargo(){
    return cargo;
  }
  public override String ToString(){
    return $"{id} - {nome} - {senha} - {cargo}";
  }
}