👨‍💻 Autores

Gustavo Cerqueira Murai
Igor Cerqueira Murai

# 🍽️ RestauranteApp  
Sistema de Pedidos para Cozinha Industrial — Trabalho de Estrutura de Dados em C# (Console App).

---

## 📖 Descrição
Este sistema simula o atendimento de uma cozinha industrial que gerencia **até 50 pedidos por dia**, sendo que cada pedido pode conter **até 10 itens**.  

O programa foi desenvolvido em **C# (Console Application)** no **Visual Studio** e segue os princípios de **Programação Orientada a Objetos (POO)**.  

O sistema permite:
- Criar pedidos sequenciais para clientes  
- Adicionar e remover itens em pedidos  
- Consultar detalhes de um pedido específico  
- Cancelar pedidos  
- Listar todos os pedidos do dia e calcular o valor total geral  

---

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C#  
- **Framework:** .NET (6 ou superior)  
- **IDE:** Visual Studio (não é Visual Studio Code)  
- **Paradigma:** Programação Orientada a Objetos (POO)  

---

## 📂 Estrutura do Projeto
```bash
RestauranteApp/
│
├── Models/
│   ├── Item.cs
│   ├── Pedido.cs
│   └── Restaurante.cs
│
├── Program.cs
└── README.md

-------------------------------------
| Item                              |
|-----------------------------------|
| - id: int                         |
| - descricao: string               |
| - preco: double                   |
-------------------------------------

-------------------------------------
| Pedido                            |
|-----------------------------------|
| - id: int                         |
| - cliente: string                 |
| - itens: Item[10]                 |
|-----------------------------------|
| + adicionarItem(Item item): bool  |
| + removerItem(Item item): bool    |
| + dadosDoPedido(): string         |
| + calcularTotal(): double         |
-------------------------------------

-----------------------------------------
| Restaurante                           |
|---------------------------------------|
| - proxPedido: int                     |
| - pedidos: Pedido[50]                 |
|---------------------------------------|
| + novoPedido(Pedido pedido): bool     |
| + buscarPedido(int id): Pedido        |
| + cancelarPedido(int id): bool        |
-----------------------------------------

Funcionalidades do Menu
0. Sair
1. Criar novo pedido
2. Adicionar item ao pedido
3. Remover item do pedido
4. Consultar pedido (mostrar id, cliente, itens e valor total)
5. Cancelar pedido
6. Listar todos os pedidos (com id, valores totais e soma geral do dia)

