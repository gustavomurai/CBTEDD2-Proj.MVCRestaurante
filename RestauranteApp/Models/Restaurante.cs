using System;

namespace RestauranteApp
{
    public class Restaurante
    {
        private int proxPedido = 1; // ID sequencial para os pedidos (começa em 1)
        private Pedido[] pedidos = new Pedido[50]; // máximo 50 pedidos por dia

        // adiciona um novo pedido; atribui ID automaticamente
        public bool NovoPedido(Pedido pedido)
        {
            if (pedido == null) return false;
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedido.Id = proxPedido++;
                    pedidos[i] = pedido;
                    return true;
                }
            }
            return false; // capacidade máxima atingida
        }

        // busca pedido por id (retorna objeto Pedido ou null se não achar)
        public Pedido BuscarPedido(int id)
        {
            foreach (var p in pedidos)
                if (p != null && p.Id == id)
                    return p;
            return null;
        }

        // cancela (remove) pedido por id; compacta a lista e retorna true se removido
        public bool CancelarPedido(int id)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Id == id)
                {
                    for (int j = i; j < pedidos.Length - 1; j++)
                        pedidos[j] = pedidos[j + 1];
                    pedidos[pedidos.Length - 1] = null;
                    return true;
                }
            }
            return false;
        }

        // retorna uma cópia do array de pedidos (pode conter nulls)
        public Pedido[] ListarPedidos()
        {
            return (Pedido[])pedidos.Clone();
        }
    }
}
