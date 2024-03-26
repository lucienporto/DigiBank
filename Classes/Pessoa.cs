using DigiBank.Contratos;
using System.Globalization;

namespace DigiBank.Classes
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public string CPF { get; private set;}
        public string Senha { get; private set; }

        public Iconta Conta { get; set; }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetCPF(string cpf)
        {
            this.CPF = cpf;
        }

        public void SetSenha (string senha)
        {
            this.Senha = senha;
        }
    }
}
