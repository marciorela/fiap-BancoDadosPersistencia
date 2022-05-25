using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMeuTeste1
{
    public class Endereco
    {
        public Endereco(string? logradouro, string? numero, string? cidade, string? estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }

        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }

    }
}
