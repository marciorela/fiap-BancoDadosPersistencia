using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMeuTeste1
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

    }
}
