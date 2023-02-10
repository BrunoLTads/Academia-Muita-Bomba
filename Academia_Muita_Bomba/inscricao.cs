using System;

class Inscricao{
  private int id;
  private int idLogin;
  private int idAula;
  
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