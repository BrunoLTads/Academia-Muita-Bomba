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
}