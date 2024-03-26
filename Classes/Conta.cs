using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, Iconta
    {
        public Conta()
        {
            this.NumeroConta = "0001";
            Conta.NumeroSerialConta++;
        }
        
        public double Saldo { get; protected set; }

        public string NumeroAgencia { get; private set; }

        public string NumeroConta { get; protected set; }
        public static int NumeroSerialConta { get; private set; }


        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public bool Saque(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

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
    }
}
