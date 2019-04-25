using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    public class Predio
    {
        public int altura;
        public int largura;
        public int distancia;
        public int posicaoInicial;
        public static BlocosDestrutiveis blocosdestrutiveis;
        public static Jogo jogo;


        //desenha os prédios no canvas
        public void desenhaPredios(ref char[,] posicaoCanvas)
        {
            posicaoInicial = 3;
            Random gerador = new Random();

            for (posicaoInicial = 5; posicaoInicial < 90; posicaoInicial += distancia)
            {
                geradorNumerico(gerador);

                for (int posY = 0; posY < altura; posY++)
                {

                    for (int posX = 0; posX < largura; posX++)
                    {


                        if (posY % 2 == 1)
                        {
                            posicaoCanvas[posicaoInicial + posX, 20 - posY] = Jogo.pixelBloco;
                        }
                        else
                        {
                            if (posX % 2 == 0)
                            {
                                posicaoCanvas[posicaoInicial + posX, 20 - posY] = Jogo.pixelBloco;
                            }
                            else
                            {
                                posicaoCanvas[posicaoInicial + posX, 20 - posY] = Jogo.pixelPreto;
                            }
                        }
                    }
                }
            }
        }
        //gera numeros aleatórios
        public void geradorNumerico(Random gerador)
        {
            largura = 1 + (2 * gerador.Next(2, 4));
            altura = 2 * gerador.Next(2, 9);
            distancia = 2 * gerador.Next(3, 9);
        }
    }
}


