using RestauranteWarley.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RestauranteWarley.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelPedidos model)
        {
            // Array char para separação das strings através dos caracteres.
            char[] delimitador = { ',', '.' };

            string novoPedido = model.Pedido;

            // Array pedidos para recebimento das strings separadas da função Split com o caracteres do delimitador
            string[] pedidos = novoPedido.Split(delimitador);

            string menu = "";
            string[] periodo = { "Manhã", "Noite" };

            // Array com a quantidade de indice pela contagem de strings separado pelo delimitador.
            // Variável será armazenado o pedido do usuário.
            string[] cardapio = new string[pedidos.Length - 1];

            // Variável quantidadePedido é a contagem de solicitação de café ou batatas pelo usuário.
            int quantidadePedido = 1;
            int k = 0;

            // Verifição do período escolhido pelo usuário.
            if (periodo[0] == pedidos[0])
            {
                for (int i = 1; i < pedidos.Length; i++)
                {
                    // Pegando o id do pedido solicitado para validação do nome do pedido.
                    string idPedido = pedidos[i];

                    // Validando o id do pedido pelo Switch Case.
                    switch (idPedido)
                    {
                        case " 1":
                            // Acrecenta o nome do pedido a variável cardápio, pelo operador ternário.
                            cardapio[k] = cardapio.Contains("Ovos, ") ? "Erro, " : "Ovos, ";
                            break;
                        case " 2":
                            // Acrecenta o nome do pedido a variável cardápio, pelo operador ternário.
                            cardapio[k] = cardapio.Contains("Torradas, ") ? "Erro, " : "Torradas, ";
                            break;
                        case " 3":
                            string cafe = "";

                            // Validação da quantidade de cafés solicitado pelo usuário.
                            for (int j = 0; j < cardapio.Length; j++)
                            {
                                if (cardapio[j] == "Café, ")
                                {
                                    quantidadePedido += 1;
                                    cardapio[j] = "Café(x" + quantidadePedido + "), ";
                                    cafe = cardapio[j];
                                }
                                else if (cardapio[j] == "Café(x" + quantidadePedido + "), ")
                                {
                                    quantidadePedido += 1;
                                    cardapio[j] = "Café(x" + quantidadePedido + "), ";
                                    cafe = cardapio[j];
                                }
                                else
                                {
                                    cafe = cardapio.Contains("Café, ") || cardapio.Contains("Café(x" + quantidadePedido + "), ") ? "" : "Café, ";
                                }
                            }

                            // Inserindo a variável café no array cardapio.
                            cardapio[k] = cafe;
                            break;
                        default:
                            cardapio[k] = "Erro, ";
                            break;
                    }

                    // Utilização do String.Join para a junção das strings do array cardapio.
                    menu = String.Join("", cardapio.ToArray());
                    k++;
                }
            }
            else
            {
                for (int i = 1; i < pedidos.Length; i++)
                {
                    // Pegando o id do pedido solicitado para validação do nome do pedido.
                    string idPedido = pedidos[i];

                    // Validando o id do pedido pelo Switch Case.
                    switch (idPedido)
                    {
                        case " 1":
                            // Acrecenta o nome do pedido a variável cardápio, pelo operador ternário.
                            cardapio[k] = cardapio.Contains("Bife, ") ? "Erro, " : "Bife, ";
                            break;
                        case " 2":
                            string batatas = "";

                            // Validação da quantidade de batatas solicitado pelo usuário.
                            for (int j = 0; j < cardapio.Length; j++)
                            {
                                if (cardapio[j] == "Batatas, ")
                                {
                                    quantidadePedido += 1;
                                    cardapio[j] = "Batatas(x" + quantidadePedido + "), ";
                                    batatas = cardapio[j];
                                }
                                else if (cardapio[j] == "Batatas(x" + quantidadePedido + "), ")
                                {
                                    quantidadePedido += 1;
                                    cardapio[j] = "Batatas(x" + quantidadePedido + "), ";
                                    batatas = cardapio[j];
                                }
                                else
                                {
                                    batatas = cardapio.Contains("Batatas, ") || cardapio.Contains("Batatas(x" + quantidadePedido + "), ") ? "" : "Batatas, ";
                                }
                            }
                            cardapio[k] = batatas;
                            break;
                        case " 3":
                            // Acrecenta o nome do pedido a variável cardápio, pelo operador ternário.
                            cardapio[k] = cardapio.Contains("Vinho, ") ? "Erro, " : "Vinho, ";
                            break;
                        case " 4":
                            // Acrecenta o nome do pedido a variável cardápio, pelo operador ternário.
                            cardapio[k] = cardapio.Contains("Bolo, ") ? "Erro, " : "Bolo, ";
                            break;
                        default:
                            cardapio[k] = "Erro, ";
                            break;
                    }

                    // Utilização do String.Join para a junção das strings do array cardapio.
                    menu = String.Join("", cardapio.ToArray());
                    k++;
                }
            }

            // Criando um lista com os id dos pedidos solicitado pelo usuário.
            List<string> listaPedidos = model.ListaPedidos is null ? new List<string>() : model.ListaPedidos;
            listaPedidos.Add(novoPedido);
            model.ListaPedidos = listaPedidos;

            // Criando um lista com os nomes dos pedidos solicitado pelo usuário.
            List<string> listCardapio = model.ListCardapio is null ? new List<string>() : model.ListCardapio;
            listCardapio.Add(menu);
            model.ListCardapio = listCardapio;

            return View(model);
        }
    }
}