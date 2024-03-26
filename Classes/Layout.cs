using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t\tDigite a opção desejada:\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t1. Criar conta\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t2. Entrar com CPF e Senha\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");

            opcao = int.Parse(Console.ReadLine());

            try
            {
                switch (opcao)
                {
                    case 1:
                        CriarConta();
                        break;

                    case 2:
                        TelaLogin();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (FormatException erro) 
            {
                Console.WriteLine("Desculpe, aconteceu um erro. Tente novamente mais tarde!" + erro);
            }     
        }

        private static void CriarConta()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t\tDigite seu nome: \t\t\t\t\t");
            string nome = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\tDigite seu CPF: \t\t\t\t\t");
            string cpf = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\tDigite sua senha: \t\t\t\t\t");
            string senha = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");

            // Criar uma conta
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t\tDigite seu CPF: \t\t\t\t\t");
            string cpf = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\tDigite sua senha: \t\t\t\t\t");
            string senha = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");

            // Logar no sistema
        }
    }
}
