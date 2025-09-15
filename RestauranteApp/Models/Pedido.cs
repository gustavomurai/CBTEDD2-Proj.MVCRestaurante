using System;
using System.Text;

namespace RestauranteApp
{
    public class Pedido
    {
        public int Id { get; set; } // será atribuído pelo Restaurante
        public string Cliente { get; set; }
        private Item[] itens;

        public Pedido(string cliente)
        {
            Cliente = cliente;
            itens = new Item[10]; // máximo de 10 itens por pedido
        }

        // adiciona item, retorna true se conseguiu (ou false se cheio ou item nulo)
        public bool AdicionarItem(Item item)
        {
            if (item == null) return false;

            // evita IDs duplicados no mesmo pedido
            for (int k = 0; k < itens.Length; k++)
                if (itens[k] != null && itens[k].Id == item.Id)
                    return false;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }
            return false; // já tem 10 itens
        }

        // remove item por id, compacta o array e retorna true se removido
        public bool RemoverItem(int itemId)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].Id == itemId)
                {
                    for (int j = i; j < itens.Length - 1; j++)
                        itens[j] = itens[j + 1];
                    itens[itens.Length - 1] = null;
                    return true;
                }
            }
            return false;
        }

        // retorna uma string com os dados do pedido (id, cliente, itens e total)
        public string DadosDoPedido()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Pedido #{Id} - Cliente: {Cliente}");
            sb.AppendLine("Itens:");
            bool temItens = false;
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    sb.AppendLine($"  {itens[i].ToString()}");
                    temItens = true;
                }
            }
            if (!temItens) sb.AppendLine("  (nenhum item)");
            sb.AppendLine($"Valor total: R$ {CalcularTotal():F2}");
            return sb.ToString();
        }

        // soma os preços dos itens
        public double CalcularTotal()
        {
            double total = 0.0;
            for (int i = 0; i < itens.Length; i++)
                if (itens[i] != null)
                    total += itens[i].Preco;
            return total;
        }

        // retorna uma cópia do array de itens (para leitura)
        public Item[] GetItens()
        {
            return (Item[])itens.Clone();
        }
    }
}
