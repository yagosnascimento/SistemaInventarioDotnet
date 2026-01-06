namespace SistemaInventario.Models;
using SistemaInventario.Models;

public class Item
{
    public Item (string Nome, string Descricao, int Quantidade, CategoriaItem Categoria)
    {
        this.Nome = Nome;
        this.Descricao = Descricao;
        this.Quantidade = Quantidade;
        this.Equipado = false;
        this.Categoria = Categoria;
    }

    public string Nome { get; }
    public string Descricao { get; }
    public int Quantidade { get; }
    public bool Equipado { get; set; }
    public CategoriaItem Categoria { get; }

}
