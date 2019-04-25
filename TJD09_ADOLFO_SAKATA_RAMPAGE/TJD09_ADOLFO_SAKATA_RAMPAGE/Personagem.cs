using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJD09_ADOLFO_SAKATA_RAMPAGE
{
    public class Personagem
    {
        //variaveis do personagem

        int vida;
        int ponto;
        public int posX;
        public int posY;
        public static Jogo jogo;

        //posição do personagem personagem
        public Personagem(char pixelDoPersonagem, int posInicialX, int posInicialY)
        {
            posX = posInicialX;
            posY = posInicialY;

        }

        //movimentação do personagem
        public void Move(int posInicialX, int posInicialY)
        {
            posX += posInicialX;
            posY += posInicialY;
        }
        public void ataca()
        {
            ponto += 100;
        }
    }
}
