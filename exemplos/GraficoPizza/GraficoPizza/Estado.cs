using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficoPizza
{
    class Estado
    {
        private string sigla;
        private int votacao;

        public Estado(string sigla, int votacao)
        {
            this.Sigla = sigla;
            this.Votacao = votacao;
        }

        public string Sigla { get => sigla; set => sigla = value; }
        public int Votacao { get => votacao; set => votacao = value; }
    }
}
