using System;
using System.Collections.Generic;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
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
            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("\t\t\t\t\tConta cadastrada com sucesso!\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t=============================\t\t\t\t\t");

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
