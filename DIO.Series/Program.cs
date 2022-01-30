using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado(a) por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id do livro: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Del(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id do livro: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id do livro: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do livro: ");
			string entradaTitle = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do livro: ");
			int entradaYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do livro: ");
			string entradaDescription = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genre: (Genre)entradaGenre,
										title: entradaTitle,
										year: entradaYear,
										description: entradaDescription);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar livros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var deleted = serie.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(),
				serie.returnTitle(), (deleted ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir novo livro");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do livro: ");
			string entradaTitle = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do livro: ");
			int entradaYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da livro: ");
			string entradaDescription = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genre: (Genre)entradaGenre,
										title: entradaTitle,
										year: entradaYear,
										description: entradaDescription);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Livraria DIO a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Livros");
			Console.WriteLine("2- Inserir nova Livros");
			Console.WriteLine("3- Atualizar Livros");
			Console.WriteLine("4- Excluir Livros");
			Console.WriteLine("5- Visualizar Livros");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
