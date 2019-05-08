using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Neptune_System_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool estajogando = true;
            

            Jogo meuJogo = new Jogo();

            while(true)
            {
                meuJogo.GameLoop();
            }

            //Pagina paginaDeExemplo = new Pagina("asdasd", new Opcao());
        }
    }
}