using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    //variaveis dos blocos

    public class BlocosDestrutiveis
    {
        public int vida;
        public int pontosGanhos;
        private bool vivo;
        public int posicaoNoCanvas;



        public BlocosDestrutiveis(char pixel, int vida, int pontosGanhos, int posicaoNoCanvas)
        {
           
            this.vida = vida;
            this.pontosGanhos = pontosGanhos;
            this.posicaoNoCanvas = posicaoNoCanvas;
            checaVida(vivo);
        }
        
        //não lembro se estou usando isso.
        public bool checaVida(bool estaVivo)
        {
            if (vida < 0)
            {
                vivo = true;
                return vivo;
            }
            else if (vida >= 0)
            {
                vivo = false;
                return vivo;
            }
        return true;
        }   

    }
}
