using SistemaInventario.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Personagem> listaDePersonagens = new List<Personagem>();
        List<Item> listaDeItens = new List<Item>();

        string opcao = "";

        while (opcao != "sair")
        {
            Console.Clear();
            Console.WriteLine(@"
    ________________________  ______     ___  ___  _____
   / __/  _/ __/_  __/ __/  |/  / _ |   / _ \/ _ \/ ___/
  _\ \_/ /_\ \  / / / _// /|_/ / __ |  / , _/ ___/ (_ / 
 /___/___/___/ /_/ /___/_/  /_/_/ |_| /_/|_/_/   \___/ ");

            Console.WriteLine("1 - Criar um personagem");
            Console.WriteLine("2 - Ver meus personagens");
            Console.WriteLine("3 - Criar um Item Novo");
            Console.WriteLine("4 - Ver Itens Criados");
            Console.WriteLine("Digite 'sair' para fechar");
            Console.Write("\nO que voce quer fazer? ");

            opcao = Console.ReadLine().ToLower();

            switch (opcao)
            {
                case "1":
                    Console.Write("Qual o nome dele? ");
                    string n = Console.ReadLine();
                    Console.Write("Qual o nivel? ");
                    int niv = int.Parse(Console.ReadLine());
                    Console.Write("Qual a classe? (Guerreiro, Mago, Arqueiro): ");
                    string entradaClasse = Console.ReadLine();
                    if (Enum.TryParse(entradaClasse, true, out CategoriaClasse classeFinal))
                    {
                        Personagem p = new Personagem(n, niv, classeFinal);
                        listaDePersonagens.Add(p);
                        Console.WriteLine("Personagem salvo com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro: Essa classe não existe. Tente Guerreiro, Mago ou Arqueiro.");
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine(" Personagens: ");
                    foreach (var boneco in listaDePersonagens)
                    {
                        boneco.MostrarInfo();
                        boneco.ExibirInventario();
                    }
                    break;

                case "3":
                    Console.Write("Nome do Item: ");
                    string nomeI = Console.ReadLine();

                    Console.Write("Descricao: ");
                    string descI = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    int quantI = int.Parse(Console.ReadLine());

                    Console.Write("Categoria (Arma, Armadura, Consumivel, Material, Outro): ");
                    string entradaCat = Console.ReadLine();
                    if (Enum.TryParse(entradaCat, true, out CategoriaItem catFinal))
                    {
                        Item novoItem = new Item(nomeI, descI, quantI, catFinal);
                        listaDeItens.Add(novoItem);

                        Console.WriteLine("Item guardado no banco com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro: Categoria inexistente. Use: Arma, Armadura, Consumivel, Material ou Outro.");
                    }

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("\n--- Banco de Itens: ---");
                    foreach (var i in listaDeItens)
                    {
                        Console.WriteLine($"Item: {i.Nome} - {i.Descricao} - Qtd: {i.Quantidade} - Tipo: {i.Categoria}");
                    }
                    break;

                case "sair":
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente de novo!");
                    break;
            }
        }

        Console.WriteLine("Fim do programa!");
    }
}