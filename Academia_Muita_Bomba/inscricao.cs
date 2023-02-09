using System;

class Inscricao{
  private int id;
  private int idAluno;
  private int idAula;
  
  public Inscricao(int id, int idAluno, int idAula){
    this.id = id;
    this.idAluno = idAluno;
    this.idAula = idAula;
  }
  public void SetId(int id){
    this.id = id;
  }
  public void SetIdAluno(int idAluno){
    this.idAluno = idAluno;
  }
   public void SetIdAula(int idAula){
    this.idAula = idAula;
  }
  public int GetId(){
    return id;
  }
  public int GetIdAluno(){
    return idAluno;
  }
  public int GetIdAula(){
    return idAula;
  }
  public override String ToString(){
    return $"{id} - {idAluno} - {idAula}";
  }
}