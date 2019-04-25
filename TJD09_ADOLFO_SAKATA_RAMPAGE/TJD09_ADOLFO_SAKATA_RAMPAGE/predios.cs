using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    class predios : BlocosDestrutiveis
    {
        static int altura;
        static int largura;
        static int distancia;
        //public int[,] tamanhoPredio = new int[largura, altura];
        public int posicaoInicial = 0;


        public void geradorDePredios(ref int largura, ref int altura, ref int distancia)
        {
            Random geradorLargura = new Random();
            largura = 1 + (2 * geradorLargura.Next(1, 4));
            Random geradorAltura = new Random();
            altura = 1 + (2 * geradorAltura.Next(1, 4));
            Random geradorDistancia = new Random();
            distancia = 2 * geradorDistancia.Next(4, 6);
        }

        public void desenhadorPredios(ref char[,] posicaoCanvas)
        {
            posicaoInicial = 3;

            while (posicaoInicial < 80)
            {
                geradorDePredios(ref largura, ref altura, ref distancia);

                for (int posY = 0; posY < altura; posY++)
                {
                    if (posY % 2 == 1 /*&& posY != 0 */)
                    {
                        for (int posX = 0; posX < largura; posX++)
                        {
                            posicaoCanvas[posicaoInicial + posX, 23 - posY] = '\u2588';
                            
                        }
                    }
                    // se for impar ou par
                    else if (posY % 2 == 0 /*&& posY != 0*/)
                    {
                        for (int posX = 0; posX < largura; posX++)
                        {

                            if (posX == 0 || posX % 2 == 0)
                            {
                                posicaoCanvas[posicaoInicial + posX, 23 - posY] = '\u2588';
                                
                            }
                            else
                            {
                                posicaoCanvas[posicaoInicial + posX, 23 - posY] = 'H';
                                
                            }
                        }

                    }

                }

                posicaoInicial += 10;
                //teste de desenho
                //posicaoInicial += distancia;
            }
        }

    }
}
