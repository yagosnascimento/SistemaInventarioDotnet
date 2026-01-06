namespace SistemaInventario.Models;

public class Personagem
{
    public Personagem(string Nome, int Nivel, CategoriaClasse Classe)
    {
        this.Nome = Nome;
        this.Nivel = Nivel;
        this.Classe = Classe;
        this.Mochila = new Inventario();
    }

    public string Nome { get; }
    public int Nivel { get; }
    public CategoriaClasse Classe { get; }
    public Inventario Mochila { get; }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nome: {Nome}, Nível: {Nivel}, Classe: {Classe}");
    }

    public void ExibirInventario()
    {
        foreach (var item in Mochila.Itens)
        {
            Console.WriteLine($"Item: {item.Nome}, Descrição: {item.Descricao}, Quantidade: {item.Quantidade}, Equipado: {item.Equipado}");
        }
    }

    public void EquiparItem (Item itempraequipar)
    {
        if (itempraequipar.Categoria == CategoriaItem.Arma || itempraequipar.Categoria == CategoriaItem.Armadura)
        {
            itempraequipar.Equipado = true;
            Console.WriteLine($"{itempraequipar.Nome} Foi equipado!");
        }
        else
        {
            Console.WriteLine($"{itempraequipar.Nome} Não pode ser equipado!");
        }
    }

    public void DesequiparItem (Item itempradesequipar)
    {
        if (itempradesequipar.Equipado)
        {
            itempradesequipar.Equipado = false;
            Console.WriteLine($"{itempradesequipar.Nome} Foi desequipado!");
        }
        else
        {
            Console.WriteLine($"{itempradesequipar.Nome} Não está equipado!");
        }
    }

    public void MostrarEquipados()
    {
        Console.WriteLine("Itens Equipados:");
        foreach (var item in Mochila.Itens)
        {
            if (item.Equipado)
            {
                Console.WriteLine($"- {item.Nome}");
            }
        }
    }
}
