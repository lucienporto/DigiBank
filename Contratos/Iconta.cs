using DigiBank.Classes;
using System.Collections.Generic;

namespace DigiBank.Contratos
{
    public interface Iconta
    {
        void Deposita(double valor);

        bool Saque(double valor);

        double ConsultaSaldo();

        string GetCodigoBanco();

        string GetNumeroAgencia();

        string GetNumeroConta();

        List<Extrato> Extrato();
    }
}
