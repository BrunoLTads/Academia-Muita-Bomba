using System;

class Sistema{
  private static Registro[] registros = new Registro[10];
  private static int nRegistros;
  public static void RegistroInserir(Registro obj){
    // verifica o tamanho do vetor
    if (nRegistros == registros.Length)
      Array.Resize(ref registros, 2 * registros.Length);
      // Inserir o objeto no vetor
      registros[nRegistros] = obj;
      // Incrementar o contador
      nRegistros++;
    }
  public static Registro[] RegistroListar(){
    // Retornar os objetos cadastrados
    Registro[] aux = new Registro[nRegistros];
    Array.Copy(registros, aux, nRegistros);
    return aux;
    }
  public static Registro RegistroListar(int id){
    // Retornar o registro do id informado
    foreach(Registro obj in registros)
    if (obj != null && obj.GetId() == id){
      return obj;
    }
    return null;
    }
  public static void RegistroAtualizar(Registro obj){
    // Buscar registro informado
    Registro aux = RegistroListar(obj.GetId());
    // Atualizar a descrição
    if (aux != null){
      aux.SetDescricao(obj.GetDescricao());
    }
  }
  public static void RegistroExcluir(Registro obj){
    //Encontrar o indíce do obj no vetor
    int aux = RegistroIndice(obj.GetId());
    // Remove o registro quando o índice for achado
    if (aux != -1){
      for (int i = aux; i < nRegistros - 1; i++){
        registros[i] = registros[i + 1];
        nRegistros--;
        // Ficar atento a esse nRegistros(nRegistro)
      }
    }
  }
  public static int RegistroIndice(int id){
    //Localizar os registros no vetor para retornar o índice com o id
    for(int i = 0; i < nRegistros; i++){
      // Cada obj registro
      Registro obj = registros[i];
      if (obj.GetId() == id) return i;
    }
    return -1;
  }
}