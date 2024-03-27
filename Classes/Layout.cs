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
            Console.WriteLine($"\t\t\tSeja bem vindo(a), {pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}");
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
                    TelaDeposito(pessoa);
                    break;

                case 2:
                    TelaSaque(pessoa);
                    break;

                case 3:
                    TelaSaldo(pessoa);
                    break;

                case 4:
                    TelaExtrato(pessoa);
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

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("\t\t\t\t\tDigite o valor do depósito:");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("\t\t\t\t==============================");

            pessoa.Conta.Deposita(valor);

            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\tDepósito realizado com sucesso!");
            Console.WriteLine("\t\t\t\t==================================");
            Console.WriteLine("");

            VoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("\t\t\t\t\tDigite o valor do saque:");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("\t\t\t\t==============================");

            bool okSaque = pessoa.Conta.Saque(valor);

            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("");
            if (okSaque)
            {
                Console.WriteLine("\t\t\t\t\tSaque realizado com sucesso!");
                Console.WriteLine("\t\t\t\t==================================");
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tSaldo insuficiente para esta operação.");
                Console.WriteLine("\t\t\t\t========================================");
            }
            Console.WriteLine("");

            VoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine($"\t\t\t\t\tSeu saldo é: R${pessoa.Conta.ConsultaSaldo()}");
            Console.WriteLine("\t\t\t\t================================");
            Console.WriteLine("");
            VoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            if(pessoa.Conta.Extrato().Any())
            {
                //Mostrar extrato
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                
                foreach(Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("");
                    Console.WriteLine($"\t\t\t\t\tData: {extrato.Data.ToString("dd/MM/yyy HH:mm:ss")}");
                    Console.WriteLine($"\t\t\t\t\tTipo de movimentação: {extrato.Descricao}");
                    Console.WriteLine($"\t\t\t\t\tTipo de movimentação: {extrato.Valor}");
                    Console.WriteLine("\t\t\t\t============================================");
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.WriteLine($"\t\t\t\t\tSUB TOTAL: {total}");
                Console.WriteLine("\t\t\t\t==============================");
                Console.WriteLine("");
            }
            else
            {
                //Mostrar msg que não há extrato
                Console.WriteLine("\t\t\t\t\tNão há extrato a ser exibido.");
                Console.WriteLine("\t\t\t\t===============================");
            }

            VoltarLogado(pessoa);
        }

        private static void VoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("\t\t\t\t\tEntre com uma opção abaixo");
            Console.WriteLine("\t\t\t\t==============================");
            Console.WriteLine("\t\t\t\t\t1. Voltar para a minha conta");
            Console.WriteLine("\t\t\t\t==============================");
            Console.WriteLine("\t\t\t\t\t2. Sair");
            Console.WriteLine("\t\t\t\t==============================");

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
                    TelaContaLogada(pessoa);
                    break;

                case 2:
                    TelaPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        }

        private static void VoltarDeslogado()
        {
            Console.WriteLine("\t\t\t\t\tEntre com uma opção abaixo");
            Console.WriteLine("\t\t\t\t=================================");
            Console.WriteLine("\t\t\t\t\t1. Voltar para o menu principal");
            Console.WriteLine("\t\t\t\t=================================");
            Console.WriteLine("\t\t\t\t\t2. Sair");
            Console.WriteLine("\t\t\t\t=================================");

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
                    TelaPrincipal();
                    break;

                case 2:
                    TelaPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        }
    }
}
