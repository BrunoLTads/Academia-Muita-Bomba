using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema{
  private static List<Login> logins = new List<Login>();
  private static List<Matricula> matriculas = new List<Matricula>();
  private static List<Aula> aulas = new List<Aula>();
  private static List<Plano> planos = new List<Plano>();
  private static List<Inscricao> inscricoes = new List<Inscricao>();


  public static void ArquivosAbrir(){
    Arquivo<List<Login>> f1 = new Arquivo<List<Login>>();
    logins = f1.Abrir("./logins.xml");

    Arquivo<List<Matricula>> f2 = new Arquivo<List<Matricula>>();
    matriculas = f2.Abrir("./matriculas.xml");

    Arquivo<List<Aula>> f3 = new Arquivo<List<Aula>>();
    aulas = f3.Abrir("./aulas.xml");

    Arquivo<List<Plano>> f4 = new Arquivo<List<Plano>>();
    planos = f4.Abrir("./planos.xml");

    Arquivo<List<Inscricao>> f5 = new Arquivo<List<Inscricao>>();
    inscricoes = f5.Abrir("./inscricoes.xml");
    
    //XmlSerializer xml = new XmlSerializer(typeof(List<Login>));
    //StreamReader f = new StreamReader("./logins.xml", Encoding.Default);
    //logins = (List<Login>) ()xml.Deserialize(f);
    //f.Close();
  }
  public static void ArquivosSalvar(){
    Arquivo<List<Login>> f1 = new Arquivo<List<Login>>();
    f1.Salvar("./logins.xml", logins);

    Arquivo<List<Matricula>> f2 = new Arquivo<List<Matricula>>();
    f2.Salvar("./matriculas.xml", matriculas);

    Arquivo<List<Aula>> f3 = new Arquivo<List<Aula>>();
    f3.Salvar("./aulas.xml", aulas);

    Arquivo<List<Plano>> f4 = new Arquivo<List<Plano>>();
    f4.Salvar("./planos.xml", planos);

    Arquivo<List<Inscricao>> f5 = new Arquivo<List<Inscricao>>();
    f5.Salvar("./inscricoes.xml", inscricoes);
    
    
    //XmlSerializer xml = new XmlSerializer(typeof(List<Login>));
    //StreamWriter f = new StreamWriter("./logins.xml", false, Encoding.Default);
    //logins = (List<Login>) xml.Serialize(f, LoginRead());
    //f.Close();
  }
  
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
      aux.SetIdPlano(obj.GetIdPlano());
      aux.SetIdLogin(obj.GetIdLogin());
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
  public static void AulaCreate(Aula obj){
    // Id da aula
    int id = 0;
    foreach(Aula aux in aulas)
      if (aux.Id > id){
        id = aux.Id;
      }
    obj.Id = id + 1;
    aulas.Add(obj);
  }

  public static List<Aula> AulaRead(){
    return aulas;
  }

  public static Aula AulaRead(int id){
    // Olha a lista e pega o id
    foreach(Aula obj in aulas)
      if (obj.Id == id){
        return obj;
      }
    return null;
  }

  public static void AulaUpdate(Aula obj){
    // Encontra o servico com o id
    Aula aux = AulaRead(obj.Id);
    // Atualiza
    if (aux != null){
      aux.Descricao = obj.Descricao;
    }
  }

  public static void AulaDelete(Aula obj){
    Aula aux = AulaRead(obj.Id);
    if (aux != null){
      aulas.Remove(aux);
    }
  }

  public static void PlanoCreate(Plano obj){
    // Id do plano
    int id = 0;
    foreach(Plano aux in planos)
      if (aux.Id > id){
        id = aux.Id;
      }
    obj.Id = id + 1;
    planos.Add(obj);
  }

  public static List<Plano> PlanoRead(){
    return planos;
  }

  public static Plano PlanoRead(int id){
    // Olha a lista e pega o id
    foreach(Plano obj in planos)
      if (obj.Id == id){
        return obj;
      }
    return null;
  }

  public static void PlanoUpdate(Plano obj){
    // Encontra o servico com o id
    Plano aux = PlanoRead(obj.Id);
    // Atualiza
    if (aux != null){
      aux.Descricao = obj.Descricao;
    }
  }

  public static void PlanoDelete(Plano obj){
    Plano aux = PlanoRead(obj.Id);
    if (aux != null){
      planos.Remove(aux);
    }
  }

public static void InscricaoCreate(Inscricao obj){
    inscricoes.Add(obj);
    }
  public static List<Inscricao> InscricaoRead(){
    return inscricoes;
    }
  public static List<Inscricao> InscricaoListar(Login login){
    List<Inscricao> r = new List<Inscricao>();
    foreach(Inscricao obj in inscricoes)
      if (obj.GetIdLogin() == login.Id)
        r.Add(obj);
        return r; 
  }
  
  public static Inscricao InscricaoRead(int id){
    // Retornar a inscrição do id informado
    foreach(Inscricao obj in inscricoes)
    if (obj.GetId() == id){
      return obj;
    }
    return null;
    }
  public static void InscricaoUpdate(Inscricao obj){
    // Buscar inscrição informada
    Inscricao aux = InscricaoRead(obj.GetId());
    // Atualizar atributos da inscrição
    if (aux != null){
      aux.SetId(obj.GetId());
      aux.SetIdLogin(obj.GetIdLogin());
      aux.SetIdAula(obj.GetIdAula());
    }
  }
  public static void InscricaoDelete(Inscricao obj){
    //Encontrar o indíce do obj na lista
    Inscricao aux = InscricaoRead(obj.GetId());
    if (aux != null){
      inscricoes.Remove(aux);
    }
    // Remove a inscrição quando o índice for achado
  }
}