using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class DateFormatAttribute : Attribute
        {
            public string Format { get; }

            public DateFormatAttribute(string format)
            {
                Format = format;
            }
        }
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [DateFormat("dd/MM/yyyy")]
        public DateOnly DataLancamento { get; set; }
        public float Valor { get; set; }
        public EstudioDomain Estudio { get; set; }

    }
}


