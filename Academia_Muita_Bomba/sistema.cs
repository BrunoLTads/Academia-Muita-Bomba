using System;
using System.Collections.Generic;

class Sistema{
  private static List<Login> logins = new List<Login>();
  private static List<Matricula> matriculas = new List<Matricula>();
  private static List<Evento> eventos = new List<Evento>();

  public static void LoginCreate(Login obj){
    logins.Add(obj);
  }
  public static List<Login> LoginRead(){
    return logins;
  }
  public static Login LoginRead(int id){
    foreach(Login obj in logins)
    if (obj.GetId() == id){
      return obj;
    }
  return null;
  }
  public static void LoginUpdate(Login obj){
    Login aux = LoginRead(obj.GetId());
    if (aux != null){
      aux.SetId(obj.GetId());
      aux.SetNome(obj.GetNome());
      aux.SetSenha(obj.GetSenha());
      aux.SetCargo(obj.GetCargo());
    }
  }
  public static void LoginDelete(Login obj){
    Login aux = LoginRead(obj.GetId());
    if (aux != null){
      logins.Remove(aux);
    }
  }
  
  public static void MatriculaCreate(Matricula obj){
    matriculas.Add(obj);
    }
  public static List<Matricula> MatriculaRead(){
    return matriculas;
    }
  public static Matricula MatriculaRead(int id){
    // Retornar a matricula do id informado
    foreach(Matricula obj in matriculas)
    if (obj.GetId() == id){
      return obj;
    }
    return null;
    }
  public static void MatriculaUpdate(Matricula obj){
    // Buscar matricula informada
    Matricula aux = MatriculaRead(obj.GetId());
    // Atualizar atributos da matricula
    if (aux != null){
      aux.SetId(obj.GetId());
      aux.SetNome(obj.GetNome());
      aux.SetIdade(obj.GetIdade());
      aux.SetPagamento(obj.GetPagamento());
      aux.SetPlano(obj.GetPlano());
      aux.SetIdRegistro(obj.GetIdRegistro());
    }
  }
  public static void MatriculaDelete(Matricula obj){
    //Encontrar o indíce do obj na lista
    Matricula aux = MatriculaRead(obj.GetId());
    if (aux != null){
      matriculas.Remove(aux);
    }
    // Remove a matricula quando o índice for achado
  }
  public static void EventoCreate(Evento obj){
    // Id do serviço
    int id = 0;
    foreach(Evento aux in eventos)
      if (aux.Id > id){
        id = aux.Id;
      }
    obj.Id = id + 1;
    eventos.Add(obj);
  }

  public static List<Evento> EventoRead(){
    return eventos;
  }

  public static Evento EventoRead(int id){
    // Olha a lista e pega o id
    foreach(Evento obj in eventos)
      if (obj.Id == id){
        return obj;
      }
    return null;
  }

  public static void EventoUpdate(Evento obj){
    // Encontra o servico com o id
    Evento aux = EventoRead(obj.Id);
    // Atualiza
    if (aux != null){
      aux.Descricao = obj.Descricao;
    }
  }

  public static void EventoDelete(Evento obj){
    Evento aux = EventoRead(obj.Id);
    if (aux != null){
      eventos.Remove(aux);
    }
  }
}