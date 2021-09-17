using System;
using Dio.Series;
using System.Collections.Generic;
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
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
                    default:
                       Console.WriteLine("Voce precisa selecionar uma opção ;)");
                       break; 
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine();
            Console.WriteLine("Até a próxima!");
            Console.WriteLine("   #Partiu    ");
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("xxxxxx_____________________________________________xxxxxx");
            Console.WriteLine("xxxxxx|  Bem Vindo ao meu catálogo de séries :)   |xxxxxx");
            Console.WriteLine("xxxxxx|                                           |xxxxxx");
            Console.WriteLine("xxxxxx|  Informe a opção desejada:                |xxxxxx");
            Console.WriteLine("xxxxxx|                                           |xxxxxx");
            Console.WriteLine("xxxxxx|  1- Listar séries                         |xxxxxx");
            Console.WriteLine("xxxxxx|  2- Inserir nova série                    |xxxxxx");
            Console.WriteLine("xxxxxx|  3- Atualizar série                       |xxxxxx");
            Console.WriteLine("xxxxxx|  4- Excluir série                         |xxxxxx");
            Console.WriteLine("xxxxxx|  5- Visualizar série                      |xxxxxx");
            Console.WriteLine("xxxxxx|  X- Encerrrar                             |xxxxxx");
            Console.WriteLine("xxxxxx|___________________________________________|xxxxxx");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0 )
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma série Cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                if (serie.retornaExcluido() != true)
                {
                Console.WriteLine("#ID {0}: - {1}", serie.retonaId(), serie.retornaTitulo());
                }
            }
        }
        private static void InserirSeries()
        {
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            
            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            repositorio.Insere(novaSerie);
            }
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Deseja mesmo excluir a série: Y/N ?: ");
            string confirmacao = Console.ReadLine().ToUpper();
            if (confirmacao == "Y")
            {
            repositorio.Exclui(indiceSerie);
            }
            return;
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine();
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }     
    }
}