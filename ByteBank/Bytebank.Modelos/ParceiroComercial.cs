using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Modelos
{
    public class ParceiroComercial : IAutenticavel
    {
        private AutenticacacoHelper _autenticacacoHelper = new AutenticacacoHelper();
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return _autenticacacoHelper.CompararSenhas(Senha, senha);
        }
    }
}
