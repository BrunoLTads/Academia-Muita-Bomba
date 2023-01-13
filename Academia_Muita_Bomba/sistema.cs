using System;
using System.Collections.Generic;

class Sistema{
  private static List<Login> logins = new List<Login>();
  private static List<Matricula> matriculas = new List<Matricula>();
  private static List<Evento> eventos = new List<Evento>();

  public static void LoginInserir(Login obj){
    logins.Add(obj);
  }
  public static List<Login> LoginListar(){
    return logins;
  }
  public static Login LoginListar(int id){
    foreach(Login obj in logins)
    if (obj.GetId() == id){
      return obj;
    }
  return null;
  }
  public static void LoginAtualizar(Login obj){
    Login aux = LoginListar(obj.GetId());
    if (aux != null){
      aux.SetId(obj.GetId());
      aux.SetNome(obj.GetNome());
      aux.SetSenha(obj.GetSenha());
      aux.SetCargo(obj.GetCargo());
    }
  }
  public static void LoginExcluir(Login obj){
    Login aux = LoginListar(obj.GetId());
    if (aux != null){
      logins.Remove(aux);
    }
  }
  
  public static void MatriculaInserir(Matricula obj){
    matriculas.Add(obj);
    }
  public static List<Matricula> MatriculaListar(){
    return matriculas;
    }
  public static Matricula MatriculaListar(int id){
    // Retornar a matricula do id informado
    foreach(Matricula obj in matriculas)
    if (obj.GetId() == id){
      return obj;
    }
    return null;
    }
  public static void MatriculaAtualizar(Matricula obj){
    // Buscar matricula informada
    Matricula aux = MatriculaListar(obj.GetId());
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
  public static void MatriculaExcluir(Matricula obj){
    //Encontrar o indíce do obj na lista
    Matricula aux = MatriculaListar(obj.GetId());
    if (aux != null){
      matriculas.Remove(aux);
    }
    // Remove a matricula quando o índice for achado
  }
  public static void EventoInserir(Evento obj){
    // Id do serviço
    int id = 0;
    foreach(Evento aux in eventos)
      if (aux.Id > id){
        id = aux.Id;
      }
    obj.Id = id + 1;
    eventos.Add(obj);
  }

  public static List<Evento> EventoListar(){
    return eventos;
  }

  public static Evento EventoListar(int id){
    // Olha a lista e pega o id
    foreach(Evento obj in eventos)
      if (obj.Id == id){
        return obj;
      }
    return null;
  }

  public static void EventoAtualizar(Evento obj){
    // Encontra o servico com o id
    Evento aux = EventoListar(obj.Id);
    // Atualiza
    if (aux != null){
      aux.Descricao = obj.Descricao;
    }
  }

  public static void EventoExcluir(Evento obj){
    Evento aux = EventoListar(obj.Id);
    if (aux != null){
      eventos.Remove(aux);
    }
  }
}