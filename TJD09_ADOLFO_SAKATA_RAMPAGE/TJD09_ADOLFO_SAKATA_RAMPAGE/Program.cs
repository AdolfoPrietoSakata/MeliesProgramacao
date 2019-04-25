using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    class Program
    {
        // variavel que diz se o jogador quer recomeçar
        public static bool reset = true;

        

        static void Main(string[] args)
        {

            //Console.Beep(32, 2);
            //som do console


            Console.OutputEncoding = Encoding.UTF8;
            //cria as telas de intro

            Telas telas = new Telas();
            telas.telaLogo();
            telas.telaMenu();

            while (reset)
            {
                //inicia o jogo, cria predios.
                Jogo jogo = new Jogo();
                Predio predio = new Predio();
                predio.desenhaPredios(ref jogo.posicaoCanvas);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n SUA META É DESTRUIR OS PRÉDIOS E CONSEGUIR {0} PONTOS         \n\n", Jogo.pontuacaoNovoNivel);
                Thread.Sleep(1000);

                //atualiza a cada movimento do personagem

                while (true)
                {
                    jogo.Canvas();
                    jogo.Input();

                    jogo.DesenhaPersonagemJogo();

                    if (jogo.jogando())
                    {
                        break;
                    }

                }
            }
        }
    }
}
