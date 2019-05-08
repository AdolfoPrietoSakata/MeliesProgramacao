using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune_System_Project
{
    public class Opcao
    {
        public string textoDaOpcao;
        public int paginaDeDestino;

        public Opcao(string novoTextoDaOpcao, int novaPaginaDeDestino)
        {
            textoDaOpcao = novoTextoDaOpcao;
            paginaDeDestino = novaPaginaDeDestino;
        }

        public Opcao(string novoTextoDaOpcao, string baguioPraEscreve, int novaPaginaDeDestino)
        {
            textoDaOpcao = novoTextoDaOpcao;
            paginaDeDestino = novaPaginaDeDestino;
        }
    }
}