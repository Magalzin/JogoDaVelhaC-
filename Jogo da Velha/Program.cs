using Jogo_da_Velha;
using System;
using System.Globalization;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Inicialização das variaveis
            Players Jogador = new Players();
            int[] Posicao = new int[2];
            char continuar = ' ';
            string[] continuarVerificar = new string[2];
            char JogadorEscolhido;
            string[] JogadorEscolhidoVerificar;


            do
            {
                Console.Clear();
                //Preenche a tabela com variaveis vazias
                JogoVelha.Preencher();
                //Escolhe qual sera o primeiro jogador

                Console.Write("Escolha quem sera o primeiro a jogar(X|O) -> ");
                JogadorEscolhidoVerificar = Console.ReadLine().ToUpperInvariant().Split(' ');


                while (true)
                {
                    if (char.TryParse(JogadorEscolhidoVerificar[0], out JogadorEscolhido) && JogadorEscolhido == 'X' || JogadorEscolhido == 'O')
                    {
                        Players.JogadorAtual = JogadorEscolhido;
                        break;
                    }
                    else
                    {
                        Console.Write("Entrada invalida, tente novamente(X|O) ->");
                        JogadorEscolhidoVerificar = Console.ReadLine().ToUpperInvariant().Split(' ');
                    }
                }

                do
                {
                    //Mostrar a Tabela
                    Console.Clear();
                    JogoVelha.Mostrar();
                    Players.MostrarPontos();

                    //Le a jogada e a insere na tabela
                    JogoVelha.LerJogada();

                    //Verifica a vitoria ou o empate
                    var vencedor = JogoVelha.VerificarVitoria(Players.JogadorAtual);

                    var empate = JogoVelha.VerificarEmpate();

                    if (vencedor == 1 || vencedor == 2 || empate == 1)
                        break;

                    //troca de jogador
                    Players.TrocaJogador();
                } while (true);

                Console.Clear();
                JogoVelha.Mostrar();
                Players.MostrarPontos();

                if (JogoVelha.Vencedor == 1)
                {
                    Console.Write($"PARABENS!! O jogador {Players.JogadorX} Venceu, Sua pontuação de vitorias é {Players.VitoriaX}\n");
                }
                if (JogoVelha.Vencedor == 2)
                {
                    Console.Write($"PARABENS!! O jogador {Players.JogadorO} Venceu, Sua pontuação de vitorias é {Players.VitoriaO}\n");
                }
                if (JogoVelha.Vencedor == 3)
                {
                    Console.Write($"EMPATE!! Infelizmente não há nenhum ganhador\n");
                }

                
                if (continuar == 'n')
                    break;
                else
                {
                    Console.Write("\n" +
                    "Deseja continuar?(s/n) -> ");
                    continuarVerificar = Console.ReadLine().ToUpper().Split(' ');
                    char.TryParse(continuarVerificar[0], out continuar);
                }
            } while (continuar == 's');


        }

    }
}