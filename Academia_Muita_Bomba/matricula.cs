using System;

class Matricula{
  private int id;
  private string nome;
  private int idade;
  private DateTime pagamento;
  private string plano;
  private int idRegistro;
  public Matricula(int id){
    this.id = id;
  }
  public Matricula(int id, string nome, int idade, DateTime pagamento, string plano, int idRegistro){
    this.id = id;
    this.nome = nome;
    this.idade = idade;
    this.pagamento = pagamento;
    this.plano = plano;
    this.idRegistro = idRegistro;
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
  public void SetPlano(string plano){
    this.plano = plano;
  }
  public void SetIdRegistro(int idRegistro){
    this.idRegistro = idRegistro;
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
  public string GetPlano(){
    return plano;
  }
  public int GetIdRegistro(){
    return idRegistro;
  }
  public override String ToString(){
    return $"{id} - {nome} - {idade} - {pagamento:dd/MM/yyyy} - {plano}";
  }
}