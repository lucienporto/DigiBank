using DigiBank.Contratos;
using System;
using System.Collections.Generic;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, Iconta
    {
        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroSerialConta++;
            this.Movimentacoes = new List<Extrato>();
        }
        
        public double Saldo { get; protected set; }

        public string NumeroAgencia { get; private set; }

        public string NumeroConta { get; protected set; }
        public static int NumeroSerialConta { get; private set; }

        private List<Extrato> Movimentacoes;


        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Depósito", valor));
            this.Saldo += valor;
        }

        public bool Saque(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));
            this.Saldo -= valor;
            return true;
        }

        public string GetCodigoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}
