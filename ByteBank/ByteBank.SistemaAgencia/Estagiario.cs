using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Estagiario : Funcionario
    {
        public Estagiario(string cpf, double salario)
            : base(cpf, salario)
        {

        }

        public override void AumentarSalario()
        {
            //Qualquer código
        }

        protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}
