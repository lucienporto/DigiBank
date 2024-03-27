using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            Console.WriteLine("\t--------------------------------------");
            Console.WriteLine("\t|             DIGIBANK               |");
            Console.WriteLine("\t--------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("\tDigite a opção desejada:");
            Console.WriteLine("");
            Console.WriteLine("\t1. Criar conta");
            Console.WriteLine("");
            Console.WriteLine("\t2. Entrar com CPF e Senha");
            Console.WriteLine("");
            Console.WriteLine("\t3. Sair do programa");
            Console.WriteLine("");

            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException erro) 
            {
                Console.WriteLine("\tOps! Encontramos um erro, tente novamente.");
                Thread.Sleep(3000);
                TelaPrincipal();
            }
            switch (opcao)
            {
                case 1:
                    CriarConta();
                    break;

                case 2:
                    TelaLogin();
                    break;

                case 3:
                    Console.WriteLine("\tEncerrando sistema...");
                    break;

                default:
                    Console.WriteLine("\tOpção inválida!");
                    Thread.Sleep(1000);
                    TelaPrincipal();
                    break;
            }     
        }

        private static void CriarConta()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\tDigite seu nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("\tDigite seu CPF:");
            string cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("\tDigite sua senha:");
            string senha = Console.ReadLine();
            Console.WriteLine("");

            // Criar uma conta
            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;
            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\tConta cadastrada com sucesso!");
            Thread.Sleep(1000);

            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("\tDigite seu CPF:");
            string cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("\tDigite sua senha:");
            string senha = Console.ReadLine();

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

                Console.WriteLine("\tUsuário não cadastrado.");
                Console.WriteLine("");
                Console.WriteLine("\tRedirecionando...");
                Thread.Sleep(2000);

                TelaPrincipal();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            Console.WriteLine();
            Console.WriteLine($"\t\tSeja bem vindo(a), {pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}");
            Console.WriteLine();
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("\tDigite a opção desejada:");
            Console.WriteLine("");
            Console.WriteLine("\t1. Realizar um depósito");
            Console.WriteLine("");
            Console.WriteLine("\t2. Realizar um saque");
            Console.WriteLine("");
            Console.WriteLine("\t3. Consultar saldo");
            Console.WriteLine("");
            Console.WriteLine("\t4. Extrato");
            Console.WriteLine("");
            Console.WriteLine("\t5. Sair");
            Console.WriteLine("");

            try
            {
                opcao = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("\tOpção inválida! Tente novamente.");
                        Thread.Sleep(1000);
                        TelaContaLogada(pessoa);
                        break;
                }
            }
            catch(FormatException erro)
            {
                Console.WriteLine("\tOps! Encontramos um erro, tente novamente");
                Thread.Sleep(1000);
                TelaContaLogada(pessoa);
            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("\tDigite o valor do depósito:");
            double valor = double.Parse(Console.ReadLine());

            pessoa.Conta.Deposita(valor);

            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("");
            Console.WriteLine("\tDepósito realizado com sucesso!");
            Console.WriteLine("");

            VoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("\tDigite o valor do saque:");
            double valor = double.Parse(Console.ReadLine());

            bool okSaque = pessoa.Conta.Saque(valor);

            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("");
            if (okSaque)
            {
                Console.WriteLine("\tSaque realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\tSaldo insuficiente para esta operação.");
            }
            Console.WriteLine("");

            VoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine($"\tSeu saldo é: R${pessoa.Conta.ConsultaSaldo()}");
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
                    Console.WriteLine($"\tData:\t\t\t\t{extrato.Data.ToString("dd/MM/yyy HH:mm:ss")}");
                    Console.WriteLine($"\tTipo de movimentação:\t\t{extrato.Descricao}");
                    Console.WriteLine($"\tTipo de movimentação:\t\tR${extrato.Valor}");
                    Console.WriteLine("\t-----------------------------------------------------------");
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.WriteLine($"\tSUB TOTAL:\t\t\tR${total}");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                //Mostrar msg que não há extrato
                Console.WriteLine("\tNão há extrato a ser exibido.");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            VoltarLogado(pessoa);
        }

        private static void VoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("\tEntre com uma opção abaixo");
            Console.WriteLine("");
            Console.WriteLine("\t1. Voltar para a minha conta");
            Console.WriteLine("");
            Console.WriteLine("\t2. Sair");

            try
            {
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        TelaContaLogada(pessoa);
                        break;

                    case 2:
                        TelaPrincipal();
                        break;

                    default:
                        Console.WriteLine("\tOpção inválida! Tente novamente.");
                        Thread.Sleep(1000);
                        VoltarLogado(pessoa);
                        break;
                }
            }
            catch (FormatException erro)
            {
                opcao = 0;
                Console.WriteLine("\tOps! Encontramos um erro.");
                Console.WriteLine("\tRedirecionando...");
                Thread.Sleep(3000);
                TelaPrincipal();
            }
        }
    }
}
