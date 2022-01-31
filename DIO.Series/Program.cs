using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repository = new SerieRepositorio();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						BookList();
						break;
					case "2":
						BookInsert();
						break;
					case "3":
						BookUpdate();
						break;
					case "4":
						BookDelete();
						break;
					case "5":
						BookView();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}

			Console.WriteLine("Obrigado(a) por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void BookDelete()
		{
			Console.Write("Digite o id do livro: ");
			int bookIndex = int.Parse(Console.ReadLine());

			repository.Del(bookIndex);
		}

        private static void BookView()
		{
			Console.Write("Digite o id do livro: ");
			int bookIndex = int.Parse(Console.ReadLine());

			var book = repository.ReturnById(bookIndex);

			Console.WriteLine(book);
		}

        private static void BookUpdate()
		{
			Console.Write("Digite o id do livro: ");
			int bookIndex = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int inputGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do livro: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do livro: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do livro: ");
			string inputDescription = Console.ReadLine();

			Serie updateBook = new Serie(id: bookIndex,
										genre: (Genre)inputGenre,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Update(bookIndex, updateBook);
		}
        private static void BookList()
		{
			Console.WriteLine("Listar Livros");

			var list = repository.Lista();

			if (list.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var book in list)
			{
                var deleted = book.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", book.returnId(),
				book.returnTitle(), (deleted ? "*Excluído*" : ""));
			}
		}

        private static void BookInsert()
		{
			Console.WriteLine("Inserir novo livro");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int inputGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do livro: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do livro: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da livro: ");
			string inputDescription = Console.ReadLine();

			Serie novaBook = new Serie(id: repository.NextId(),
										genre: (Genre)inputGenre,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Insert(novaBook);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Livraria DIO, seja-bem vindo(a).");
			Console.WriteLine("Informe a opção desejada:\n");

			Console.WriteLine("1- Listar Livros");
			Console.WriteLine("2- Inserir novo Livro");
			Console.WriteLine("3- Atualizar Livro");
			Console.WriteLine("4- Excluir Livro");
			Console.WriteLine("5- Visualizar Livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
    }
}
