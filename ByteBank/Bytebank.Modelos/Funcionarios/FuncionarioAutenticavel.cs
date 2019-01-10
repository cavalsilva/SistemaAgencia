using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytebank.Modelos;

namespace ByteBank.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        private AutenticacacoHelper _autenticacacoHelper = new AutenticacacoHelper();

        public string Senha { get; set; }

        public FuncionarioAutenticavel(string cpf, double salario)
            : base(cpf, salario)
        {

        }

        public bool Autenticar(string senha)
        {
            return _autenticacacoHelper.CompararSenhas(Senha, senha);
        }
    }
}
