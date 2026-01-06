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
            Console.WriteLine("2 - Ver meus personagens e Equipar Itens");
            Console.WriteLine("3 - Criar um Item Novo");
            Console.WriteLine("4 - Ver Itens Criados");
            Console.WriteLine("5 - Dar um Item para um Personagem");
            Console.WriteLine("Digite 'sair' para fechar");
            Console.Write("\nO que voce quer fazer? ");

            opcao = Console.ReadLine().ToLower();

            switch (opcao)
            {
                case "1":
                    Console.Write("Qual o nome dele? ");
                    string n = Console.ReadLine();
                    Console.Write("Qual o nivel? ");
                    if (!int.TryParse(Console.ReadLine(), out int niv))
                    {
                        Console.WriteLine("Erro: Nível inválido. Use números.");
                        Console.ReadKey();
                        break;
                    }
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
                        Console.WriteLine("Erro: Essa classe não existe.");
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("\n--- Seus Personagens ---");
                    if (listaDePersonagens.Count == 0) Console.WriteLine("Nenhum personagem criado.");
                    for (int i = 0; i < listaDePersonagens.Count; i++)
                    {
                        Console.WriteLine($"\n[{i}]");
                        listaDePersonagens[i].MostrarInfo();
                        listaDePersonagens[i].MostrarEquipados();
                        Console.WriteLine("Inventário:");
                        listaDePersonagens[i].ExibirInventario();
                    }

                    Console.WriteLine("\nDeseja EQUIPAR um item de um personagem? (s/n)");
                    if (Console.ReadLine().ToLower() == "s" && listaDePersonagens.Count > 0)
                    {
                        Console.Write("Digite o número do personagem: ");
                        if (int.TryParse(Console.ReadLine(), out int pIdx) && pIdx < listaDePersonagens.Count)
                        {
                            var p = listaDePersonagens[pIdx];
                            Console.WriteLine($"\nItens na mochila de {p.Nome}:");
                            for (int j = 0; j < p.Mochila.Itens.Count; j++)
                                Console.WriteLine($"{j} - {p.Mochila.Itens[j].Nome}");

                            Console.Write("Escolha o número do item para equipar: ");
                            if (int.TryParse(Console.ReadLine(), out int iIdx) && iIdx < p.Mochila.Itens.Count)
                                p.EquiparItem(p.Mochila.Itens[iIdx]);
                        }
                    }
                    Console.WriteLine("\nPressione qualquer tecla...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Nome do Item: ");
                    string nomeI = Console.ReadLine();
                    Console.Write("Descricao: ");
                    string descI = Console.ReadLine();
                    Console.Write("Quantidade: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantI))
                    {
                        Console.WriteLine("Erro: Quantidade inválida.");
                        Console.ReadKey();
                        break;
                    }
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
                        Console.WriteLine("Erro: Categoria inexistente.");
                    }
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("\n--- Banco de Itens: ---");
                    foreach (var i in listaDeItens)
                        Console.WriteLine($"Item: {i.Nome} - {i.Descricao} - Tipo: {i.Categoria}");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine("\n--- DAR ITEM PARA PERSONAGEM ---");
                    if (listaDePersonagens.Count == 0 || listaDeItens.Count == 0)
                    {
                        Console.WriteLine("Crie personagens e itens primeiro.");
                    }
                    else
                    {
                        for (int i = 0; i < listaDePersonagens.Count; i++)
                            Console.WriteLine($"{i} - {listaDePersonagens[i].Nome}");
                        Console.Write("Número do Personagem: ");
                        int pSel = int.Parse(Console.ReadLine());

                        for (int i = 0; i < listaDeItens.Count; i++)
                            Console.WriteLine($"{i} - {listaDeItens[i].Nome}");
                        Console.Write("Número do Item: ");
                        int iSel = int.Parse(Console.ReadLine());

                        listaDePersonagens[pSel].Mochila.Itens.Add(listaDeItens[iSel]);
                        Console.WriteLine("Item entregue!");
                    }
                    Console.ReadKey();
                    break;

                case "sair":
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opcao invalida!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}