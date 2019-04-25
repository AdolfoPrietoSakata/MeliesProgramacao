using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    public class Jogo
    {
        public static char pixelPreto = ' ';
        public static char pixelBloco = '\u2588';
        public static char pixelJogador = '\u1D15';
        public static char pixelRua = '-';
        public static int pontuacaoNovoNivel = 1000;
        public static int nivelAtual = 1;
        static int larguraTela = 100;
        static int alturaTela = 22;
        static int pontuacao;
        string buffer;
        bool precisaAtualizarTela = true;

        //habilitar o unicode do personagem

        Personagem personagem = new Personagem(pixelJogador, Definicoes.POSICAO_MIN_X, Definicoes.NIVEL_DE_CHAO);
        ConsoleKeyInfo teclaApertada;

        public char[,] posicaoCanvas = new char[larguraTela, alturaTela];

        public void Canvas()
        {
            if (!precisaAtualizarTela)
            {
                return;
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     PONTOS - {0} - NÍVEL - {1} ", pontuacao, nivelAtual);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            for (int y = 0; y < alturaTela; y++)
            {
                for (int x = 0; x < larguraTela; x++)
                {
                    if (posicaoCanvas[x, y] == 0 || posicaoCanvas[x, y] == pixelPreto)
                    {
                        posicaoCanvas[x, y] = pixelPreto;
                        buffer += posicaoCanvas[x, y].ToString();
                    }
                    else if (posicaoCanvas[x, y] == pixelBloco)
                    {
                        posicaoCanvas[x, y] = pixelBloco;
                        buffer += posicaoCanvas[x, y].ToString();
                    }
                    else if (posicaoCanvas[x, y] == pixelPreto)
                    {
                        posicaoCanvas[x, y] = pixelPreto;
                        buffer += posicaoCanvas[x, y].ToString();
                    }
                    else if (posicaoCanvas[x, y] == pixelJogador)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        posicaoCanvas[x, y] = pixelJogador;
                        buffer += posicaoCanvas[x, y].ToString();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                buffer += "\n";
            }
            Console.Write(buffer);
            buffer = string.Empty;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------\n" +
                              "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \n" +
                              "----------------------------------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(120);
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                teclaApertada = Console.ReadKey(true);
                switch (teclaApertada.Key)
                {
                    case ConsoleKey.RightArrow:
                        //vai para a direita se não for o limite da tela, se existir espaço, e se existe um bloco abaixo ou na diagonal inferior
                        if (personagem.posX + 1 > Definicoes.POSICAO_MIN_X
                            && personagem.posY == Definicoes.NIVEL_DE_CHAO
                            && posicaoCanvas[personagem.posX + 1, personagem.posY] == pixelPreto)
                        {
                            posicaoCanvas[personagem.posX + 1, personagem.posY] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(+1, 0);
                        }
                        else if (personagem.posY < Definicoes.NIVEL_DE_CHAO
                            && posicaoCanvas[personagem.posX + 1, personagem.posY] == pixelPreto
                            && ((posicaoCanvas[personagem.posX - 1, personagem.posY + 1] == pixelBloco
                            || posicaoCanvas[personagem.posX + 1, personagem.posY + 1] == pixelBloco
                            || posicaoCanvas[personagem.posX, personagem.posY + 1] == pixelBloco)))

                        {
                            posicaoCanvas[personagem.posX + 1, personagem.posY] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(+1, 0);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        //vai para a esquerda se não for o limite da tela, se existir espaço, e se existe um bloco abaixo ou na diagonal inferior
                        if (personagem.posX - 1 > Definicoes.POSICAO_MIN_X
                            && personagem.posY == Definicoes.NIVEL_DE_CHAO
                            && posicaoCanvas[personagem.posX - 1, personagem.posY] == pixelPreto)
                        {
                            posicaoCanvas[personagem.posX - 1, personagem.posY] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(-1, 0);
                        }
                        else if (personagem.posY < Definicoes.NIVEL_DE_CHAO
                            && posicaoCanvas[personagem.posX - 1, personagem.posY] == pixelPreto
                            && ((posicaoCanvas[personagem.posX - 1, personagem.posY + 1] == pixelBloco
                            || posicaoCanvas[personagem.posX + 1, personagem.posY + 1] == pixelBloco
                            || posicaoCanvas[personagem.posX, personagem.posY + 1] == pixelBloco)))

                        {
                            posicaoCanvas[personagem.posX - 1, personagem.posY] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(-1, 0);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        //sobe se existir bloco na lateral e na diagonal do personagem E se o "pixel" de baixo estivcer sem blocos.
                        if (posicaoCanvas[personagem.posX, personagem.posY - 1] == pixelPreto
                            && ((posicaoCanvas[personagem.posX + 1, personagem.posY] == pixelBloco
                            || posicaoCanvas[personagem.posX - 1, personagem.posY] == pixelBloco)
                            || (posicaoCanvas[personagem.posX + 1, personagem.posY - 1] == pixelBloco
                            || posicaoCanvas[personagem.posX - 1, personagem.posY - 1] == pixelBloco)))
                        {
                            posicaoCanvas[personagem.posX, personagem.posY - 1] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(0, -1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        //Desce se estiver mais alto que o nivel do chão E se o "pixel" de baixo estivcer sem blocos. 
                        if (personagem.posY < Definicoes.NIVEL_DE_CHAO
                            && posicaoCanvas[personagem.posX, personagem.posY + 1] == pixelPreto)
                        {
                            posicaoCanvas[personagem.posX, personagem.posY + 1] = pixelJogador;
                            posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                            personagem.Move(0, 1);
                        }
                        break;
                    //se existir à esquerda bloco, substitui por um preto e soma 100 ponto
                    case ConsoleKey.A:
                        if (posicaoCanvas[personagem.posX - 1, personagem.posY] == pixelBloco)
                        {
                            posicaoCanvas[personagem.posX - 1, personagem.posY] = pixelPreto;
                            personagem.ataca();
                            pontuacao += 100;
                        }
                        break;
                    //se existir à direita bloco, substitui por um preto e soma 100 ponto
                    case ConsoleKey.D:
                        if (posicaoCanvas[personagem.posX + 1, personagem.posY] == pixelBloco)
                        {
                            posicaoCanvas[personagem.posX + 1, personagem.posY] = pixelPreto;
                            personagem.ataca();
                            pontuacao += 100;
                        }
                        break;
                    //se existir abaixo bloco, substitui por um preto e soma 100 ponto
                    case ConsoleKey.W:
                        if (posicaoCanvas[personagem.posX, personagem.posY - 1] == pixelBloco)
                        {
                            posicaoCanvas[personagem.posX, personagem.posY - 1] = pixelPreto;
                            personagem.ataca();
                            pontuacao += 100;
                        }
                        break;
                    //se existir acima bloco, substitui por um preto e soma 100 ponto
                    case ConsoleKey.S:
                        if (posicaoCanvas[personagem.posX, personagem.posY + 1] == pixelBloco)
                        {
                            posicaoCanvas[personagem.posX, personagem.posY + 1] = pixelPreto;
                            personagem.ataca();
                            pontuacao += 100;
                        }
                        break;
                }

                while(Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                precisaAtualizarTela = true;
            }
            else
            {
                if ((personagem.posY < Definicoes.NIVEL_DE_CHAO
                    && posicaoCanvas[personagem.posX, personagem.posY + 1] == pixelPreto
                    && ((posicaoCanvas[personagem.posX + 1, personagem.posY] == pixelPreto
                    && posicaoCanvas[personagem.posX - 1, personagem.posY] == pixelPreto)
                    && (posicaoCanvas[personagem.posX + 1, personagem.posY - 1] == pixelPreto
                    && posicaoCanvas[personagem.posX - 1, personagem.posY - 1] == pixelPreto))))
                {
                    posicaoCanvas[personagem.posX, personagem.posY + 1] = pixelJogador;
                    posicaoCanvas[personagem.posX, personagem.posY] = pixelPreto;
                    personagem.Move(0, 1);
                    precisaAtualizarTela = true;
                    Thread.Sleep(100);
                }else
                {
                    precisaAtualizarTela = false;
                }
            }


        }
        public void DesenhaPersonagemJogo()
        {
            posicaoCanvas[personagem.posX, personagem.posY] = pixelJogador;
        }
        public bool jogando()
        {
            if (posicaoCanvas[98, personagem.posY] == pixelJogador)
            {
                if (pontuacaoNovoNivel > pontuacao)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n    Voce Perdeu!\n   Deseja jogar novamente?\n\n SIM [S] / NÃO [N]");
                    string reset = Console.ReadLine().ToUpper();
                    if (reset == "S")
                    {
                        Console.Clear();
                        pontuacao = 0;
                        nivelAtual = 1;
                        pontuacaoNovoNivel = 1000;
                        Program.reset = true;
                        return true;
                    }
                    else
                    {
                        Program.reset = false;
                        return true;
                    }
                }
                else
                {
                    Console.Clear();
                    pontuacaoNovoNivel = pontuacao + 1000;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Voce venceu com {0} pontos", pontuacao);
                    nivelAtual++;
                    pontuacao = 0;


                    personagem.posX = Definicoes.POSICAO_MIN_X;
                    personagem.posY = Definicoes.NIVEL_DE_CHAO;

                    return true;
                }

            }

            return false;
        }
    }
}
