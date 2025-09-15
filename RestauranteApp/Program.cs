using System;
using System.Globalization;

namespace RestauranteApp
{
    class Program
    {
        static Restaurante restaurante = new Restaurante();

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Pedidos - Cozinha Industrial";
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Criar novo pedido");
                Console.WriteLine("2. Adicionar item ao pedido");
                Console.WriteLine("3. Remover item do pedido");
                Console.WriteLine("4. Consultar pedido (mostrar id, cliente, itens e valor total)");
                Console.WriteLine("5. Cancelar pedido");
                Console.WriteLine("6. Listar todos os pedidos (id, valores totais e soma geral do dia)");
                Console.Write("Escolha uma opção: ");

                string opc = Console.ReadLine()?.Trim();

                switch (opc)
                {
                    case "0":
                        executando = false;
                        break;
                    case "1":
                        CriarNovoPedido();
                        break;
                    case "2":
                        AdicionarItemAoPedido();
                        break;
                    case "3":
                        RemoverItemDoPedido();
                        break;
                    case "4":
                        ConsultarPedido();
                        break;
                    case "5":
                        CancelarPedido();
                        break;
                    case "6":
                        ListarPedidos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            Console.WriteLine("Encerrando... pressione qualquer tecla.");
            Console.ReadKey();
        }

        static void CriarNovoPedido()
        {
            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(cliente))
            {
                Console.WriteLine("Nome inválido. Operação cancelada.");
                return;
            }
            Pedido p = new Pedido(cliente);
            if (restaurante.NovoPedido(p))
                Console.WriteLine($"Pedido criado com sucesso! ID: {p.Id}");
            else
                Console.WriteLine("Não foi possível criar o pedido. Capacidade máxima (50) atingida.");
        }

        static void AdicionarItemAoPedido()
        {
            int idPedido = LerInt("Digite o ID do pedido para adicionar um item: ");
            var pedido = restaurante.BuscarPedido(idPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }

            int idItem = LerInt("Digite o ID do item: ");
            Console.Write("Descrição do item: ");
            string desc = Console.ReadLine()?.Trim() ?? "";
            double preco = LerDouble("Preço do item (ex: 12.50 ou 12,50): ");

            Item item = new Item(idItem, desc, preco);
            if (pedido.AdicionarItem(item))
                Console.WriteLine("Item adicionado com sucesso.");
            else
                Console.WriteLine("Não foi possível adicionar. Pedido pode estar cheio (10 itens) ou já conter item com esse ID.");
        }

        static void RemoverItemDoPedido()
        {
            int idPedido = LerInt("Digite o ID do pedido: ");
            var pedido = restaurante.BuscarPedido(idPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }
            int idItem = LerInt("Digite o ID do item a remover: ");
            if (pedido.RemoverItem(idItem))
                Console.WriteLine("Item removido com sucesso.");
            else
                Console.WriteLine("Item não encontrado no pedido.");
        }

        static void ConsultarPedido()
        {
            int idPedido = LerInt("Digite o ID do pedido: ");
            var pedido = restaurante.BuscarPedido(idPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }
            Console.WriteLine("\n" + pedido.DadosDoPedido());
        }

        static void CancelarPedido()
        {
            int idPedido = LerInt("Digite o ID do pedido a cancelar: ");
            if (restaurante.CancelarPedido(idPedido))
                Console.WriteLine("Pedido cancelado com sucesso.");
            else
                Console.WriteLine("Pedido não encontrado.");
        }

        static void ListarPedidos()
        {
            var lista = restaurante.ListarPedidos();
            double somaGeral = 0;
            Console.WriteLine("\n=== Pedidos do dia ===");
            bool tem = false;
            foreach (var p in lista)
            {
                if (p != null)
                {
                    tem = true;
                    double total = p.CalcularTotal();
                    somaGeral += total;
                    Console.WriteLine($"ID {p.Id} | Cliente: {p.Cliente} | Total: R$ {total:F2}");
                }
            }
            if (!tem) Console.WriteLine("(Nenhum pedido registrado)");
            Console.WriteLine($"Soma geral do dia: R$ {somaGeral:F2}");
        }

        static int LerInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v))
                    return v;
                Console.WriteLine("Valor inválido. Digite um número inteiro.");
            }
        }

        static double LerDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (double.TryParse(s, System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.CurrentCulture, out double v) ||
                    double.TryParse(s, System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.InvariantCulture, out v))
                {
                    return v;
                }
                Console.WriteLine("Valor inválido. Use formato numérico (ex.: 12.50 ou 12,50).");
            }
        }
    }
}
