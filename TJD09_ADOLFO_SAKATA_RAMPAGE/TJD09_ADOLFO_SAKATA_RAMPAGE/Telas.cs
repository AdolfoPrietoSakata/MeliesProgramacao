using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    public class Telas
    {
        //tela de logo da "empresa", demora 3s pasra aparecer
        
        public void telaLogo()
        {
            

                 string logo = "\n\n\n\n\n\n\n\n\n\n                  ___  _________ ___________ _________  ___\n"
                                    + "                 /  / |  _______|___    ____|   ____  | \\  \\\n"
                                    + "                /  /  |  |          |  |    |  |   |  |  \\  \\\n"
                                    + "               /  /   |  |____      |  |    |  |___|  |   \\  \\\n"
                                    + "               \\  \\   |   ____|     |  |    |   ______|   /  /\n"
                                    + "                \\  \\  |  |          |  |    |  |         /  /\n"
                                    + "                 \\__\\ |__|          |__|    |__|        /__/\n"
                                    + "                       COMPANY";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(logo);
            Thread.Sleep(2000);
            Console.Clear();
        }

        //tela de menu do jogo

        public void telaMenu()
        {
            string menu = "\n\n\n           __________ ________ ____    ____         _______ ________ __   ___  ______\n"
                        + "          |   ____   |   __   |    \\  /    |       |   ____|   __   |  | /  / |      |\n"
                        + "          |  |    |  |  |  |  |     \\/     |  ___  |  |    |  |  |  |  |/  /  |  ____|\n"
                        + "          |  |____|  |  |__|  |            | |___| |  |___ |  |__|  |     /   |  |___ \n"
                        + "          |      ____|   __   |  |\\    /|  |       |   ___||   __   |     \\   |   ___|\n"
                        + "          |  |\\  \\   |  |  |  |  | \\  / |  |       |  |    |  |  |  |  |\\  \\  |  |___ \n"
                        + "          |__| \\__\\  |__|  |__|__|  \\/  |__|       |__|    |__|  |__|__| \\__\\ |______|\n"
                        + "\n\n\n          >>>PARA INICIAR APERTE  [I]"
                        + "\n\n\n          >>>PARA VER OS COMANDOS E A AJUDA DO JOGO APERTE  [H]\n";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(menu);
            string selecaoJogador = Console.ReadLine().ToUpper();
            if (selecaoJogador == "H")
            {
                Console.Clear();
                telaComandos();
            }
            else if (selecaoJogador == "I")
            {
                Console.Clear();
            }
            else
            {
                Console.Clear();
                telaMenu();
            }
        }

        // tela de comandos e ajuda

        public void telaComandos()
        {
            string menu = "\n\n\n           __________ ________ ____    ____         _______ ________ __   ___  ______\n"
                           + "          |   ____   |   __   |    \\  /    |       |   ____|   __   |  | /  / |      |\n"
                           + "          |  |    |  |  |  |  |     \\/     |  ___  |  |    |  |  |  |  |/  /  |  ____|\n"
                           + "          |  |____|  |  |__|  |            | |___| |  |___ |  |__|  |     /   |  |___ \n"
                           + "          |      ____|   __   |  |\\    /|  |       |   ___||   __   |     \\   |   ___|\n"
                           + "          |  |\\  \\   |  |  |  |  | \\  / |  |       |  |    |  |  |  |  |\\  \\  |  |___ \n"
                           + "          |__| \\__\\  |__|  |__|__|  \\/  |__|       |__|    |__|  |__|__| \\__\\ |______|\n\n\n\n";
                          

            string comandos = " SUA MISSÃO É ATACAR A CIDADE E GANHAR PONTOS PARA PODER PASSAR DE NÍVEL\n" +
                              " O NÍVEL TERMINA QUANDO O MONSTRO CHEGA AO OUTRO LADO DA CIDADE\n\n\n" +
                              " USE AS SETAS DO TECLADO PARA MOVIMENTAR O MONSTRO\n\n" + 
                              " TECLA [A] = ATACA ESQUERDA\n" +
                              " TECLA [D] = ATACA DIREITA\n" +
                              " TECLA [S] = ATACA ABAIXO\n" +
                              " TECLA [W] = ATACA ACIMA\n\n\n\n\n" +
                              " PARA VOLTAR AO MENU APERTE [V]";


            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(menu);
            Console.Write(comandos);
            string selecaoJogador = Console.ReadLine().ToUpper();
            if (selecaoJogador == "V")
            {
                Console.Clear();
                telaMenu();
            }
            else
            {
                Console.Clear();
                telaComandos();
            }

            Console.Clear();

        }
    }
}
