using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha
{
    internal class JogoVelha
    {
        static char[,] B = new char[3, 3];
        public static string JogoDaVelha;
        public static int Vencedor = 0;

        public static void Preencher()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    B[i, j] = ' ';
                }
            }
            Jogo();
        }


        public static void LerJogada()
        {
            int[] Posicao = new int[2];

            Console.Clear();
            Mostrar();
            Players.MostrarPontos();

            Console.Write($"Jogador atual = {Players.JogadorAtual}\n");
            Console.Write("Insira a linha(1 a 3) e coluna(1 a 3)\nPosição = ");
            string[] posicaoLer = Console.ReadLine().Split(' ');

            InserirValoresValidos(Posicao, posicaoLer);
        }


        public static void InserirValoresValidos(int[] Posicao, string[] posicaoLer)
        {
            if (posicaoLer.Length == 2 &&
                int.TryParse(posicaoLer[0], out Posicao[0]) && Posicao[0] >= 1 && Posicao[0] <= 3 &&
                int.TryParse(posicaoLer[1], out Posicao[1]) && Posicao[1] >= 1 && Posicao[1] <= 3)
            {
                InserirJogador(Players.JogadorAtual, Posicao[0], Posicao[1]);

                return;
            }

            Console.WriteLine("Linha ou coluna inserida errada, Insira a linha(1 a 3) e coluna(1 a 3)");
            Console.Write("Posição = ");
            posicaoLer = Console.ReadLine().Split(' ');

            InserirValoresValidos(Posicao, posicaoLer);

        }

        //Coloca o jogador na posição desejada
        public static void InserirJogador(char jogador, int posicao1, int posicao2)
        {
            if (B[posicao1 - 1, posicao2 - 1] != ' ')
            {
                Console.Write("\nJogada invalida!!\n" +
                    "TenteNovamente\n\n");
                Console.ReadKey();
                LerJogada();
            }
            else
            {
                B[posicao1 - 1, posicao2 - 1] = jogador;
                Jogo();
            }

        }

        //Tabela do jogo
        public static void Jogo()
        {
            JogoDaVelha =
            $" {B[0, 0]} | {B[0, 1]} | {B[0, 2]} \n" +
            $"---+---+---\n" +
            $" {B[1, 0]} | {B[1, 1]} | {B[1, 2]} \n" +
            $"---+---+---\n" +
            $" {B[2, 0]} | {B[2, 1]} | {B[2, 2]} \n";
        }

        //Verifica o empate
        public static int VerificarEmpate()
        {
            int Voltar = (B[0, 0] != ' ' && B[0, 1] != ' ' && B[0, 2] != ' '
                && B[1, 0] != ' ' && B[1, 1] != ' ' && B[1, 2] != ' '
                && B[2, 0] != ' ' && B[2, 1] != ' ' && B[2, 2] != ' ') ? 1 : 0;
            if(Voltar == 1)
                Vencedor = 3;

            return Voltar;
        }

        //Verifica o Vencedor
        public static int VerificarVitoria(char jogadorAtual)
        {
            Vencedor = 0;
            if (B[0, 0] == jogadorAtual && B[1, 1] == jogadorAtual && B[2, 2] == jogadorAtual ||
                B[0, 2] == jogadorAtual && B[1, 1] == jogadorAtual && B[2, 0] == jogadorAtual)
            {
                if (jogadorAtual == 'X')
                {
                    Players.VitoriaX++;
                    Vencedor = 1;
                }
                if (jogadorAtual == 'O')
                {
                    Players.VitoriaO++;
                    Vencedor = 2;
                }
            }
            else if (B[0, 0] == jogadorAtual && B[0, 1] == jogadorAtual && B[0, 2] == jogadorAtual
                || B[1, 0] == jogadorAtual && B[1, 1] == jogadorAtual && B[1, 2] == jogadorAtual
                || B[2, 0] == jogadorAtual && B[2, 1] == jogadorAtual && B[2, 2] == jogadorAtual)
            {
                if (jogadorAtual == 'X')
                {
                    Players.VitoriaX++;
                    Vencedor = 1;
                }
                if (jogadorAtual == 'O')
                {
                    Players.VitoriaO++;
                    Vencedor = 2;
                }
            }
            else if (B[0, 0] == jogadorAtual && B[1, 0] == jogadorAtual && B[2, 0] == jogadorAtual
                || B[0, 1] == jogadorAtual && B[1, 1] == jogadorAtual && B[2, 1] == jogadorAtual
                || B[0, 2] == jogadorAtual && B[1, 2] == jogadorAtual && B[2, 2] == jogadorAtual)
            {
                if (jogadorAtual == 'X')
                {
                    Players.VitoriaX++;
                    Vencedor = 1;
                }
                if (jogadorAtual == 'O')
                {
                    Players.VitoriaO++;
                    Vencedor = 2;
                }
            }

            return Vencedor;
        }

        //Mostra a tabela do jogo
        public static void Mostrar()
        {
            Console.WriteLine(JogoDaVelha);
        }
    }
}
