using System;

namespace TrabalhoAtpFinal
{
    class Program
    {
        static int[] dia = new int[10];
        static int[] mes = new int[10];
        static string[] descricao = new string[10];
        static double[] valor = new double[10];
        static string[] tipo = new string[10];
        static double saldoInicial = 0;
        static double saldoFinal = 0;

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                //texto do menu para usuario ver as opcoes
                Console.WriteLine("MENU");
                Console.WriteLine("1. Incluir Lançamento");
                Console.WriteLine("2. Exibir Extrato");
                Console.WriteLine("3. Encerrar");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                //caso de switch para a opcao escolhida pelo usuario
                switch (opcao)
                {
                    case 1:
                        IncluirLancamento();
                        break;
                    case 2:
                        ExibirExtrato();
                        break;
                    case 3:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 3);
        }

        //pega os valores que o usario escolher(dia,mes,descricao,valor e tipo) e coloca no vetor
        static void IncluirLancamento()
        {
            Console.WriteLine("Incluir Lançamento");

            if (dia[9] != 0)
            {
                // Quando o extrato ta cheio, remove o lançamento mais antigo
                for (int i = 0; i < 9; i++)
                {
                    dia[i] = dia[i + 1];
                    mes[i] = mes[i + 1];
                    descricao[i] = descricao[i + 1];
                    valor[i] = valor[i + 1];
                    tipo[i] = tipo[i + 1];
                }
            }

            Console.Write("Dia: ");
            dia[9] = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            mes[9] = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            descricao[9] = Console.ReadLine();
            Console.Write("Valor: ");
            valor[9] = double.Parse(Console.ReadLine());
            Console.Write("Tipo (Débito/Crédito): ");
            tipo[9] = Console.ReadLine();

            //com base no tipo define se o valor e subtraido ou adicionado
            if (tipo[9].ToLower() == "débito")
            {
                saldoFinal = saldoFinal - valor[9];
            }
            else if (tipo[9].ToLower() == "crédito")
            {
                saldoFinal = saldoFinal + valor[9];
            }

            Console.WriteLine("Lançamento incluído com sucesso!");
        }

        //exibe as informacoes dos vetores para o cliente
        static void ExibirExtrato()
        {
            Console.WriteLine("Extrato");

            Console.WriteLine("Dia\tMês\tDescrição\tValor\tTipo");

            for (int i = 0; i < 10; i++)
            {
                if (dia[i] != 0)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}", dia[i], mes[i], descricao[i], valor[i], tipo[i]);
                }
            }

            Console.WriteLine("Saldo Inicial: {0}", saldoInicial);
            Console.WriteLine("Saldo Final: {0}", saldoFinal);
        }
    }
}