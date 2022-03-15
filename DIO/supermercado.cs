using System;
using System.Linq;

class MinhaClasse {
  public static void Main (string[] args) {

    var totalDeCasosDeTeste = int.Parse(Console.ReadLine());

    int i = totalDeCasosDeTeste;
    string[] lista;

    for( ; i > 0; i--)
    {
        lista = Console.ReadLine().Split();

        var newList = lista.Distinct().ToList();
        newList.Sort();
        Console.WriteLine(String.Join(" ",newList));
        
    }

  }
}