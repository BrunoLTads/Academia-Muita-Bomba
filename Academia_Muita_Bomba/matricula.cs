using System;

class Matricula{
  private int id;
  private string nome;
  private int idade;
  private DateTime pagamento;
  private int idPlano;
  private int idLogin;
  
  public Matricula(int id, string nome, int idade, DateTime pagamento, int idPlano, int idLogin){
    this.id = id;
    this.nome = nome;
    this.idade = idade;
    this.pagamento = pagamento;
    this.idPlano = idPlano;
    this.idLogin = idLogin;
  }
  public void SetId(int id){
    this.id = id;
  }
  public void SetNome(string nome){
    this.nome = nome;
  }
  public void SetIdade(int idade){
    this.idade = idade;
  }
  public void SetPagamento(DateTime pagamento){
    this.pagamento = pagamento;
  }
  public void SetIdPlano(int idPlano){
    this.idPlano = idPlano;
  }
  public void SetIdLogin(int idLogin){
    this.idLogin = idLogin;
  }
  public int GetId(){
    return id;
  }
  public string GetNome(){
    return nome;
  }
  public int GetIdade(){
    return idade;
  }
  public DateTime GetPagamento(){
    return pagamento;
  }
  public int GetIdPlano(){
    return idPlano;
  }
  public int GetIdLogin(){
    return idLogin;
  }
  public override String ToString(){
    return $"{id} - {nome} - {idade} - {pagamento:dd/MM/yyyy}";
  }
}