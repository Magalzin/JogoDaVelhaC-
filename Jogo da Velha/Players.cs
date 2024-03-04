using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha
{
    internal class Players
    {
        public static char JogadorX { get; private set; } = 'X';
        public static char JogadorO { get; private set; } = 'O';
        public static int VitoriaX;
        public static int VitoriaO;
        public static char JogadorAtual;

        public static void TrocaJogador()
        {
            if (JogadorAtual == JogadorO) 
            { 
                JogadorAtual = JogadorX;
            }
            else if (JogadorAtual == JogadorX)
            {
                JogadorAtual = JogadorO;
            }
        }

        public static void MostrarPontos()
        {
            Console.Write($"Vitórias do jogador X = {VitoriaX}\n");
            Console.Write($"Vitórias do jogador O = {VitoriaO}\n" +
                $"\n" +
                $"\n");
        }




    }
}
