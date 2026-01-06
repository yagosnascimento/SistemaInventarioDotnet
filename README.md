Este é um modelo de `README.md` estruturado para o seu projeto, focando especialmente no uso de **Enums** e no processo de **validação** que você implementou para garantir que o usuário escolha apenas opções válidas.

---

# Sistema de Inventário RPG (.NET 8)

Este é um sistema de gerenciamento de inventário para RPG desenvolvido em C#. O projeto permite a criação de personagens de diferentes classes, a criação de itens categorizados e a gestão de equipamentos (equipar/desequipar).

## 🚀 Funcionalidades

* **Criação de Personagens:** Define nome, nível e classe.
* **Banco de Itens:** Criação de itens globais com descrição e categoria.
* **Gestão de Inventário:** Transferência de itens do banco para personagens específicos.
* **Sistema de Equipamento:** Possibilidade de equipar ou desequipar itens que estão na mochila do personagem.

## 🛠️ O uso de Enums (Categorias e Classes)

No projeto, utilizamos **Enums** para padronizar as opções disponíveis e evitar erros de digitação. Um `Enum` (enumeração) define um conjunto de constantes nomeadas, garantindo que uma variável só aceite valores pré-definidos.

Foram criados dois Enums principais no arquivo `Categoria.cs`:

* `CategoriaItem`: Define se o item é uma **Arma, Armadura, Consumivel, Material** ou **Outro**.
* `CategoriaClasse`: Define se o personagem é um **Guerreiro, Mago** ou **Arqueiro**.

## 🔍 Validação de Entradas

Para garantir que o sistema não trave caso o usuário digite uma opção inválida, foi implementada uma lógica de validação robusta no `Program.cs` utilizando o método `Enum.TryParse`.

### Como funciona a validação:

1. **Entrada de Texto:** O sistema solicita que o usuário digite o nome da classe ou categoria (ex: "Mago").
2. **Tentativa de Conversão (`TryParse`):** O código tenta converter o texto digitado para o tipo do Enum correspondente.
3. **Tratamento de Erro:** * Se o texto corresponder a um dos nomes no Enum, o objeto é criado com sucesso.
* Se o usuário digitar algo inexistente (ex: "Ninja"), o sistema identifica que a conversão falhou e exibe uma mensagem de erro: `"Erro: Essa classe não existe"` ou `"Erro: Categoria inexistente"`, impedindo o fechamento abrupto do programa.



**Exemplo de código da validação:**

```csharp
if (Enum.TryParse(entradaClasse, true, out CategoriaClasse classeFinal)) 
{
    // Se a conversão der certo, cria o personagem
    Personagem p = new Personagem(n, niv, classeFinal);
} 
else 
{
    // Se falhar, avisa o usuário
    Console.WriteLine("Erro: Essa classe não existe.");
}

```

## 📂 Estrutura do Projeto

* `Models/`: Contém as classes de modelo (`Item`, `Personagem`, `Inventario`) e os `Enums`.
* `Program.cs`: Contém o menu principal e a lógica de interação com o usuário.

## ⚙️ Como executar

1. Certifique-se de ter o **SDK do .NET 8** instalado.
2. Clone o repositório.
3. No terminal, execute:
```bash
dotnet run

```