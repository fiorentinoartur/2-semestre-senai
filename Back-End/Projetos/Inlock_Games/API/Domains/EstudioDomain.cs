using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        public string Nome { get; set; }

        public JogoDomain ListaJogos { get; set; }
    }
}
