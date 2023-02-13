using System;

public class Matricula : IComparable<Matricula>{
  public int id;
  public string nome;
  public int idade;
  public DateTime pagamento;
  public int idPlano;
  public int idLogin;

  public int CompareTo(Matricula obj){
    return nome.CompareTo(obj.nome);
    return idPlano.CompareTo(obj.idPlano);
  }

  
  public int Id{
  get => id;
  set => id = value;
}
  public string Nome{
  get => nome;
  set => nome = value;
}
  public int Idade{
  get => idade;
  set => idade = value;
}
  public int IdPlano{
  get => idPlano;
  set => idPlano = value;
}
  public int IdLogin{
  get => idLogin;
  set => idLogin = value;
}

  public Matricula(){ }
  
  public Matricula(int id, string nome, int idade, DateTime pagamento, int idPlano, int idLogin){
    this.id = id;
    this.nome = nome;
    this.idade = idade;
    this.pagamento = pagamento;
    this.idPlano = idPlano;
    this.idLogin = idLogin;
  }

  public Matricula(int id){
    this.id = id;
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
    return $"Id: {id} \nNome: {nome} \nIdade: {idade} \nData de pagamento: {pagamento:dd/MM/yyyy}\n";
  }
}