using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException erro) 
            {
                Console.WriteLine("");
            }
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

            //Esperar 1s para ir para  tela logada
            Thread.Sleep(1000);

            TelaContaLogada(pessoa);

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
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);

                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("\t\t\t\t\tUsuário não cadastrado.\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t=======================\t\t\t\t\t");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            Console.WriteLine();
            Console.WriteLine($"\t\t\tSeja bem vindo, {pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}");
            Console.WriteLine();
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("\t\t\t\t\t\tDigite a opção desejada:\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t1. Realizar um depósito\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t2. Realizar um saque\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t3. Consultar saldo\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t4. Extrato\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t5. Sair\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t========================================\t\t\t\t");

            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException erro)
            {
                Console.WriteLine("");
            }

            switch (opcao)
            {
                case 1:
                    
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
