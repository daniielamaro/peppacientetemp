using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public Arquivo FotoPerfil { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }

    }
}
