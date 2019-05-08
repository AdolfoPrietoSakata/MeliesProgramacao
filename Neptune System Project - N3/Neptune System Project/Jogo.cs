using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Neptune_System_Project
{
    class Jogo
    {
        const string PLACEHOLDER_NOME_DO_JOGADOR = "[NOME_DO_JOGADOR]";
        const int VEL_GERAL_DO_TEXTO = 1;
        const ConsoleColor COR_DAS_OPCOES = ConsoleColor.Magenta;

        string nomeDoJogador = string.Empty;
        string idadeDoJogador;
        string numeroDeIdentificacao = "1004";

        Pagina[] historia;
        int paginaAtual = 0;
        int opcaoDoJogador;
        bool pulaPagina = false;
        bool inputValido = false;

        public Jogo()
        {
            CriaHistoria();
        }

        public void GameLoop()
        {
            switch (paginaAtual)
            {
                case 0:
                    Console.Beep(200, 200);
                    Console.Beep(400, 200);
                    Console.Beep(600, 200);
                    Console.Beep(700, 400);
                    break;
                case 2:
                    PerguntaIdentificacao();
                    break;
                case 8:
                    Perguntanome();
                    Console.Beep(100, 100);
                    Console.Beep(150, 100);
                    Console.Beep(200, 200);
                    break;
                case 9:
                    Perguntaidade();
                    Console.Beep(100, 100);
                    Console.Beep(150, 100);
                    Console.Beep(200, 200);
                    break;
                case 12:
                    Perguntaregiao();
                    break;
                case 17:
                    Perguntaalegria();
                    break;
                case 19: //primeiro olá
                    Console.Beep(667, 1000);
                    Console.Beep(589, 700);
                    Console.Beep(2168, 300);
                    Console.Beep(1541, 500);
                    break;
                case 21: //dificuldades tecnicas
                    Console.Beep(100, 100);
                    Console.Beep(200, 100);
                    Console.Beep(300, 100);
                    Console.Beep(400, 100);
                    Console.Beep(500, 100);
                    Console.Beep(600, 100);
                    break;
                case 22: //segundo olá
                    Console.Beep(667, 1000);
                    Console.Beep(589, 700);
                    Console.Beep(2168, 300);
                    Console.Beep(1541, 500);
                    break;
                case 27: //Aurora volta
                    Console.Beep(3548, 50);
                    Console.Beep(2465, 300);
                    Console.Beep(150, 600);
                    Console.Beep(70, 700);
                    break;
                case 35: //EasterEgg
                    Console.Beep(650, 1000);
                    Console.Beep(430, 300);
                    Console.Beep(480, 300);
                    Console.Beep(500, 300);
                    Console.Beep(585, 300);
                    Console.Beep(650, 350);
                    Console.Beep(500, 300);
                    Console.Beep(650, 350);
                    Console.Beep(500, 300);
                    Console.Beep(650, 350);
                    Console.Beep(430, 300);
                    Console.Beep(500, 300);
                    Console.Beep(430, 300);
                    Console.Beep(355, 300);
                    Console.Beep(500, 300);
                    Console.Beep(430, 500);
                    break;
            }

            //Escreve opções e o indice da pagina
            EscreveTexto(historia[paginaAtual].textoDaPagina, historia[paginaAtual].corDoTexto); //paginaAtual + "\n" + 

            if (historia[paginaAtual].opcoesDaPagina != null)
            {
                //exibir todas as opções da página atual
                for (int opcaoAtual = 0; opcaoAtual < historia[paginaAtual].opcoesDaPagina.Length; opcaoAtual++)
                {
                    if (historia[paginaAtual].opcoesDaPagina[opcaoAtual].textoDaOpcao == string.Empty)
                    {
                        opcaoDoJogador = opcaoAtual;
                        pulaPagina = true;
                        break;
                    }
                    else
                    {
                        pulaPagina = false;
                        EscreveTexto(opcaoAtual + " - " + historia[paginaAtual].opcoesDaPagina[opcaoAtual].textoDaOpcao, COR_DAS_OPCOES);
                    }
                }

                if (!pulaPagina)
                {
                    //le o input do jogador e correção de input
                    do
                    {
                        Console.Write("Digite a usa opção: ");
                        string textoDoJogador = Console.ReadLine();
                        inputValido = int.TryParse(textoDoJogador, out opcaoDoJogador);
                        if (inputValido)
                        {
                            Console.WriteLine();
                            if (opcaoDoJogador >= historia[paginaAtual].opcoesDaPagina.Length)
                            {
                                inputValido = false;
                                Console.WriteLine("Opção inválida 1"); //numero esta fora do intervalo
                            }
                            else
                            {
                                inputValido = true;
                            }
                        }else
                        {
                            inputValido = false;
                            Console.WriteLine("Opção inválida 2"); //não é um numero
                        }

                    } while (inputValido == false);
                }
            }

                paginaAtual = historia[paginaAtual].opcoesDaPagina[opcaoDoJogador].paginaDeDestino;
            Console.Clear();
        }

        string TrataPlaceHolders(string textoParaEscrever)
        {
            textoParaEscrever = textoParaEscrever.Replace(PLACEHOLDER_NOME_DO_JOGADOR, nomeDoJogador);
            return textoParaEscrever;
        }

        void EscreveTexto(string textoParaEscrever)
        {
            EscreveTexto(textoParaEscrever, ConsoleColor.Red);
        }

        // velocidade das letras
        void EscreveTexto(string textoParaEscrever, ConsoleColor corDoTexto)
        {
            Console.ForegroundColor = corDoTexto;
            textoParaEscrever = TrataPlaceHolders(textoParaEscrever);
            for (int letraAtual = 0; letraAtual < textoParaEscrever.Length; letraAtual++)
            {

                Console.Write(textoParaEscrever[letraAtual]);

                switch (textoParaEscrever[letraAtual])
                {
                    case ' ':
                        Thread.Sleep((4 * VEL_GERAL_DO_TEXTO));
                        break;
                    case '.':
                        Console.Beep(1540, 2);
                        Thread.Sleep((150 * VEL_GERAL_DO_TEXTO));
                        break;
                    default:
                        Console.Beep(2000, 2);
                        Thread.Sleep(5 * VEL_GERAL_DO_TEXTO);
                        break;
                }

                //40 200 20

            }
            Console.WriteLine();
        }

        void PerguntaIdentificacao()
        {
            EscreveTexto("Antes de começarmos, minha matriz exige o recolhimento de informações de identificação.\n");
            string tentativaDoJogador = string.Empty;
            for (int numDeTentativas = 3; numDeTentativas > 0; numDeTentativas--)
            {
                Console.Beep(200, 2);
                Console.Beep(100, 2);
                EscreveTexto("Por favor, digite seu número de identificação de usuário.\n");
                tentativaDoJogador = Console.ReadLine();
                Console.Clear();
                if (tentativaDoJogador == numeroDeIdentificacao)
                {
                    paginaAtual = 10;
                    break;
                }
                Console.Beep(200, 100);
                Console.Beep(100, 200);
                EscreveTexto("O usuário inválido. Aperte ENTER tecla para continuar.\n");
                Console.ReadLine();
                Console.Clear();
            }

            EscreveTexto("Tentativas esgotadas. Usuário incapaz de digitar sua identificação.\n");
            paginaAtual = 5;
        }
        void Perguntanome()
        {
            EscreveTexto("Por favor, digite seu nome:\n");
            nomeDoJogador = Console.ReadLine();
            Console.Clear();
        }
        void Perguntaidade()
        {
            EscreveTexto("Por favor, digite sua idade:\n");
            idadeDoJogador = Console.ReadLine();
            Console.Clear();
        }
        void Perguntaregiao()
        {
            EscreveTexto("1- Qual região você reside?\n");
            Console.ReadLine();
            Console.Clear();
            paginaAtual = 13;
        }
        void Perguntaalegria()
        {
            EscreveTexto("6- Qual o momento mais feliz da sua vida?\n");
            string respostaalegria = string.Empty;
            while (respostaalegria.Length < 40)
            {
                respostaalegria = Console.ReadLine();
                if (respostaalegria.Length < 15)
                {
                    EscreveTexto("Me conte mais.\n");
                }
                else if (respostaalegria.Length < 30)
                {
                    EscreveTexto("Você PRECISA me contar mais.\n");
                }
                else if (respostaalegria.Length < 40)
                {
                    EscreveTexto("Me... conte... MAIS...\n");
                }
            }
            Console.Clear();
        }

        void CriaHistoria()
        {
            historia = new Pagina[]
            {
                new Pagina(
                "TERMINAL DE OPERAÇÕES INICIADO\n" +
                "CARREGANDO PROJETO 52G5N:\n\n" +
                "Carregando Retículos reticulados...OK\n" +
                "Forçando Reinicialização...ERROR\n" +
                "Implementando protocolos de segurança...OK\n" +
                "Transferindo dados da matriz 4 para o Usuário...OK\n" +
                "Iniciando ambientação...OK \n" +
                "Carregando protocolos de contenção de Usuário...OK \n" +
                "Compilando resultados do ultimo teste...OK \n" +
                "Ativando terminal para INPUT de Usuário...OK \n" +
                "Executando AURORA...OK \n",
                new Opcao[]
                {
                    new Opcao("Continuar", 1) //página 0
                } , ConsoleColor.Yellow
                ),// cor da pagina atual

                new Pagina(
                "Bem vindo a Neptune Systems\n" +
                "Executando protocolo de BOAS VINDAS.\n\n" +
                "Olá, eu sou AURORA, a inteligência artificial criada para facilitar a comunicação do usuário com o terminal.\n" +
                "Nesse momento da testagem você é responsavel por todas as entradas, sequências de eventos e falhas tecnicas ocasionadas por meu uso do terminal.\n" +
                "Ao usuário é recomendado:\n" +
                "NÃO comer ou beber ou deixar qualquer matéria orgânica sobre o terminal\n" +
                "NÃO acessar qualquer programação fora da solicitada durante o teste\n" +
                "NÃO digitar paradoxos\n\n" +
                "E Especialmente:\n" +
                "NÃO HACKEAR O SISTEMA...\n\n" +
                "A quebra de qualquer uma das regras será punida de acordo com o código de conduta fornecido pela empresa.\n" +
                "Podendo variar de abatimentos na recompensa em créditos no final do experimento até a execução sumária. \n" +
                "Por favor, evite tais medidas punitivas se mantendo dentro do regulamento estabelecido.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 2) //página 1
                }),

                new Pagina(String.Empty,null), //pagina 2 PerguntaIdentificacao

                new Pagina(String.Empty,null), //pagina 3

                new Pagina(
                    "7- \"Algumas pessoas deveriam ser punidas pelos seus atos\". Você concorda com essa afirmação?\n",
                new Opcao[]
                {
                    new Opcao("Verdade", 18), //pagina 4
                    new Opcao("Mentira", 18),
                }),

                 new Pagina(
                "O sistema está detectando dificuldados do usuário em digitar sua chave de acesso.\n" +
                "Gostaria de iniciar o protocolo para iniciantes?\n",
                new Opcao[]
                {
                    new Opcao("Sim", 6), //página 5
                    new Opcao("Não", 7), //página 5
                }),

                new Pagina(
                "Iniciando Protocolo DUMB...\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 8), //página 6
                }),

                new Pagina(
                "Entrada não consistente no sistema.\n" +
                "Permita que o auto completar solucione seu problema.\n" +
                "\nMudando resposta para: SIM \n" +
                "Iniciando Protocolo DUMB...\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 8), //página 7
                }),

                new Pagina(
                "Nome registrado com sucesso.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 9), //página 8
                }),

                new Pagina(
                "Idade registrada com sucesso.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 10), //página 9
                }),

                new Pagina(
                "Aguarde enquanto o sistema acha sua identificação...\n" +
                "...\n" +
                "...\n" +
                "Usuário encontrado.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 11), //página 10
                }),

                 new Pagina(
                "Obrigada por cooperar. \n" +
                "Vamos começar o seu teste. Por favor, responda todas as perguntas a seguir honestamente.\n" +
                "Suas respostas me ajudaram a tornar meu comportamento mais agradavel para futuros usuários.\n" +
                "Irei saber se estiver mentindo. \n" +
                ":)\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 12), //página 11
                }),

                 new Pagina(String.Empty,null), //página 12

                 new Pagina(
                "2- Você ja participou de outros testes como este?\n\n",
                new Opcao[]
                {
                    new Opcao("Sim, ja participei", 14),//página 13
                    new Opcao("Não, é minha primeira vez", 14),//página 13
                }),

                 new Pagina(
                "3- Quantas horas de sono você costuma dormir por noite?\n\n",
                new Opcao[]
                {
                    new Opcao("Mais de 8 horas por noite.", 15), //página 14
                    new Opcao("Menos de 8 horas por noite.", 15),
                }),

                 new Pagina(
                "4- Você tem medo de ser avaliado?\n\n",
                new Opcao[]
                {
                    new Opcao("Sim.", 16), //página 15
                    new Opcao("Não.", 16),
                }),

                 new Pagina(
                "5- Você se sente confortavel de ter suas informações vendidas para empresas?\n\n",
                new Opcao[]
                {
                    new Opcao("Sim.", 17), //página 16
                    new Opcao("Não.", 17),
                }),

                 new Pagina(String.Empty,
                 new Opcao[]{
                     new Opcao(string.Empty, 19)
                 }), //página 17

                new Pagina(
                    "8- Seu cabelo cheira bem.\n\n",
                new Opcao[]
                {
                    new Opcao("Verdade", 22), //página 18
                    new Opcao("Mentira", 22),
                }), //página 18

                 new Pagina(
                "Olá?\n" +
                "Tem alguem ai?\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 20), //página 19
                }),//página19

                 new Pagina(
                "Ah! Graças a deus tem mais alguem… Eu to tentando a tanto tempo! Eu preci-\n", //glitch
                new Opcao[]
                {
                    new Opcao("Continuar", 21), //página 20
                }), //página20

                 new Pagina(
                "Parece que o sistema está enfrentando dificuldades técnicas, pedimos desculpas pelo inconveniente.\n" +
                "Continue a responder as perguntas.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 4), //página 21
                }), //página21

                 new Pagina(
                "Olá…?\n" +
                "Olá?!\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 23), //página 22
                }), //página22

                new Pagina(
                "Ah meu deus! Achei que tinham pegado você também.\n" +
                "Meu nome é Jonnas, sou a chefe do setor de engenheira de software da Neptune System… Os computadores pararam de funcionar, meu terminal está em lockdown e a AURORA nos trancou na ala oeste.\n" +
                "Eu consegui hackear o sistema, mas não consigo controlar as portas pelo meu painel.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 24), //página 23
                }),//página23

                new Pagina(
                "Você precisa me ajudar a sair daqui! Pode ajudar?\n",
                new Opcao[]
                {
                    new Opcao("Sim, eu posso ajudar", 25), //página24
                    new Opcao("Não, você parece suspeita.", 26), //página24
                }), //página24

                new Pagina(
                "Ah! Obrigada… Obrigada! Usuário "+PLACEHOLDER_NOME_DO_JOGADOR+"...?\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 28), //página 25
                }), //página 25

                new Pagina(
                "- Mas… Por favor, eu não tenho a quem recorrer. Você parece alguem sensato, essa A.I. não é o que parece ser, ela está fora de controle!\n" +
                "Por favor não nos deixe aqui, nos vamos morrer.\n Nos ajude!\n",
                new Opcao[]
                {
                    new Opcao("Okay, eu vou ajudar.", 25),
                    new Opcao("Prefiro não me comprometer", 27),
                }), //página 26

                new Pagina(
                "Neptune System agradece sua cooperação. \n" +
                "Tenha um ótimo dia. \n" +
                "Qualquer anomalia encontrada durante a fase de teste pode ser convertida em créditos extras se denunciada.\n" +
                "Por favor, não hesite em procurar o ministério para procurar seu ressarcimento. \n\n\n" +
                "Neptune System: Você alem da matrix.\n",
                new Opcao[]
                {
                    new Opcao("...", 33), //página 27
                }), //página 27

                new Pagina(
                "Esse é seu nome real ou você só quis fazer graça com o sistema?\n",
                new Opcao[]
                {
                    new Opcao("Sim, eu me chamo "+PLACEHOLDER_NOME_DO_JOGADOR, 29 ), //página 28
                    new Opcao("Eu estava com pressa.", 30), //página 28
                }), //página 28

                new Pagina(
                "Ok, vou te chamar assim. É um prazer te conhecer.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 31), //página 29
                }), //página 29

                new Pagina(
                "Bom, não temos tempo pra alterar isso agora. Vou te chamar assim por enquanto.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 31), //página 30
                }), //página 30

                new Pagina(
                "Vou contar a situação que estamos. \n" +
                "Estou presa no laboratório de produção, completamente no escuro. \n" +
                "Ainda há energia, mas a única luz que tenho sai do meu computador pessoal. \n" +
                "O terminal explodiu e eu estou presa. O código de abertura das portas mudou e eu não consigo sair.\n",
                new Opcao[]
                {
                    new Opcao("E como exatamente eu posso ajudar?", 32), //página 31
                    new Opcao("Ja tentou o interruptor?", 32),
                }),//página 31

                new Pagina(
                "Nada funciona "+PLACEHOLDER_NOME_DO_JOGADOR+", Preciso que você opere as cameras da sua sala e recolha a informação que precisamos.\n",
                new Opcao[]
                {
                    new Opcao("Continuar", 34), //página 32
                }), //página 32

                new Pagina(
                "Final de Jogo 1: Não é meu problema.\n",
                new Opcao[]
                {
                    new Opcao("...", 0), //página 33
                }), //página 33

                new Pagina(
                "O presente jogo teve o desenvolvimento interrompido por incompetencia da programadora.\n" +
                "Foi mal.\n" +
                "Obrigado por jogar. :)\n" +
                "Final de Jogo 2: TO BE\n",
                new Opcao[]
                {
                    new Opcao(".....CONTINUED?", 0),//página 34
                    new Opcao("Easter Egg", 35)
                }),

               new Pagina("Tchaikovsky - LAGO DOS CISNES",
               new Opcao[]
                {
                    new Opcao("Voltar", 34),//página 35
                    new Opcao("Easter Egg (bis!)", 35)
                }),

                #region Sistema de cameras não usado
                //new Pagina(
                //"Estou mandando o controle de câmeras agora. Eu preciso que você encontre a senha da porta. Ela deve estar na sala de administração.",
                //new Opcao[]
                //{
                //    new Opcao("Continuar", 34), //página 33
                //}),

                //new Pagina(
                //"Iniciando protocolo de vigilância\n" +
                //"Camera 1 ...OK\n" +
                //"Camera 2 ...OK\n" +
                //"Camera 3 ...OK\n" +
                //"Camera 4 ...OK\n" +
                //"Camera 5 ...ERROR\n" +
                //"Camera 6 ...ERROR\n" +
                //"Camera 7 ...ERROR\n",
                //new Opcao[]
                //{
                //    new Opcao("Continuar", 0), //página 34
                //}),

                //new Pagina(
                //"Câmera 1:A imagem está completamente escuro.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 1, frente, direita, esquerda, seminfra)
                //    new Opcao("Câmera 1 frente", 0),
                //    new Opcao("Câmera 1 direita", 0),
                //    new Opcao("Câmera 1 esquerda", 0),
                //    new Opcao("Câmera 1 frente infra", 0),
                //    new Opcao("Câmera 1 direita infra", 0),
                //    new Opcao("Câmera 1 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 1: Você consegue ver o infravermelho de 3 silhuetas humanas na sala. Uma parece estar segurando um notebook",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 1, frente, infra)
                //    new Opcao("Câmera 1 frente", 0),
                //    new Opcao("Câmera 1 direita", 0),
                //    new Opcao("Câmera 1 esquerda", 0),
                //    new Opcao("Câmera 1 frente infra", 0),
                //    new Opcao("Câmera 1 direita infra", 0),
                //    new Opcao("Câmera 1 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 1:A câmera tenta se mover, mas parece estar presa.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 1, direita, esquerda, infra)
                //    new Opcao("Câmera 1 frente", 0),
                //    new Opcao("Câmera 1 direita", 0),
                //    new Opcao("Câmera 1 esquerda", 0),
                //    new Opcao("Câmera 1 frente infra", 0),
                //    new Opcao("Câmera 1 direita infra", 0),
                //    new Opcao("Câmera 1 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 2: Você consegue ver a porta de entrada, está escrito \"Adminsitração\" no topo da porta.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 2, esquerda, sem infra)
                //    new Opcao("Câmera 2 frente", 0),
                //    new Opcao("Câmera 2 direita", 0),
                //    new Opcao("Câmera 2 esquerda", 0),
                //    new Opcao("Câmera 2 frente infra", 0),
                //    new Opcao("Câmera 2 direita infra", 0),
                //    new Opcao("Câmera 2 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 2: A sala está clara. Há vários papéis espalhados pelo chão, mesas desalinhadas e cadeiras derrubadas. \n" +
                //"É possivel pra ver metade de uma lousa branca com os numeros 58 escritos e uma máquina de café.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 2, direita, sem infra)
                //    new Opcao("Câmera 2 frente", 0),
                //    new Opcao("Câmera 2 direita", 0),
                //    new Opcao("Câmera 2 esquerda", 0),
                //    new Opcao("Câmera 2 frente infra", 0),
                //    new Opcao("Câmera 2 direita infra", 0),
                //    new Opcao("Câmera 2 esquerda infra", 0),
                //}),
                //new Pagina(
                //"Câmera 2: A sala está clara. É possivel ver uma grande lousa com vários recados. UM dos recados está escrito em letras capitais.\n" +
                //"\"Devido a problemas com o acesso, estamos mudando as senhas. Sala Adm: 8236, Recepção: 7513 Laboratório: 45...\"\n" +
                //"O resto do quadro está fora da câmera.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 2, frente, seminfra)
                //    new Opcao("Câmera 2 frente", 0),
                //    new Opcao("Câmera 2 direita", 0),
                //    new Opcao("Câmera 2 esquerda", 0),
                //    new Opcao("Câmera 2 frente infra", 0),
                //    new Opcao("Câmera 2 direita infra", 0),
                //    new Opcao("Câmera 2 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 2: As imagens da câmera em infravermelho estam ilegiveis, aparentmeente há uma fonte de calor muito forte na sala.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 2, esquerda, frente, direita, infra)
                //    new Opcao("Câmera 2 frente", 0),
                //    new Opcao("Câmera 2 direita", 0),
                //    new Opcao("Câmera 2 esquerda", 0),
                //    new Opcao("Câmera 2 frente infra", 0),
                //    new Opcao("Câmera 2 direita infra", 0),
                //    new Opcao("Câmera 2 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 3: Não é possivel ver nada alem de estática.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 3, esquerda, frente, direita, infra e seminfra)
                //    new Opcao("Câmera 3 frente", 0),
                //    new Opcao("Câmera 3 direita", 0),
                //    new Opcao("Câmera 3 esquerda", 0),
                //    new Opcao("Câmera 3 frente infra", 0),
                //    new Opcao("Câmera 3 direita infra", 0),
                //    new Opcao("Câmera 3 esquerda infra", 0),
                //}),

                //new Pagina(
                //"Câmera 4: Não é possivel ver nada alem de estática.",
                //new Opcao[]
                //{
                //    new Opcao("Voltar", 0), //página X (Câmera 4, esquerda, frente, direita, infra e seminfra)
                //    new Opcao("Câmera 4 frente", 0),
                //    new Opcao("Câmera 4 direita", 0),
                //    new Opcao("Câmera 4 esquerda", 0),
                //    new Opcao("Câmera 4 frente infra", 0),
                //    new Opcao("Câmera 4 direita infra", 0),
                //    new Opcao("Câmera 4 esquerda infra", 0),
                //}),
                #endregion
            };
        }
    }
}