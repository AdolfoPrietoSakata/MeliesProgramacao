using System;

namespace Neptune_System_Project
{
    public class Pagina
    {
        public string textoDaPagina;
        public Opcao[] opcoesDaPagina;
        public ConsoleColor corDoTexto = ConsoleColor.Green;

        public Pagina(string textoDaNovaPagina, Opcao[] novasOpcoesDaPagina)
        {
            textoDaPagina = textoDaNovaPagina;
            opcoesDaPagina = novasOpcoesDaPagina;
        }

        public Pagina(string textoDaNovaPagina, string baguioPraEscreve, Opcao[] novasOpcoesDaPagina)
        {
            textoDaPagina = textoDaNovaPagina;
            opcoesDaPagina = novasOpcoesDaPagina;
        }

        public Pagina(string textoDaNovaPagina, Opcao[] novasOpcoesDaPagina, ConsoleColor corDoTexto)
        {
            textoDaPagina = textoDaNovaPagina;
            opcoesDaPagina = novasOpcoesDaPagina;
            this.corDoTexto = corDoTexto;
        }
    }
}