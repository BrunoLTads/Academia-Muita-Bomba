using System;

public class Inscricao{
  private int id;
  private int idLogin;
  private int idAula;

  public int Id{
  get => id;
  set => id = value;
}
  public int IdLogin{
  get => idLogin;
  set => idLogin = value;
}
  public int IdAula{
  get => idAula;
  set => idAula = value;
}
  
  public Inscricao(){ }


  
  public Inscricao(int id){
    this.id = id;
  }
  
  public Inscricao(int id, int idLogin, int idAula){
    this.id = id;
    this.idLogin = idLogin;
    this.idAula = idAula;
  }
  public void SetId(int id){
    this.id = id;
  }
  public void SetIdLogin(int idLogin){
    this.idLogin = idLogin;
  }
   public void SetIdAula(int idAula){
    this.idAula = idAula;
  }
  public int GetId(){
    return id;
  }
  public int GetIdLogin(){
    return idLogin;
  }
  public int GetIdAula(){
    return idAula;
  }
  public override String ToString(){
    return $"{id} - {idLogin} - {idAula}";
  }
}