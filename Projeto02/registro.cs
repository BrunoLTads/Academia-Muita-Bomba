using System;

class Registro{
  private int id;
  private string descricao;
  public Registro(int id, string descricao){
    this.id = id;
    this.descricao = descricao;
  }
  public void SetId(int id){
    this.id = id;
  }
  public void SetDescricao(string descricao){
    this.descricao = descricao;
  }
  public int GetId(){
    return id;
  }
  public string GetDescricao(){
    return descricao;
  }
  public override String ToString(){
    return $"{id} - {descricao}";
  }
}