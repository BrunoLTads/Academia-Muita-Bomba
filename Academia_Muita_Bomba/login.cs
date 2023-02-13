using System;

public class Login{
  private int id;
  private string nome;
  private string senha;
  private string cargo;

  public int CompareTo(Login obj){
    return nome.CompareTo(obj.nome);
  }
  
  public int Id{
    get => id;
    set => id = value;
  }
  public string Nome{
    get => nome;
    set => nome = value;
  }
  public string Senha{
    get => senha;
    set => senha = value;
  }
  public string Cargo{
    get => cargo;
    set => cargo = value;
  }

  public Login(){ }
  public Login(int id){
    this.id = id;
    }
  
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
    return $"Id: {id}\nNome: {nome}\nSenha: {senha}\nCargo: {cargo}\n";
  }
}