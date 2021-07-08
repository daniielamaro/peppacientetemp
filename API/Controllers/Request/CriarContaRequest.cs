using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Request
{
    public class CriarContaRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DataNasc { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }
    }
}
